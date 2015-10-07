using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.helper;
using BoatClub.model;

namespace BoatClub.view
{
    class EditBoatView
    {
        private Helper helper;
        private MemberDAL memberDAL;
        private string boatId;
        private string boatType;
        private string boatLength;
        private string memberId;

        public EditBoatView() {
            this.helper = new Helper();
            this.memberDAL = new MemberDAL();
        }

        public void showMemberBoatsMenu(string memberId){

            this.memberId = memberId;

            List<KeyValuePair<string, string>> boats = new List<KeyValuePair<string, string>>();
            boats = memberDAL.getBoatsByMemberId(memberId);

            Console.Clear();
            this.helper.printDivider();
            Console.WriteLine("MEDLEM " + memberId + ":S BÅTAR");
            this.helper.printDivider();

            Console.WriteLine("\nAnge båtens id för att redigera eller radera.\n");

            foreach (var boat in boats)
            {
                Console.WriteLine("{0}: {1}", boat.Key, boat.Value);
            }
        }

        public string getSelectedBoat()
        {
            boatId = Console.ReadLine();
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
                if(element.Key == memberDAL.getBoatTypeKey()){
                    boatType = element.Value;
                }

                if (element.Key == memberDAL.getBoatLengthKey())
                {
                    boatLength = element.Value;
                }
                Console.WriteLine("{0}: {1}", element.Key, element.Value);
            }
        }

        public Helper.MenuChoice getEditBoatMenuChoice()
        {
            string menuChoice = Console.ReadLine().ToUpper();
            if (menuChoice == "T")
            {
                return Helper.MenuChoice.Delete;
            }
            if (menuChoice == "R")
            {
                return Helper.MenuChoice.Edit;
            }
            return Helper.MenuChoice.None;
        }

        public Boat editBoat(string selectedBoatId) {
            Console.Clear();
            helper.printDivider();
            Console.WriteLine("REDIGERA BÅT MED ID " + selectedBoatId + "\n");
            helper.printDivider();
            helper.getBoatTypeMenu();
            string newBoatType = setBoatType(Console.ReadLine());
            Console.Write("Båtlängd: \n");
            string newBoatLength = Console.ReadLine();

            if (newBoatLength == "")
            {
                newBoatLength = boatLength;
            }

            Boat editedBoat = new Boat(int.Parse(boatId), newBoatType, newBoatLength, memberId);

            return editedBoat;
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
