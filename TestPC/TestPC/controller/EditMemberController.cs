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
    class EditMemberController
    {
        private string selectedMember;
        private MemberDAL memberDAL;
        private EditMemberView editMemberView;

        public EditMemberController(string selectedMember)
        {
            this.selectedMember = selectedMember;
            this.memberDAL = new MemberDAL();
            this.editMemberView = new EditMemberView();
            showMemberView();
            executeMenuChoice(editMemberView.getMenuChoice());
        }

        public void showMemberView()
        {
            editMemberView.showEditMemberMenu();
            editMemberView.showSelectedMember(selectedMember);
        }

        public void executeMenuChoice(Helper.MenuChoice menuChoice)
        {
            if (menuChoice == Helper.MenuChoice.Delete)
            {
                memberDAL.deleteMemberById(selectedMember);
                StartController startController = new StartController();
            }
            if (menuChoice == Helper.MenuChoice.Edit)
            {
                editMemberView.showSelectedMemberWithoutBoats(selectedMember);
                memberDAL.updateMemberById(editMemberView.editMember(selectedMember));
                StartController startController = new StartController();
            }
            if (menuChoice == Helper.MenuChoice.Boats)
            {
                EditBoatController editBoatcontroller = new EditBoatController(selectedMember);
            }
            if (menuChoice == Helper.MenuChoice.Back)
            {
                StartController startController = new StartController();
            }
        }
    }
}
