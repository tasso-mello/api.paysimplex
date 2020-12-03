namespace domain.paysimplex.Business
{
    using data.paysimplex.Repository;
    using domain.paysimplex.Contracts.Business;
    using domain.paysimplex.Models;
    using domain.paysimplex.Utilities;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TaskBusiness : ITaskBusiness
    {
        #region Attributes
        private readonly ILogger<Task> _logger;
        private readonly ITaskRepository _taskRepository;
        #endregion Attributes

        #region Constructor
        public TaskBusiness(ILogger<Task> logger, ITaskRepository taskRepository)
        {
            _logger = logger;
            _taskRepository = taskRepository;
        }
        #endregion

        #region Public Methods

        public object Get()
        {
            try
            {
                return Messages.GenerateGenericSuccessObjectMessage("Task", _taskRepository.GetAll(GetUserIncludes()).Select(e => e.ToModelTask()), 200);
            }
            catch (NullReferenceException e)
            {
                _logger.LogError(e.Message ?? e.InnerException.Message, null);
                return Messages.GenerateGenericNullErrorMessage("Task", "O registro não existe.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message ?? e.InnerException.Message, null);
                return (e.Message != null && e?.InnerException?.Message != null) ? Messages.GenerateGenericErrorMessage(e.Message, e.InnerException.Message) : Messages.GenerateGenericErrorMessage(e.Message ?? e.InnerException.Message);
            }
        }

        public object GetById(long id)
        {
            try
            {
                return Messages.GenerateGenericSuccessObjectMessage("Task", _taskRepository.Get(p => p.Id == id, GetUserIncludes()).ToModelTask(), 200);
            }
            catch (NullReferenceException)
            {
                return Messages.GenerateGenericNullErrorMessage("Task", "O registro não existe.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message ?? e.InnerException.Message, null);
                return (e.Message != null && e?.InnerException?.Message != null) ? Messages.GenerateGenericErrorMessage(e.Message, e.InnerException.Message) : Messages.GenerateGenericErrorMessage(e.Message ?? e.InnerException.Message);
            }
        }

        public object GetByName(string name)
        {
            try
            {
                return Messages.GenerateGenericSuccessObjectMessage("Task", _taskRepository.GetMany(e => e.Title.Contains(name), GetUserIncludes()).Select(e => e.ToModelTask()), 200);
            }
            catch (NullReferenceException)
            {
                return Messages.GenerateGenericNullErrorMessage("Task", "O registro não existe.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message ?? e.InnerException.Message, null);
                return (e.Message != null && e?.InnerException?.Message != null) ? Messages.GenerateGenericErrorMessage(e.Message, e.InnerException.Message) : Messages.GenerateGenericErrorMessage(e.Message ?? e.InnerException.Message);
            }
        }

        public object Save(Task obj, long idUser)
        {
            try
            {
                _taskRepository.Add(obj.ToEntityTask(), idUser);
                _taskRepository.SaveChanges();
                return Messages.GenerateGenericSuccessObjectMessage("Task", "Sucesso", 201);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message ?? e.InnerException.Message, null);
                return (e.Message != null && e?.InnerException?.Message != null) ? Messages.GenerateGenericErrorMessage(e.Message, e.InnerException.Message) : Messages.GenerateGenericErrorMessage(e.Message ?? e.InnerException.Message);
            }
        }

        public object Update(Task obj, long idUser)
        {
            try
            {
                _taskRepository.Update(obj.ToEntityTask(), idUser);
                _taskRepository.SaveChanges();
                return Messages.GenerateGenericSuccessObjectMessage("Task", "Sucesso", 200);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message ?? e.InnerException.Message, null);
                return (e.Message != null && e?.InnerException?.Message != null) ? Messages.GenerateGenericErrorMessage(e.Message, e.InnerException.Message) : Messages.GenerateGenericErrorMessage(e.Message ?? e.InnerException.Message);
            }
        }

        public object Delete(Task obj)
        {
            try
            {
                _taskRepository.Delete(obj.ToEntityTask());
                _taskRepository.SaveChanges();
                return Messages.GenerateGenericSuccessObjectMessage("Task", "Sucesso", 200);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message ?? e.InnerException.Message, null);
                return (e.Message != null && e?.InnerException?.Message != null) ? Messages.GenerateGenericErrorMessage(e.Message, e.InnerException.Message) : Messages.GenerateGenericErrorMessage(e.Message ?? e.InnerException.Message);
            }
        }

        #endregion

        #region Private Methods

        private List<string> GetUserIncludes()
        {
            return new List<string> { "User" };
        }

        #endregion Private Methods
    }
}
