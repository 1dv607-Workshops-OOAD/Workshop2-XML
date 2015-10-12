using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.helper;
using BoatClub.view;

namespace BoatClub.controller
{
    class ListController
    {
        private ListView listView;

        public ListController(StartView.MenuChoice menuChoice)
        {
            this.listView = new ListView();
            executeMenuChoice(menuChoice);
        }

        public void executeMenuChoice(StartView.MenuChoice menuChoice)
        {
            if (menuChoice == StartView.MenuChoice.CompactListMembers)
            {
                listView.showCompactList();
                Helper.MenuChoice choice = listView.goToStartMenu();
                if (choice == Helper.MenuChoice.Back || choice == Helper.MenuChoice.None)
                {
                    StartController startController = new StartController();
                }
            }
            else
            {
                listView.showVerboseList();
                string selectedMember = listView.getSelectedMember();
                EditMemberController editMemberController = new EditMemberController(selectedMember);
            }
        }
    }
}
