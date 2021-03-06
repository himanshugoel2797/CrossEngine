﻿/*
 CgNet v1.0
 Copyright (c) 2010 - 2013 Tobias Bohnen

 Permission is hereby granted, free of charge, to any person obtaining a copy of this
 software and associated documentation files (the "Software"), to deal in the Software
 without restriction, including without limitation the rights to use, copy, modify, merge,
 publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
 to whom the Software is furnished to do so, subject to the following conditions:

 The above copyright notice and this permission notice shall be included in all copies or
 substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
 FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
 OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
 DEALINGS IN THE SOFTWARE.
 */
namespace CgNet
{
    using System.Runtime.InteropServices;

    #region Enumerations

    public enum AutoCompileMode
    {
        CompileManual = 4114,
        CompileImmediate = 4115,
        CompileLazy = 4116,
    }

    public enum Behavior
    {
        Unknown = 0,
        Latest = 1,
        Behavior2200 = 1000,
        Behavior3000 = 2000,
        Behavior3100 = 3000,
        Current = Behavior3100
    }

    public enum BufferAccess
    {
        Read = 0,
        Write = 1,
        ReadWrite = 2,
        WriteDiscard = 3,
        WriteNoOverwrite = 4
    }

    public enum BufferUsage
    {
        StreamDraw = 0,
        StreamRead = 1,
        StreamCopy = 2,
        StaticDraw = 3,
        StaticRead = 4,
        StaticCopy = 5,
        DynamicDraw = 6,
        DynamicRead = 7,
        DynamicCopy = 8
    }

    public enum CasePolicy
    {
        ForceUpperCasePolicy = 4136,
        UnchangedCasePolicy = 4137,
    }

    public enum CgAll
    {
        Unknown = 4096,
        In = 4097,
        Out = 4098,
        Inout = 4099,
        Mixed = 4100,
        Varying = 4101,
        Uniform = 4102,
        Constant = 4103,
        ProgramSource = 4104, /* GetProgramString                       */
        ProgramEntry = 4105, /* GetProgramString                       */
        CompiledProgram = 4106, /* GetProgramString                       */
        ProgramProfile = 4107, /* GetProgramString                       */
        Global = 4108,
        Program = 4109,
        Default = 4110,
        Error = 4111,
        Source = 4112,
        Object = 4113,
        CompileManual = 4114,
        CompileImmediate = 4115,
        CompileLazy = 4116,
        Current = 4117,
        Literal = 4118,
        Version = 4119, /* GetString                              */
        RowMajor = 4120,
        ColumnMajor = 4121,
        Fragment = 4122, /* GetProgramInput and GetProgramOutput */
        Vertex = 4123, /* GetProgramInput and GetProgramOutput */
        Point = 4124, /* Geometry program GetProgramInput       */
        Line = 4125, /* Geometry program GetProgramInput       */
        LineAdj = 4126, /* Geometry program GetProgramInput       */
        Triangle = 4127, /* Geometry program GetProgramInput       */
        TriangleAdj = 4128, /* Geometry program GetProgramInput       */
        PointOut = 4129, /* Geometry program GetProgramOutput      */
        LineOut = 4130, /* Geometry program GetProgramOutput      */
        TriangleOut = 4131, /* Geometry program GetProgramOutput      */
        ImmediateParameterSetting = 4132,
        DeferredParameterSetting = 4133,
        NoLocksPolicy = 4134,
        ThreadSafePolicy = 4135,
        ForceUpperCasePolicy = 4136,
        UnchangedCasePolicy = 4137,
        IsOpenglProfile = 4138,
        IsDirect3DProfile = 4139,
        IsDirect3D8Profile = 4140,
        IsDirect3D9Profile = 4141,
        IsDirect3D10Profile = 4142,
        IsVertexProfile = 4143,
        IsFragmentProfile = 4144,
        IsGeometryProfile = 4145,
        IsTranslationProfile = 4146,
        IsHLSLProfile = 4147,
        IsGLSLProfile = 4148,
        IsTessellationControlProfile = 4149,
        IsTessellationEvaluationProfile = 4150,
        Patch = 4152, /* GetProgramInput and GetProgramOutput */
        IsDirect3D11Profile = 4153,
        SamplePos = 4420,
        NumSamples = 4421,
    }

