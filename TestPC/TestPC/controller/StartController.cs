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
        private ListController _listController;

   

    public StartController(){
        _memberDAL = new MemberDAL();
        _startView = new StartView ();
       
        _startView.showStartMenu ();
		executeMenuChoice ();
     }
    public void executeMenuChoice(){
			StartView.MenuChoice menuChoice = _startView.GetMenuChoice();
			Console.WriteLine (menuChoice);
			if (menuChoice == StartView.MenuChoice.AddMember)
			{
				AddMemberController addMemberController = new AddMemberController();
			}
			if (menuChoice == StartView.MenuChoice.CompactListMembers ||
				menuChoice == StartView.MenuChoice.VerboseListMembers){
                bool showCompactList = false;
                
                if (menuChoice == StartView.MenuChoice.CompactListMembers)
				{
                    showCompactList = true;
				}
                ListController listController = new ListController(showCompactList);
			}
		
		}
    }
}