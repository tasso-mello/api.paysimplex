namespace domain.paysimplex.Business
{
    using data.paysimplex.Repository;
    using domain.paysimplex.Contracts.Business;
    using domain.paysimplex.Models;
    using domain.paysimplex.Utilities;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserBusiness : IUserBusiness
    {
        #region Attributes

        private readonly ILogger<User> _logger;
        private readonly IUserRepository _userRepository;

        #endregion Attributes

        #region Constructor

        public UserBusiness(ILogger<User> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        #endregion

        #region Public Methods

        public async Task<object> Get()
        {
            try
            {
                return Messages.GenerateGenericSuccessObjectMessage("User", _userRepository.GetAll().Select(e => e.ToModelUser()), 200);
            }
            catch (NullReferenceException e)
            {
                _logger.LogError(e.Message ?? e.InnerException.Message, null);
                return Messages.GenerateGenericNullErrorMessage("User", "O registro não existe.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message ?? e.InnerException.Message, null);
                return (e.Message != null && e?.InnerException?.Message != null) ? Messages.GenerateGenericErrorMessage(e.Message, e.InnerException.Message) : Messages.GenerateGenericErrorMessage(e.Message ?? e.InnerException.Message);
            }
        }

        public async Task<object> GetById(long id)
        {
            try
            {
                return Messages.GenerateGenericSuccessObjectMessage("User", _userRepository.Get(p => p.Id == id).ToModelUser(), 200);
            }
            catch (NullReferenceException)
            {
                return Messages.GenerateGenericNullErrorMessage("User", "O registro não existe.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message ?? e.InnerException.Message, null);
                return (e.Message != null && e?.InnerException?.Message != null) ? Messages.GenerateGenericErrorMessage(e.Message, e.InnerException.Message) : Messages.GenerateGenericErrorMessage(e.Message ?? e.InnerException.Message);
            }
        }

        public async Task<object> GetByName(string name)
        {
            try
            {
                return Messages.GenerateGenericSuccessObjectMessage("User", _userRepository.GetMany(e => e.Login.Contains(name)).Select(e => e.ToModelUser()), 200);
            }
            catch (NullReferenceException)
            {
                return Messages.GenerateGenericNullErrorMessage("User", "O registro não existe.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message ?? e.InnerException.Message, null);
                return (e.Message != null && e?.InnerException?.Message != null) ? Messages.GenerateGenericErrorMessage(e.Message, e.InnerException.Message) : Messages.GenerateGenericErrorMessage(e.Message ?? e.InnerException.Message);
            }
        }

        public async Task<object> Save(User obj, long idUser)
        {
            try
            {
                _userRepository.Add(obj.ToEntityUser(), idUser);
                _userRepository.SaveChanges();
                return Messages.GenerateGenericSuccessObjectMessage("User", "Sucesso", 201);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message ?? e.InnerException.Message, null);
                return (e.Message != null && e?.InnerException?.Message != null) ? Messages.GenerateGenericErrorMessage(e.Message, e.InnerException.Message) : Messages.GenerateGenericErrorMessage(e.Message ?? e.InnerException.Message);
            }
        }

        public async Task<object> Update(User obj, long idUser)
        {
            try
            {
                _userRepository.Update(obj.ToEntityUser(), idUser);
                _userRepository.SaveChanges();
                return Messages.GenerateGenericSuccessObjectMessage("User", "Sucesso", 200);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message ?? e.InnerException.Message, null);
                return (e.Message != null && e?.InnerException?.Message != null) ? Messages.GenerateGenericErrorMessage(e.Message, e.InnerException.Message) : Messages.GenerateGenericErrorMessage(e.Message ?? e.InnerException.Message);
            }
        }

        public async Task<object> Delete(User obj)
        {
            try
            {
                _userRepository.Delete(obj.ToEntityUser());
                _userRepository.SaveChanges();
                return Messages.GenerateGenericSuccessObjectMessage("User", "Sucesso", 200);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message ?? e.InnerException.Message, null);
                return (e.Message != null && e?.InnerException?.Message != null) ? Messages.GenerateGenericErrorMessage(e.Message, e.InnerException.Message) : Messages.GenerateGenericErrorMessage(e.Message ?? e.InnerException.Message);
            }
        }
        
        #endregion Public Methods
    }
}
