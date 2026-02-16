namespace cad_git;

using VectSharp;

using VectSharp.SVG;
public class Class1
{
    // Entry point for the application
    static void Main(string[] args)
    {
        testVectSharp();
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
}