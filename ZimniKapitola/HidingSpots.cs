using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZimniKapitola
{
    public class HidingSpots
    {

        public List<string> spots = new List<string>();
        public List<bool> arespotsFiled = new List<bool>();
        public List<int> chancesToFind_MOM = new List<int>();
        public List<int> chancesToFind_DAD = new List<int>();
        public List<int> chancesToFind_CHILD1 = new List<int>();
        public List<int> chancesToFind_CHILD2 = new List<int>();
        public List<int> chancesToFind_CHILD3 = new List<int>();

        public void addToSpots(string spot, List<int> chances)
        {
            if (!spots.Contains(spot))
            {
                spots.Add(spot);
                arespotsFiled.Add(false);
                chancesToFind_MOM.Add(chances[0]);
                chancesToFind_DAD.Add(chances[1]);
                chancesToFind_CHILD1.Add(chances[2]);
                chancesToFind_CHILD2.Add(chances[3]);
                chancesToFind_CHILD3.Add(chances[4]);
            }
        }
    }
}
