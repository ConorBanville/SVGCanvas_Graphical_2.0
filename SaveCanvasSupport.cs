using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SVGCanvas_Graphical_2._0
{
    class SaveCanvasSupport
    {
        public static void SaveCanvas(Canvas c)
        {
            string saveName = DateTime.Now.ToString("dddd, dd MM yyyy HH-mm-ss");
            string savedFiles = File.ReadAllText("./SavedCanvases/Saves.txt");
            savedFiles += $"\n{saveName}.json";

            string fileText = 
$@"
{{
    ""width"": {c.w},
    ""height"": {c.h},
    ""shapes"":
    [";
            var ending = 
@"
    ]
}
     ";
            foreach(Shape shape in c.shapes)
            {
                fileText += "\n"+JsonConvert.SerializeObject(shape, Formatting.Indented)+",";
            }

            fileText = fileText.Substring(0,fileText.Length - 1);
            fileText += ending;

            File.WriteAllText($"./SavedCanvases/{saveName}.json",fileText);
            File.WriteAllText("./SavedCanvases/Saves.txt",savedFiles);
        }
    
        public static string[] GetSaves()
        {
            string[] temp =  File.ReadAllLines("./SavedCanvases/Saves.txt");
            string[] saves = new string[temp.Length -1];

            for(int i=1; i<temp.Length; i++)
            {
                saves[i-1] = temp[i].Replace(".json","");
            }

            return saves;
        }
    
        public static Canvas BuildCanvas(string filename)
        {
            List<Shape> canvasShapes = new List<Shape>();
            string jsonCanvas = File.ReadAllText($"./SavedCanvases/{filename}.json");
            CanvasJson loadedCanvas = JsonConvert.DeserializeObject<CanvasJson>(jsonCanvas);

            foreach(string shape in loadedCanvas.shapes)
            {
                switch(JsonConvert.DeserializeObject<SimpleShape>(shape).Name)
                {
                    case "Rectangle":
                        SimpleRect rect = JsonConvert.DeserializeObject<SimpleRect>(shape);
                        Rectangle Rect = new Rectangle(rect.xpos,rect.ypos,rect.width,rect.height,rect.id);
                        Rect.fill = rect.fill;
                        Rect.stroke = rect.stroke;
                        Rect.strokeDashArray = rect.dash;
                        Rect.strokeWidth = rect.strokeWidth;
                        canvasShapes.Add(Rect);
                    break;

                    case "Circle":
                        SimpleCircle circle = JsonConvert.DeserializeObject<SimpleCircle>(shape);
                        Circle Circle = new Circle(circle.centerX,circle.centerY,circle.radius,circle.id);
                        Circle.fill = circle.fill;
                        Circle.stroke = circle.stroke;
                        Circle.strokeDashArray = circle.dash;
                        Circle.strokeWidth = circle.strokeWidth;
                        canvasShapes.Add(Circle);
                    break;

                    case "Ellipse":
                        SimpleEllipse ellipse = JsonConvert.DeserializeObject<SimpleEllipse>(shape);
                        Ellipse Ellipse = new Ellipse(ellipse.centerX,ellipse.centerY,ellipse.radiusX,ellipse.radiusY,ellipse.id);
                        Ellipse.fill = ellipse.fill;
                        Ellipse.stroke = ellipse.stroke;
                        Ellipse.strokeDashArray = ellipse.dash;
                        Ellipse.strokeWidth = ellipse.strokeWidth;
                        canvasShapes.Add(Ellipse);
                    break;

                    case "Line":
                        SimpleLine line = JsonConvert.DeserializeObject<SimpleLine>(shape);
                        Line Line = new Line(line.x1,line.y1,line.x2,line.y2,line.id);
                        Line.stroke = line.stroke;
                        Line.strokeDashArray = line.dash;
                        Line.strokeWidth = line.strokeWidth;
                        canvasShapes.Add(Line);
                    break;

                    case "Polyline":
                        List<Point> points = new List<Point>();
                        SimplePoly polyline = JsonConvert.DeserializeObject<SimplePoly>(shape);
                        foreach(string p in polyline.points)
                        {
                            SimplePoint po = JsonConvert.DeserializeObject<SimplePoint>(p);
                            points.Add(new Point(po.x,po.y));
                        }
                        Polyline Polyline = new Polyline(points,polyline.id);
                        Polyline.fill = polyline.fill;
                        Polyline.stroke = polyline.stroke;
                        Polyline.strokeDashArray = polyline.dash;
                        Polyline.strokeWidth = polyline.strokeWidth;
                        canvasShapes.Add(Polyline);
                    break;

                    case "Polygon":
                        points = new List<Point>();
                        SimplePoly polygon = JsonConvert.DeserializeObject<SimplePoly>(shape);
                        foreach(string p in polygon.points)
                        {
                            SimplePoint po = JsonConvert.DeserializeObject<SimplePoint>(p);
                            points.Add(new Point(po.x,po.y));
                        }
                        Polygon Polygon = new Polygon(points,polygon.id);
                        Polygon.fill = polygon.fill;
                        Polygon.stroke = polygon.stroke;
                        Polygon.strokeDashArray = polygon.dash;
                        Polygon.strokeWidth = polygon.strokeWidth;
                        canvasShapes.Add(Polygon);
                    break;

                    case "Path":
                        SimplePath path = JsonConvert.DeserializeObject<SimplePath>(shape);
                        Path Path = new Path(path.instructions,path.id);
                        Path.fill = path.fill;
                        Path.stroke = path.stroke;
                        Path.strokeDashArray = path.dash;
                        Path.strokeWidth = path.strokeWidth;
                    break;
                }
            }

            Canvas canvas = new Canvas(canvasShapes);
            canvas.SetWidth(loadedCanvas.width);
            canvas.SetHeight(loadedCanvas.height);
            return canvas;
        }

        class CanvasJson
        {
            public double width {get; set;}
            public double height {get; set;}
            public string[] shapes{get; set;}

        }
        
        struct SimpleShape
        {
            public string Name{get; set;}
        }

        struct SimpleRect
        {
            public string Name{get; set;}
            public int id {get; set;}
            public double xpos {get; set;}
            public double ypos {get; set;}
            public double width {get; set;}
            public double height {get; set;}
            public string fill {get; set;}
            public string stroke {get; set;}
            public int strokeWidth {get; set;}
            public string dash{get; set;}
            
        }

        struct SimpleCircle
        {
            public string Name{get; set;}
            public int id {get; set;}
            public double centerX {get; set;}
            public double centerY {get; set;}
            public double radius {get; set;}
            public string fill {get; set;}
            public string stroke {get; set;}
            public int strokeWidth {get; set;}
            public string dash{get; set;}
        }

        struct SimpleEllipse
        {
            public string Name{get; set;}
            public int id {get; set;}
            public double centerX {get; set;}
            public double centerY {get; set;}
            public double radiusX {get; set;}
            public double radiusY {get; set;}
            public string fill {get; set;}
            public string stroke {get; set;}
            public int strokeWidth {get; set;}
            public string dash{get; set;}
        }

        struct SimpleLine
        {
            public string Name{get; set;}
            public int id {get; set;}
            public double x1 {get; set;}
            public double y1 {get; set;}
            public double x2 {get; set;}
            public double y2 {get; set;}
            public string stroke {get; set;}
            public int strokeWidth {get; set;}
            public string dash{get; set;}
        }

        struct SimplePoly
        {
            public string Name{get; set;}
            public int id {get; set;}
            public string fill {get; set;}
            public string stroke {get; set;}
            public int strokeWidth {get; set;}
            public string dash{get; set;}
            public string[] points { get; set;}
        }

        struct SimplePath
        {
            public string Name{get; set;}
            public int id {get; set;}
            public string instructions {get; set;}
            public string fill {get; set;}
            public string stroke {get; set;}
            public int strokeWidth {get; set;}
            public string dash{get; set;}
        }

        struct SimplePoint
        {
            public double x {get; set;}
            public double y {get; set;}
        }
    }
}