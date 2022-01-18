using Newtonsoft.Json;
using System;

namespace SVGCanvas_Graphical_2._0
{
    public class Rectangle : Shape
    {
        //Store all the information that svg needs to create a rectangle
        public string Name { get; set; }

        public int id { get; set; }
        public double xpos { get; set; }
        public double ypos { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public string fill { get; set; }
        public string stroke { get; set; }
        public string strokeDashArray { get; set; }
        public int strokeWidth { get; set; }
        public static string DefaultFill { get; set; } = "transparent";
        public static string DefaultStroke { get; set; } = "black";
        public static string DefaultStrokeDashArray { get; set; } = "";
        public static int DefaultStrokeWidth { get; set; } = 1;

        public Rectangle(double x, double y, double w, double h, int id)
        {
            Name = "Rectangle";
            xpos = x;
            ypos = y;
            width = w;
            height = h;
            this.id = id;

            fill = DefaultFill;
            stroke = DefaultStroke;
            strokeDashArray = DefaultStrokeDashArray;
            strokeWidth = DefaultStrokeWidth;
        }

        //Set the default styles for a Rectangle
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
            //Read in the new dimensions from the user
            Console.WriteLine("Enter this Rectangle's new dimensions in the form, <X,Y,Width,Height>:");
            string new_data = Console.ReadLine();
            if (new_data == "..") return;	//Allow the user to escape this edit
            try
            {
                /* Try separate the values out from the rest of the command
				 * convert the values to doubles and set those values as
				   the new dimensions of the shape							*/
                string[] data = new_data.Split(',');
                data[0] = data[0].Substring(1, data[0].Length - 1);
                data[3] = data[3].Substring(0, data[3].Length - 1);
                //Convert and set
                xpos = Convert.ToDouble(data[0]);
                ypos = Convert.ToDouble(data[1]);
                width = Convert.ToDouble(data[2]);
                height = Convert.ToDouble(data[3]);
            }
            catch
            {
                //Give the user a response if their input couldn't be understood (converted)
                Console.WriteLine("Sorry I couldn't understand that, for more information on editing shapes look at the help screen.");
                Console.WriteLine("Enter `..` if you wish to cancel this dimension edit\n");
                //We call this same method again so the user can retry
                this.Dimensions();
            }
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
                //We call this methode again so the user can retry
                this.Decorations();
            }
        }

        //Embed this Rectangle into svg
        public override string Embed()
        {
            String svg = $"<rect x=\"{xpos}\" y=\"{ypos}\" width=\"{width}\" height=\"{height}\"" +
                $" stroke=\"{stroke}\" fill=\"{fill}\" stroke-width=\"{strokeWidth}\"";

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