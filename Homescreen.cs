using System;

namespace SVGCanvas_Graphical_2._0
{
    internal class Homescreen : IMenu
    {
        private string[] items;    // Array of items in the menu
        private int active = 0;     // Track the active item

        // Constructor
        public Homescreen(string[] items)
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
                switch (KeyPressed(Console.ReadKey()))
                {
                    case "BACK":   // We need to close the menu
                        MenuOpen = false;
                        return "CLOSE PROGRAM";

                    case "SAVED CANVASES":
                     return "SAVED CANVASES";

                    case "NEW CANVAS":  // We need to move onto a new menu
                        MenuOpen = false;
                        return "NEW CANVAS";
                }
            }

            return ""; // Do nothing
        }

        // Enter key pressed, Run key function
        public string KeyPressed(ConsoleKeyInfo key)
        {
            // If ENTER key was pressed

            if (key.Key == ConsoleKey.Enter)
            {
                switch (active)
                {
                    // NEW CANVAS has been selected
                    case 0:
                        return "NEW CANVAS";

                    // LOAD CANVAS has been selected
                    case 1:
                        return "SAVED CANVASES";

                    // HELP OPTION has been selected
                    case 2:
                        Console.Clear();    // Clear the console
                        Console.WriteLine(InfoScreens.help);   // Diplay the help screen
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();  // Wait for key press
                        return "";

                    // EXIT OPTION has been selected
                    case 3:
                        return "BACK";

                    // Default keep running menu
                    default:
                        return "";
                }
            }

            // If ESC key was pressed
            else if (key.Key == ConsoleKey.Escape)
            {
                return "BACK";
            }

            // If UP ARROW was pressed
            else if (key.Key == ConsoleKey.UpArrow)
            {
                active--;
                if (active < 0) { active = items.Length - 1; }
                return "";
            }

            // If DOWN ARROW was pressed
            if (key.Key == ConsoleKey.DownArrow)
            {
                active++;
                if (active > items.Length - 1) { active = 0; }
                return "";
            }

            // If any other key was pressed
            else
            {
                return "";
            }
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