using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPC.helper
{
    public class Helper
    {
        public enum MenuChoice
        {
            DeleteMember,
            EditMember,
            Boats,
            Back,
            None
        }
        
        public Helper()
        {

        }
        public void printDivider()
        {
            Console.WriteLine("*************************************************");
        }
    }
}
