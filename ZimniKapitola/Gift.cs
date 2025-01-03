
namespace ZimniKapitola
{
    /// <summary>
    /// a class that works as an object Gift that has a name, future owner and a boolean that determins whether its hidden
    /// </summary>
    public class Gift
    {
        public string name {  get; set; }
        public string futureOwner {  get; set; }
        public bool isHidden { get; set; }
        /// <summary>
        /// just a constructor for the object gift that holds a name, the one who will recieve the gift and an information
        /// if the gift is hidden or not.
        /// </summary>
        /// <param name="futureOwner"> the one who will recieve the gift </param>
        /// <param name="isHidden"> self explanatory </param>
        /// <param name="name"> just a name bro </param>
        public Gift(string futureOwner, bool isHidden, string name) 
        {
            this.futureOwner = futureOwner;
            this.isHidden = isHidden;
            this.name = name;
        }
    }
}
