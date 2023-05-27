var RoyalBank = await "Royal Bank Of Ayr".GetBank();

if(RoyalBank is null) Console.WriteLine(Code.AccountNotFound);

string name = "JWhite123";


var jules = await DataBaseClient.PlayerCollection.FindAsync(
    Builders<Player>.Filter.Eq(x => x.Username, name)
);



Player Jules = jules.FirstOrDefault();

if(Jules is null) Console.WriteLine(Code.AccountNotFound);

await Jules.JoinAlliance("Alliance of Awesomeness");