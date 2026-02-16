namespace cad_git;

using VectSharp;
using VectSharp.ThreeD;
using VectSharp.SVG;
public class Class1
{
    // Entry point for the application
    static void Main(string[] args)
    {
        test3D();
    }

    static void testVectSharp () {
        // Width of the page.
        double width = 100;

        // Height of the page.
        double height = 100;

        // Create the page.
        Page page = new Page(width, height);
        
        // Get the Graphics object.
        Graphics graphics = page.Graphics;
        
        // Position and size of the rectangle.
        double rectangleX = 10;
        double rectangleY = 10;
        double rectangleWidth = 80;
        double rectangleHeight = 80;

        // Colour of the rectangle.
        Colour fillColour = Colours.Green;

        // Draw the rectangle.
        graphics.FillRectangle(rectangleX, rectangleY, rectangleWidth, rectangleHeight, fillColour);
        
        // Set the page background to a light grey.
        page.Background = Colour.FromRgb(200, 200, 200);
        
        // Output file name.
        string outputFile = "Rectangle.svg";

        // Save the page as an SVG document.
        page.SaveAsSVG(outputFile); 
    }
    

    static void test3D()
    {
        // Create a scene to contain 3D objects
        Scene scene = new Scene();

        // The static ObjectFactory class can be used to create "complex" 3D objects, such as a cube.
        // These are returned as a list of triangles that can be added to the scene.
        scene.AddRange(ObjectFactory.CreateCube(new Point3D(0, 0, 0), 100,
                                                new IMaterial[] {
                                                    new PhongMaterial(Colour.FromRgb(0, 158, 115))
                                                }));

        // The light will be used to illuminate the object(s) in the scene and make them actually visible.
        ParallelLightSource light = new ParallelLightSource(0.5, new NormalizedVector3D(1, 2, 3));

        // A camera that renders the scene using a perspective projection.
        PerspectiveCamera camera = new PerspectiveCamera(new Point3D(-200, -200, -300),
                                                        new NormalizedVector3D(2, 2, 3), 50,
                                                        new Size(30, 30), 1);

        // A renderer to render the scene as a vector image.
        VectorRenderer renderer = new VectorRenderer() { DefaultOverFill = 0.02, ResamplingMaxSize = 1 };

        // Render the scene.
        Page pag = renderer.Render(scene, new ILightSource[] { light }, camera);

        // Save as an SVG image.
        pag.SaveAsSVG("Cube.svg");
    }
}