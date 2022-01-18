using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SVGCanvas_Graphical_2._0
{
    /*  This classes function is to take input from the user and return a
        shape object    */

    public class ShapeGenerator
    {
        // When a method is called the first time we will print a usage message
        // These boolean flags will track which methods have been called
        private static bool rectangle = true;

        private static bool circle = true;
        private static bool ellipse = true;
        private static bool line = true;
        private static bool polyline = true;
        private static bool polygon = true;
        private static bool path = true;

        // Method will take the user through command prompts in order to create
        // a Rectangle. If the inputs are all valid a new Rectangle object will
        // be returned.
        public static Rectangle Rectangle(int id)
        {
            double? x = null;   // The X position of the rectangle
            double? y = null;   // The Y position of the rectangle
            double? w = null;   // The Width of the rectangle
            double? h = null;   // The Height of the rectangle
            string input;       // Store the user input
            bool cancelled = false;  // If set to true then creation will be aborted

            // Explain usage to the user
            if (rectangle)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine("Enter the values for this Rectangle below");
                Console.WriteLine("You may cancel at any stage by entering ..");
                Console.WriteLine("Press any key to continue ...");
                Console.ReadKey();
                Console.Clear();
                rectangle = false;
            }

            // Get a x value from user
            while (true)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);  // Redraw the screen
                Console.WriteLine(@"        Rectangle       ");
                Console.WriteLine("------------------------");
                Console.WriteLine("X Position:");   // Prompt the user for a value
                input = Console.ReadLine(); // Read input from user
                double value;

                // If .. was entered then abort this shape's creation
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }

                // If the user's input was successfully converted to a double, break the loop and store the value
                else if (Double.TryParse(input, out value))
                {
                    x = value;
                    break;
                }
            }

            // If canceled then return from this method
            if (cancelled) return null;

            // Get a y value from user
            while (true)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);  // Redraw the screen
                Console.WriteLine(@"        Rectangle       ");
                Console.WriteLine("------------------------");
                Console.WriteLine("Y Position:");   // Prompt the user for a value
                input = Console.ReadLine(); // Read input from user
                double value;

                // If .. was entered then abort this shape's creation
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }

                // If the user's input was successfully converted to a double, break the loop and store the value
                else if (Double.TryParse(input, out value))
                {
                    y = value;
                    break;
                }
            }

            // If canceled then return from this method
            if (cancelled) return null;

            // Get a width value from user
            while (true)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);  // Redraw the screen
                Console.WriteLine(@"        Rectangle       ");
                Console.WriteLine("------------------------");
                Console.WriteLine("Width:");   // Prompt the user for a value
                input = Console.ReadLine(); // Read input from user
                double value;

                // If .. was entered then abort this shape's creation
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }

                // If the user's input was successfully converted to a double, break the loop and store the value
                else if (Double.TryParse(input, out value))
                {
                    w = value;
                    break;
                }
            }

            // If canceled then return from this method
            if (cancelled) return null;

            // Get a height value from user
            while (true)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);  // Redraw the screen
                Console.WriteLine(@"        Rectangle       ");
                Console.WriteLine("------------------------");
                Console.WriteLine("Height:");   // Prompt the user for a value
                input = Console.ReadLine(); // Read input from user
                double value;

                // If .. was entered then abort this shape's creation
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }

                // If the user's input was successfully converted to a double, break the loop and store the value
                else if (Double.TryParse(input, out value))
                {
                    h = value;
                    break;
                }
            }

            // If canceled then return from this method
            if (cancelled) return null;

            // If we have all the neccessary values, create and return a new rectangle
            // else return null
            if (x != null && y != null && w != null && h != null)
            {
                return new Rectangle((double)x, (double)y, (double)w, (double)h, id);
            }
            else
            {
                return null;
            }
        }

        // Method will take the user through command prompts in order to create
        // a Circle. If the inputs are all valid a new Circle object will
        // be returned.
        public static Circle Circle(int id)
        {
            double? x = null;   // The X position of the circle
            double? y = null;   // The Y position of the circle
            double? r = null;   // The Radius of the circle
            string input;       // Store the user input
            bool cancelled = false;  // If set to true then creation will be aborted

            // Explain usage to the user
            if (circle)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine("Enter the values for this Circle below");
                Console.WriteLine("You may cancel at any stage by entering ..");
                Console.WriteLine("Press any key to continue ...");
                Console.ReadKey();
                Console.Clear();
                circle = false;
            }

            // Get a x value from user
            while (true)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);  // Redraw the screen
                Console.WriteLine(@"        Circle       ");
                Console.WriteLine("---------------------");
                Console.WriteLine("X Position:");   // Prompt the user for a value
                input = Console.ReadLine(); // Read input from user
                double value;

                // If .. was entered then abort this shape's creation
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }

                // If the user's input was successfully converted to a double, break the loop and store the value
                else if (Double.TryParse(input, out value))
                {
                    x = value;
                    break;
                }
            }

            // If canceled then return from this method
            if (cancelled) return null;

            // Get a y value from user
            while (true)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);  // Redraw the screen
                Console.WriteLine(@"        Circle       ");
                Console.WriteLine("---------------------");
                Console.WriteLine("Y Position:");   // Prompt the user for a value
                input = Console.ReadLine(); // Read input from user
                double value;

                // If .. was entered then abort this shape's creation
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }

                // If the user's input was successfully converted to a double, break the loop and store the value
                else if (Double.TryParse(input, out value))
                {
                    y = value;
                    break;
                }
            }

            // If canceled then return from this method
            if (cancelled) return null;

            // Get a width value from user
            while (true)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);  // Redraw the screen
                Console.WriteLine(@"        Circle       ");
                Console.WriteLine("---------------------");
                Console.WriteLine("Radius:");   // Prompt the user for a value
                input = Console.ReadLine(); // Read input from user
                double value;

                // If .. was entered then abort this shape's creation
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }

                // If the user's input was successfully converted to a double, break the loop and store the value
                else if (Double.TryParse(input, out value))
                {
                    r = value;
                    break;
                }
            }

            // If canceled then return from this method
            if (cancelled) return null;

            // If we have all the neccessary values, create and return a new circle
            // else return null
            if (x != null && y != null && r != null)
            {
                return new Circle((double)x, (double)y, (double)r, id);
            }
            else
            {
                return null;
            }
        }

        // Method will take the user through command prompts in order to create
        // an Ellipse. If the inputs are all valid a new Ellipse object will
        // be returned.
        public static Ellipse Ellipse(int id)
        {
            double? x = null;   // The X position of the ellipse
            double? y = null;   // The Y position of the ellipse
            double? xrad = null;   // The X radius of the ellipse
            double? yrad = null;   // The Y radius of the ellipse
            string input;       // Store the user input
            bool cancelled = false;  // If set to true then creation will be aborted

            // Explain usage to the user
            if (ellipse)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine("Enter the values for this Ellipse below");
                Console.WriteLine("You may cancel at any stage by entering ..");
                Console.WriteLine("Press any key to continue ...");
                Console.ReadKey();
                Console.Clear();
                ellipse = false;
            }

            // Get a x value from user
            while (true)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);  // Redraw the screen
                Console.WriteLine(@"        Ellipse       ");
                Console.WriteLine("----------------------");
                Console.WriteLine("X Position:");   // Prompt the user for a value
                input = Console.ReadLine(); // Read input from user
                double value;

                // If .. was entered then abort this shape's creation
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }

                // If the user's input was successfully converted to a double, break the loop and store the value
                else if (Double.TryParse(input, out value))
                {
                    x = value;
                    break;
                }
            }

            // If canceled then return from this method
            if (cancelled) return null;

            // Get a y value from user
            while (true)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);  // Redraw the screen
                Console.WriteLine(@"        Ellipse       ");
                Console.WriteLine("----------------------");
                Console.WriteLine("Y Position:");   // Prompt the user for a value
                input = Console.ReadLine(); // Read input from user
                double value;

                // If .. was entered then abort this shape's creation
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }

                // If the user's input was successfully converted to a double, break the loop and store the value
                else if (Double.TryParse(input, out value))
                {
                    y = value;
                    break;
                }
            }

            // If canceled then return from this method
            if (cancelled) return null;

            // Get a width value from user
            while (true)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);  // Redraw the screen
                Console.WriteLine(@"        Ellipse       ");
                Console.WriteLine("----------------------");
                Console.WriteLine("X Radius:");   // Prompt the user for a value
                input = Console.ReadLine(); // Read input from user
                double value;

                // If .. was entered then abort this shape's creation
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }

                // If the user's input was successfully converted to a double, break the loop and store the value
                else if (Double.TryParse(input, out value))
                {
                    xrad = value;
                    break;
                }
            }

            // If canceled then return from this method
            if (cancelled) return null;

            // Get a height value from user
            while (true)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);  // Redraw the screen
                Console.WriteLine(@"        Ellipse       ");
                Console.WriteLine("----------------------");
                Console.WriteLine("Y Radius:");   // Prompt the user for a value
                input = Console.ReadLine(); // Read input from user
                double value;

                // If .. was entered then abort this shape's creation
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }

                // If the user's input was successfully converted to a double, break the loop and store the value
                else if (Double.TryParse(input, out value))
                {
                    yrad = value;
                    break;
                }
            }

            // If canceled then return from this method
            if (cancelled) return null;

            // If we have all the neccessary values, create and return a new ellipse
            // else return null
            if (x != null && y != null && xrad != null && yrad != null)
            {
                return new Ellipse((double)x, (double)y, (double)xrad, (double)yrad, id);
            }
            else
            {
                return null;
            }
        }

        // Method will take the user through command prompts in order to create
        // a Line. If the inputs are all valid a new Line object will
        // be returned.
        public static Line Line(int id)
        {
            double? x1 = null;   // The X1 position of the line
            double? y1 = null;   // The Y1 position of the line
            double? x2 = null;   // The X2 radius of the line
            double? y2 = null;   // The Y2 radius of the line
            string input;       // Store the user input
            bool cancelled = false;  // If set to true then creation will be aborted

            // Explain usage to the user
            if (line)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine("Enter the values for this Line below");
                Console.WriteLine("You may cancel at any stage by entering ..");
                Console.WriteLine("Press any key to continue ...");
                Console.ReadKey();
                Console.Clear();
                line = false;
            }

            // Get a x value from user
            while (true)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);  // Redraw the screen
                Console.WriteLine(@"        Line       ");
                Console.WriteLine("-------------------");
                Console.WriteLine("X1 Position:");   // Prompt the user for a value
                input = Console.ReadLine(); // Read input from user
                double value;

                // If .. was entered then abort this shape's creation
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }

                // If the user's input was successfully converted to a double, break the loop and store the value
                else if (Double.TryParse(input, out value))
                {
                    x1 = value;
                    break;
                }
            }

            // If canceled then return from this method
            if (cancelled) return null;

            // Get a y value from user
            while (true)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);  // Redraw the screen
                Console.WriteLine(@"        Line       ");
                Console.WriteLine("-------------------");
                Console.WriteLine("Y1 Position:");   // Prompt the user for a value
                input = Console.ReadLine(); // Read input from user
                double value;

                // If .. was entered then abort this shape's creation
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }

                // If the user's input was successfully converted to a double, break the loop and store the value
                else if (Double.TryParse(input, out value))
                {
                    y1 = value;
                    break;
                }
            }

            // If canceled then return from this method
            if (cancelled) return null;

            // Get a width value from user
            while (true)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);  // Redraw the screen
                Console.WriteLine(@"        Line       ");
                Console.WriteLine("-------------------");
                Console.WriteLine("X2 Position:");   // Prompt the user for a value
                input = Console.ReadLine(); // Read input from user
                double value;

                // If .. was entered then abort this shape's creation
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }

                // If the user's input was successfully converted to a double, break the loop and store the value
                else if (Double.TryParse(input, out value))
                {
                    x2 = value;
                    break;
                }
            }

            // If canceled then return from this method
            if (cancelled) return null;

            // Get a height value from user
            while (true)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);  // Redraw the screen
                Console.WriteLine(@"        Line       ");
                Console.WriteLine("-------------------");
                Console.WriteLine("Y2 Position:");   // Prompt the user for a value
                input = Console.ReadLine(); // Read input from user
                double value;

                // If .. was entered then abort this shape's creation
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }

                // If the user's input was successfully converted to a double, break the loop and store the value
                else if (Double.TryParse(input, out value))
                {
                    y2 = value;
                    break;
                }
            }

            // If canceled then return from this method
            if (cancelled) return null;

            // If we have all the neccessary values, create and return a new line
            // else return null
            if (x1 != null && y1 != null && x2 != null && y2 != null)
            {
                return new Line((double)x1, (double)y1, (double)x2, (double)y2, id);
            }
            else
            {
                return null;
            }
        }

        // Method will take the user through command prompts in order to create
        // a Polyline. If the inputs are all valid a new Polyline object will
        // be returned.
        public static Polyline Polyline(int id)
        {
            List<Point> points = new List<Point>(); // Store a list of points required to create a polyline
            Point p;    // Store a single point
            string input;
            Regex regex = new Regex("^(-?)(0|([1-9][0-9]*))(\\.[0-9]+)?$"); // Regex match for a positive/negative integer/floating-point number

            // Explain usage to the user
            if (polyline)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine("Enter the values for this Polyline below in the form:");
                Console.WriteLine("Enter values in the form: x1,y1,x2,y2, ... ,xN,yN");
                Console.WriteLine("You may cancel at any stage by entering ..");
                Console.WriteLine("Press any key to continue ...");
                Console.ReadKey();
                Console.Clear();
                polyline = false;
            }

            while (true)
            {
                // Redraw the screen
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine(@"        Polyline       ");
                Console.WriteLine("-----------------------");
                Console.WriteLine("Enter values in the form: x1,y1,x2,y2, ... ,xN,yN");

                // Read input from user
                input = Console.ReadLine();

                // Abort this shapes creation
                if (input.Contains(".."))
                {
                    break;
                }
                else
                {
                    // Split the input on ',' and store in array
                    string[] numbers = input.Split(',');
                    // We must have an even number of values so that each point has an X and Y pair
                    if (numbers.Length % 2 != 0) break;
                    // Flag will be set to false if any value entered cannot be converted to a double
                    bool success = true;

                    // Go through the array and confirm that each value is a number
                    // creating points as we go and adding those points to the list
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (regex.IsMatch(numbers[i]) && regex.IsMatch(numbers[i + 1]))
                        {
                            p = new Point(Convert.ToDouble(numbers[i]), Convert.ToDouble(numbers[i + 1]));
                            points.Add(p);
                            i++;
                        }
                        else
                        {
                            // If any of the values cannot be converted explain the error to the user and
                            // break the for loop
                            success = false;
                            Console.Clear();
                            Console.WriteLine("Failed to convert every value to a number!");
                            Console.WriteLine("Please try again.");
                            Console.WriteLine("Press any key to continue ...");
                            Console.ReadLine();
                            break;
                        }
                    }

                    // If every value was successfully converted then create and return
                    // a new Polyline object
                    if (success)
                    {
                        return new Polyline(points, id);
                    }
                }
            }
            // If this line is reached then either the user cancelled the creation
            // or the creation failed in some way
            return null;
        }

        // Method will take the user through command prompts in order to create
        // a Polygon. If the inputs are all valid a new Polygon object will
        // be returned.
        public static Polygon Polygon(int id)
        {
            List<Point> points = new List<Point>(); // Store a list of points required to create a polygon
            Point p;    // Store a single point
            string input;
            Regex regex = new Regex("^(-?)(0|([1-9][0-9]*))(\\.[0-9]+)?$"); // Regex match for a positive/negative integer/floating-point number

            // Explain usage to the user
            if (polygon)
            {
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine("Enter the values for this Polygon below in the form:");
                Console.WriteLine(" x1,y1,x2,y2, ... ,xN,yN");
                Console.WriteLine("You may cancel at any stage by entering ..");
                Console.WriteLine("Press any key to continue ...");
                Console.ReadKey();
                Console.Clear();
                polygon = false;
            }

            while (true)
            {
                // Redraw the screen
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine(@"        Polygon       ");
                Console.WriteLine("----------------------");
                Console.WriteLine("Enter values in the form: x1,y1,x2,y2, ... ,xN,yN");

                // Read input from user
                input = Console.ReadLine();

                // Abort this shapes creation
                if (input.Contains(".."))
                {
                    break;
                }
                else
                {
                    // Split the input on ',' and store in array
                    string[] numbers = input.Split(',');
                    // We must have an even number of values so that each point has an X and Y pair
                    if (numbers.Length % 2 != 0) break;
                    // Flag will be set to false if any value entered cannot be converted to a double
                    bool success = true;

                    // Go through the array and confirm that each value is a number
                    // creating points as we go and adding those points to the list
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (regex.IsMatch(numbers[i]) && regex.IsMatch(numbers[i + 1]))
                        {
                            p = new Point(Convert.ToDouble(numbers[i]), Convert.ToDouble(numbers[i + 1]));
                            points.Add(p);
                            i++;
                        }
                        else
                        {
                            // If any of the values cannot be converted explain the error to the user and
                            // break the for loop
                            success = false;
                            Console.Clear();
                            Console.WriteLine("Failed to convert every value to a number!");
                            Console.WriteLine("Please try again.");
                            Console.WriteLine("Press any key to continue ...");
                            Console.ReadLine();
                            break;
                        }
                    }

                    // If every value was successfully converted then create and return
                    // a new Polygon object
                    if (success)
                    {
                        return new Polygon(points, id);
                    }
                }
            }
            // If this line is reached then either the user cancelled the creation
            // or the creation failed in some way
            return null;
        }

        // Method will take the user through command prompts in order to create
        // a Path. If the inputs are all valid a new Path object will
        // be returned.
        public static Path Path(int id)
        {
            string input;

            // Explain usage to the user
            if (path)
            {
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine("Enter the intructions for a path below");
                Console.WriteLine("for more info: https://www.w3schools.com/graphics/svg_path.asp");
                Console.WriteLine("You may cancel at any stage by entering ..");
                Console.WriteLine("Press any key to continue ...");
                Console.ReadKey();
                Console.Clear();
                path = false;
            }

            // Redraw the screen
            Console.Clear();
            Console.WriteLine(InfoScreens.welcome_banner);
            Console.WriteLine(@"        Path       ");
            Console.WriteLine("----------------------");

            // Read input from the user
            Console.WriteLine("Instructions:");
            input = Console.ReadLine();

            // Abort creation if .. was entered
            if (input.Contains(".."))
            {
                return null;
            }
            else
            {
                return new Path(input, id);
            }
        }
    }
}