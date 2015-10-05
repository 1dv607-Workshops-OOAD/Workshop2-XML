using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPC.view;

namespace TestPC.controller
{
    class AddBoatController
    {
        private BoatView boatView;
        public AddBoatController() {
            this.boatView = new BoatView();
            boatView.showAddBoatMenu();
            boatView.showMemberList();
        }

    }
}
