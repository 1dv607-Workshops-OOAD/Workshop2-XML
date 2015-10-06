using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XmlConfiguration;

namespace TestPC.model
{
    class MemberDAL
    {
        private string boatType = "Båttyp";
        private string boatLength = "Båtlängd";
        private string socialSecNo = "Personnummer";
        private string memberId = "MEDLEMSID";
        private string name = "Namn";
        private string numberOfBoats = "Antal båtar";

        private string path = "../../data/Members.xml";
		public MemberDAL ()
		{
		}

        public string getBoatType() {
            return boatType;
        }

        public string getBoatLength() {
            return boatLength;
        }

        public string getSocialSecNo() {
            return socialSecNo;
        }

        public List<KeyValuePair<string, string>> listMembers(){
            List<KeyValuePair<string, string>> members = new List<KeyValuePair<string, string>>();
            
            using(XmlTextReader reader = new XmlTextReader (path)){
               while (reader.Read()){
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Member")){
                    if (reader.HasAttributes)

                        members.Add(new KeyValuePair<string, string>(memberId, reader.GetAttribute("id")));
                        members.Add(new KeyValuePair<string, string>(name, reader.GetAttribute("name")));
                        members.Add(new KeyValuePair<string, string>(socialSecNo, reader.GetAttribute("socialnumber")));
                        members.Add(new KeyValuePair<string, string>(numberOfBoats, getNumberOfBoats(reader.GetAttribute("id")).ToString()));
                    }

                   if((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Boat")){
                       members.Add(new KeyValuePair<string, string>(boatType, reader.GetAttribute("boatType")));
                       members.Add(new KeyValuePair<string, string>(boatLength, reader.GetAttribute("boatLength")));
                   }
               }
                
               return members;
              }
        }

        public int getNumberOfBoats(string memberId){
            var id = memberId;
            XDocument doc = XDocument.Load(path);
            var selectors = (from elements in doc.Elements("members").Elements("Member")
                             where elements.Attribute("id").Value == id
                             select elements).FirstOrDefault();
            var boatList = selectors.Elements("Boat").ToList();
            return boatList.Count;
        }

        public void editMember() { 
            //kalla på save
        }
        
		public void saveMember(Member newMember){
			XDocument doc = XDocument.Load(path); 
			XElement memberRoot = new XElement("Member");
            memberRoot.Add(new XAttribute("id", newMember.MemberID.ToString()));
            memberRoot.Add(new XAttribute("name", newMember.MemberName));
            memberRoot.Add(new XAttribute("socialnumber", newMember.MemberSocSecNo));
            //memberRoot.Add(new XElement("Boats"));
            doc.Element("members").Add(memberRoot); 
			doc.Save(path);
            
        }
	    public void saveBoat(Boat newBoat, string memberId){
            Console.WriteLine(memberId);
            XDocument doc = XDocument.Load(path);
            //XElement memberRoot = new XElement("Member");

            doc.Element("members").Elements("Member")
            .First(c => (string)c.Attribute("id") == memberId).Add
                 (
                     new XElement
                         (
                             "Boat",    new XAttribute("boatType", newBoat.BoatType),
                                        new XAttribute("boatLength", newBoat.BoatLength)
                         )
                  );
            doc.Save(path);
        }

    }
}
                                                                               