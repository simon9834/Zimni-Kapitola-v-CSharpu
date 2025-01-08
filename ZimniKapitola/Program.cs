
using ZimniKapitola;
//main class that starts everything

FamilyMembers familyMembers = new FamilyMembers();
familyMembers.AddFamilyMem("Family.txt");
UserSpots userSpots = new UserSpots();
userSpots.AddUsersSpots("UserSpotsFile.txt");
SpotManager sm = new SpotManager();
giftHandler gh = new giftHandler();
gh.AddGiftAndOwners("Gifts.txt", "FutureOwners.txt");
int spotsCount = 0;
Random rnd = new Random();



foreach (var spot in userSpots.usrSpots)
{
    familyMembers.famDictFill(userSpots);
    sm.AddSpot(userSpots.usrSpots[spotsCount]);
    sm.FillSpot(familyMembers.Family[0], familyMembers.famNumberos[familyMembers.Family[0]][0], familyMembers.Family[1], rnd.NextInt64(0, 100), familyMembers.Family[2], rnd.NextInt64(0, 100), familyMembers.Family[3], rnd.NextInt64(0, 100), familyMembers.Family[4], rnd.NextInt64(0, 100));
    spotsCount += 1;
}
if (sm.checkGiftsVsSpots(gh))
{
    List<int> num = sm.randomNumbers(gh);
    for (int i = 0; i < gh.Gifts.Count; i++)
    {
        Gift g = new Gift(gh.FutureOwner[num[i]], false, gh.Gifts[num[i]]);
        sm.HideGift(g);
    }
}

string path = "TheFinalGiftPlacement.txt";
string path2 = "AllInformations.txt";

//storing all values into the txt files
using (StreamWriter sw = new StreamWriter(path))
{
    using (StreamWriter sw2 = new StreamWriter(path2))
    {
        foreach (var item in sm.hiddenGifts)
        {
            sw.WriteLine($"dárkem je/jsou {item.Value.name} a je schovaný {item.Key.name}");
        }
        for (int i = 0; i < familyMembers.Family.Count; i++)
        {
            sw2.WriteLine($"{familyMembers.Family[i]} má dárek pro {gh.FutureOwner[i]} a tím dárkem je {gh.Gifts[i]} a je schovaný {userSpots.usrSpots[i]}. Šance na nalezení je: {sm.bestChances[i] / familyMembers.Family.Count + 1}%");
        }
        sw.Close();
        sw2.Close();
    }
}




