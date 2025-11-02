using System;
using Rhino.Runtime.InProcess;

namespace RhinoInsideMicroStation
{
    /// <summary>
    /// Ensures a single RhinoCore instance is shared by all commands.
    /// </summary>
    internal static class RhinoHost
    {
        private static readonly object SyncRoot = new object();
        private static RhinoCore _core;
        private static bool _resolverInitialized;

        static RhinoHost()
        {
            AppDomain.CurrentDomain.ProcessExit += (_, __) => Shutdown();
            AppDomain.CurrentDomain.DomainUnload += (_, __) => Shutdown();
        }

        internal static RhinoCore EnsureCore()
        {
            if (_core != null)
                return _core;

            lock (SyncRoot)
            {
                if (_core != null)
                    return _core;

                if (!_resolverInitialized)
                {
                    RhinoInside.Resolver.Initialize();
                    _resolverInitialized = true;
                }

                // Start Rhino in hidden mode with a MicroStation-specific scheme
                //var args = new[] { "/NOSPLASH", "/NOTEMPLATE", "/SCHEME=MicroStation" };
                //_core = new RhinoCore(args, WindowStyle.NoWindow);
                _core = new RhinoCore();
            }

            return _core;
        }

        internal static void Shutdown()
        {
            lock (SyncRoot)
            {
                if (_core == null)
                    return;

                _core.Dispose();
                _core = null;
            }
        }
    }
}
