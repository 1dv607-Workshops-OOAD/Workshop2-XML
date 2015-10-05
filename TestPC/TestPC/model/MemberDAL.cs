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
        private string path = "../../data/Members.xml";
		public MemberDAL ()
		{
		}
        
        public List<KeyValuePair<string, string>> listMembers(){
            List<KeyValuePair<string, string>> members = new List<KeyValuePair<string, string>>();
            
            using(XmlTextReader reader = new XmlTextReader (path)){
               while (reader.Read()){
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Member")){
                    if (reader.HasAttributes)
                        
                        members.Add(new KeyValuePair<string, string>("id", reader.GetAttribute("id")));
                        members.Add(new KeyValuePair<string, string>("name", reader.GetAttribute("name")));
                        members.Add(new KeyValuePair<string, string>("socialnumber", reader.GetAttribute("socialnumber")));
                        //Console.WriteLine(reader.GetAttribute("id"));
                        //Console.WriteLine(reader.GetAttribute("name"));
                        //Console.WriteLine(reader.GetAttribute("socialnumber"));
                    }
               }
               //foreach (var item in members){
               //    Console.WriteLine("{0}: {1}", item.Key, item.Value);
               //}
               //Console.ReadLine();
                
               return members;
              }
        }
    
 
        
		public void saveMember(Member newMember){
			XDocument doc = XDocument.Load(path); 
			XElement memberRoot = new XElement("Member");
            memberRoot.Add(new XAttribute("id", newMember.MemberID.ToString()));
            memberRoot.Add(new XAttribute("name", newMember.MemberName));
            memberRoot.Add(new XAttribute("socialnumber", newMember.MemberSocSecNo));
            memberRoot.Add(new XElement("Boats"));
            doc.Element("members").Add(memberRoot); 
			doc.Save(path);
            
        }
	    public void saveBoat(Boat newBoat, int memberId){
            XDocument doc = XDocument.Load(path);

            doc.Element("Members").Elements("Member")
                .First(c => (int)c.Attribute("id") == memberId).Add(new XElement(
                             "boat", new XAttribute("id", "")));


           /* XElement memberRoot = new XElement("Member");
            XElement boat = new XElement("Boat");
            memberRoot.Add(boat);
            boat.Add(new XAttribute("id", ""));
            boat.Add(new XAttribute("boattype", newBoat.BoatType));
            boat.Add(new XAttribute("boatlength", newBoat.BoatLength));*/




        }

    }
}
