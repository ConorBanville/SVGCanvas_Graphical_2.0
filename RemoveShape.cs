using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SVGCanvas_Graphical_2._0
{
    internal class RemoveShape : IMenu
    {
        private string[] items;    // Array of items in the menu
        private List<Shape> canvas; // Store the list of shapes on the canvas
        private static string optional_text; // Display some optional text
        private int active = 0;     // Track the active item

        // Constructor
        public RemoveShape(List<Shape> canvas)
        {
            this.canvas = canvas;
            this.items = new string[canvas.Count];
            for (int i = 0; i < canvas.Count; i++)
            {
                items[i] = JsonConvert.SerializeObject(canvas[i], Formatting.Indented);
            }
            optional_text = "Select a shape below to remove it";
        }

        // Open the menu
        public override string Open()
        {
            bool MenuOpen = true;

            // While the menu is open
            while (MenuOpen)
            {
                // Display some stuff
                //Console.Clear();
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
                return "Exit Default Style"; // Return from this menu
            }

            // If ENTER key was pressed
            else if (key.Key == ConsoleKey.Enter)
            {
                return canvas[active].GetId() + "";
            }

            // If any other key was pressed
            return "";
        }

        //Display the menu items
        public void Display()
        {
            Console.Clear();
            Console.WriteLine(InfoScreens.welcome_banner);
            Console.WriteLine(optional_text);

            for (int i = 0; i < items.Length; i++)
            {
                if (i == active)
                {
                    //Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(items[i]);
                    Console.ResetColor();
                }
                else
                {
                    //Console.Write("  ");
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