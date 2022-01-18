using System;
using System.Collections.Generic;
using System.IO;

namespace SVGCanvas_Graphical_2._0
{
    internal class Game
    {
        public Caretaker caretaker;    // CareTaker class to implement Memento DP [undo-redo functionality]
        private static Memento m;   // Store a memento
        private static Canvas c;    // Store a canvas
        private IMenu[] menus;  // Store array of menus

        public int i, shape_id;
        private double canvas_width, canvas_height;

        public Game()
        {
            // The options you see on screen
            menus = new IMenu[]{
                new Homescreen(new string[] {"NEW CANVAS","LOAD CANVAS","HELP","EXIT"}),
                new EditCanvas(new string[]{"Add Shape","Remove Shape","Shift Shape","Edit Style","Edit Shape","Edit Default Style","Edit Canvas","Display Canvas","Export","Save Canvas","Undo","Redo","Switch to CLI Mode","Exit"}),   // Menu to edit the active canvas
                new AddShape(new string[]{"Rectangle","Circle","Ellispe","Line","Polyline","Polygon","Path","Exit"}),
                new DefaultStyle(new string[]{"Style a Rectangle","Style a Circle","Style a Ellispe","Style a Line","Style a Polyline","Style a Polygon","Style a Path","Exit"})
            };
            i = 0;
            shape_id = 0;
        }

