using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPC.model;
using TestPC.view;

namespace TestPC.controller
{
    class EditBoatController
    {
        private MemberDAL memberDAL;
        private EditBoatView editBoatView;
        private string memberId;

        public EditBoatController(string memberId) {
            this.memberDAL = new MemberDAL();
            this.editBoatView = new EditBoatView();
            this.memberId = memberId;
            editBoatView.showMemberBoatsMenu(memberId);
            showSelectedBoat();
            //editBoatView.getSelectedBoat();
            
            
        }

        public void showSelectedBoat() {
            editBoatView.showEditBoatMenu(editBoatView.getSelectedBoat(), memberId);
            
            Console.WriteLine(editBoatView.getEditBoatMenuChoice());
        }
    }
}
