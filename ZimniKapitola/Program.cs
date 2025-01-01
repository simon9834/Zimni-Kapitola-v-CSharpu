using System.Runtime.CompilerServices;
using ZimniKapitola;

FamilyMembers familyMembers = new FamilyMembers();
familyMembers.AddFamilyMem("Family.txt");
UserSpots userSpots = new UserSpots();
userSpots.AddUsersSpots("UserSpotsFile.txt");
SpotManager sm = new SpotManager();
int spotsCount = 0;
Random rnd = new Random();

foreach (var spot in userSpots.usrSpots)
{
    sm.AddSpot(userSpots.usrSpots[spotsCount]);
    sm.FillSpot(familyMembers.Family[0], rnd.NextInt64(0, 100), familyMembers.Family[1], rnd.NextInt64(0, 100), familyMembers.Family[2], rnd.NextInt64(0, 100), familyMembers.Family[3], rnd.NextInt64(0, 100));
    spotsCount++;
}

giftHandler gh = new giftHandler();
gh.AddGiftAndOwners("Gifts.txt", "FutureOwners.txt");
for (int i = 0; i < gh.Gifts.Count; i++)
{
    Gift g = new Gift(gh.FutureOwner[i], false, gh.Gifts[i]);
    sm.HideGift(g);
}
foreach (var item in sm.hiddenGifts)
{
    Console.WriteLine($"spot: {item.Key.name}, gift: {item.Value.name}");
}



