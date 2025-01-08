
using System.Runtime.CompilerServices;

namespace ZimniKapitola
{
    /// <summary>
    /// class where i read the members of the family from a text file and store em in to a list
    /// </summary>
    public class FamilyMembers
    {
        private List<string> _family = new List<string>();
        private List<int> nums { get; set; } = new List<int>();
        public void famDictFill(UserSpots us)
        {
            int i = 0;
            List<int> li;
            readNum();
            foreach (var family in _family)
            {
                li = new List<int>();
                while (i < us.usrSpots.Count)
                {
                    li.Add(nums[i]);
                    i++;
                }
                famNumberos.Add(family, li);
            }
        }
        private void readNum()
        {
            using(StreamReader sr = new StreamReader("numbers.txt"))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    nums.Add(int.Parse(line));
                }
                sr.Close();
            }
        }

        public Dictionary<string, List<int>> famNumberos { get; set; } = new Dictionary<string, List<int>>();
        public List<string> Family { get => _family; set => _family = value; }
        /// <summary>
        /// this method reads from the file whichs fillepath is being passed in and stores all values in to the
        /// field _family list that is being accessed later on thru the property Family
        /// </summary>
        /// <param name="filepath"> the filepath to the text file with all family members </param>
        public void AddFamilyMem(string filepath)
        {
            using (StreamReader sr = new StreamReader(filepath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    _family.Add(line);
                }
                sr.Close();
            }
        }
    }
}
