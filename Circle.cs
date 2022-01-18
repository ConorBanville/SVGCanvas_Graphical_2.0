using Newtonsoft.Json;
using System;

namespace SVGCanvas_Graphical_2._0
{
    /*	This class will represent a circle and contains methods for
		manipulating the attributes of the circle as well as embeding
		the circle into svg.*/

    public class Circle : Shape
    {
        public string Name { get; set; } // Name of the shape
        public int id { get; set; } // Unique ID of the shape
        public double centerX { get; set; } // X coordinate of the shapes center
        public double centerY { get; set; } // Y coordinate of the shapes center
        public double radius { get; set; }  // Radius of the circle
        public string fill { get; set; }    // Fill colour
        public string stroke { get; set; }  //	Stroke colour
        public string strokeDashArray { get; set; } // Stroke dash
        public int strokeWidth { get; set; } // Stroke width
        public static string DefaultFill { get; set; } = "transparent";	//Default fill colour
        public static string DefaultStroke { get; set; } = "black";	// Default stroke colour
        public static string DefaultStrokeDashArray { get; set; } = "";	// Default stroke dash
        public static int DefaultStrokeWidth { get; set; } = 1; // Default stroke width

        //Constructor
        public Circle(double x, double y, double r, int id)
        {
            Name = "Circle";
            centerX = x;
            centerY = y;
            radius = r;
            this.id = id;
            fill = DefaultFill;
            stroke = DefaultStroke;
            strokeDashArray = DefaultStrokeDashArray;
            strokeWidth = DefaultStrokeWidth;
        }

        //Set the default styles for a Circle
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
            //Read in the new decorations attributes for this shape
            Console.WriteLine(
@"Enter the new decoration attribute values for this Recatngle in the form
(fill,stroke,stroke-width,stroke_dasharray):");
            string new_data = Console.ReadLine();
            if (new_data == "..") return;   //Allow the user to escape this edit

            try
            {
                /* Try separate the values out from the rest of the command
				 * convert the values to doubles and set those values as
				   the new dimensions of the shape							*/
                string[] data = new_data.Split(',');
                data[0] = data[0].Substring(1, data[0].Length - 1);
                data[2] = data[2].Substring(0, data[2].Length - 1);
                //Convert and set
                centerX = Convert.ToDouble(data[0]);
                centerY = Convert.ToDouble(data[1]);
                radius = Convert.ToDouble(data[2]);
            }
            catch
            {
                // Give the user a response if their input couldn't be understood
                Console.WriteLine("Sorry I couldn't understand that, for more information on editing shapes look at the help screen.");
                Console.WriteLine("Enter `..` if you wish to cancel this edit\n");
                //We call this same method so the user can try again
                this.Dimensions();
            }
        }

        //Edit the decoration of this shape
        public override void Decorations()
        {
            //Read in the new decorations attributes for this shape
            Console.WriteLine("Enter the new decoration attribute values for this Circle in the form,\n\t"
                + "(fill,stroke,stroke-width,stroke_dasharray):");
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

        //Embed this Circle into svg
        public override string Embed()
        {
            String svg = $"<circle cx=\"{centerX}\" cy=\"{centerY}\" r=\"{radius}\" " +
                $"stroke=\"{stroke}\" fill=\"{fill}\" stroke-width=\"{strokeWidth}\"";

            //Only add in the stroke-dasharray attribute if it's not set to the default
            if (strokeDashArray.Length != 0) { svg += $" stroke-dasharray=\"{strokeDashArray}\""; }

            return svg + "/>";  //Return the embedded circle
        }

        //Return the id of the shape
        public override int GetId()
        { return this.id; }
    }
}