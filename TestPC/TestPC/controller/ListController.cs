using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPC.helper;
using TestPC.view;

namespace TestPC.controller
{
    class ListController
    {
        private ListView _listView;
        
        public ListController(StartView.MenuChoice menuChoice){
            this._listView = new ListView();
            executeMenuChoice(menuChoice);
        }

        public void executeMenuChoice(StartView.MenuChoice menuChoice) {
            if (menuChoice == StartView.MenuChoice.CompactListMembers)
            {
                _listView.showCompactList();
                Helper.MenuChoice back = _listView.goToStartMenu();
                if(back==Helper.MenuChoice.Back){
                    StartController startController = new StartController();
                }
            }
            else 
            {
                _listView.showVerboseList();
                string selectedMember = _listView.getSelectedMember();
                EditMemberController editMemberController = new EditMemberController(selectedMember);
            }
        }

    }
}
