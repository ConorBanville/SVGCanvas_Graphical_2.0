using System;
using System.Collections.Generic;

namespace SVGCanvas_Graphical_2._0
{
    internal class CLICanvasToolkit
    {
        public static List<Shape> Remove(Canvas c, int id)
        {
            List<Shape> shapes = c.GetList();
            for (int i = 0; i < c.shapes.Count; i++)
            {
                if (shapes[i].GetId() == id)
                {
                    shapes.RemoveAt(i);
                    return shapes;
                }
            }

            return null;
        }

        public static void Display(Canvas c)
        {
            if (c.shapes.Count == 0)
            {
                Console.WriteLine("Canvas is empty!");
            }
            else
            {
                foreach (Shape shape in c.shapes)
                {
                    Console.WriteLine(shape.GetInfo());
                }
            }
        }

        public static List<Shape> Style(Canvas c, int id)
        {
            List<Shape> shapes = c.GetList();

            foreach (Shape shape in shapes)
            {
                if (shape.GetId() == id)
                {
                    shape.Decorations();
                    return shapes;
                }
            }

            return null;
        }

        public static List<Shape> Shift(Canvas c, int ID, int newIndex)
        {
            List<Shape> shapes = c.GetList();
            Shape temp;

            if (newIndex > shapes.Count - 1)
            {
                return new List<Shape>();
            }

            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i].GetId() == ID)
                {
                    temp = shapes[i];
                    shapes.RemoveAt(i);
                    shapes.Insert(newIndex, temp);
                    return shapes;
                }
            }

            return null;
        }
    }
}