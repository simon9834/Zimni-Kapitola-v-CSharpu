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
    
    public void SetSpotNamesAndChances(params object[] items)
    {
        string name = "";
        int chance = 0;
        Spot spot = new Spot(doplnit jmeno skryse ze souboru skrysi);
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
        spots.Add(spot.name, spot);
        spots[spot.name].isFilled = true;
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
