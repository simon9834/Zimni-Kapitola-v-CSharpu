using ZimniKapitola;

FamilyMembers familyMembers = new FamilyMembers();
familyMembers.AddFamilyMem("Family.txt");
UserSpots userSpots = new UserSpots();
userSpots.AddUsersSpots("UserSpotsFile.txt");
SpotManager sm = new SpotManager(userSpots);

sm.AddSpot()