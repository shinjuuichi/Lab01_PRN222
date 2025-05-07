using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
