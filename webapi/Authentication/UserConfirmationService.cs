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
        public Guid GetConfirmationGuidSaved(User User)
        {
            DeleteExistingConfirmationGuidUnsaved(User);
            Guid Guid = GenerateConfirmationGuidUnsaved(User);
            _context.SaveChanges();

            return Guid;
        }
        private void DeleteExistingConfirmationGuidUnsaved(User User)
        {
            UserConfirmationGuid? ExistingGuid = _context.UserConfirmationGuids.FirstOrDefault(g => g.User == User);
            if(ExistingGuid != null) _context.UserConfirmationGuids.Remove(ExistingGuid);
        }
        private Guid GenerateConfirmationGuidUnsaved(User User)
        {
            Guid Guid = new Guid();

            UserConfirmationGuid NewConfirmationGuid = new UserConfirmationGuid
            {
                User = User,
                ConfirmationKey = Guid
            };

            _context.UserConfirmationGuids.Add(NewConfirmationGuid);

            return Guid;
        }
    }
}