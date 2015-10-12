using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.helper;
using BoatClub.model;
using BoatClub.view;

namespace BoatClub.controller
{
    class AddMemberController
    {
        private AddMemberView addMemberView;
        private MemberDAL memberDAL;
        public AddMemberController()
        {
            this.memberDAL = new MemberDAL();
            this.addMemberView = new AddMemberView();
            addNewMember();
        }

        public void addNewMember()
        {
            this.memberDAL.saveMember(addMemberView.showAddMemberView());
            StartController startController = new StartController();
        }


    }
}
