using System;

using Bentley.MstnPlatformNET;

namespace RhinoInsideMicroStation.Entry
{
    [AddIn(MdlTaskID = "RimAddin")]
    public class RimAddin : AddIn
    {
        private static RimAddin _instance;
        internal static RimAddin Instance
        {
            get { return _instance; }
        }

        public RimAddin(IntPtr mdlDesc) : base(mdlDesc)
        {

        }

        protected override int Run(string[] commandLine)
        {
            _instance = this;
            RhinoInside.Resolver.Initialize();
            return 0;
        }
    }
}