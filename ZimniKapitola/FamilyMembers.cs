
namespace ZimniKapitola
{
    public class FamilyMembers
    {
        private List<string> _family = new List<string>();

        public List<string> Family { get => _family; set => _family = value; }

        public void AddFamilyMem(string filepath)
        {
            using (StreamReader sr = new StreamReader(filepath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    _family.Add(line);
                }
            }
        }
    }
}
