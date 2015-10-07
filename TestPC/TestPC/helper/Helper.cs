using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPC.controller;

namespace TestPC.helper
{
    public class Helper
    {
        public enum MenuChoice
        {
            Delete,
            Edit,
            Boats,
            Back,
            None
        }

        public void printDivider()
        {
            Console.WriteLine("*************************************************");
        }

        public void getBoatTypeMenu()
        {
            Console.WriteLine("Ange båttyp:");
            Console.WriteLine("1 för segelbåt,");
            Console.WriteLine("2 för kayak eller kanot,");
            Console.WriteLine("3 för motorseglare,");
            Console.WriteLine("4 för annan typ.\n");
        }

        public void getBackToStartMessage()
        {
            Console.WriteLine("Ange S för att komma tillbaka till startmenyn.\n");
        }
    }
}
