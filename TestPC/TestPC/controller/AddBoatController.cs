using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPC.model;
using TestPC.view;

namespace TestPC.controller
{
    class AddBoatController
    {
        private AddBoatView boatView;
        private MemberDAL memberDAL;
        private string selectedMember;

        public AddBoatController() {
            this.boatView = new AddBoatView();
            this.memberDAL = new MemberDAL();
            boatView.showAddBoatMenu();
            boatView.showMemberList();
            this.selectedMember = boatView.getSelectedMember();
            saveBoat();
        }

        public void saveBoat() {
            Boat newBoat = boatView.addBoat(selectedMember);
            memberDAL.saveBoat(newBoat, selectedMember);
            StartController startController = new StartController();
        }
    }
}
