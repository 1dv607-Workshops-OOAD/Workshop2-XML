using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPC.helper;
using TestPC.model;

namespace TestPC.view
{
    class AddBoatView
    {
        private List<KeyValuePair<string, string>> listMembers = new List<KeyValuePair<string, string>>();

        Helper helper = new Helper();
        private MemberDAL _memberDAL;

        public AddBoatView() {
            this._memberDAL = new MemberDAL();
        }

        public void showAddBoatMenu()
        {
            Console.Clear();
            this.helper.printDivider();
            Console.WriteLine("LÄGG TILL EN BÅT");
            this.helper.printDivider();
            Console.WriteLine("\nVälj medlemsnummer.\n");
        }

        public void showMemberList() 
        {
            listMembers = _memberDAL.listMembers();

            foreach (var member in listMembers)
            {
                Console.WriteLine("{0}: {1}", member.Key, member.Value);
            }
        }

        public string getSelectedMember() {
            return Console.ReadLine();
        }

        public Boat addBoat(string selectedMember)
        {
            Console.Clear();
            this.helper.printDivider();
            Console.WriteLine("LÄGG TILL EN BÅT");
            this.helper.printDivider();
            Console.WriteLine("\nAnge båttyp:");
            Console.WriteLine("1 för segelbåt,");
            Console.WriteLine("2 för kayak eller kanot,");
            Console.WriteLine("3 för motorseglare,");
            Console.WriteLine("4 för annan typ.");
            string boatType = setBoatType(Console.ReadLine());
            Console.Write("Ange båtens längd: ");
            string boatLength = Console.ReadLine();

            Boat newBoat = new Boat(0, boatType, boatLength, selectedMember);

            return newBoat;

        }

        public string setBoatType(string input) {
           
            string boatType = "";
            
            if(input == "1")
            {
                boatType = "Segelbåt";
            }
            if(input == "2")
            {
                boatType = "Kajak";
            }
            if(input == "3")
            {
                boatType = "Motorseglare";
            }
            if(input == "4")
            {
                boatType = "Annan";
            }

            return boatType;
        }
    }
}
