using webapi.Data;
using webapi.Models;

namespace webapi.Authentication
{
    public class UserConfirmationService
    {
        private readonly ApplicationContext _context;
        public UserConfirmationService(ApplicationContext Context)
        {
            _context = Context;
        }
        public string GenerateConfirmationKeySaved(User User)
        {
            DeleteExistingConfirmationKeyUnsaved(User);

            string Key = Guid.NewGuid().ToString();

            UserConfirmationKey NewConfirmationKey = new UserConfirmationKey
            {
                User = User,
                Value = Key
            };

            _context.UserConfirmationKeys.Add(NewConfirmationKey);
            _context.SaveChanges();

            return Key;
        }
        public bool ValidateUserConfirmationKey(User User , string ProposedKey)
        {
            UserConfirmationKey? ValidKey = _context.UserConfirmationKeys.FirstOrDefault(g => g.User == User);

            return (ValidKey != null) && (ValidKey.Value == ProposedKey);
        }
        public bool ConfirmUserSaved(User User)
        {
            DeleteExistingConfirmationKeyUnsaved(User);
            User.EmailIsConfirmed = true;
            _context.SaveChanges();
            return true;
        }
        private void DeleteExistingConfirmationKeyUnsaved(User User)
        {
            UserConfirmationKey? ExistingKey = _context.UserConfirmationKeys.FirstOrDefault(g => g.User == User);
            if(ExistingKey != null) _context.UserConfirmationKeys.Remove(ExistingKey);
        }
    }
}