using System;
using System.Collections.Specialized;
using System.ComponentModel.Design;

namespace Projeto1_LP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu Menu = new Menu(args);
            Menu.ShowCollection();
        }
    }
}
