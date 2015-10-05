using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPC.model
{
    class Member
    {
        int _memberId;
        string _memberName;
        string _memberSocSecNo;

        public Member(string memberName, string memberSocSecNo)
        {
            this._memberName = memberName;
            this._memberSocSecNo = memberSocSecNo;
            MemberID memberId = new MemberID();
            this._memberId = memberId.generateMemberId();
        }

        public string MemberName { get { return _memberName; } }
        public string MemberSocSecNo { get { return _memberSocSecNo; } }
        public int MemberID { get { return _memberId; } 
        }
    }
}
