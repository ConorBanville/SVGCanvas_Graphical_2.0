using System;

namespace SVGCanvas_Graphical_2._0
{
    internal class AddShape : IMenu
    {
        private string[] items;    // Array of items in the menu
        private int active = 0;     // Track the active item

        // Constructor
        public AddShape(string[] items)
        {
            this.items = items; // Set the menu items
        }

        // Open the menu
        public override string Open()
        {
            bool MenuOpen = true;

            // While the menu is open
            while (MenuOpen)
            {
                // Display some stuff
                Console.Clear();
                Display();

                // Read a key and decide what to do with it
                return KeyPressed(Console.ReadKey());
            }

            return ""; // Do nothing
        }

        // Enter key pressed, Run key function
        public string KeyPressed(ConsoleKeyInfo key)
        {
            // If DOWN ARROW was pressed
            if (key.Key == ConsoleKey.DownArrow)
            {
                active++;  // Move active item down
                if (active > items.Length - 1) { active = 0; } // Can't go past last item
                return "";
            }

            // If UP ARROW was pressed
            else if (key.Key == ConsoleKey.UpArrow)
            {
                active--;  // Move active item up
                if (active < 0) { active = items.Length - 1; }   // Can't go past first item
                return "";
            }

            // If ESC key was pressed
            else if (key.Key == ConsoleKey.Escape)
            {
                return "BACK"; // Return from this menu
            }

            // If ENTER key was pressed
            else if (key.Key == ConsoleKey.Enter)
            {
                switch (active)
                {
                    // Create a rectangle
                    case 0:
                        return "rect";

                    // Create a Circle
                    case 1:
                        return "circle";

                    // Create an Ellipse
                    case 2:
                        return "ellipse";

                    // Create a Line
                    case 3:
                        return "line";

                    // Create a Polyline
                    case 4:
                        return "polyline";

                    // Create a Polygon
                    case 5:
                        return "polygon";

                    // Create a Path
                    case 6:
                        return "path";

                    // Exit the menu
                    case 7:
                        return "BACK";
                }
            }

            // If any other key was pressed
            return "";
        }

        //Display the menu items
        public void Display()
        {
            Console.WriteLine(InfoScreens.welcome_banner);

            for (int i = 0; i < items.Length; i++)
            {
                if (i == active)
                {
                    Console.Write("> ");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(items[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("  ");
                    Console.WriteLine(items[i]);
                }
            }
        }

        public string GetActiveItem()
        {
            return items[active];
        }
    }
}