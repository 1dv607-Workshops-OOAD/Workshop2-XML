using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPC.helper;
using TestPC.model;
using TestPC.view;

namespace TestPC.controller
{
    class EditMemberController
    {
        private string selectedMember;
        private MemberDAL memberDAL;
        private EditMemberView editMemberView;

        public EditMemberController(string selectedMember) {
            this.selectedMember = selectedMember;
            this.memberDAL = new MemberDAL();
            this.editMemberView = new EditMemberView();
            showMemberView();
            executeMenuChoice(editMemberView.getMenuChoice());
        }

        public void showMemberView(){
            editMemberView.showEditMemberMenu();
            editMemberView.showSelectedMember(selectedMember);
        }

        public void executeMenuChoice(Helper.MenuChoice menuChoice)
        {
            if (menuChoice == Helper.MenuChoice.DeleteMember)
            {
                memberDAL.deleteMemberById(selectedMember);
                StartController startController = new StartController();
            }
            if (menuChoice == Helper.MenuChoice.EditMember)
            {
            }
            if (menuChoice == Helper.MenuChoice.Boats)
            {
            }
            if (menuChoice == Helper.MenuChoice.Back)
            {
            }

        }
    }
}
