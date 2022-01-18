using System.Collections.Generic;

namespace SVGCanvas_Graphical_2._0
{
    public class Canvas
    {
        public List<Shape> shapes;
        public double w, h;

        public Canvas()
        {
            shapes = new List<Shape>();
            w = 1000.00d;
            h = 1000.00d;
        }

        public Canvas(double w, double h)
        {
            shapes = new List<Shape>();
            this.w = w;
            this.h = h;
        }

        public Canvas(List<Shape> shapes)
        {
            this.shapes = shapes;
            w = 1000.00d;
            h = 1000.00d;
        }

        public void SetWidth(double w)
        {
            this.w = w;
        }

        public void SetHeight(double h)
        {
            this.h = h;
        }

        public List<Shape> GetList()
        {
            List<Shape> s = new List<Shape>();

            foreach (var obj in shapes)
            {
                s.Add(obj);
            }

            return s;
        }

        public void SetList(List<Shape> shapes)
        {
            this.shapes = shapes;
        }
    }
}