namespace SVGCanvas_Graphical_2._0
{
    internal class InfoScreens
    {
        public static string welcome_banner =

      @"
    █████████╗   ██╗██████╗      ██████╗█████╗███╗   ████╗   ██╗█████╗███████╗
    ██╔════██║   ████╔════╝     ██╔════██╔══██████╗  ████║   ████╔══████╔════╝
    █████████║   ████║  ███╗    ██║    █████████╔██╗ ████║   ████████████████╗
    ╚════██╚██╗ ██╔██║   ██║    ██║    ██╔══████║╚██╗██╚██╗ ██╔██╔══██╚════██║
    ███████║╚████╔╝╚██████╔╝    ╚████████║  ████║ ╚████║╚████╔╝██║  █████████║
    ╚══════╝ ╚═══╝  ╚═════╝      ╚═════╚═╝  ╚═╚═╝  ╚═══╝ ╚═══╝ ╚═╝  ╚═╚══════╝";

        public static string help =
            @"
------------------------------------------------

h[elp]         |       Display a help screen
l[ist]         |       Display a list of supported SVG shapes
[k/kill]       |       Close the program
e              |       Export the current canvas using a default name
c              |       Display a stack view of all shapes on the canvas
closecli       |       Exit CLI Mode

remove (shape_ID)              *Remove a shape from the canvas
                                shape_ID -> The unique id of the shape. This ID can
                                            be found when displaying the canvas.

style (shape_ID)               *Update the style attributes of a shape
                                shape_ID -> The unique id of the shape. This ID can
                                            be found when displaying the canvas.

default-style (shape name)     *Set the default styling for a shape
                                shape name -> The name of the shape who's default style
                                              is to be changed.

                                        eg.   default-style (rect) to update the Rectangle
                                              style.

shift (shape_ID, Index)        *Change the Z-Index of a shape
                                shape_ID -> The unique id of the shape. This ID can
                                            be found when displaying the canvas.

                                Indec    -> The index that the shape is to be moved
                                            to.

rect (x,y,w,h)                 *Add a rectangle.
                                x -> X position of the             y -> Y position of the
                                     top left corner of the             top left corner of the
                                     rectangle.                         rectangle.

                                w -> width of the rectangle.       h -> height of the rectangle.

circle (x,y,r)                 *Add a circle.
                                x -> X position of the             y -> Y position of the
                                     center of the circle.              center of the circle.

                                r -> radius of the circle

line (x1,y1,x2,y2)             *Add a line.
                                x1 -> X position of the             y1 -> Y position of the
                                      line start.                         line start.

                                x2 -> X position of the             y2 -> Y position of the
                                      line end.                           line end.

ellipse (x,y,rx,ry)            *Add an ellipse.
                                x -> X position of the             y -> Y position of the
                                     center of the ellipse.             center of the ellispe.

                                rx -> radius of the ellipse        ry -> radius of the ellipse
                                      in the X sense.                    in the Y sense.

polyline (x1,y1,x2,y2,...xn,yn)    * Add a polyline
                                    polyline takes list of points where,

                                (x1,y1) -> is the starting position    (xn,yn) -> is the finishing position
                                           of the polyline.                       of the polyline.

                                And every (x,y) pair inbetween is a point along the path the polyline takes
                                to reach the final position.

                                *Note*  polyline does not directly connect the starting position and the
                                finishing position via a single line.

polygon  (x1,y1,x2,y2,...xn,yn)    * Add a polygon
                                    polygon takes list of points where,

                                (x1,y1) -> is the starting position    (xn,yn) -> is the finishing position
                                           of the polygon.                       of the polygon.

                                And every (x,y) pair inbetween is a point along the path the polygon takes
                                to reach the final position.

                                *Note*  polygon will directly connect the starting position and the
                                finishing position via a single line.

path (list of instructions)    * Add a path
                                M = moveto                          L = lineto          H = horizontal lineto
                                V = vertical lineto                 C = curveto         S = smooth curveto
                                A = elliptical Arc                  Z = closepath
                                T = smooth quadratic                Q = quadratic
                                    Bézier curveto                      Bézier curve

                                Example:

                                path (M150 0 L75 200 L225 200 Z)

                                *More   https://www.w3schools.com/graphics/svg_path.asp

------------------------------------------------
";

        public static string list =
        @"
------------------------------------------------

Supported shapes:

Rectangle   (x,y,width,height)
Circle      (x,y,radius)
Line        (x1,y1,x2,y2)
Ellipse     (x,y,radius_x,radius_y)
Polyline    (x1,y1,x2,y2, ... xn,yn)
Polygone    (x1,y1,x2,y2, ... xn,yn)
Path        (list of instructions)          for more details see https://www.w3schools.com/graphics/svg_path.asp

------------------------------------------------
";
    }
}