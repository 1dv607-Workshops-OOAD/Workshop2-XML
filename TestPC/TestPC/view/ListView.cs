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
       
        public ListView()
        {
            this._memberDAL = new MemberDAL();
            listMembers = _memberDAL.listMembers();
        }

        public Helper.MenuChoice goToStartMenu() { 
            char menuChoice = System.Console.ReadKey().KeyChar;
            if (menuChoice == 'B' || menuChoice == 'b')
            {
                return Helper.MenuChoice.Back;
            }

            return Helper.MenuChoice.None;
        }

        public void showCompactList()
        {
            //Denna ska skrivas om till en compact list!
            Console.Clear();
            this.helper.printDivider();
            Console.WriteLine("FÖRENKLAD MEDLEMSLISTA");
            this.helper.printDivider();
            Console.WriteLine("Tryck B för att gå tillbaka till startmenyn.\n");
            foreach (var member in listMembers)
            {
                if (member.Key == _memberDAL.getBoatTypeKey() || 
                    member.Key == _memberDAL.getBoatLengthKey() ||
                    member.Key == _memberDAL.getSocialSecNoKey())
                {
                    continue;
                }
                Console.WriteLine("{0}: {1}", member.Key, member.Value);
            }
        }

        public void showVerboseList() {
            Console.Clear();
            this.helper.printDivider();
            Console.WriteLine("UTÖKAD MEDLEMSLISTA");
            this.helper.printDivider();

            Console.WriteLine("Ange medlemsId för att redigera en medlem.\n");

            foreach (var member in listMembers)
            {
                if (member.Key == _memberDAL.getNumberOfBoatsKey()) {
                    continue;
                }
                Console.WriteLine("{0}: {1}", member.Key, member.Value);
            }
        }

        public string getSelectedMember()
        {
            string memberId = Console.ReadLine();
            return memberId;
        }

       
    }
}
