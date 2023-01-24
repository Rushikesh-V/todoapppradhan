using Todo_Data.Models;

namespace Todo_Repository.Accounts
{
    public interface IAccountMain
    {
        public bool AddNewAccount(Account account);
        public bool Login(string Email, string Password);
        public void DeleteAccount(string Email);
        public void UpdateAccount(string Phonenumber);
        public List<Account> GetAllAccounts();
    }
}
