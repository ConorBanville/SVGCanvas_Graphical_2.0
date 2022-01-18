using System;
using System.Collections.Generic;
using System.IO;

namespace SVGCanvas_Graphical_2._0
{
    internal class CLIParser
    {
        public static Canvas c;
        public static List<Shape> shapes;
        public static List<Point> points;
        public static Point p;

        public static string Parse(string input)
        {
            // Split up the input
            string argument;
            string data;

            if (input.Contains(' '))
            {
                argument = input.Substring(0, input.IndexOf(' '));
                data = input.Substring(input.IndexOf(' ') + 1, input.Length - (input.IndexOf(' ') + 1));
                if (argument.ToLower() == "path")
                {
                    return AddPath(data);
                }
                else if (argument.ToLower() == "default-style")
                {
                    return DefaultStyle(data);
                }
                else
                {
                    return Switch(argument, data);
                }
            }
            else
            {
                argument = input;
                return Switch(argument);
            }
        }

        public static string Switch(string argument, string _data)
        {
            // Convert string data to a double[]
            _data = _data.Substring(1, _data.Length - 2);
            string[] temp = _data.Split(',');
            double[] data = new double[temp.Length];

            for (int i = 0; i < data.Length; i++)
            {
                if (!Double.TryParse(temp[i], out data[i]))
                {
                    Console.WriteLine($"Failed to parse {_data}, valid command must only contain numbers");
                    return "";
                }
            }

            switch (argument.ToLower())
            {
                case "rect":
                    if (data.Length == 4)
                    {
                        Rectangle r = new Rectangle(data[0], data[1], data[2], data[3], Program.game.shape_id);
                        c = new Canvas(Program.game.caretaker.GetState().canvas.GetList());
                        c.shapes.Add(r);
                        Console.WriteLine($"Rectangle added with ID = {Program.game.shape_id}");
                        Program.game.shape_id++;
                        Program.game.caretaker.o.NewState(c);
                        Program.game.caretaker.BackUp();
                    }
                    break;

                case "circle":
                    if (data.Length == 3)
                    {
                        Circle cir = new Circle(data[0], data[1], data[2], Program.game.shape_id);
                        c = new Canvas(Program.game.caretaker.GetState().canvas.GetList());
                        c.shapes.Add(cir);
                        Console.WriteLine($"Circle added with ID = {Program.game.shape_id}");
                        Program.game.shape_id++;
                        Program.game.caretaker.o.NewState(c);
                        Program.game.caretaker.BackUp();
                    }
                    break;

                case "ellipse":
                    if (data.Length == 4)
                    {
                        Ellipse e = new Ellipse(data[0], data[1], data[2], data[3], Program.game.shape_id);
                        c = new Canvas(Program.game.caretaker.GetState().canvas.GetList());
                        c.shapes.Add(e);
                        Console.WriteLine($"Ellipse added with ID = {Program.game.shape_id}");
                        Program.game.shape_id++;
                        Program.game.caretaker.o.NewState(c);
                        Program.game.caretaker.BackUp();
                    }
                    break;

                case "line":
                    if (data.Length == 4)
                    {
                        Line l = new Line(data[0], data[1], data[2], data[3], Program.game.shape_id);
                        c = new Canvas(Program.game.caretaker.GetState().canvas.GetList());
                        c.shapes.Add(l);
                        Console.WriteLine($"Line added with ID = {Program.game.shape_id}");
                        Program.game.shape_id++;
                        Program.game.caretaker.o.NewState(c);
                        Program.game.caretaker.BackUp();
                    }
                    break;

                case "polyline":
                    if (data.Length % 2 == 0)
                    {
                        points = new List<Point>();

                        for (int i = 0; i < data.Length; i++)
                        {
                            p = new Point(data[i], data[i + 1]);
                            points.Add(p);
                            i++;
                        }

                        Polyline pl = new Polyline(points, Program.game.shape_id);
                        c = new Canvas(Program.game.caretaker.GetState().canvas.GetList());
                        c.shapes.Add(pl);
                        Console.WriteLine($"Polyline added with ID = {Program.game.shape_id}");
                        Program.game.shape_id++;
                        Program.game.caretaker.o.NewState(c);
                        Program.game.caretaker.BackUp();
                    }
                    break;

                case "polygon":
                    if (data.Length % 2 == 0)
                    {
                        points = new List<Point>();

                        for (int i = 0; i < data.Length; i++)
                        {
                            p = new Point(data[i], data[i + 1]);
                            points.Add(p);
                            i++;
                        }

                        Polygon pg = new Polygon(points, Program.game.shape_id);
                        c = new Canvas(Program.game.caretaker.GetState().canvas.GetList());
                        c.shapes.Add(pg);
                        Console.WriteLine($"Polygon added with ID = {Program.game.shape_id}");
                        Program.game.shape_id++;
                        Program.game.caretaker.o.NewState(c);
                        Program.game.caretaker.BackUp();
                    }
                    break;

                case "remove":
                    shapes = CLICanvasToolkit.Remove(Program.game.caretaker.GetState().canvas, (int)data[0]);
                    if (shapes != null)
                    {
                        Program.game.caretaker.o.NewState(new Canvas(shapes));
                        Program.game.caretaker.BackUp();
                        Console.WriteLine($"Shape with ID[{data[0]}] removed");
                    }
                    else
                    {
                        Console.WriteLine($"Shape with ID: {data[0]} could not be found in the canvas");
                    }
                    break;

                case "style":
                    shapes = CLICanvasToolkit.Style(Program.game.caretaker.GetState().canvas, (int)data[0]);
                    if (shapes != null)
                    {
                        Program.game.caretaker.o.NewState(new Canvas(shapes));
                        Program.game.caretaker.BackUp();
                    }
                    else
                    {
                        Console.WriteLine($"Shape with ID: {data[0]} could not be found in the canvas");
                    }
                    break;

                case "shift":
                    shapes = CLICanvasToolkit.Shift(Program.game.caretaker.GetState().canvas, (int)data[0], (int)data[1]);
                    if (shapes.Count == 0)
                    {
                        Console.WriteLine("Error: New index must not exceed the index of the last shape in the canvas ...");
                    }
                    else if (shapes != null)
                    {
                        Program.game.caretaker.o.NewState(new Canvas(shapes));
                        Program.game.caretaker.BackUp();
                        Console.WriteLine($"Shape with ID: [{data[0]}] has been moved to index [{data[1]}]");
                    }
                    else
                    {
                        Console.WriteLine($"Shape with ID: {data[0]} could not be found in the canvas");
                    }
                    break;
            }
            return "";
        }

