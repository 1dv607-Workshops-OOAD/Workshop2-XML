using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPC.helper;
using TestPC.model;

namespace TestPC.view
{
    class EditMemberView
    {
        Helper helper = new Helper();
        private MemberDAL memberDAL;
        public EditMemberView() {
            this.memberDAL = new MemberDAL();
        }

        public Helper.MenuChoice getMenuChoice()
        {
            string menuChoice = Console.ReadLine().ToUpper();
            if (menuChoice == "T")
            {
                return Helper.MenuChoice.DeleteMember;
            }
            if (menuChoice == "R")
            {
                return Helper.MenuChoice.EditMember;
            }
            if (menuChoice == "B")
            {
                return Helper.MenuChoice.Boats;
            }
            if (menuChoice == "S")
            {
                return Helper.MenuChoice.Back;
            }

            return Helper.MenuChoice.None;
        }

        public void showEditMemberMenu() {
            Console.Clear();
            this.helper.printDivider();
            Console.WriteLine("VALD MEDLEM");
            this.helper.printDivider();

            Console.WriteLine("Ange T för att ta bort medlem.");
            Console.WriteLine("Ange R för att redigera medlem.");
            Console.WriteLine("Ange B för att redigera medlemmens båtar.");
            Console.WriteLine("Ange S för att gå tillbaka till startmenyn.\n");
        }

        public void showSelectedMember(string memberId) {
            List<KeyValuePair<string, string>> member = memberDAL.getMemberById(memberId);

            foreach (var element in member)
            {
                if (element.Key == memberDAL.getNumberOfBoatsKey())
                {
                    continue;
                }
                Console.WriteLine("{0}: {1}", element.Key, element.Value);
            }
        }

    }
}
