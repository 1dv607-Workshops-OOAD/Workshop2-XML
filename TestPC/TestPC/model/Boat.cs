using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPC.model
{
    class Boat
    {
        string _boatType;
        string _boatLength;

        public Boat(string boatType, string boatLength)
        {
            this._boatType = boatType;
            this._boatLength = boatLength;
        }

        public string BoatType { get { return _boatType; } }
        public string BoatLength { get { return _boatLength; } }
    }
    
}
