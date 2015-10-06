using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPC.helper;
using TestPC.model;

namespace TestPC.view
{
    class EditBoatView
    {
        Helper helper = new Helper();
        private MemberDAL memberDAL;
        public EditBoatView() {
            this.memberDAL = new MemberDAL();
        }

        public void showMemberBoatsMenu(string memberId){

            List<KeyValuePair<string, string>> boats = new List<KeyValuePair<string, string>>();
            boats = memberDAL.getBoatsByMemberId(memberId);

            Console.Clear();
            this.helper.printDivider();
            Console.WriteLine("MEDLEM " + memberId + ":S BÅTAR");
            this.helper.printDivider();

            Console.WriteLine("\nAnge båtens id för att redigera eller radera.");

            foreach (var boat in boats)
            {
                Console.WriteLine("{0}: {1}", boat.Key, boat.Value);
            }
        }

        public string getSelectedBoat()
        {
            string boatId = Console.ReadLine();
            return boatId;
        }

        public void showEditBoatMenu(string boatId, string memberId) {
            List<KeyValuePair<string, string>> boat = memberDAL.getBoatById(boatId);
            Console.Clear();
            this.helper.printDivider();
            Console.WriteLine("MEDLEM " + memberId + ":S BÅT " + boatId);
            this.helper.printDivider();

            Console.WriteLine("\nAnge T för att ta bort båt.");
            Console.WriteLine("Ange R för att redigera båt.\n");

            foreach (var element in boat)
            {
                Console.WriteLine("{0}: {1}", element.Key, element.Value);
            }
        }

        public string getEditBoatMenuChoice()
        {
            string boatId = Console.ReadLine();
            return boatId;
        }
    }
}
