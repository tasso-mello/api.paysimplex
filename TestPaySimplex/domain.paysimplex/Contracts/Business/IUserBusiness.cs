namespace domain.paysimplex.Contracts.Business
{
    using domain.paysimplex.Contracts.Base;
    using domain.paysimplex.Models;

    public interface IUserBusiness: IGenericReadBusiness<User>, IGenericPersistBusiness<User> { }
}
