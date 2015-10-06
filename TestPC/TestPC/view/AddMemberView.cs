using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPC.helper;
using TestPC.model;

namespace TestPC.view
{
    class AddMemberView
    {
        private string memberName;
        private string memberSocSecNo;
        Helper helper;

        public AddMemberView()
        {
            this.helper = new Helper();
        }

        public Member showAddMemberView()
        {
            Console.Clear();
            this.helper.printDivider();
            Console.WriteLine("LÄGG TILL MEDLEM");
            this.helper.printDivider();

            Console.Write("Ange namn: ");
            this.memberName = Console.ReadLine();
            Console.Write("Ange personnummer: ");
            this.memberSocSecNo = Console.ReadLine();
            Member newMember = new Member(0, this.memberName, this.memberSocSecNo);

            return newMember;

        }
    }
}