        public static string Switch(string argument)
        {
            switch (argument.ToLower())
            {
                // Show the help info
                case "h":
                    Console.WriteLine(InfoScreens.help);
                    break;

                case "help":
                    Console.WriteLine(InfoScreens.help);
                    break;

                // Show the list info
                case "l":
                    Console.WriteLine(InfoScreens.list);
                    break;

                case "list":
                    Console.WriteLine(InfoScreens.list);
                    break;

                // Close the program
                case "k":
                    return "close";

                case "kill":
                    return "close";

                // Export the canvas
                case "e":
                    string save_name = DateTime.Now.ToString("dddd, dd MM yyyy HH-mm-ss");  // Use a DateTime object to ensure a unique filename
                    string svg = CanvasToolkit.EmbedCanvas(Program.game.caretaker.GetState().canvas);   // Convert the canvas into svg
                    File.WriteAllText($"./exported svg/{save_name}.svg", svg);   // Save the svg in a new file
                    Console.WriteLine("Canvas exported successfully");
                    break;

                // Display the canvas
                case "c":
                    CLICanvasToolkit.Display(Program.game.caretaker.GetState().canvas);
                    break;

                // Switch back the the menu system
                case "closecli":
                    return "closecli";

                // Undo
                case "undo":
                    Program.game.caretaker.undo();
                    break;

                // Redo
                case "redo":
                    Program.game.caretaker.redo();
                    break;
            }
            return "";
        }

