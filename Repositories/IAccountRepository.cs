using BusinessObjects;

namespace Repositories
{
    public interface IAccountRepository
    {
        AccountMember GetAccountByEmail(string email);
    }
}
