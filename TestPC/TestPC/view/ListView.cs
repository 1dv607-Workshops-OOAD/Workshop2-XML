using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPC.model;

namespace TestPC.view
{
    class ListView
    {
        private MemberDAL _memberDAL;

        public ListView()
        {
            this._memberDAL = new MemberDAL();
        }

        public void showCompactList()
        {
            Console.Clear();
            this._memberDAL.listMembers();
        }
    }
}
