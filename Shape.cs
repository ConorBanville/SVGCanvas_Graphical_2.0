using System;

namespace SVGCanvas_Graphical_2._0
{
    public abstract class Shape
    {
        public abstract string GetInfo(); //Get some info about the shape

        public abstract void Dimensions();  //Starts a command promt to change the dimensions of this shape

        public abstract void Decorations(); //Starts a command prompt to change the decorations of this shape

        public abstract String Embed();     //Embed the details of the shape into svg

        public abstract int GetId();    //Return the id of the shape
    }
}