    public enum Domain
    {
        UnknownDomain = 0,
        FirstDomain = 1,
        VertexDomain = 1,
        FragmentDomain = 2,
        GeometryDomain = 3,
        TessellationControlDomain = 4,
        TessellationEvaluationDomain = 5
    }

    public enum ErrorType
    {
        NoError = 0,
        CompilerError = 1,
        InvalidParameterError = 2,
        InvalidProfileError = 3,
        ProgramLoadError = 4,
        ProgramBindError = 5,
        ProgramNotLoadedError = 6,
        UnsupportedGLExtensionError = 7,
        InvalidValueTypeError = 8,
        NotMatrixParamError = 9,
        InvalidEnumerantError = 10,
        Not_4X4MatrixError = 11,
        FileReadError = 12,
        FileWriteError = 13,
        NvparseError = 14,
        MemoryAllocError = 15,
        InvalidContextHandleError = 16,
        InvalidProgramHandleError = 17,
        InvalidParamHandleError = 18,
        UnknownProfileError = 19,
        VarArgError = 20,
        InvalidDimensionError = 21,
        ArrayParamError = 22,
        OutOfArrayBoundsError = 23,
        ConflictingTypesError = 24,
        ConflictingParameterTypesError = 25,
        ParameterIsNotSharedError = 26,
        InvalidParameterVariabilityError = 27,
        CannotDestroyParameterError = 28,
        NotRootParameterError = 29,
        ParametersDoNotMatchError = 30,
        IsNotProgramParameterError = 31,
        InvalidParameterTypeError = 32,
        ParameterIsNotResizableArrayError = 33,
        InvalidSizeError = 34,
        BindCreatesCycleError = 35,
        ArrayTypesDoNotMatchError = 36,
        ArrayDimensionsDoNotMatchError = 37,
        ArrayHasWrongDimensionError = 38,
        TypeIsNotDefinedInProgramError = 39,
        InvalidEffectHandleError = 40,
        InvalidStateHandleError = 41,
        InvalidStateAssignmentHandleError = 42,
        InvalidPassHandleError = 43,
        InvalidAnnotationHandleError = 44,
        InvalidTechniqueHandleError = 45,
        InvalidParameterHandleError = 46,
        StateAssignmentTypeMismatchError = 47,
        InvalidFunctionHandleError = 48,
        InvalidTechniqueError = 49,
        InvalidPointerError = 50,
        NotEnoughDataError = 51,
        NonNumericParameterError = 52,
        ArraySizeMismatchError = 53,
        CannotSetNonUniformParameterError = 54,
        DuplicateNameError = 55,
        InvalidObjHandleError = 56,
        InvalidBufferHandleError = 57,
        BufferIndexOutOfRangeError = 58,
        BufferAlreadyMappedError = 59,
        BufferUpdateNotAllowedError = 60,
        GlslgUncombinedLoadError = 61,
        ErrorMax
    }

    public enum LockingPolicy
    {
        NoLocksPolicy = 4134,
        ThreadSafePolicy = 4135,
    }

    public enum MatrixOrder
    {
        ColumnMajor = 4121,
        RowMajor = 4120
    }

    public enum NameSpace
    {
        Global = 4108,
        Program = 4109,
    }

    public enum ParameterClass
    {
        Unknown = 0,
        Scalar = 1,
        Vector = 2,
        Matrix = 3,
        Struct = 4,
        Array = 5,
        Sampler = 6,
        Object = 7,
        Buffer = 8
    }

    public enum ParameterDirection
    {
        In = 4097,
        Out = 4098,
        Inout = 4099,
        Error = 4111,
    }

    public enum ParameterSettingMode
    {
        Immediate = 4132,
        Deferred = 4133
    }

