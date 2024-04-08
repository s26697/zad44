namespace LegacyApp;

public class ImportantClientCreditLimitSetter : ICreditLimitSetter
{
    public void SetCreditLimit(User user, ICreditLimitService creditLimitService)
    {
        int creditLimit = creditLimitService.GetCreditLimit(user.LastName, user.DateOfBirth);
        creditLimit = creditLimit * 2;
        user.CreditLimit = creditLimit;
    }
}