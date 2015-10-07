using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPC.model;
using TestPC.view;

namespace TestPC.controller
{
    public class StartController
    {
        private StartView startView;
        private MemberDAL memberDAL;
        private ListView listView;

        public StartController()
        {
            this.memberDAL = new MemberDAL();
            this.startView = new StartView();
            this.listView = new ListView();
            startView.showStartMenu();
            executeMenuChoice();
        }

        public void executeMenuChoice()
        {
            StartView.MenuChoice menuChoice = startView.GetMenuChoice();
            if (menuChoice == StartView.MenuChoice.AddMember)
            {
                AddMemberController addMemberController = new AddMemberController();
            }
            if (menuChoice == StartView.MenuChoice.VerboseListMembers || 
                menuChoice == StartView.MenuChoice.CompactListMembers)
            {
                ListController listController = new ListController(menuChoice);
            }
            if (menuChoice == StartView.MenuChoice.AddBoat)
            {
                AddBoatController addBoatController = new AddBoatController();
            }
        }
    }
}