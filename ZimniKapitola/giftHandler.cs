
namespace ZimniKapitola
{
    /// <summary>
    /// a class that reads from text file of gifts and of the ones who the gifts are for later and stores the values in the lists
    /// </summary>
    public class giftHandler
    {
        public List<string> Gifts { get; set; } = new List<string>();
        public List<string> FutureOwner { get; set; } = new List<string>();
        /// <summary>
        /// this method reads from files mentioned below and stores all the values from 'em into the dedicated lists
        /// </summary>
        /// <param name="GiftFile"> this is a string pathway to a text file containing all gifts </param>
        /// <param name="FutureOwnersFile"> this is a string pathway to a text file containing all future owners of the gifts </param>
        public void AddGiftAndOwners(string GiftFile, string FutureOwnersFile)
        {
            string line;
            using (StreamReader sr = new StreamReader(GiftFile))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Gifts.Add(line);
                }
                sr.Close();
            }
            using (StreamReader sr = new StreamReader(FutureOwnersFile))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    FutureOwner.Add(line);
                }
                sr.Close();
            }
        }
    }
}
