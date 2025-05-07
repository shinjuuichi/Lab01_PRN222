using BusinessObjects;

namespace DataAccessObjects
{
    public class AccountDAO
    {

        private readonly MyStoreContext _context;

        public AccountDAO(MyStoreContext context)
        {
            _context = context;
        }
        public AccountMember GetAccountByEmail(string email)
        {
            return _context.AccountMembers.FirstOrDefault(c => c.EmailAddress.Equals(email));
        }
    }
}
