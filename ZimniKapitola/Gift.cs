
namespace ZimniKapitola
{
    public class Gift
    {
        public string name {  get; set; }
        public string futureOwner {  get; set; }
        public bool isHidden { get; set; }
        
        public Gift(string futureOwner, bool isHidden, string name) 
        {
            this.futureOwner = futureOwner;
            this.isHidden = isHidden;
            this.name = name;
        }
    }
}
