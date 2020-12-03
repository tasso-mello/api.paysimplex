namespace domain.paysimplex.Contracts.Base
{
    using System.Threading.Tasks;

    public interface IGenericPersistBusiness<TEntity> where TEntity : class
    {
        Task<object> Save(TEntity obj, long idUser);
        Task<object> Update(TEntity obj, long idUser);
        Task<object> Delete(TEntity obj);
    }
}
