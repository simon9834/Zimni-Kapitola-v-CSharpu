
namespace ZimniKapitola
{
    public class UserSpots
    {
        public List<string> usrSpots {  get; set; }
        public UserSpots()
        {
            usrSpots = new List<string>();
        }
        public void AddUsersSpots(string filepath)
        {
            using (StreamReader sr = new StreamReader(filepath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    usrSpots.Add(line);
                }
                sr.Close();
            }
        }
    }
}
