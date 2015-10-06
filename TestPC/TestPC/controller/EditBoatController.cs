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
    class EditBoatController
    {
        private MemberDAL memberDAL;
        private EditBoatView editBoatView;
        private string memberId;
        private string selectedBoatId;

        public EditBoatController(string memberId) {
            this.memberDAL = new MemberDAL();
            this.editBoatView = new EditBoatView();
            this.memberId = memberId;
            editBoatView.showMemberBoatsMenu(memberId);
            showSelectedBoat();
            executeMenuChoice();
        }

        public void showSelectedBoat() {
            selectedBoatId = editBoatView.getSelectedBoat();
            editBoatView.showEditBoatMenu(selectedBoatId, memberId);
        }

        public void executeMenuChoice() {
            Helper.MenuChoice menuChoice = editBoatView.getEditBoatMenuChoice();

            if(menuChoice == Helper.MenuChoice.Delete){
                memberDAL.deleteBoatById(selectedBoatId, memberId);
                StartController startController = new StartController();
            }
            if(menuChoice == Helper.MenuChoice.Edit){

                memberDAL.updateBoatById(editBoatView.editBoat(selectedBoatId), memberId);
                StartController startController = new StartController();
            }


        }
    }
}
