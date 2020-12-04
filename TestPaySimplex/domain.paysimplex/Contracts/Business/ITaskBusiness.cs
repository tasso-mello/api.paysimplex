namespace domain.paysimplex.Contracts.Business
{
    using domain.paysimplex.Contracts.Base;
    using domain.paysimplex.Models;
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public interface ITaskBusiness: IGenericReadBusiness<Models.Task>, IGenericPersistBusiness<Models.Task> 
    {
        Task<object> AttachTaskFile(IFormFile file, long idTask, long idUser);
        Task<object> GetDuration(long id);
    }
}
