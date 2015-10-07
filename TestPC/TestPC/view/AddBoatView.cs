using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.helper;
using BoatClub.model;

namespace BoatClub.view
{
    class AddBoatView
    {
        private List<KeyValuePair<string, string>> listMembers;
        private Helper helper;
        private MemberDAL memberDAL;

        public AddBoatView()
        {
            this.listMembers = new List<KeyValuePair<string, string>>();
            this.memberDAL = new MemberDAL();
            this.helper = new Helper();
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
            listMembers = memberDAL.listMembers();

            foreach (var member in listMembers)
            {
                Console.WriteLine("{0}: {1}", member.Key, member.Value);
            }
        }

        public string getSelectedMember()
        {
            return Console.ReadLine();
        }

        public Boat addBoat(string selectedMember)
        {
            Console.Clear();
            helper.printDivider();
            Console.WriteLine("LÄGG TILL EN BÅT");
            helper.printDivider();
            helper.getBoatTypeMenu();
            string boatType = setBoatType(Console.ReadLine());
            Console.Write("Ange båtens längd: \n");
            string boatLength = Console.ReadLine();

            Boat newBoat = new Boat(0, boatType, boatLength, selectedMember);
            return newBoat;
        }

        public string setBoatType(string input)
        {
            string boatType = "";

            if (input == "1")
            {
                boatType = "Segelbåt";
            }
            if (input == "2")
            {
                boatType = "Kajak";
            }
            if (input == "3")
            {
                boatType = "Motorseglare";
            }
            if (input == "4")
            {
                boatType = "Annan";
            }

            return boatType;
        }
    }
}
