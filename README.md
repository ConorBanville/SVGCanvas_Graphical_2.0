# SvgCanvas Graphical 

This is a console application written in the C# programming language intended to help a user create and maintiang an array of basic SVG (Scalable Vector Graphics) on a single canvas. The application offers an intuitive menu system to aid users unfamiliar with command line interfaces, aswell as a CLI mode to facilitate users who are more familiar with command line interfaces. Using the application, a user can create a fresh canvas, add and maintain customised svg elements and then export the data structure to a svg file viewable in the browser.

>Future updates
- Allow importing of existing svg files
- Support PDF conversion
- Support PNG Conversion 

>List of included SVG elements 
- Rectangle
- Circle 
- Ellipse 
- Line 
- Polyline
- Polygon 
- Path 

>List of commands

```
{
h[elp]         |       Display a help screen
l[ist]         |       Display a list of supported SVG shapes
[k/kill]       |       Close the program
u[ndo]         |       Undo the last command
r[edo]         |       Redo the last command
e              |       Export the current canvas using a default name
c              |       Display a stack view of all shapes on the canvas

c[anvas] (width, height)        *Update the width and height of the canvas
                                width  -> The new width of the canvas.

                                height -> The new height of the canvas.

export (FileName)               *Export the canvas to a svg file
                                FileName -> The name being given to the file.

remove (shape_ID)              *Remove a shape from the canvas
                                shape_ID -> The unique id of the shape. This ID can
                                            be found when displaying the canvas.

edit (shape_ID, new_values)    *Edit a shapes values
                               shape_ID        -> The unique id of the shape. This ID can
                                                  be found when displaying the canvas.

                               new_values      -> The new values for the shape, in the same
                                                  format as when creating a new shape.

                               eg. Say the shape with ID = 1 is a Rectangle then the command
                                   to edit the that rectangle would be,
                                   edit (1,100,200,300,400)
                                   This would set the,
                                   X = 100,
                                   Y = 200,
                                   Width = 300,
                                   Height = 400,

style (shape_ID, fill colour ?, stroke colour, dash array, stroke width)
                                *Update the style attributes of a shape
                                shape_ID        -> The unique id of the shape. This ID can
                                                   be found when displaying the canvas.

                                fill colour     -> The colour of the body of the shape.
                                                   When dealing with a line a fill
                                                   colour may be ommitted.

                                stroke colour   -> The line colour.

                                dash array      -> The stroke dash array setting.

                                stroke width    -> The width of the line.

default-style (name, fill colour ?, stroke colour, dash array, stroke width)

                                *Set the default styling for a shape
                                name            -> The name of the shape.

                                fill colour     -> The colour of the body of the shape.
                                                   When dealing with a line a fill
                                                   colour may be ommitted.

                                stroke colour   -> The line colour.

                                dash array      -> The stroke dash array setting.

                                stroke width    -> The width of the line.

                                eg.   default-style (rect,blue,black,11,2) to update the Rectangle's
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
                                    B??zier curveto                      B??zier curve

                                Example:

                                path (M150 0 L75 200 L225 200 Z)


                                *More   https://www.w3schools.com/graphics/svg_path.asp
}
```