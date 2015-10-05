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
            //Console.Clear();
        }

        public void showCompactList()
        {
            
            //Console.WriteLine("Listview");
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
    }
}
