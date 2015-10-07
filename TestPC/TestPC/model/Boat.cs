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
        int _boatId;

        public Boat(int boatId, string boatType, string boatLength, string selectedMember)
        {
            MemberDAL _memberDAL = new MemberDAL();

            if (boatId == 0)
            {
                this._boatId = 1 + _memberDAL.getNumberOfBoats(selectedMember);
            }
            else
            {
                this._boatId = boatId;
            }
            this._boatType = boatType;
            this._boatLength = boatLength;
        }

        public int BoatId { get { return _boatId; } }
        public string BoatType { get { return _boatType; } }
        public string BoatLength { get { return _boatLength; } }
    }
}
