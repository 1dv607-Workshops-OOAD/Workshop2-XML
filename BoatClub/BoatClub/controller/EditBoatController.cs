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
    class EditBoatController
    {
        private MemberDAL memberDAL;
        private EditBoatView editBoatView;
        private string memberId;
        private string selectedBoatId;

        public EditBoatController(string memberId)
        {
            this.memberDAL = new MemberDAL();
            this.editBoatView = new EditBoatView();
            this.memberId = memberId;
            editBoatView.showMemberBoatsMenu(memberId);
            showSelectedBoat();
            executeMenuChoice();
        }

        public void showSelectedBoat()
        {
            selectedBoatId = editBoatView.getSelectedBoat();
            if(selectedBoatId.ToUpper() == "S"){
                StartController startController = new StartController();
            }
            editBoatView.showEditBoatMenu(selectedBoatId, memberId);
        }

        public void executeMenuChoice()
        {
            Helper.MenuChoice menuChoice = editBoatView.getEditBoatMenuChoice();

            if (menuChoice == Helper.MenuChoice.Delete)
            {
                memberDAL.deleteBoatById(selectedBoatId, memberId);
            }
            if (menuChoice == Helper.MenuChoice.Edit)
            {
                memberDAL.updateBoatById(editBoatView.editBoat(selectedBoatId), memberId);
            }
            StartController startController = new StartController();
        }
    }
}
