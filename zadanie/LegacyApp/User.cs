using System;

namespace LegacyApp
{
    public class User
    {
        public object Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }


        public User(string firstName, string lastName, string email, DateTime dateOfBirth, object client)
        {
            {
                Client = client;
                DateOfBirth = dateOfBirth;
                EmailAddress = email;
                FirstName = firstName;
                LastName = lastName;

            }
        }

        public static bool ValidateName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            return true;
        }

        public static bool ValidateEmail(string email)
        {
            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }

            return true;
        }

        public static bool ValidateAge(DateTime dateOfBirth)
        {
            int age = CalculateAge(dateOfBirth);
            
            if (age < 21)
            {
                return false;
            }

            return true;
        }

        internal static int CalculateAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
            return age;
        }

        public static bool ValidateCreditLimit(User user)
        {
            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            return true;
        }
        
        
        
        
        
    }

   
    
    
    
    
    
    
}