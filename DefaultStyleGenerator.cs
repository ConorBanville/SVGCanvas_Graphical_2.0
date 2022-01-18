using System;

namespace SVGCanvas_Graphical_2._0
{
    internal class DefaultStyleGenerator
    {
        /*  Take the user through command prompts to get default
            style attributes for a shape that can have a fill colour*/

        public static string[] FillShape()
        {
            string[] attr = new string[4];
            bool cancelled = false;
            string input;

            // Get a fill colour
            while (true)
            {
                // Redraw the screen
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine("You can cancel at any stage by entering ..");
                Console.WriteLine("Fill :");

                // Accept new input
                input = Console.ReadLine();

                // If .. was entered then exit
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }
                else
                {
                    attr[0] = input; // Save the value
                    break;
                }
            }

            // If .. was entered abort
            if (cancelled) return null;

            while (true)
            {
                // Redraw the screen
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine("You can cancel at any stage by entering ..");
                Console.WriteLine("Stroke :");
                // Accept new input
                input = Console.ReadLine();

                // If .. was entered then exit
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }
                else
                {
                    attr[1] = input; // Save the value
                    break;
                }
            }

            // If .. was entered abort
            if (cancelled) return null;

            while (true)
            {
                // Redraw the screen
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine("You can cancel at any stage by entering ..");
                Console.WriteLine("Stroke Width:");
                // Accept new input
                input = Console.ReadLine();

                // If .. was entered then exit
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }
                else
                {
                    if (Int32.TryParse(input, out int x)) // Check if value can be converted to an int
                    {
                        attr[2] = input; // Save the value
                        break;
                    }
                }
            }

            // If .. was entered abort
            if (cancelled) return null;

            while (true)
            {
                // Redraw the screen
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine("You can cancel at any stage by entering ..");
                Console.WriteLine("Stroke Dash Array :");
                // Accept new input
                input = Console.ReadLine();

                // If .. was entered then exit
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }
                else
                {
                    attr[3] = input; // Save the value
                    break;
                }
            }

            // If .. was entered abort
            if (cancelled) return null;

            return attr;
        }

        /*  Take the user through command prompts to get default
            style attributes for a shape that can't have a fill colour*/

        public static string[] NonFillShape()
        {
            string[] attr = new string[4];
            bool cancelled = false;
            string input;

            // Get a fill colour
            while (true)
            {
                // Redraw the screen
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine("You can cancel at any stage by entering ..");
                Console.WriteLine("Stroke :");

                // Accept new input
                input = Console.ReadLine();

                // If .. was entered then exit
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }
                else
                {
                    attr[0] = input; // Save the value
                    break;
                }
            }

            // If .. was entered abort
            if (cancelled) return null;

            while (true)
            {
                // Redraw the screen
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine("You can cancel at any stage by entering ..");
                Console.WriteLine("Stroke Width:");
                // Accept new input
                input = Console.ReadLine();

                // If .. was entered then exit
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }
                else
                {
                    if (Int32.TryParse(input, out int x)) // Check if value can be converted to an int
                    {
                        attr[1] = input; // Save the value
                        break;
                    }
                }
            }

            // If .. was entered abort
            if (cancelled) return null;

            while (true)
            {
                // Redraw the screen
                Console.Clear();
                Console.WriteLine(InfoScreens.welcome_banner);
                Console.WriteLine("You can cancel at any stage by entering ..");
                Console.WriteLine("Stroke Dash Array:");
                // Accept new input
                input = Console.ReadLine();

                // If .. was entered then exit
                if (input.Contains(".."))
                {
                    cancelled = true;
                    break;
                }
                else
                {
                    attr[2] = input; // Save the value
                    break;
                }
            }

            // If .. was entered abort
            if (cancelled) return null;

            return attr;
        }
    }
}