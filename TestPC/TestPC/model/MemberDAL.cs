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
        public MemberDAL()
        {
        }

        public string getBoatTypeKey()
        {
            return boatType;
        }

        public string getBoatLengthKey()
        {
            return boatLength;
        }

        public string getSocialSecNoKey()
        {
            return socialSecNo;
        }

        public string getNumberOfBoatsKey()
        {
            return numberOfBoats;
        }

        public List<KeyValuePair<string, string>> listMembers()
        {
            List<KeyValuePair<string, string>> members = new List<KeyValuePair<string, string>>();

            using (XmlTextReader reader = new XmlTextReader(path))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Member"))
                    {
                        if (reader.HasAttributes) { 
                            members.Add(new KeyValuePair<string, string>(this.memberId, reader.GetAttribute("id")));
                            members.Add(new KeyValuePair<string, string>(name, reader.GetAttribute("name")));
                            members.Add(new KeyValuePair<string, string>(socialSecNo, reader.GetAttribute("socialnumber")));
                            members.Add(new KeyValuePair<string, string>(numberOfBoats, getNumberOfBoats(reader.GetAttribute("id")).ToString()));
                        }
                    }

                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Boat"))
                    {
                        members.Add(new KeyValuePair<string, string>(boatType, reader.GetAttribute("boatType")));
                        members.Add(new KeyValuePair<string, string>(boatLength, reader.GetAttribute("boatLength")));
                    }
                }

                return members;
            }
        }

        public int getNumberOfBoats(string memberId)
        {
            XDocument doc = XDocument.Load(path);
            var selectors = (from elements in doc.Elements("members").Elements("Member")
                             where elements.Attribute("id").Value == memberId
                             select elements).FirstOrDefault();
            var boatList = selectors.Elements("Boat").ToList();
            return boatList.Count;
        }

        public void editMember()
        {
            //kalla på save
        }

        public List<KeyValuePair<string, string>> getMemberById(string memberId)
        {
            List<KeyValuePair<string, string>> member = new List<KeyValuePair<string, string>>();

            using (XmlTextReader reader = new XmlTextReader(path))
            {
                XDocument doc = XDocument.Load(path);

                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Member"))
                    {
                        if (reader.GetAttribute("id") == memberId){
                            member.Add(new KeyValuePair<string, string>(this.memberId, reader.GetAttribute("id")));
                            member.Add(new KeyValuePair<string, string>(name, reader.GetAttribute("name")));
                            member.Add(new KeyValuePair<string, string>(socialSecNo, reader.GetAttribute("socialnumber")));

                            // For each element that is a child of member with id = memberId
                            foreach (var item in doc.Descendants("Member").Elements("Boat").Where(e => e.Parent.Name == "Member" && e.Parent.Attribute("id").Value == memberId))
                            {
                                var type = item.Attribute("boatType").Value;
                                var length = item.Attribute("boatLength").Value;
                                member.Add(new KeyValuePair<string, string>(boatType, type));
                                member.Add(new KeyValuePair<string, string>(boatLength, length));
                            }

                        }

                    }

                }

                return member;
            }
        }

        public void saveMember(Member newMember)
        {
            XDocument doc = XDocument.Load(path);
            XElement memberRoot = new XElement("Member");
            memberRoot.Add(new XAttribute("id", newMember.MemberID.ToString()));
            memberRoot.Add(new XAttribute("name", newMember.MemberName));
            memberRoot.Add(new XAttribute("socialnumber", newMember.MemberSocSecNo));
            //memberRoot.Add(new XElement("Boats"));
            doc.Element("members").Add(memberRoot);
            doc.Save(path);

        }

        public void deleteMemberById(string memberId) {
            XDocument doc = XDocument.Load(path);
            doc.Root.Elements("Member").Where(e => e.Attribute("id").Value.Equals(memberId)).Select(e => e).Single().Remove(); 
            doc.Save(path);
        }

        public void saveBoat(Boat newBoat, string memberId)
        {
            Console.WriteLine(memberId);
            XDocument doc = XDocument.Load(path);
            //XElement memberRoot = new XElement("Member");

            doc.Element("members").Elements("Member")
            .First(c => (string)c.Attribute("id") == memberId).Add
                 (
                     new XElement
                         (
                             "Boat", new XAttribute("boatType", newBoat.BoatType),
                                        new XAttribute("boatLength", newBoat.BoatLength)
                         )
                  );
            doc.Save(path);
        }

    }
}
