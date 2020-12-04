namespace domain.paysimplex.Utilities
{
    using domain.paysimplex.Enums;

    public static class ModelExtensions
    {
        #region User
        public static Models.User ToModelUser(this data.paysimplex.Entities.User user)
        {
            return new Models.User
            {
                Id = user.Id,
                Login = user.Login,
                FullName = user.FullName,
                InsertDate = user.InsertDate,
                UpdateDate = user.UpdateDate,
                UserInsert = user.UserInsert,
                UserUpdate = user.UserUpdate
            };
        }

        public static data.paysimplex.Entities.User ToEntityUser(this Models.User user)
        {
            return new data.paysimplex.Entities.User
            {
                Id = user.Id,
                Login = user.Login,
                FullName = user.FullName,
                InsertDate = user.InsertDate,
                UpdateDate = user.UpdateDate,
                UserInsert = user.UserInsert,
                UserUpdate = user.UserUpdate
            };
        }
        #endregion User

        #region Task
        public static Models.Task ToModelTask(this data.paysimplex.Entities.Task task)
        {
            return new Models.Task
            {
                Id = task.Id,
                Description = task.Description,
                Title = task.Title,
                Start = task.StartDate,
                End = task.EndDate,
                State = (State)task.State,
                UserId = task.UserId,
                File = task.FileBlob,
                EstimatedTime = task.EstimatedTime,
                User = task.User?.ToModelUser(),
                InsertDate = task.InsertDate,
                UpdateDate = task.UpdateDate,
                UserInsert = task.UserInsert,
                UserUpdate = task.UserUpdate
            };
        }

        public static object ToViewModelTask(this Models.Task task)
        {
            return new
            {
                Id = task.Id,
                Description = task.Description,
                Title = task.Title,
                Start = task.Start,
                End = task.End,
                State = ((State)task.State).GetDescription(),
                UserId = task.UserId,
                File = task.File,
                EstimatedTime = task.EstimatedTime,
                User = task.User,
                InsertDate = task.InsertDate,
                UpdateDate = task.UpdateDate,
                UserInsert = task.UserInsert,
                UserUpdate = task.UserUpdate
            };
        }

        public static data.paysimplex.Entities.Task ToEntityTask(this Models.Task task)
        {
            return new data.paysimplex.Entities.Task
            {
                Id = task.Id,
                Description = task.Description,
                Title = task.Title,
                StartDate = task.Start,
                EndDate = task.End,
                State = (int)task.State,
                UserId = task.UserId,
                FileBlob = task.File,
                EstimatedTime = task.EstimatedTime,
                InsertDate = task.InsertDate,
                UpdateDate = task.UpdateDate,
                UserInsert = task.UserInsert,
                UserUpdate = task.UserUpdate
            };
        }

        #endregion Task
    }
}
