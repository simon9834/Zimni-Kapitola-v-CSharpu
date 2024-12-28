using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZimniKapitola
{
    public class Process
    {
        HidingSpots hs = new HidingSpots();
        Gift gift = new Gift();
        List<int> freeSpots = new List<int>();
        int chance = 0;
        int finaĺChance = 0;


        public void hide()
        {
            if (hs.arespotsFilled.Contains(false) && !gift.isHidden)
            {
                freeSpots = hs.arespotsFilled
                .Select((value, index) => new { Value = value, Index = index })
                .Where(item => !item.Value)
                .Select(item => item.Index)
                .ToList();

                foreach (var index in freeSpots)
                {
                    
                }

                //function where the gift will be hidden in the most efficient place

            }
        }

        public void calculateSpot(int index)
        {

            chance = hs.chancesToFind_MOM[index]/2 + hs.chancesToFind_DAD[index]/2 + hs.chancesToFind_CHILD1[index]/2 + hs.chancesToFind_CHILD2[index]/2 + hs.chancesToFind_CHILD3[index]/2;
            if(chance < )
        }
    }
}
