
var RoyalBank = await "Royal Bank Of Ayr".GetBank();

if(RoyalBank is null) Console.WriteLine(Code.AccountNotFound);


// var account = await Cosmin.Id.GetAccountPlayer();

// await Account.Deposit(account.AccountId, 50);


var Cosmin = await "CUrsache123".GetPlayer();
var Jules = await "JWhite123".GetPlayer();
if(Jules is null) Console.WriteLine(Code.AccountNotFound);
if(Cosmin is null) Console.WriteLine(Code.AccountNotFound);


var CosminAccount = await Cosmin.Id.GetAccountPlayer();
var JulesAccount = await Jules.Id.GetAccountPlayer();



Console.WriteLine(await Account.Transfer(CosminAccount, JulesAccount, 4000));





