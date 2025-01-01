
namespace ZimniKapitola
{
    public class Gift
    {
        public string futureOwner {  get; set; }
        public bool isHidden { get; set; }
        
        public Gift(string futureOwner, bool isHidden) 
        {
            this.futureOwner = futureOwner;
            this.isHidden = isHidden;
        }
    }
}
