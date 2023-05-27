# Bank.cs - Class

## **Methods**

- ***None***

## **Properties**

- Id
- BankName
- Accounts
- CountryOfOrigin


<br>
<br>

# Account.cs - Class

## **Methods**

- ***CreateAccount***(*Guid? playerGuid, Guid? bankGuid*), returns status code
  
- ***Withdrawl***(*Account account, decimal amount*), returns status code
- ***Transfer***(*Account WithdrawAccount, Account RecipientAccount, decimal TransferAmount*) returns status code
- ***Deposit***(*Account account, decimal amount*) returns status code

## **Properties**

- AccountId
- PlayerId
- BankId
- Balance