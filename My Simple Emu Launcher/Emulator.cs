using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Simple_Emu_Launcher
{
    internal class Emulator
    {
        //This class should represent an emulator
        public string Path 
        { 
            get; 
            set; 
        }
        public string Name
        {
            get;
            set;
        }

        public string Icon
        {
            get;
            set;
        }

        public void DoNothing()
        {
            Console.WriteLine("This is a simple class that does nothing");
        }
    }
}
