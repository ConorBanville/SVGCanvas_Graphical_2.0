using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SVGCanvas_Graphical_2._0
{
    public class Polygon : Shape
    {
        //Store all the information that svg needs to create a Polygon
        public string Name { get; set; } // Name of the shape

        public int id { get; set; }
        public string fill { get; set; }
        public string stroke { get; set; }
        public string strokeDashArray { get; set; }
        public int strokeWidth { get; set; }
        public static string DefaultFill { get; set; } = "transparent";
        public static string DefaultStroke { get; set; } = "black";
        public static string DefaultStrokeDashArray { get; set; } = "";
        public static int DefaultStrokeWidth { get; set; } = 1;
        public List<Point> points;

        public Polygon(List<Point> points, int id)
        {
            Name = "Polygon";//Don't really need this but it was a nice way to use a variable that was only present in the abstract definition
            this.points = points;
            this.id = id;
            //These variables || all get default values that can be changed later
            //                \/
            fill = DefaultFill;
            stroke = DefaultStroke;
            strokeDashArray = DefaultStrokeDashArray;
            strokeWidth = DefaultStrokeWidth;
        }

        //Set the default styles for a Polygon
        public static void SetDefaultStyle(string default_fill, string default_stroke, int default_stroke_width, string default_stroke_dash_array)
        {
            DefaultFill = default_fill;
            DefaultStroke = default_stroke;
            DefaultStrokeWidth = default_stroke_width;
            DefaultStrokeDashArray = default_stroke_dash_array;
        }

        //This method returns a formatted Json Object Representing this shape
        public override string GetInfo()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        //Edit the dimensions of this shape
        public override void Dimensions()
        {
            Point temp = new Point(0, 0);
            List<Point> temp_points = new List<Point>();//Create a list of type, Point
            Console.WriteLine("Enter this Ploygon's new list of points in the from, <x1,y1,x2,y2,...xn,yn>");
            string newPoints = Console.ReadLine();
            if (newPoints == "..") return;

            try
            {
                /* Try to separate out the numbers from the command given, ie. the info in the `< >` and then
                 * put each of those numbers in a string array */
                string arguments = newPoints.Substring(newPoints.IndexOf('<') + 1, newPoints.IndexOf('>') - (newPoints.IndexOf('<') + 1));
                string[] args = arguments.Split(',');
                if (args.Length % 2 != 0)
                {
                    //If we dont have an even number of numbers then we cant make every point whole
                    Console.WriteLine("Must enter only complete points, every point must have an X and Y pair of coordinates");
                    Console.WriteLine("You can try again or enter `..` to exit this Polygon edit.\n");
                    this.Dimensions();
                }

                /*  For every pair of x and y coordinates in the array we try to create a new point
                 */
                for (int i = 0; i < args.Length; i++)
                {
                    try
                    {
                        temp = new Point(Convert.ToDouble(args[i]), Convert.ToDouble(args[i + 1]));//Try to convert the arguments to doubles and
                                                                                                   //if successful create a Point from the arguments
                    }
                    catch
                    {
                        //If any of the conversions fail then we start again
                        Console.WriteLine("Failed to convert every coordinate to a valid point.");
                        Console.WriteLine("You can try again or enter `..` to exit this Polygon edit.\n");
                        this.Dimensions();
                    }
                    temp_points.Add(temp); //Add the point to our list of points
                    i++;
                }
            }
            catch
            {
                // Give the user a response if their input couldn't be separated out and turned into an array of numbers
                Console.WriteLine("Sorry I couldn't understand that, for more information on editing shapes look at the help screen.");
                Console.WriteLine("Enter `..` if you wish to cancel this dimension edit\n");
                //We call this same method so the user can try again
                this.Dimensions();
            }
            points = temp_points;   //If every thing was succesfull then we can set the points to their new values
        }

        //Edit the decoration of this shape
        public override void Decorations()
        {
            //Read in the new decorations attributes for this shape
            Console.WriteLine(
@"Enter the new decoration attribute values for this Recatngle in the form
(fill,stroke,stroke-width,stroke_dasharray):");
            String new_decor = Console.ReadLine();
            if (new_decor == "..") return;    //Allow the user to escape this edit

            try
            {
                //  Try to separate the data from the rest of the command and set the new values
                string[] data = new_decor.Split(',');
                data[0] = data[0].Substring(1, data[0].Length - 1);
                data[3] = data[3].Substring(0, data[3].Length - 1);
                //Set the new values
                fill = data[0];
                stroke = data[1];
                strokeWidth = Convert.ToInt32(data[2]);
                strokeDashArray = data[3];
            }
            catch
            {
                //Give the user a response if their input couldn't be understood
                Console.WriteLine("Sorry I couldn't understand that, for more information on editing shapes look at the help screen.");
                Console.WriteLine("Enter `..` if you wish to cancel this edit\n");
                //We call this method again so the user can retry
                this.Decorations();
            }
        }

        //Embed this Polygon into svg
        public override string Embed()
        {
            String svg = "<polygon points=\"";

            foreach (Point obj in points)
            {
                svg += obj.toString() + " ";
            }
            svg = svg.Substring(0, svg.Length - 1);

            svg += $"\" fill=\"{fill}\" stroke=\"{stroke}\" stroke-width=\"{strokeWidth}\"";

            if (strokeDashArray.Length != 0)
            {
                //Only add in the stroke-dasharray attribute if it's not set to the default
                svg += $" stroke-dasharray=\"{strokeDashArray}\"";
            }

            return svg + "/>";//Return the embedded rectangle
        }

        //Return the id of the shape
        public override int GetId()
        { return this.id; }
    }
}