    public enum ParameterType
    {
        UnknownType = 0,
        Array = 2,
        String = 1135,
        Struct = 1,
        TypelessStruct = 3,
        Texture = 1137,
        PixelshaderType = 1142,
        ProgramType = 1136,
        VertexshaderType = 1141,
        TypeStartEnum = 1024,
        Sampler = 1143,
        Sampler1D = 1065,
        Sampler1DArray = 1138,
        Sampler1DShadow = 1313,
        Sampler2D = 1066,
        Sampler2DArray = 1139,
        Sampler2DMS       = 1317,
        Sampler2DMSArray  = 1318,
        Sampler2DShadow = 1314,
        SamplerRBuf       = 1316,
        Sampler3D = 1067,
        SamplerBuf = 1144,
        SamplerCube = 1069,
        SamplerCubeArray = 1140,
        SamplerRect = 1068,
        SamplerRectShadow = 1315,
        Bool = 1114,
        Bool1 = 1115,
        Bool2 = 1116,
        Bool3 = 1117,
        Bool4 = 1118,
        Bool1X1 = 1119,
        Bool1X2 = 1120,
        Bool1X3 = 1121,
        Bool1X4 = 1122,
        Bool2X1 = 1123,
        Bool2X2 = 1124,
        Bool2X3 = 1125,
        Bool2X4 = 1126,
        Bool3X1 = 1127,
        Bool3X2 = 1128,
        Bool3X3 = 1129,
        Bool3X4 = 1130,
        Bool4X1 = 1131,
        Bool4X2 = 1132,
        Bool4X3 = 1133,
        Bool4X4 = 1134,
        Char = 1166,
        Char1 = 1167,
        Char2 = 1168,
        Char3 = 1169,
        Char4 = 1170,
        Char1X1 = 1171,
        Char1X2 = 1172,
        Char1X3 = 1173,
        Char1X4 = 1174,
        Char2X1 = 1175,
        Char2X2 = 1176,
        Char2X3 = 1177,
        Char2X4 = 1178,
        Char3X1 = 1179,
        Char3X2 = 1180,
        Char3X3 = 1181,
        Char3X4 = 1182,
        Char4X1 = 1183,
        Char4X2 = 1184,
        Char4X3 = 1185,
        Char4X4 = 1186,
        Double = 1145,
        Double1 = 1146,
        Double2 = 1147,
        Double3 = 1148,
        Double4 = 1149,
        Double1X1 = 1150,
        Double1X2 = 1151,
        Double1X3 = 1152,
        Double1X4 = 1153,
        Double2X1 = 1154,
        Double2X2 = 1155,
        Double2X3 = 1156,
        Double2X4 = 1157,
        Double3X1 = 1158,
        Double3X2 = 1159,
        Double3X3 = 1160,
        Double3X4 = 1161,
        Double4X1 = 1162,
        Double4X2 = 1163,
        Double4X3 = 1164,
        Double4X4 = 1165,
        Fixed = 1070,
        Fixed1 = 1092,
        Fixed2 = 1071,
        Fixed3 = 1072,
        Fixed4 = 1073,
        Fixed1X1 = 1074,
        Fixed1X2 = 1075,
        Fixed1X3 = 1076,
        Fixed1X4 = 1077,
        Fixed2X1 = 1078,
        Fixed2X2 = 1079,
        Fixed2X3 = 1080,
        Fixed2X4 = 1081,
        Fixed3X1 = 1082,
        Fixed3X2 = 1083,
        Fixed3X3 = 1084,
        Fixed3X4 = 1085,
        Fixed4X1 = 1086,
        Fixed4X2 = 1087,
        Fixed4X3 = 1088,
        Fixed4X4 = 1089,
        Float = 1045,
        Float1 = 1091,
        Float2 = 1046,
        Float3 = 1047,
        Float4 = 1048,
        Float1X1 = 1049,
        Float1X2 = 1050,
        Float1X3 = 1051,
        Float1X4 = 1052,
        Float2X1 = 1053,
        Float2X2 = 1054,
        Float2X3 = 1055,
        Float2X4 = 1056,
        Float3X1 = 1057,
        Float3X2 = 1058,
        Float3X3 = 1059,
        Float3X4 = 1060,
        Float4X1 = 1061,
        Float4X2 = 1062,
        Float4X3 = 1063,
        Float4X4 = 1064,
        Half = 1025,
        Half1 = 1090,
        Half2 = 1026,
        Half3 = 1027,
        Half4 = 1028,
        Half1X1 = 1029,
        Half1X2 = 1030,
        Half1X3 = 1031,
        Half1X4 = 1032,
        Half2X1 = 1033,
        Half2X2 = 1034,
        Half2X3 = 1035,
        Half2X4 = 1036,
        Half3X1 = 1037,
        Half3X2 = 1038,
        Half3X3 = 1039,
        Half3X4 = 1040,
        Half4X1 = 1041,
        Half4X2 = 1042,
        Half4X3 = 1043,
        Half4X4 = 1044,
        Int = 1093,
        Int1 = 1094,
        Int2 = 1095,
        Int3 = 1096,
        Int4 = 1097,
        Int1X1 = 1098,
        Int1X2 = 1099,
        Int1X3 = 1100,
        Int1X4 = 1101,
        Int2X1 = 1102,
        Int2X2 = 1103,
        Int2X3 = 1104,
        Int2X4 = 1105,
        Int3X1 = 1106,
        Int3X2 = 1107,
        Int3X3 = 1108,
        Int3X4 = 1109,
        Int4X1 = 1110,
        Int4X2 = 1111,
        Int4X3 = 1112,
        Int4X4 = 1113,
        Long = 1271,
        Long1 = 1272,
        Long2 = 1273,
        Long3 = 1274,
        Long4 = 1275,
        Long1X1 = 1276,
        Long1X2 = 1277,
        Long1X3 = 1278,
        Long1X4 = 1279,
        Long2X1 = 1280,
        Long2X2 = 1281,
        Long2X3 = 1282,
        Long2X4 = 1283,
        Long3X1 = 1284,
        Long3X2 = 1285,
        Long3X3 = 1286,
        Long3X4 = 1287,
        Long4X1 = 1288,
        Long4X2 = 1289,
        Long4X3 = 1290,
        Long4X4 = 1291,
        Short = 1208,
        Short1 = 1209,
        Short2 = 1210,
        Short3 = 1211,
        Short4 = 1212,
        Short1X1 = 1213,
        Short1X2 = 1214,
        Short1X3 = 1215,
        Short1X4 = 1216,
        Short2X1 = 1217,
        Short2X2 = 1218,
        Short2X3 = 1219,
        Short2X4 = 1220,
        Short3X1 = 1221,
        Short3X2 = 1222,
        Short3X3 = 1223,
        Short3X4 = 1224,
        Short4X1 = 1225,
        Short4X2 = 1226,
        Short4X3 = 1227,
        Short4X4 = 1228,
        Uchar = 1187,
        Uchar1 = 1188,
        Uchar2 = 1189,
        Uchar3 = 1190,
        Uchar4 = 1191,
        Uchar1X1 = 1192,
        Uchar1X2 = 1193,
        Uchar1X3 = 1194,
        Uchar1X4 = 1195,
        Uchar2X1 = 1196,
        Uchar2X2 = 1197,
        Uchar2X3 = 1198,
        Uchar2X4 = 1199,
        Uchar3X1 = 1200,
        Uchar3X2 = 1201,
        Uchar3X3 = 1202,
        Uchar3X4 = 1203,
        Uchar4X1 = 1204,
        Uchar4X2 = 1205,
        Uchar4X3 = 1206,
        Uchar4X4 = 1207,
        Uint = 1250,
        Uint1 = 1251,
        Uint2 = 1252,
        Uint3 = 1253,
        Uint4 = 1254,
        Uint1X1 = 1255,
        Uint1X2 = 1256,
        Uint1X3 = 1257,
        Uint1X4 = 1258,
        Uint2X1 = 1259,
        Uint2X2 = 1260,
        Uint2X3 = 1261,
        Uint2X4 = 1262,
        Uint3X1 = 1263,
        Uint3X2 = 1264,
        Uint3X3 = 1265,
        Uint3X4 = 1266,
        Uint4X1 = 1267,
        Uint4X2 = 1268,
        Uint4X3 = 1269,
        Uint4X4 = 1270,
        Ulong = 1292,
        Ulong1 = 1293,
        Ulong2 = 1294,
        Ulong3 = 1295,
        Ulong4 = 1296,
        Ulong1X1 = 1297,
        Ulong1X2 = 1298,
        Ulong1X3 = 1299,
        Ulong1X4 = 1300,
        Ulong2X1 = 1301,
        Ulong2X2 = 1302,
        Ulong2X3 = 1303,
        Ulong2X4 = 1304,
        Ulong3X1 = 1305,
        Ulong3X2 = 1306,
        Ulong3X3 = 1307,
        Ulong3X4 = 1308,
        Ulong4X1 = 1309,
        Ulong4X2 = 1310,
        Ulong4X3 = 1311,
        Ulong4X4 = 1312,
        Ushort = 1229,
        Ushort1 = 1230,
        Ushort2 = 1231,
        Ushort3 = 1232,
        Ushort4 = 1233,
        Ushort1X1 = 1234,
        Ushort1X2 = 1235,
        Ushort1X3 = 1236,
        Ushort1X4 = 1237,
        Ushort2X1 = 1238,
        Ushort2X2 = 1239,
        Ushort2X3 = 1240,
        Ushort2X4 = 1241,
        Ushort3X1 = 1242,
        Ushort3X2 = 1243,
        Ushort3X3 = 1244,
        Ushort3X4 = 1245,
        Ushort4X1 = 1246,
        Ushort4X2 = 1247,
        Ushort4X3 = 1248,
        Ushort4X4 = 1249
    }

