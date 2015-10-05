using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPC.view;

namespace TestPC.controller
{
    class ListController
    {
        private ListView _listView;
        private bool _showCompactList;
        
        public ListController(bool showCompactList){
            this._listView = new ListView();
            this._showCompactList = showCompactList;
            showView();
        }

        public void showView(){
            if(_showCompactList){
               _listView.showCompactList();
            }
        }
    }
}
