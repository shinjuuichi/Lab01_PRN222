using BusinessObjects;

namespace Services
{
    public interface IAccountService
    {
        AccountMember GetAccountByEmail(string accountID);
    }
}
