
using ZimniKapitola;

public class SpotManager
{
    private Dictionary<string, Spot> spots;
    private Dictionary<Spot, Gift> hiddenGifts { get; set; }
    private UserSpots usrspt;
    private int i = 0;
    private Spot spot;

    public SpotManager(UserSpots usrspt)
    {
        spots = new Dictionary<string, Spot>();
        hiddenGifts = new Dictionary<Spot, Gift>();
        this.usrspt = usrspt;
    }

    public void AddSpot(string spotName)
    {
        if (!spots.ContainsKey(spotName))
        {
            spot = new Spot(spotName);
            spots.Add(spotName, spot);
        }
    }
    
    public void FillSpot(params object[] items) // string -> name of one member of the fam, int -> the chance
    {
        string name = "";
        int chance = 0;
        foreach (var item in items)
        {
            if (item is int && chance == 0)
            {
                chance = (int)item;
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
        spots[spot.name].isFilled = true;
    }

    public Spot GetSpot(string spotName)
    {
        return spots.ContainsKey(spotName) ? spots[spotName] : null;
    }

    public void HideGift(Gift gift)
    {
        int chance = 0;
        int bestChance = 0;
        string spotName = "";
        foreach (var spot in spots)
        {
            chance = spot.Value.CalculateAdjustedSum(gift.futureOwner);
            if (chance < bestChance)
            {
                bestChance = chance;
                spotName = spot.Key;
            }
        }
        hiddenGifts.Add(spots[spotName], gift);
    }
}
