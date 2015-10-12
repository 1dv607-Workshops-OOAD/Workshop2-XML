﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.model;
using BoatClub.view;

namespace BoatClub.controller
{
    class AddBoatController
    {
        private AddBoatView boatView;
        private MemberDAL memberDAL;
        private string choice;

        public AddBoatController()
        {
            this.boatView = new AddBoatView();
            this.memberDAL = new MemberDAL();
            boatView.showAddBoatMenu();
            boatView.showMemberList();
            choice = boatView.getChoice();
            if (boatView.doesMemberExist())
            {
                saveBoat();
            }
            else {
                StartController startController = new StartController();
            }
            
        }

        public void saveBoat()
        {
            Boat newBoat = boatView.addBoat(choice);
            memberDAL.saveBoat(newBoat, choice);
            StartController startController = new StartController();
        }
    }
}
