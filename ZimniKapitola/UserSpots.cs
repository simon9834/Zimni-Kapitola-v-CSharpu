
namespace ZimniKapitola
{
    /// <summary>
    /// a class that reads from á text file that contains all the hiding spots used later on
    /// </summary>
    public class UserSpots
    {
        public List<string> usrSpots {  get; set; } = new List<string>();
        /// <summary>
        /// this method reads from a filepath mentioned below and stores all values into a dedicated list
        /// </summary>
        /// <param name="filepath"> this string is a filepath to the text file containing all the hiding spots used</param>
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
