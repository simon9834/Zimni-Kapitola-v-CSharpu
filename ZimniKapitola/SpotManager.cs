using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using ZimniKapitola;

public class SpotManager
{
    private Dictionary<string, Spot> spots;
    private Dictionary<Spot, Gift> hiddenGifts { get; set; }

    public SpotManager()
    {
        spots = new Dictionary<string, Spot>();
        hiddenGifts = new Dictionary<Spot, Gift>();
    }

    public void AddSpot(string spotName)
    {
        if (!spots.ContainsKey(spotName))
        {
            spots[spotName] = new Spot(spotName);
        }
    }

    public void SetSpotChances(string spotName, int momsChance, int dadsChance, int child1Chance, int child2Chance, int child3Chance)
    {
        if (spots.ContainsKey(spotName))
        {
            Spot spot = spots[spotName];
            spot.SetChance("MOM", momsChance);
            spot.SetChance("DAD", dadsChance);
            spot.SetChance("CHILD1", child1Chance);
            spot.SetChance("CHILD2", child2Chance);
            spot.SetChance("CHILD3", child3Chance);
        }
    }

    public void MarkSpotFilled(string spotName)
    {
        if (spots.ContainsKey(spotName))
        {
            spots[spotName].isFilled = true;
        }
    }

    public Spot GetSpot(string spotName)
    {
        return spots.ContainsKey(spotName) ? spots[spotName] : null;
    }

    public void hideGift(Gift gift)
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
