namespace LegacyApp;

public class VeryImportantClientCreditLimitSetter : ICreditLimitSetter
{
    public void SetCreditLimit(User user, ICreditLimitService creditLimitService)
    {
        user.HasCreditLimit = false;
    }
}