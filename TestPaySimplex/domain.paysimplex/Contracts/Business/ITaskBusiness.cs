namespace domain.paysimplex.Contracts.Business
{
    using domain.paysimplex.Contracts.Base;
    using domain.paysimplex.Models;

    public interface ITaskBusiness: IGenericReadBusiness<Task>, IGenericPersistBusiness<Task> { }
}