        public static string AddPath(string data)
        {
            data = data.Substring(1, data.Length - 2);
            Path p = new Path(data, Program.game.shape_id);
            c = new Canvas(Program.game.caretaker.GetState().canvas.GetList());
            c.shapes.Add(p);
            Console.WriteLine($"Path added with ID = {Program.game.shape_id}");
            Program.game.shape_id++;
            Program.game.caretaker.o.NewState(c);
            Program.game.caretaker.BackUp();
            return "";
        }

        public static string DefaultStyle(string _data)
        {
            _data = _data.Substring(1, _data.Length - 2);
            string[] data = _data.Split(',');
            string fill = "", stroke, dash;
            int width;

            if (data[0] == "line")
            {
                try
                {
                    stroke = data[1];
                    width = Convert.ToInt32(data[2]);
                    dash = data[3];
                }
                catch
                {
                    Console.WriteLine("Whoops! We have run into an error parsing your input. Ensure that the value passed to stroke-width is a number.");
                    return "";
                }
            }
            else
            {
                try
                {
                    fill = data[1];
                    stroke = data[2];
                    width = Convert.ToInt32(data[3]);
                    dash = data[4];
                }
                catch
                {
                    Console.WriteLine("Whoops! We have run into an error parsing your input. Ensure that the value passed to stroke-width is a number.");
                    return "";
                }
            }

            switch (data[0])
            {
                case "rect":
                    if (data.Length == 5)
                    {
                        Rectangle.SetDefaultStyle(fill, stroke, width, dash);
                    }
                    else
                    {
                        Console.WriteLine("Error! Must include an assignment for Fill/Stroke/Stroke Width/Stroke Dash Array");
                    }
                    break;

                case "circle":
                    if (data.Length == 5)
                    {
                        Circle.SetDefaultStyle(fill, stroke, width, dash);
                    }
                    else
                    {
                        Console.WriteLine("Error! Must include an assignment for Fill/Stroke/Stroke Width/Stroke Dash Array");
                    }
                    break;

                case "ellipse":
                    if (data.Length == 5)
                    {
                        Ellipse.SetDefaultStyle(fill, stroke, width, dash);
                    }
                    else
                    {
                        Console.WriteLine("Error! Must include an assignment for Fill/Stroke/Stroke Width/Stroke Dash Array");
                    }
                    break;

                case "line":
                    if (data.Length == 4)
                    {
                        Line.SetDefaultStyle(stroke, width, dash);
                    }
                    else
                    {
                        Console.WriteLine("Error! Must include an assignment for Stroke/Stroke Width/Stroke Dash Array");
                    }
                    break;

                case "polyline":
                    if (data.Length == 5)
                    {
                        Polyline.SetDefaultStyle(fill, stroke, width, dash);
                    }
                    else
                    {
                        Console.WriteLine("Error! Must include an assignment for Fill/Stroke/Stroke Width/Stroke Dash Array");
                    }
                    break;

                case "polygon":
                    if (data.Length == 5)
                    {
                        Polygon.SetDefaultStyle(fill, stroke, width, dash);
                    }
                    else
                    {
                        Console.WriteLine("Error! Must include an assignment for Fill/Stroke/Stroke Width/Stroke Dash Array");
                    }
                    break;

                case "path":
                    if (data.Length == 5)
                    {
                        Path.SetDefaultStyle(fill, stroke, width, dash);
                    }
                    else
                    {
                        Console.WriteLine("Error! Must include an assignment for Fill/Stroke/Stroke Width/Stroke Dash Array");
                    }
                    break;
            }

            return "";
        }
    }
}