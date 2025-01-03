
using ZimniKapitola;
/// <summary>
/// a class that handles most of the actions in the whole project
/// </summary>
public class SpotManager
{
    private Dictionary<string, Spot> spots { get; set; } = new Dictionary<string, Spot>();
    public Dictionary<Spot, Gift> hiddenGifts { get; set; } = new Dictionary<Spot, Gift>();
    private Spot spot;
    public List<int> bestChances { get; set; } = new List<int>();
    /// <summary>
    /// this method creates a new instance of a class spot with the spot name thats being passed in
    /// </summary>
    /// <param name="spotName"> a string that is used as a name of the spot in object spot</param>
    public void AddSpot(string spotName)
    {
        if (!spots.ContainsKey(spotName))
        {
            spot = new Spot(spotName);
        }
    }
    /// <summary>
    /// this method gets smth like an array of objects and decides whether the object is a string or long and based ont that 
    /// saves the value and when both string and long are saved, it adds a new value to the chances dictionary and then resets
    /// the variables to their basic values and repeats the cycle until all values that were passed in are stored. And after that
    /// we add it to the spots dictionary
    /// </summary>
    /// <param name="items"> this is a list of items type object thta are later used in the method </param>
    public void FillSpot(params object[] items) // string -> name of one member of the fam, int -> the chance of the member
    {
        string name = "";
        int chance = 0;
        foreach (var item in items)
        {
            if (item is long longVal && chance == 0)
            {
                chance = Convert.ToInt32(longVal);
            }
            else if (item is string && name == "")
            {
                name = (string)item;
            }
            if (!(name == "") && !(chance == 0))
            {
                spot.SetChance(name, chance);
                chance = 0;
                name = "";
            }
        }
        spots.Add(spot.name, spot);
    }
    /// <summary>
    /// this method chooses the best spot in the spots dict to hide the gift accordingly to whom the gift will be for.
    /// Firstly checks if the spot is filled and if not, then calculates the chance of the spot being leaked and stores
    /// the chance. Like that it goes thru all empty spots and chooses the best one and stores the gift and the spot
    /// into the hiddenGifts dict. and adds the best chance in to the list of chances and marks the spot that was chosen
    /// as filled.
    /// </summary>
    /// <param name="gift"> the gift thats going to be hid </param>
    public void HideGift(Gift gift)
    {
        int chance = 0;
        int bestChance = int.MaxValue;
        string spotName = null;
        foreach (var spot in spots.Where(x => !x.Value.isFilled))
        {
            chance = spot.Value.CalculateAdjustedSum(gift.futureOwner);
            if (chance < bestChance && chance != 0)
            {
                bestChance = chance;
                spotName = spot.Key.ToString();
            }
        }
        bestChances.Add(bestChance);
        spots[spotName].isFilled = true;
        hiddenGifts.Add(spots[spotName], gift); 
    }
}
