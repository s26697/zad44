using System;

namespace LegacyApp
{
    
    public class UserService
    {
        
        
        private ICreditLimitSetter _creditLimitSetter;
        private IClientRepository _clientRepository;
        private ICreditLimitService _creditLimitService;

        [Obsolete]
        public UserService()
        {
            _clientRepository = new ClientRepository();
            _creditLimitService = new UserCreditService();
        }
        
        
        public UserService(IClientRepository clientRepository,
            ICreditLimitService creditLimitService)
        {
            _clientRepository = clientRepository;
            _creditLimitService = creditLimitService;
            
        }
        
        
        
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {

            if (!User.ValidateName(firstName, lastName) || !User.ValidateEmail(email) ||
                !User.ValidateAge(dateOfBirth)) return false;
           
            
            var client = _clientRepository.GetById(clientId);
            var user = new User(firstName, lastName, email, dateOfBirth, client);
           
            
            
            if (client.Type == "VeryImportantClient")
            {
                _creditLimitSetter = new VeryImportantClientCreditLimitSetter();
            }
            else if (client.Type == "ImportantClient")
            {
                _creditLimitSetter = new ImportantClientCreditLimitSetter();
            }
            else
            {
                _creditLimitSetter = new DefaultClientCreditLimitSetter();
            }

           
            _creditLimitSetter.SetCreditLimit(user, _creditLimitService);
            
           
            User.ValidateCreditLimit(user);
            
            
            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
