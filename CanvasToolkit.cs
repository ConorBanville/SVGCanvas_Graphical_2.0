using System;
using System.Collections.Generic;

namespace SVGCanvas_Graphical_2._0
{
    internal class CanvasToolkit
    {
        private static bool shift = true;

        /*  Removes the shape specified by id from the canvas c
            and returns a new list with the shape removed. If
            the shape could not be found then null is returned */

        public static List<Shape> Remove(Canvas c, int id)
        {
            for (int i = 0; i < c.shapes.Count; i++)
            {
                if (c.shapes[i].GetId() == id)
                {
                    c.shapes.RemoveAt(i);
                    Console.WriteLine("Shape removed");
                    Console.ReadKey();
                    return c.shapes;
                }
            }
            Console.WriteLine($"Shape with ID: [{id}] could not be found.\n");
            Console.ReadKey();

            return null;
        }

        /*  Call a method to edit a shape specified by it's id
            and returns a new list with the shape edit included */

        public static List<Shape> EditStyle(Canvas c, int id)
        {
            for (int i = 0; i < c.shapes.Count; i++)
            {
                if (c.shapes[i].GetId() == id)
                {
                    Console.Clear();
                    c.shapes[i].Decorations();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return c.shapes;
                }
            }
            return null;
        }

        /*  Call a method thats prompts the user for a shape ID and
            a new index so move that shape to in the cannvas    */

        public static List<Shape> Shift(Canvas canvas)
        {
            List<Shape> shapes = canvas.GetList();
            Shape temp;
            bool cancelled = false;
            int shapeID = -1, index = -1;
            string input;

            if (shift)
            {
                // Redraw the canvas
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine("Enter the ID of the shape to be moved and the new index below");
                Console.WriteLine("You can cancel this edit by entering ..");
                Console.WriteLine("Press any key to begin ...");
                Console.ReadKey();
                shift = false;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine("Shape ID:");
                input = Console.ReadLine();

                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }
                else
                {
                    if (Int32.TryParse(input, out shapeID))
                    {
                        break;
                    }
                }
            }

            if (cancelled)
            {
                return null;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine("New Index:");
                input = Console.ReadLine();

                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }
                else
                {
                    if (Int32.TryParse(input, out index))
                    {
                        if (index > shapes.Count - 1)
                        {
                            Console.Clear();
                            Console.WriteLine(InfoScreens.welcome_banner);
                            Console.WriteLine("Error: New index must not exceed the index of the last shape in the canvas ...");
                            Console.ReadKey();
                        }
                        else break;
                    }
                }
            }

            if (cancelled)
            {
                return null;
            }

            if (shapeID != -1 && index != -1)
            {
                for (int i = 0; i < shapes.Count; i++)
                {
                    if (shapes[i].GetId() == shapeID)
                    {
                        temp = shapes[i];
                        shapes.RemoveAt(i);
                        shapes.Insert(index, temp);
                    }
                }
            }

            return shapes;
        }

        /*  Call a method to edit a shape specified by it's id
            and returns a new list with the shape edit included */

        public static List<Shape> EditDimensions(Canvas c, int id)
        {
            for (int i = 0; i < c.shapes.Count; i++)
            {
                if (c.shapes[i].GetId() == id)
                {
                    Console.Clear();
                    c.shapes[i].Dimensions();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return c.shapes;
                }
            }
            return null;
        }

        /*  Returns an svg string containing a svg representation
            for each shape in the canvas c */

        public static string EmbedCanvas(Canvas c)
        {
            string svg = $"<?xml version=\"1.0\" standalone=\"no\"?>\n" +
                $"<svg width=\"{c.w}\" height=\"{c.h}\" version=\"1.1\" xmlns=\"http://www.w3.org/2000/svg\">\n";

            foreach (Shape obj in c.shapes)
            {
                svg += obj.Embed() + "\n";
            }

            return svg + "</svg>";
        }

        /*  Display the shapes on the canvas to the screen*/

        public static void Display(Canvas c)
        {
            if (c.shapes.Count > 0)
            {
                foreach (var obj in c.shapes)
                {
                    Console.WriteLine(obj.GetInfo());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Canvas is empty!");
            }
        }

        /*  Start a propmpt to change the dimensions of the canvas*/

        public static double[] EditCanvas()
        {
            string input;
            double w = -100100122228963144, h = -100100122228963144;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine("Width:");
                input = Console.ReadLine();

                if (Double.TryParse(input, out w))
                {
                    break;
                }
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine("Height:");
                input = Console.ReadLine();

                if (Double.TryParse(input, out h))
                {
                    break;
                }
            }

            if (w != -100100122228963144 && h != 100100122228963144)
            {
                return new double[] { w, h };
            }
            else return null;
        }
    }
}