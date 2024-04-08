namespace LegacyApp;

public interface ICreditLimitSetter
{
    void SetCreditLimit(User user, ICreditLimitService creditLimitService);
}