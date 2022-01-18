/*      CS264 Assignment 3
        ------------------

        For the assignment I decided to implement a graphical menu system, allowing a user to
        create a canvas, add shapes to the canvas, update / remove shapes aswell as exporting
        the canvas to a svg file.

        In order to implemenent undo-redo functionallity I used the memento design pattern,
        with a slight variation. I will outline exactly how it was implemented in the relevant
        class files, with a more broad overview explanation in the CareTaker.cs file.

        As you will see below the Program class is pretty much bare containing only a Game
        object and calling GameStart() on it. Essentially, the game has an array list of IMenu
        objects, each IMenu can be opened and will return a string and then the rest of the
        game class is essentially one big switch board that decides what to do based on what
        is returned from the IMenus.

        The IMenu objects, store the options you see on screen and provide part of the functionality
        of those options. Aswell as allowing the arrow / escape / enter keys to do something.

        This project ended up becoming pretty large and is still unfinished so I have not completed
        detailed commenting. However, I have given a detailed explanation of how I used the Memento DP.

        I really enjoyed working on this project and hope you enjoy it too, if you decide the menu
        system is too slow or just want to switch out of it there is an option called
        "Switch to CLI Mode", hit enter on this option and the application will switch back
        to the more traditional command line argument format. You can also switch again by
        entering "closecli" in CLI Mode.

        I find the application looks better in the standard windows cmd shell, rather than the
        VS Code one. But I have themes applied to my VS Code and this might be the reason.

        Name: Conor Banville
        Student Number: 18383803
        OS : Windows 10/11
        IDE: Visual Studio Code (I ported the project over to VS 2019 just to use the Class Diagram extension at the end, aswell as CodeMaid)

*/
namespace SVGCanvas_Graphical_2._0
{
    internal class Program
    {
        public static Game game = new Game();

        public static void Main()
        {
            game.GameStart();
        }
    }
}