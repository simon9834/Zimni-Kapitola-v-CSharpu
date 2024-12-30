using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZimniKapitola
{
    public class FamilyMembers
    {
        public void AddFamilyMem(string filepath)
        {
            using (StreamReader sr = new StreamReader(filepath, System.Text.Encoding.UTF8))
            {
                Dictionary<string, string> personAndTheirGiftDict = new Dictionary<string, string>();
                char[] ar;
                string line;
                string name = "";
                string gift = "";
                bool getIn = false;

                while ((line = sr.ReadLine()) != null)
                {
                    char[] charArray = line.ToCharArray();
                    foreach (char c in charArray)
                    {
                            name += c;
                        if (c == ' ' || getIn)
                        {
                            if (!getIn) getIn = true;
                            gift += c;
                        }
                    }
                    personAndTheirGiftDict.Add(string.Concat(name.Where(c => !char.IsWhiteSpace(c))),
                                               string.Concat(gift.Where(c => !char.IsWhiteSpace(c))));
                }
            }
        }

    }
}
