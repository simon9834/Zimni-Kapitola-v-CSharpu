

public class Spot
{
    public string name { get; private set; }
    public bool isFilled { get; set; }
    public Dictionary<string, int> chances { get; private set; } // string -> who's chance it is and int -> the chance
    /// <summary>
    /// constructor for this class that creates a chances dict whenever called
    /// </summary>
    /// <param name="name"> the name of the spot (the object) </param>
    public Spot(string name)
    {
        this.name = name;
        isFilled = false;
        chances = new Dictionary<string, int>();
    }
    /// <summary>
    /// this method adds the string and int into the chances dict
    /// </summary>
    /// <param name="who"> string of who's chance it is </param>
    /// <param name="chance"> int chance that the person has </param>
    public void SetChance(string who, int chance)
    {
       chances.Add(who, chance);
    }
    /// <summary>
    /// this method calculates the chance that you have of someone finding ur gift. It does it by passing in the future owner
    /// and getting the chance from the chances dict and just adding em all up, but the one who will recieve the gift will
    /// have his chances of finding upgraded to double the chance to make sure he especially doesnt find the gift
    /// </summary>
    /// <param name="whoWillRecieveTheGift"> a string which is a name of the one who will recieve this gift </param>
    /// <returns> returns the sum of all chances for this spot </returns>
    public int CalculateAdjustedSum(string whoWillRecieveTheGift)
    {
        int sum = 0;

        foreach (var chance in chances)
        {
            if (chance.Key == whoWillRecieveTheGift) // if -> the chances of the one who will recieve the gift will be doubled
            {
                sum += chance.Value * 2;
            }
            else
            {
                sum += chance.Value; // others chances will just add to the sum integer
            }
        }
        return sum; // returning the sum of the chances
    }
}

