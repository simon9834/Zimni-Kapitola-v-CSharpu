
using ZimniKapitola;

public class SpotManager
{
    private Dictionary<string, Spot> spots { get; set; } = new Dictionary<string, Spot>();
    public Dictionary<Spot, Gift> hiddenGifts { get; set; } = new Dictionary<Spot, Gift>();
    private Spot spot;
    public List<int> bestChances { get; set; } = new List<int>(); 
    public void AddSpot(string spotName)
    {
        if (!spots.ContainsKey(spotName))
        {
            spot = new Spot(spotName);
        }
    }

    public void FillSpot(params object[] items) // string -> name of one member of the fam, int -> the chance
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
