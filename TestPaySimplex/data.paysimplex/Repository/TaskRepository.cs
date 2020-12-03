namespace data.paysimplex.Repository
{
    using data.paysimplex.Context;
    using data.paysimplex.Entities;
    using data.paysimplex.Infrastructure;

    public interface ITaskRepository : IRepository<Task> { }
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public TaskRepository(PaySimplexContext dbContext) : base(dbContext) { }
    }
}
