using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPC.model
{
    class MemberID
    {
        public MemberID()
        {
        }

        private string path = "../../data/MemberID.txt";
        private int count;

        public int generateMemberId()
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                if (new FileInfo(path).Length == 0)
                {
                    this.count = 1;
                }
                else
                {
                    this.count = int.Parse(line);
                    this.count++;
                }
            }
            writeToFile();
            return this.count;
        }

        //Save number of generated memberId's to file
        public void writeToFile()
        {
            using (StreamWriter write = new StreamWriter(path, false))
            {
                write.Write(this.count);
            }
        }
    }
}
