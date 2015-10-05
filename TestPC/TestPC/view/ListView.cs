using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPC.helper;
using TestPC.model;

namespace TestPC.view
{
    class ListView
    {
        private MemberDAL _memberDAL;
        private List<KeyValuePair<string, string>> listMembers = new List<KeyValuePair<string, string>>();
        Helper helper = new Helper();

        public enum MenuChoice
        {
            DeleteMember,
            EditMember,
            Boats,
            Back,
            None
        }
       
        public ListView()
        {
            this._memberDAL = new MemberDAL();
        }

        public MenuChoice GetMenuChoice()
        {
            char menuChoice = System.Console.ReadKey().KeyChar;
            if (menuChoice == '1')
            {
                return MenuChoice.DeleteMember;
            }
            if (menuChoice == '2')
            {
                return MenuChoice.EditMember;
            }
            if (menuChoice == '3')
            {
                return MenuChoice.Boats;
            }
            if (menuChoice == '4')
            {
                return MenuChoice.Back;
            }

            return MenuChoice.None;
        }

        public void showCompactList()
        {
            //Denna ska skrivas om till en compact list!
            listMembers = _memberDAL.listMembers();
            Console.Clear();
            this.helper.printDivider();
            Console.WriteLine("FÖRENKLAD MEDLEMSLISTA");
            this.helper.printDivider();
            foreach (var member in listMembers)
            {
                Console.WriteLine("{0}: {1}", member.Key, member.Value);
            }
        }

        public void showVerboseList() {
            listMembers = _memberDAL.listMembers();

            foreach (var member in listMembers)
            {
                Console.WriteLine("{0}: {1}", member.Key, member.Value);
            }
        }

       
    }
}
