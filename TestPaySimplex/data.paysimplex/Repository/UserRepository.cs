namespace data.paysimplex.Repository
{
    using data.paysimplex.Context;
    using data.paysimplex.Entities;
    using data.paysimplex.Infrastructure;

    public interface IUserRepository : IRepository<User> { }
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(PaySimplexContext dbContext) : base(dbContext) { }
    }
}
