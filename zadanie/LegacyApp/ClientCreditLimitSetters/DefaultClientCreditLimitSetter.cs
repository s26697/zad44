namespace LegacyApp;

public class DefaultClientCreditLimitSetter : ICreditLimitSetter
{
    public void SetCreditLimit(User user, ICreditLimitService creditLimitService)
    {
        user.HasCreditLimit = true;
        int creditLimit = creditLimitService.GetCreditLimit(user.LastName, user.DateOfBirth);
        user.CreditLimit = creditLimit;
    }
}