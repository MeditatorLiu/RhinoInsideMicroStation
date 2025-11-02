using System;
using System.Windows;

using Rhino;

namespace RhinoInsideMicroStation
{
    public class Keyins
    {
        public static void Start(string unparsed)
        {
            StartRhino();
        }

        [System.STAThread]
        public static void StartRhino()
        {
            try
            {
                RhinoHost.EnsureCore();
                HelloWorld.MeshABrep();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void RunGH(string unparsed)
        {
            StartGrasshopper(unparsed);
        }

        [System.STAThread]
        public static void StartGrasshopper(string unparsed)
        {
            try
            {
                RhinoHost.EnsureCore();
                RhinoApp.InvokeOnUiThread(new Action(RunGrasshopper.RunHelper));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