    public enum ProfileType
    {
        Unknown = 6145,
        Vp20 = 6146,
        Fp20 = 6147,
        Vp30 = 6148,
        Fp30 = 6149,
        ArbVp1 = 6150,
        Fp40 = 6151,
        ArbFp1 = 7000,
        Vp40 = 7001,
        GlslV = 7007,
        GlslF = 7008,
        GlslG = 7016,
        GlslC = 7009,
        Gp4Fp = 7010,
        Gp4Vp = 7011,
        Gp4Gp = 7012,
        Gp5Fp = 7017, /* NV_gpu_program5                                          */
        Gp5Vp = 7018, /* NV_gpu_program5                                          */
        Gp5Gp = 7019, /* NV_gpu_program5                                          */
        Gp5Tcp = 7020, /* NV_tessellation_program5 Tessellation control program    */
        Gp5Tep = 7021, /* NV_tessellation_program5 Tessellation evaluation program */
        Vs11 = 6153,
        Vs20 = 6154,
        Vs2X = 6155,
        Vs2Sw = 6156,
        Vs30 = 6157,
        HlslV = 6158,
        Ps11 = 6159,
        Ps12 = 6160,
        Ps13 = 6161,
        Ps20 = 6162,
        Ps2X = 6163,
        Ps2Sw = 6164,
        Ps30 = 6165,
        HlslF = 6166,
        Vs40 = 6167,
        Ps40 = 6168,
        Gs40 = 6169,
        Vs50 = 6170,
        Ps50 = 6171,
        Gs50 = 6172,
        Hs50 = 6173,
        Ds50 = 6174,
        Generic = 7002
    }

