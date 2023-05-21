using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperClassLibrary;

namespace BankClassLibrary
{
    public class Account
    {
        public Account(Guid holder, Name name)
        {
            this.AccountId = holder;
            this.Name = name;
        }

        public Name Name { get; set; }

        private decimal Balance { get; set; } = 0;

        public Guid AccountId { get; set; }

        public decimal GetBalance() => Balance;


        #region Withdrawl

        public static Code Withdrawl(Guid accountGuid, decimal amount)
        {
            Bank.SearchAllBankAccounts(() => accountGuid, out Account? foundAccount);

            if (foundAccount is null) return Code.AccountNotFound;

            if (foundAccount.Balance >= amount) foundAccount.Balance -= amount;

            else return Code.InsufficientFunds;

            return Code.Ok;
        }

        #endregion

        #region Transfer
        public static Code Transfer(Func<Name> WithdrawingAccount, decimal TransferAmount, Func<Name> IntendedRecipient)
        {

            Bank.SearchAllBankAccounts(WithdrawingAccount, out Account? account);
            Bank.SearchAllBankAccounts(IntendedRecipient, out Account? recipientAccount);

            if (account is null) return Code.AccountNotFound;

            if (recipientAccount is null) return Code.AccountNotFound;

            if (TransferAmount > account.Balance) return Code.InsufficientFunds;

            // Deposit(recipientAccount.AccountId, TransferAmount, x => x.Id);

            // account.Withdraw(TransferAmount);

            return Code.Ok; 
        }
        #endregion

        #region Deposit
        public static Code Deposit(Guid accountGuid, decimal amount)
        {
            Bank.SearchAllBankAccounts(() => accountGuid, out Account? foundAccount);

            if (foundAccount is null) return Code.AccountNotFound;
            

            foundAccount.Balance += amount;

            return Code.Ok;
        }

        #endregion



    }




}

