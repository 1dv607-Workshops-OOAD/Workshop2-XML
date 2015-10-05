using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPC.model;
using TestPC.view;

namespace TestPC.controller
{
    class AddMemberController
    {
        private AddMemberView addMemberView;
        private MemberDAL memberDAL;
        public AddMemberController(){
            this.memberDAL = new MemberDAL();
            this.addMemberView = new AddMemberView();
            addNewMember();

        }

        public void addNewMember()
        {
            this.memberDAL.saveMember(addMemberView.showAddMemberView());

        }


    }
}
