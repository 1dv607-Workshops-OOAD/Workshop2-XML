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
        private StartView _startView;
        private MemberDAL _memberDAL;
        private ListView listView = new ListView();

        public StartController()
        {
            _memberDAL = new MemberDAL();
            //if(_startView != null){
            //    _startView = null;
            //}
            _startView = new StartView();
            _startView.showStartMenu();
            executeMenuChoice();
        }

        public void executeMenuChoice()
        {
            StartView.MenuChoice menuChoice = _startView.GetMenuChoice();
            if (menuChoice == StartView.MenuChoice.AddMember)
            {
                AddMemberController addMemberController = new AddMemberController();
            }

       /*     if (menuChoice == StartView.MenuChoice.CompactListMembers)
            {
                
            }
            if (menuChoice == StartView.MenuChoice.VerboseListMembers) 
            {
                
                listView.showVerboseList();
            }*/
            if (menuChoice == StartView.MenuChoice.AddBoat)
            {
                AddBoatController addBoatController = new AddBoatController(); 
            }
        }
    }
}