    public enum ProgramInput
    {
        Fragment = 4122, /* GetProgramInput and GetProgramOutput */
        Vertex = 4123, /* GetProgramInput and GetProgramOutput */
        Point = 4124, /* Geometry program GetProgramInput       */
        Line = 4125, /* Geometry program GetProgramInput       */
        LineAdj = 4126, /* Geometry program GetProgramInput       */
        Triangle = 4127, /* Geometry program GetProgramInput       */
        TriangleAdj = 4128, /* Geometry program GetProgramInput       */
        PointOut = 4129, /* Geometry program GetProgramOutput      */
        LineOut = 4130, /* Geometry program GetProgramOutput      */
        TriangleOut = 4131, /* Geometry program GetProgramOutput      */
        Patch = 4152, /* GetProgramInput and GetProgramOutput */
    }

    public enum ProgramOutput
    {
        Fragment = 4122, /* GetProgramInput and GetProgramOutput */
        Vertex = 4123, /* GetProgramInput and GetProgramOutput */
        Point = 4124, /* Geometry program GetProgramInput       */
        Line = 4125, /* Geometry program GetProgramInput       */
        LineAdj = 4126, /* Geometry program GetProgramInput       */
        Triangle = 4127, /* Geometry program GetProgramInput       */
        TriangleAdj = 4128, /* Geometry program GetProgramInput       */
        PointOut = 4129, /* Geometry program GetProgramOutput      */
        LineOut = 4130, /* Geometry program GetProgramOutput      */
        TriangleOut = 4131, /* Geometry program GetProgramOutput      */
        Patch = 4152, /* GetProgramInput and GetProgramOutput */
    }

