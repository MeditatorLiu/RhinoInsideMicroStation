using System.Windows.Forms;

using Rhino.Geometry;

namespace RhinoInsideMicroStation
{
  public class HelloWorld
  {
    public static void MeshABrep()
    {
      var sphere = new Sphere(Point3d.Origin, 12);
      var brep = sphere.ToBrep();
      var mp = new MeshingParameters(0.5);
      var mesh = Mesh.CreateFromBrep(brep, mp);
      MessageBox.Show($"Mesh with {mesh[0].Vertices.Count} vertices created");
    }
  }
}