        // Open the first menu and start taking input
        public void GameStart()
        {
            // Set some game variables
            bool GameOpen = true;
            Console.CursorVisible = false;

            // While the game is running
            while (GameOpen)
            {
                // Open the active menu, then based on the string returned preform some action
                switch (menus[i].Open())
                {
                    // Close Program
                    case "CLOSE PROGRAM":
                        Console.Clear();
                        return;

                    // Go back a screen
                    case "BACK":
                        i--;
                        break;

                    // Create a new canvas
                    case "NEW CANVAS":
                        Console.Clear();
                        Console.WriteLine(InfoScreens.welcome_banner);  // Redraw the screen
                        double w, h;

                        // Get a canvas width from the user
                        Console.WriteLine("Canvas width: ");
                        while (true) // Continue to accept input untill a string that can be converted to a double is passed
                        {
                            if (Double.TryParse(Console.ReadLine(), out w))// store the value in w
                            {
                                canvas_width = w;
                                break; // Exit the loop
                            }
                        }

                        // Get a canvas height from the user
                        Console.WriteLine("Canvas height: ");
                        while (true) // Continue to accept input untill a string that can be converted to a double is passed
                        {
                            if (Double.TryParse(Console.ReadLine(), out h))// store the value in h
                            {
                                canvas_height = h;
                                break; // Break the loop
                            }
                        }

                        caretaker = new Caretaker(new Canvas(w, h)); // Set up caretaker class with a fresh canvas
                        caretaker.BackUp(); // Fresh canvas is the first state, BackUp() will store this in the history
                        i++;    // Move onto the next menu
                        break;

                    // Show the saved canvas
                    case "SAVED CANVASES":
                        LoadCanvas LC = new LoadCanvas(SaveCanvasSupport.GetSaves());
                        bool MenuOn = true;
                        while(MenuOn)
                        {
                            string saveName = LC.Open();
                            switch(saveName)
                            {
                                case "":
                                    break;
                                // Exit the load canvas screen
                                case "Exit Load Canvas":
                                    MenuOn = false;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine(InfoScreens.welcome_banner);
                                    Console.WriteLine("Sorry but this feature is not yet fully implemented!");
                                    Console.ReadKey();
                                    // caretaker = new Caretaker(SaveCanvasSupport.BuildCanvas(saveName));
                                    // caretaker.BackUp();
                                    MenuOn = false;
                                    //i++;
                                    break;
                            }
                        };
                        break;
                    

                    // Go to the add shape screen
                    case "Add Shape":
                        i++;
                        break;

                    // Genorate a new rectangle and add it to the current canvas
                    // Then add that canvas as a new memento in the history
                    case "rect":
                        Rectangle r = ShapeGenerator.Rectangle(shape_id);   // Get a new Rectangle from the user
                        if (r == null) break;   // If the rectangle is null then we won't go further
                        shape_id++; // Increment the shape_id counter
                        m = caretaker.GetState();   // Get the current state
                        c = new Canvas(m.canvas.GetList()); // Create a fresh canvas with the same shapes as the last state
                        c.shapes.Add(r); // Add that new shape to the canvas
                        caretaker.o.NewState(c); // Set the new state in the Originator
                        caretaker.BackUp(); // Add the new state to the history
                        break;

                    // Genorate a new circle and add it to the current canvas
                    // Then add that canvas as a new memento in the history
                    case "circle":
                        Circle cir = ShapeGenerator.Circle(shape_id);   // Get a new Circle from the user
                        if (cir == null) break;   // If the circle is null then we won't go further
                        shape_id++; // Increment the shape_id counter
                        m = caretaker.GetState();   // Get the current state
                        c = new Canvas(m.canvas.GetList()); // Create a fresh canvas with the same shapes as the last state
                        c.shapes.Add(cir); // Add that new shape to the canvas
                        caretaker.o.NewState(c); // Set the new state in the Originator
                        caretaker.BackUp(); // Add the new state to the history
                        break;

                    // Genorate a new ellipse and add it to the current canvas
                    // Then add that canvas as a new memento in the history
                    case "ellipse":
                        Ellipse e = ShapeGenerator.Ellipse(shape_id);   // Get a new Ellipse from the user
                        if (e == null) break;   // If the ellipse is null then we won't go further
                        shape_id++; // Increment the shape_id counter
                        m = caretaker.GetState();   // Get the current state
                        c = new Canvas(m.canvas.GetList()); // Create a fresh canvas with the same shapes as the last state
                        c.shapes.Add(e); // Add that new shape to the canvas
                        caretaker.o.NewState(c); // Set the new state in the Originator
                        caretaker.BackUp(); // Add the new state to the history
                        break;

                    // Genorate a new line and add it to the current canvas
                    // Then add that canvas as a new memento in the history
                    case "line":
                        Line l = ShapeGenerator.Line(shape_id);   // Get a new Line from the user
                        if (l == null) break;   // If the line is null then we won't go further
                        shape_id++; // Increment the shape_id counter
                        m = caretaker.GetState();   // Get the current state
                        c = new Canvas(m.canvas.GetList()); // Create a fresh canvas with the same shapes as the last state
                        c.shapes.Add(l); // Add that new shape to the canvas
                        caretaker.o.NewState(c); // Set the new state in the Originator
                        caretaker.BackUp(); // Add the new state to the history
                        break;

                    // Genorate a new polyline and add it to the current canvas
                    // Then add that canvas as a new memento in the history
                    case "polyline":
                        Polyline pl = ShapeGenerator.Polyline(shape_id);   // Get a new Polyline from the user
                        if (pl == null) break;   // If the polyline is null then we won't go further
                        shape_id++; // Increment the shape_id counter
                        m = caretaker.GetState();   // Get the current state
                        c = new Canvas(m.canvas.GetList()); // Create a fresh canvas with the same shapes as the last state
                        c.shapes.Add(pl); // Add that new shape to the canvas
                        caretaker.o.NewState(c); // Set the new state in the Originator
                        caretaker.BackUp(); // Add the new state to the history
                        break;

                    // Genorate a new polygon and add it to the current canvas
                    // Then add that canvas as a new memento in the history
                    case "polygon":
                        Polygon pg = ShapeGenerator.Polygon(shape_id);   // Get a new Polygon from the user
                        if (pg == null) break;   // If the polygon is null then we won't go further
                        shape_id++; // Increment the shape_id counter
                        m = caretaker.GetState();   // Get the current state
                        c = new Canvas(m.canvas.GetList()); // Create a fresh canvas with the same shapes as the last state
                        c.shapes.Add(pg); // Add that new shape to the canvas
                        caretaker.o.NewState(c); // Set the new state in the Originator
                        caretaker.BackUp(); // Add the new state to the history
                        break;

                    // Genorate a new path and add it to the current canvas
                    // Then add that canvas as a new memento in the history
                    case "path":
                        Path pt = ShapeGenerator.Path(shape_id);    // Get a new Path from the user
                        if (pt == null) break;   // If the path is null then we won't go further
                        shape_id++;    // Increment the shape_id counter
                        m = caretaker.GetState(); // Get the current state
                        c = new Canvas(m.canvas.GetList());  // Create a fresh canvas with the same shapes as the last state
                        c.shapes.Add(pt); // Add the new shape to the canvas
                        caretaker.o.NewState(c); // Set the new state in the Originator
                        caretaker.BackUp(); // Add the new state to the history
                        break;

                    // Remove a shape
                    case "Remove Shape":
                        // Get a list of shapes currently on the canvas
                        List<Shape> shapes = caretaker.o.GetMemento().canvas.GetList();
                        // Return if the are no shapes on the canvas
                        if (shapes.Count == 0) break;
                        // Store items to be displayed in menu
                        string[] items = new string[shapes.Count];
                        // Iterate over the list and concat into string[]
                        for (int i = 0; i < items.Length; i++)
                        {
                            items[i] = shapes[i].GetInfo();
                        }
                        // Create a new menu object with the shapes from the canvas
                        RemoveShape RemoveShape_screen = new RemoveShape(caretaker.o.GetMemento().canvas.shapes);
                        // Keep the menu open
                        bool menuOpen = true;
                        while (menuOpen)
                        {
                            string returnVal = RemoveShape_screen.Open();   // Open the menu and store the value returned
                            switch (returnVal)
                            {
                                case "close":
                                    menuOpen = false;
                                    break;

                                case "":
                                    break;

                                // Remove the shape corresponding to the id returned from the menu
                                default:
                                    m = caretaker.GetState();
                                    c = new Canvas(m.canvas.GetList());
                                    List<Shape> tempList = CanvasToolkit.Remove(c, Convert.ToInt32(returnVal));
                                    c = new Canvas(tempList);
                                    caretaker.o.NewState(c);
                                    caretaker.BackUp();
                                    menuOpen = false;
                                    i = 1;
                                    break;
                            }
                        }
                        break;

                    // Zedit a shape
                    case "Shift Shape":
                        m = caretaker.GetState();
                        c = new Canvas(m.canvas.GetList());
                        List<Shape> t = CanvasToolkit.Shift(c);
                        if (t != null)
                        {
                            c = new Canvas(t);
                            caretaker.o.NewState(c);
                            caretaker.BackUp();
                        }
                        break;

                    // Edit the style of a shape
                    case "Edit Style":
                        string text =
@"Enter a shape's ID to edit it's style.
To view the canvas enter -d.
To cancel enter ..";
                        m = caretaker.GetState();
                        c = new Canvas(m.canvas.GetList());
                        List<Shape> temp = CanvasToolkit.EditStyle(c, GetShapeID(text));
                        if (temp != null)
                        {
                            c = new Canvas(temp);
                            caretaker.o.NewState(c);
                            caretaker.BackUp();
                        }
                        break;

                    // Edit the dimensions of a shape
                    case "Edit Shape":
                        text =
@"Enter a shape's ID to edit it's dimensions.
To view the canvas enter -d.
To cancel enter ..";
                        m = caretaker.GetState();
                        c = new Canvas(m.canvas.GetList());
                        temp = CanvasToolkit.EditDimensions(c, GetShapeID(text));
                        if (temp != null)
                        {
                            c = new Canvas(temp);
                            caretaker.o.NewState(c);
                            caretaker.BackUp();
                        }
                        break;

                    // Edit the default style for a shape
                    case "Default Style":
                        i = 3;
                        break;

                    // Exit the default style menu
                    case "Exit Default Style":
                        i = 1;
                        break;

                    case "Edit Canvas":
                        double[] width_height = CanvasToolkit.EditCanvas();
                        canvas_width = width_height[0];
                        canvas_height = width_height[1];
                        break;

                    // Display the canvas
                    case "Display Canvas":
                        m = caretaker.GetState();   // Get the current state
                        Console.Clear();    // Clear the canvas
                        CanvasToolkit.Display(m.canvas);    // Display the canvas
                        Console.WriteLine("Press any key to continue ...");
                        Console.ReadKey(); // Wait for a key press
                        break;

                    // Export the canvas
                    case "Export":
                        string save_name = DateTime.Now.ToString("dddd, dd MM yyyy HH-mm-ss");  // Use a DateTime object to ensure a unique filename
                        m = caretaker.GetState();   // Get the current state
                        m.canvas.SetWidth(canvas_width); // Set the width and height before export
                        m.canvas.SetHeight(canvas_height);
                        string svg = CanvasToolkit.EmbedCanvas(m.canvas);   // Convert the canvas into svg
                        File.WriteAllText($"./exported svg/{save_name}.svg", svg);   // Save the svg in a new file
                        break;

                    // Save the Current Canvas
                    case "Save Canvas":
                        SaveCanvasSupport.SaveCanvas(caretaker.o.GetMemento().canvas);
                        break;

                    // Undo the last move
                    case "Undo":
                        caretaker.undo();
                        break;

                    // Redo the last move
                    case "Redo":
                        caretaker.redo();
                        break;

                    // Switch to CLI Mode
                    case "CLI Mode":
                        if (CLIMode() == "close")
                        {
                            Console.WriteLine("Program closing...");
                            GameOpen = false;
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        // Switch application into more traditional command line interface, i.e. removes the graphical menu system
        public string CLIMode()
        {
            // Redraw the console
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Welcome to SVGCanvas, for more information on commands enter H/h[elp]");
            bool CLIModeOn = true;  // Will be true as long as user is in CLIMode

            while (CLIModeOn)
            {
                // Read in new input
                // Pass the input to the parser, a string will be returned
                string output = CLIParser.Parse(Console.ReadLine());
                // If "close" is returned close the program
                if (output == "close")
                {
                    return "close";
                }
                // If "closecli" is returned switch back to the menu system
                else if (output == "closecli")
                {
                    CLIModeOn = false;
                }
            }
            // Clear the canvas and turn off the cursor
            Console.Clear();
            Console.CursorVisible = false;
            return "";
        }

        // Propmt the user for a shape ID
        public int GetShapeID(string text)
        {
            int id = -1;
            string input;
            bool ScreenOn = true;

            while (ScreenOn)
            {
                Console.Clear();
                Console.WriteLine(text);
                input = Console.ReadLine();

                if (input.Contains("-d"))
                {
                    foreach (Shape obj in caretaker.GetState().canvas.shapes)
                    {
                        obj.GetInfo();
                    }
                }
                else if (input.Contains("-h"))
                {
                    Console.Clear();
                    Console.WriteLine(InfoScreens.help);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (input.Contains(".."))
                {
                    ScreenOn = false;
                }
                else
                {
                    try
                    {
                        id = Convert.ToInt32(input);
                        ScreenOn = false;
                        return id;
                    }
                    catch
                    {
                        Console.WriteLine($"Could not convert {input} to a number!");
                        Console.ReadKey();
                    }
                }
            }
            return id;
        }
    }
}