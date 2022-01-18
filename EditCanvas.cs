using System;

namespace SVGCanvas_Graphical_2._0
{
    internal class EditCanvas : IMenu
    {
        private string[] items;    // Array of items in the menu
        private int active = 0;     // Track the active item

        // Constructor
        public EditCanvas(string[] items)
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
                    // Add a Shape
                    case 0:
                        return "Add Shape";

                    // Remove a Shape
                    case 1:
                        return "Remove Shape";

                    // Zedit a shape
                    case 2:
                        return "Shift Shape";

                    // Edit a shapes style
                    case 3:
                        return "Edit Style";

                    // Edit a shape size/location
                    case 4:
                        return "Edit Shape";

                    // Edit the default style of a shape
                    case 5:
                        return "Default Style";

                    // Edit the dimensions of the canvas
                    case 6:
                        return "Edit Canvas";

                    // Display Canvas
                    case 7:
                        return "Display Canvas";

                    // Export the canvas
                    case 8:
                        return "Export";

                    // Save the current canvas
                    case 9: 
                        return "Save Canvas";

                    // Undo last move
                    case 10:
                        return "Undo";

                    // Redo last move
                    case 11:
                        return "Redo";

                    // Switch to CLI Mode
                    case 12:
                        return "CLI Mode";

                    // Exit the menu
                    case 13:
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