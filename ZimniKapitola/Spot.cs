

public class Spot
{
    public string name { get; private set; }
    public bool isFilled { get; set; }
    public Dictionary<string, int> chances { get; private set; } // string who's chance it is and int -> the chance

    public Spot(string name)
    {
        this.name = name;
        isFilled = false;
        chances = new Dictionary<string, int>();
    }

    public void SetChance(string who, int chance)
    {
       chances.Add(who, chance);
    }

    public int GetChance(string who)
    {
        return chances.ContainsKey(who) ? chances[who] : 0;
    }

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

