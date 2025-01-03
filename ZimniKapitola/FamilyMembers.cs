
namespace ZimniKapitola
{
    /// <summary>
    /// class where i read the members of the family from a text file and stores em in to a list
    /// </summary>
    public class FamilyMembers
    {
        private List<string> _family = new List<string>();

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
