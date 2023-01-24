using Azure.Core;
using Todo_Data.Models;

namespace Todo_Repository.Accounts
{
    public class AccountMain:IAccountMain
    {
        TodoDbContext db;
        public AccountMain() 
        {
            db = new TodoDbContext();
        }

        public bool AddNewAccount(Account account)
        {
            bool CheckExistingEmail = db.Accounts.Any(acc => acc.Email == account.Email); 
            
            if(!CheckExistingEmail ) 
            {
                Account account1 = new();
                //account1.AccId = account.AccId;
                account1.Username = account.Username;
                account1.Password = account.Password;
                account1.Email = account.Email;
                account1.Phone = account.Phone;
                account1.Status = 0;
                account1.DateCreated = DateTime.Now;

                db.Accounts.Add(account1);
                db.SaveChanges();

                return true;
            }
            else
            {
                Account account1 = db.Accounts.Where(acc => acc.Email == account.Email).FirstOrDefault();
                if( account1.Status == 3)
                {
                    account1.Status = 0;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        
        public bool Login(string Email,string Password)
        {
            bool CheckExistingEmail = db.Accounts.Any(acc => acc.Email == Email);

            if (CheckExistingEmail)
            {
                Account account1 = db.Accounts.Where(acc => acc.Email == Email).FirstOrDefault();
                if (Password == account1.Password)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public void DeleteAccount(string Email)
        {
            Account account1 = db.Accounts.Where(acc => acc.Email == Email).FirstOrDefault();
            account1.Status = 3;

            db.SaveChanges();
        }

        public void UpdateAccount(string Phonenumber)
        {
            
        }

        public List<Account> GetAllAccounts()
        {
            List<Account> req = db.Accounts.ToList();
            return req;
        }
    }
}
