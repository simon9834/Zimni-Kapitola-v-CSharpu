
namespace ZimniKapitola
{
    public class giftHandler
    {
        public List<string> Gifts { get; set; } = new List<string>();
        public List<string> FutureOwner { get; set; } = new List<string>();
        public void AddGiftAndOwners(string GiftFile, string FutureOwnersFile)
        {
            string line;
            using (StreamReader sr = new StreamReader(GiftFile))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Gifts.Add(line);
                }
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
