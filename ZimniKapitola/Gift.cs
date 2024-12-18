using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZimniKapitola
{
    public class Gift
    {
        public string futureOwner {  get; set; }
        public bool isHidden { get; set; }
        HidingSpots hs = new HidingSpots();
        public void hide()
        {
            if(!hs.spots.Equals(null) && !isHidden)
            {
                //function where the gift will be hidden in the most efficient place
            }
        }
    }
}
