using Newtonsoft.Json;
using System;

namespace SVGCanvas_Graphical_2._0
{
    public class Line : Shape
    {
        //Store all the information that svg needs to create a Circle
        public string Name { get; set; } // Name of the shape

        public int id { get; set; } // Unique ID of the shape
        public double x1 { get; set; }  // X coordinate of the Lines start
        public double y1 { get; set; }  // Y coordinate of the Lines start
        public double x2 { get; set; }  // X coordinate of the Lines end
        public double y2 { get; set; }  // Y coordinate of the Lines end
        public string stroke { get; set; }  // Stroke colour
        public string strokeDashArray { get; set; } // Stroke dash
        public int strokeWidth { get; set; }	// Stroke width
        public static string DefaultStroke { get; set; } = "black"; // Default line colour
        public static string DefaultStrokeDashArray { get; set; } = "";	// Default stroke dash
        public static int DefaultStrokeWidth { get; set; } = 1; // Default stroke width

        //Constructor
        public Line(double xone, double yone, double xtwo, double ytwo, int id)
        {
            Name = "Line";
            x1 = xone;
            y1 = yone;
            x2 = xtwo;
            y2 = ytwo;
            this.id = id;
            stroke = DefaultStroke;
            strokeDashArray = DefaultStrokeDashArray;
            strokeWidth = DefaultStrokeWidth;
        }

        //Set the default styles for a Line
        public static void SetDefaultStyle(string default_stroke, int default_stroke_width, string default_stroke_dash_array)
        {
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
            string new_points = Console.ReadLine();
            if (new_points == "..") return; //Allow the user to escape this edit

            try
            {
                /* Try separate the values out from the rest of the command
				 * convert the values to doubles and set those values as
				   the new dimensions of the shape							*/
                string[] newPoints = new_points.Split(',');
                newPoints[0] = newPoints[0].Substring(1, newPoints[0].Length - 1);
                newPoints[3] = newPoints[3].Substring(0, newPoints[3].Length - 1);

                //Convert and set
                x1 = Convert.ToDouble(newPoints[0]);
                y1 = Convert.ToDouble(newPoints[1]);
                x2 = Convert.ToDouble(newPoints[2]);
                y2 = Convert.ToDouble(newPoints[3]);
            }
            catch
            {
                // Give the user a response if their input couldn't be understood
                Console.WriteLine("Sorry I couldn't understand that, for more information on editing shapes look at the help screen.");
                Console.WriteLine("Enter `..` if you wish to cancel this dimension edit\n");
                //We call this same method so the user can try again
                this.Dimensions();
            }
        }

        //Edit the decoration of this shape
        public override void Decorations()
        {
            //Read in the new decorations attributes for this shape
            Console.WriteLine("Enter the new decoration attribute values for this Line in the form,\n\t"
                + "(stroke,stroke-width,stroke_dasharray):");
            String new_decor = Console.ReadLine();
            if (new_decor == "..") return;    //Allow the user to escape this edit

            try
            {
                //  Try to separate the data from the rest of the command and set the new values
                string[] data = new_decor.Split(',');
                data[0] = data[0].Substring(1, data[0].Length - 1);
                data[2] = data[2].Substring(0, data[2].Length - 1);
                //Set the new values
                stroke = data[0];
                strokeWidth = Convert.ToInt32(data[1]);
                strokeDashArray = data[2];
            }
            catch
            {
                //Give the user a response if their input couldn't be understood
                Console.WriteLine("Sorry I couldn't understand that, for more information on editing shapes look at the help screen.");
                Console.WriteLine("Remember Line cannot have a fill colour.");
                Console.WriteLine("Enter `..` if you wish to cancel this edit\n");
                //We call this methode again so the user can retry
                this.Decorations();
            }
        }

        //Embed this Circle into svg
        public override string Embed()
        {
            // Embed the shape into svg
            String svg = $"<line x1=\"{x1}\" y1=\"{y1}\" x2=\"{x2}\" y2=\"{y2}\" " +
                $"stroke=\"{stroke}\" stroke-width=\"{strokeWidth}\"";

            //Only add in the stroke-dasharray attribute if it's not set to the default
            if (strokeDashArray.Length != 0) { svg += $" stroke-dasharray=\"{strokeDashArray}\""; }

            return svg + "/>"; //Return the embedded shape
        }

        //Return the id of the shape
        public override int GetId()
        { return this.id; }
    }
}