    public enum ProgramType
    {
        Source = 4112,
        Object = 4113
    }

    public enum Query
    {
        IsOpenglProfile = 4138,
        IsDirect3DProfile = 4139,
        IsDirect3D8Profile = 4140,
        IsDirect3D9Profile = 4141,
        IsDirect3D10Profile = 4142,
        IsVertexProfile = 4143,
        IsFragmentProfile = 4144,
        IsGeometryProfile = 4145,
        IsTranslationProfile = 4146,
        IsHLSLProfile = 4147,
        IsGLSLProfile = 4148,
        IsTessellationControlProfile = 4149,
        IsTessellationEvaluationProfile = 4150,
    }

    public enum ResourceType
    {
        TexUnit0 = 2048,
        TexUnit1 = 2049,
        TexUnit2 = 2050,
        TexUnit3 = 2051,
        TexUnit4 = 2052,
        TexUnit5 = 2053,
        TexUnit6 = 2054,
        TexUnit7 = 2055,
        TexUnit8 = 2056,
        TexUnit9 = 2057,
        TexUnit10 = 2058,
        TexUnit11 = 2059,
        TexUnit12 = 2060,
        TexUnit13 = 2061,
        TexUnit14 = 2062,
        TexUnit15 = 2063,
        TexUnit16 = 4624,
        TexUnit17 = 4625,
        TexUnit18 = 4626,
        TexUnit19 = 4627,
        TexUnit20 = 4628,
        TexUnit21 = 4629,
        TexUnit22 = 4630,
        TexUnit23 = 4631,
        TexUnit24 = 4632,
        TexUnit25 = 4633,
        TexUnit26 = 4634,
        TexUnit27 = 4635,
        TexUnit28 = 4636,
        TexUnit29 = 4637,
        TexUnit30 = 4638,
        TexUnit31 = 4639,
        Buffer0 = 2064,
        Buffer1 = 2065,
        Buffer2 = 2066,
        Buffer3 = 2067,
        Buffer4 = 2068,
        Buffer5 = 2069,
        Buffer6 = 2070,
        Buffer7 = 2071,
        Buffer8 = 2072,
        Buffer9 = 2073,
        Buffer10 = 2074,
        Buffer11 = 2075,
        Attr0 = 2113,
        Attr1 = 2114,
        Attr2 = 2115,
        Attr3 = 2116,
        Attr4 = 2117,
        Attr5 = 2118,
        Attr6 = 2119,
        Attr7 = 2120,
        Attr8 = 2121,
        Attr9 = 2122,
        Attr10 = 2123,
        Attr11 = 2124,
        Attr12 = 2125,
        Attr13 = 2126,
        Attr14 = 2127,
        Attr15 = 2128,
        C = 2178,
        Tex0 = 2179,
        Tex1 = 2180,
        Tex2 = 2181,
        Tex3 = 2192,
        Tex4 = 2193,
        Tex5 = 2194,
        Tex6 = 2195,
        Tex7 = 2196,
        Hpos = 2243,
        Col0 = 2245,
        Col1 = 2246,
        Col2 = 2247,
        Col3 = 2248,
        Psiz = 2309,
        Clp0 = 2310,
        Clp1 = 2311,
        Clp2 = 2312,
        Clp3 = 2313,
        Clp4 = 2314,
        Clp5 = 2315,
        Wpos = 2373,
        Pointcoord = 2374,
        Position0 = 2437,
        Position1 = 2438,
        Position2 = 2439,
        Position3 = 2440,
        Position4 = 2441,
        Position5 = 2442,
        Position6 = 2443,
        Position7 = 2444,
        Position8 = 2445,
        Position9 = 2446,
        Position10 = 2447,
        Position11 = 2448,
        Position12 = 2449,
        Position13 = 2450,
        Position14 = 2451,
        Position15 = 2452,
        Diffuse0 = 2501,
        Tangent0 = 2565,
        Tangent1 = 2566,
        Tangent2 = 2567,
        Tangent3 = 2568,
        Tangent4 = 2569,
        Tangent5 = 2570,
        Tangent6 = 2571,
        Tangent7 = 2572,
        Tangent8 = 2573,
        Tangent9 = 2574,
        Tangent10 = 2575,
        Tangent11 = 2576,
        Tangent12 = 2577,
        Tangent13 = 2578,
        Tangent14 = 2579,
        Tangent15 = 2580,
        Specular0 = 2629,
        BlendIndices0 = 2693,
        BlendIndices1 = 2694,
        BlendIndices2 = 2695,
        BlendIndices3 = 2696,
        BlendIndices4 = 2697,
        BlendIndices5 = 2698,
        BlendIndices6 = 2699,
        BlendIndices7 = 2700,
        BlendIndices8 = 2701,
        BlendIndices9 = 2702,
        BlendIndices10 = 2703,
        BlendIndices11 = 2704,
        BlendIndices12 = 2705,
        BlendIndices13 = 2706,
        BlendIndices14 = 2707,
        BlendIndices15 = 2708,
        Color0 = 2757,
        Color1 = 2758,
        Color2 = 2759,
        Color3 = 2760,
        Color4 = 2761,
        Color5 = 2762,
        Color6 = 2763,
        Color7 = 2764,
        Color8 = 2765,
        Color9 = 2766,
        Color10 = 2767,
        Color11 = 2768,
        Color12 = 2769,
        Color13 = 2770,
        Color14 = 2771,
        Color15 = 2772,
        PSize0 = 2821,
        PSize1 = 2822,
        PSize2 = 2823,
        PSize3 = 2824,
        PSize4 = 2825,
        PSize5 = 2826,
        PSize6 = 2827,
        PSize7 = 2828,
        PSize8 = 2829,
        PSize9 = 2830,
        PSize10 = 2831,
        PSize11 = 2832,
        PSize12 = 2833,
        PSize13 = 2834,
        PSize14 = 2835,
        PSize15 = 2836,
        Binormal0 = 2885,
        Binormal1 = 2886,
        Binormal2 = 2887,
        Binormal3 = 2888,
        Binormal4 = 2889,
        Binormal5 = 2890,
        Binormal6 = 2891,
        Binormal7 = 2892,
        Binormal8 = 2893,
        Binormal9 = 2894,
        Binormal10 = 2895,
        Binormal11 = 2896,
        Binormal12 = 2897,
        Binormal13 = 2898,
        Binormal14 = 2899,
        Binormal15 = 2900,
        Fog0 = 2917,
        Fog1 = 2918,
        Fog2 = 2919,
        Fog3 = 2920,
        Fog4 = 2921,
        Fog5 = 2922,
        Fog6 = 2923,
        Fog7 = 2924,
        Fog8 = 2925,
        Fog9 = 2926,
        Fog10 = 2927,
        Fog11 = 2928,
        Fog12 = 2929,
        Fog13 = 2930,
        Fog14 = 2931,
        Fog15 = 2932,
        Depth0 = 2933,
        Depth1 = 2934,
        Depth2 = 2935,
        Depth3 = 2936,
        Depth4 = 2937,
        Depth5 = 2938,
        Depth6 = 2939,
        Depth7 = 2940,
        Depth8 = 2941,
        Depth9 = 2942,
        Depth10 = 2943,
        Depth11 = 2944,
        Depth12 = 2945,
        Depth13 = 2946,
        Depth14 = 2947,
        Depth15 = 2948,
        Sample0 = 2949,
        Sample1 = 2950,
        Sample2 = 2951,
        Sample3 = 2952,
        Sample4 = 2953,
        Sample5 = 2954,
        Sample6 = 2955,
        Sample7 = 2956,
        Sample8 = 2957,
        Sample9 = 2958,
        Sample10 = 2959,
        Sample11 = 2960,
        Sample12 = 2961,
        Sample13 = 2962,
        Sample14 = 2963,
        Sample15 = 2964,
        BlendWeight0 = 3028,
        BlendWeight1 = 3029,
        BlendWeight2 = 3030,
        BlendWeight3 = 3031,
        BlendWeight4 = 3032,
        BlendWeight5 = 3033,
        BlendWeight6 = 3034,
        BlendWeight7 = 3035,
        BlendWeight8 = 3036,
        BlendWeight9 = 3037,
        BlendWeight10 = 3038,
        BlendWeight11 = 3039,
        BlendWeight12 = 3040,
        BlendWeight13 = 3041,
        BlendWeight14 = 3042,
        BlendWeight15 = 3043,
        Normal0 = 3092,
        Normal1 = 3093,
        Normal2 = 3094,
        Normal3 = 3095,
        Normal4 = 3096,
        Normal5 = 3097,
        Normal6 = 3098,
        Normal7 = 3099,
        Normal8 = 3100,
        Normal9 = 3101,
        Normal10 = 3102,
        Normal11 = 3103,
        Normal12 = 3104,
        Normal13 = 3105,
        Normal14 = 3106,
        Normal15 = 3107,
        Fogcoord = 3156,
        TexCoord0 = 3220,
        TexCoord1 = 3221,
        TexCoord2 = 3222,
        TexCoord3 = 3223,
        TexCoord4 = 3224,
        TexCoord5 = 3225,
        TexCoord6 = 3226,
        TexCoord7 = 3227,
        TexCoord8 = 3228,
        TexCoord9 = 3229,
        TexCoord10 = 3230,
        TexCoord11 = 3231,
        TexCoord12 = 3232,
        TexCoord13 = 3233,
        TexCoord14 = 3234,
        TexCoord15 = 3235,
        CombinerConst0 = 3284,
        CombinerConst1 = 3285,
        CombinerStageConst0 = 3286,
        CombinerStageConst1 = 3287,
        OffsetTextureMatrix = 3288,
        OffsetTextureScale = 3289,
        OffsetTextureBias = 3290,
        ConstEye = 3291,
        Coverage = 3292,
        Tessfactor = 3255,
        GLSLUniform = 3300,
        GLSLAttrib = 3301,
        Env = 3302,
        HLSLUniform = 3559,
        HLSLVarying = 3560,
        SamplerRes = 3561,
        LastCol0 = 4400,
        LastCol1 = 4401,
        LastCol2 = 4402,
        LastCol3 = 4403,
        LastCol4 = 4404,
        LastCol5 = 4405,
        LastCol6 = 4406,
        LastCol7 = 4407,
        Face = 4410,
        PrimitiveId = 4411,
        InstanceId = 4412,
        SampleId = 4413,
        VertexId = 4414,
        Layer = 4415,
        SampleMask = 4416,
        ControlPointId = 4417,
        Edgetess = 4418,
        Innertess = 4419,
        Undefined = 3256
    }

    public enum SourceType
    {
        ProgramSource = 4104, /* GetProgramString                       */
        ProgramEntry = 4105, /* GetProgramString                       */
        CompiledProgram = 4106, /* GetProgramString                       */
        ProgramProfile = 4107, /* GetProgramString                       */
    }

    public enum Variability
    {
        Default = 4110,
        Varying = 4101,
        Uniform = 4102,
        Literal = 4118,
        Constant = 4103,
        Mixed = 4100,
    }

    #endregion Enumerations
}