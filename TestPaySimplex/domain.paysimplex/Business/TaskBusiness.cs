namespace domain.paysimplex.Business
{
    using data.paysimplex.Repository;
    using domain.paysimplex.Contracts.Business;
    using domain.paysimplex.Models;
    using domain.paysimplex.Utilities;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class TaskBusiness : ITaskBusiness
    {
        #region Attributes
        private readonly ILogger<domain.paysimplex.Models.Task> _logger;
        private readonly ITaskRepository _taskRepository;
        #endregion Attributes

        #region Constructor
        public TaskBusiness(ILogger<domain.paysimplex.Models.Task> logger, ITaskRepository taskRepository)
        {
            _logger = logger;
            _taskRepository = taskRepository;
        }
        #endregion

        #region Public Methods

        public async Task<object> Get()
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

        public async Task<object> GetById(long id)
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

        public async Task<object> GetByName(string name)
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

        public async Task<object> Save(Models.Task obj, long idUser)
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

        public async Task<object> Update(Models.Task obj, long idUser)
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

        public async Task<object> Delete(Models.Task obj)
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

        public async Task<object> AttachTaskFile(IFormFile file, long idTask, long idUser)
        {
            try
            {
                var base64File = string.Empty;

                if (file.Length > 0)
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        base64File = Convert.ToBase64String(fileBytes);
                    }

                var taskToUpdate = _taskRepository.GetById(idTask);

                taskToUpdate.FileBlob = base64File;

                _taskRepository.Update(taskToUpdate, idUser);
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
