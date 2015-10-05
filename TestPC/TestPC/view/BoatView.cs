using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPC.helper;
using TestPC.model;

namespace TestPC.view
{
    class BoatView
    {
        private List<KeyValuePair<string, string>> listMembers = new List<KeyValuePair<string, string>>();

        Helper helper = new Helper();
        private MemberDAL _memberDAL;
        public BoatView() {
            this._memberDAL = new MemberDAL();
        }

        public void showAddBoatMenu()
        {
            Console.Clear();
            this.helper.printDivider();
            Console.WriteLine("LÄGG TILL EN BÅT");
            this.helper.printDivider();
            Console.WriteLine("Välj medlemsnummer.\n");
        }

        public void showMemberList() 
        {
            listMembers = _memberDAL.listMembers();

            foreach (var member in listMembers)
            {
                Console.WriteLine("{0}: {1}", member.Key, member.Value);
            }
        }

    }
}
