namespace ExampleBrowser.Examples.SlimDX
{
    using System;
    using System.Windows.Forms;

    using CgNet;

    public abstract class Example : IExample
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
        }

        public virtual void Start()
        {
            Cg.Error += this.CheckForCgError;
        }

        #endregion Public Methods

        #region Protected Methods

        protected void CheckForCgError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine("Cg Error: " + e.ErrorString);
        }

        #endregion Protected Methods

        #endregion Methods
    }
}