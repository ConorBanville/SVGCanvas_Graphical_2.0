using Newtonsoft.Json;
using System;

namespace SVGCanvas_Graphical_2._0
{
    public class Path : Shape
    {
        public string Name { get; set; } // Name of the shape
        public int id { get; set; }
        public string instructions { get; set; }
        public string fill { get; set; }
        public string stroke { get; set; }
        public string strokeDashArray { get; set; }
        public int strokeWidth { get; set; }
        public static string DefaultFill { get; set; } = "transparent";
        public static string DefaultStroke { get; set; } = "black";
        public static string DefaultStrokeDashArray { get; set; } = "";
        public static int DefaultStrokeWidth { get; set; } = 1;

        // Constructor
        public Path(string inst, int id)
        {
            Name = "Path";
            this.id = id;
            instructions = inst;
            //Default values
            fill = DefaultFill;
            stroke = DefaultStroke;
            strokeDashArray = DefaultStrokeDashArray;
            strokeWidth = DefaultStrokeWidth;
        }

        //Set the default styles for a Path
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

        //Edit the dimensions of this Path shape
        public override void Dimensions()
        {
            //Read in the new decorations attributes for this shape
            Console.WriteLine(
@"Enter the new decoration attribute values for this Recatngle in the form
(fill,stroke,stroke-width,stroke_dasharray):");
            string arguments = Console.ReadLine();
            if (arguments == "..") return;
            try
            {
                //Try to get a substring from the command given, ie. drop the '<' and the '>'
                arguments = arguments.Substring(arguments.IndexOf('<') + 1, ((arguments.IndexOf('>')) - (arguments.IndexOf('<') + 1)));
                instructions = arguments;   // Set the new instructions, admittedly a lot more data validation could be done here, but since
                                            // invalid instructions doesn't break svg only this specific path shape I didn't prioritise this
            }
            catch
            {
                // Give the user a response if their input couldn't be separated out and turned into an array of numbers
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
            Console.WriteLine("Enter the new decoration attribute values for this Path in the form,\n\t"
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

        //Embed this Rectangle into svg
        public override string Embed()
        {
            String svg = $"<path fill=\"{fill}\" stroke=\"{stroke}\" stroke-width=\"{strokeWidth}\" \n" +
                $"d=\"{instructions}\"";

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