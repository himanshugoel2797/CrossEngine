namespace ExampleBrowser
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;

    using ExampleBrowser.Examples;

    public partial class ExampleSelector : Form
    {
        #region Constructors

        public ExampleSelector()
        {
            InitializeComponent();
            this.GetExamples(Assembly.GetExecutingAssembly());
            this.treeView1.Sort();
        }

        #endregion Constructors

        #region Methods

        #region Private Methods

        private void GetExamples(Assembly asm)
        {
            var types = asm.GetExportedTypes().OrderBy(t => t.Name);

            foreach (Type type in types)
            {
                if (type.GetInterface(typeof(IExample).Name) != null && !type.IsAbstract)
                {
                    var example = (ExampleDescriptionAttribute)type.GetCustomAttributes(typeof(ExampleDescriptionAttribute), false)[0];

                    var paths = example.NodePath.Split(';');
                    foreach (var path in paths)
                    {
                        var pathNodes = path.Split('/');
                        var nodes = this.treeView1.Nodes;
                        for (int index = 0; index < pathNodes.Length; index++)
                        {
                            var s = pathNodes[index];
                            if (!nodes.ContainsKey(s))
                            {
                                var node = nodes.Add(s, s);
                                if (index == pathNodes.Length - 1)
                                {
                                    node.Tag = type.GetConstructor(Type.EmptyTypes);
                                }
                            }

                            nodes = nodes[s].Nodes;
                        }
                    }
                }
            }
        }

        private void TreeView1NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (this.treeView1.SelectedNode != null && this.treeView1.SelectedNode.Tag != null)
            {
                using (var example = (IExample)((ConstructorInfo)this.treeView1.SelectedNode.Tag).Invoke(null))
                {
                    example.Start();
                }
            }
        }

        #endregion Private Methods

        #endregion Methods
    }
}