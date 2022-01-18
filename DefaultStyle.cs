using System;

namespace SVGCanvas_Graphical_2._0
{
    internal class DefaultStyle : IMenu
    {
        private string[] items;    // Array of items in the menu
        private int active = 0;     // Track the active item

        // Constructor
        public DefaultStyle(string[] items)
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
                return "Exit Default Style"; // Return from this menu
            }

            // If ENTER key was pressed
            else if (key.Key == ConsoleKey.Enter)
            {
                // Store new default style attributes for a shape
                string[] style_attributes;

                switch (active)
                {
                    // Edit style for a rectangle
                    case 0:
                        style_attributes = DefaultStyleGenerator.FillShape();
                        if (style_attributes != null)
                        {
                            Rectangle.SetDefaultStyle(style_attributes[0], style_attributes[1], Convert.ToInt32(style_attributes[2]), style_attributes[3]);
                        }
                        break;

                    // Edit style for a Circle
                    case 1:
                        style_attributes = DefaultStyleGenerator.FillShape();
                        if (style_attributes != null)
                        {
                            Circle.SetDefaultStyle(style_attributes[0], style_attributes[1], Convert.ToInt32(style_attributes[2]), style_attributes[3]);
                        }
                        break;

                    // Edit style for an Ellipse
                    case 2:
                        style_attributes = DefaultStyleGenerator.FillShape();
                        if (style_attributes != null)
                        {
                            Ellipse.SetDefaultStyle(style_attributes[0], style_attributes[1], Convert.ToInt32(style_attributes[2]), style_attributes[3]);
                        }
                        break;

                    // Edit style for a Line
                    case 3:
                        style_attributes = DefaultStyleGenerator.NonFillShape();
                        if (style_attributes != null)
                        {
                            Line.SetDefaultStyle(style_attributes[0], Convert.ToInt32(style_attributes[1]), style_attributes[2]);
                        }
                        break;

                    // Edit style for a Polyline
                    case 4:
                        style_attributes = DefaultStyleGenerator.FillShape();
                        if (style_attributes != null)
                        {
                            Polyline.SetDefaultStyle(style_attributes[0], style_attributes[1], Convert.ToInt32(style_attributes[2]), style_attributes[3]);
                        }
                        break;

                    // Edit style for a Polygon
                    case 5:
                        style_attributes = DefaultStyleGenerator.FillShape();
                        if (style_attributes != null)
                        {
                            Polygon.SetDefaultStyle(style_attributes[0], style_attributes[1], Convert.ToInt32(style_attributes[2]), style_attributes[3]);
                        }
                        break;

                    // Edit style for a Path
                    case 6:
                        style_attributes = DefaultStyleGenerator.FillShape();
                        if (style_attributes != null)
                        {
                            Path.SetDefaultStyle(style_attributes[0], style_attributes[1], Convert.ToInt32(style_attributes[2]), style_attributes[3]);
                        }
                        break;

                    // Exit the menu
                    case 7:
                        return "Exit Default Style";
                }
            }

            // If any other key was pressed
            return "";
        }

        //Display the menu items
        public void Display()
        {
            Console.WriteLine(InfoScreens.welcome_banner);
            Console.WriteLine("Edit the default style for a shape by selecting it below.");

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