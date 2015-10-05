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
        
        public ListController(bool showCompactList){
            this._listView = new ListView();
            if (showCompactList)
            {
                _listView.showCompactList();
            }
        }

    }
}
