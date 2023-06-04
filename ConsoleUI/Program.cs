var armies = DataBaseClient.ArmyCollection.Find(_ => true).ToList();
if(armies is null) Console.WriteLine("No Armies");

else {
    Console.WriteLine("Armies Not Null");
    foreach(var army in armies) {
        Console.WriteLine(army.Id);
    }
}

