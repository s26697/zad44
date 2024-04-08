using System;

namespace LegacyApp;

public interface ICreditLimitService
{
    int GetCreditLimit(string lastName, DateTime birthdate);
}