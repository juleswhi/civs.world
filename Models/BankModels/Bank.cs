using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperClassLibrary;

namespace BankClassLibrary
{
    public class Bank
    {
        static Bank()
        {
            Banks = new List<Bank>();
        }

        public Bank()
        {
            this.Id = Guid.NewGuid();
            this.Accounts = new List<Account>();
            Bank.Banks.Add(this);
        }

        private Guid Id { get; set; }

        public static List<Bank> Banks { get; set; }

        private List<Account> Accounts { get; set; }

        public Guid CreateAccount(Name name)
        {
            Guid id = Guid.NewGuid();

            Accounts.Add(new Account(id, name));

            return id;
        }


        #region Search For Accounts
        private static bool SearchAccounts(Name name, out Account? FoundAccount, List<Account> accounts)
        {
            var Matches = new List<Account>();

            foreach(var account in accounts)
            {
                if(account.Name.Surname == name.Surname)
                {
                    if(account.Name.FirstName == name.FirstName)
                    {
                        Matches.Add(account);
                    }
                }
            }



            if(Matches.Count == 1)
            {
                FoundAccount = Matches[0];
                return true;
            }

            FoundAccount = null;
            return false;
        }

        private static bool SearchAccounts(Guid AccountGuid, out Account? FoundAccount, List<Account> accounts)
        {
            Account? Match = null;

            foreach(var account in accounts)
            {
                if(account.AccountId == AccountGuid)
                {
                    Match = account;
                }
            }
            FoundAccount = Match;

            if (Match is null) return false;

            return true;
            
        }


        public static Code SearchAllBankAccounts(Func<Name> SearchName, out Account? account)
        {
            Account? foundAccount = null;
            foreach(var _bank in Bank.Banks)
            {
                Bank.SearchAccounts(SearchName(), out foundAccount, _bank.Accounts);
                if (foundAccount is not null) break;
            }

            account = foundAccount;

            if (foundAccount is null) return Code.AccountNotFound;
           
            return Code.Ok;
        }

        public static Code SearchAllBankAccounts(Func<Guid> SearchGuid, out Account? account)
        {
            Account? foundAccount = null;
            foreach (var _bank in Bank.Banks)
            {
                Bank.SearchAccounts(SearchGuid(), out foundAccount, _bank.Accounts);
                if(foundAccount is not null) break;
            }

            account = foundAccount;

            if (foundAccount is null) return Code.AccountNotFound;
            
            return Code.Ok;
        }

        #endregion




    }
}
