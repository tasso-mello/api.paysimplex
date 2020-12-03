namespace domain.paysimplex.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class ModelExtensions
    {
        #region User
        public static Models.User ToModelUser(this data.paysimplex.Entities.User user)
        {
            return new Models.User
            {
                Id = user.Id,
                Login = user.Login,
                FullName = user.FullName
            };
        }

        public static data.paysimplex.Entities.User ToEntityUser(this Models.User user)
        {
            return new data.paysimplex.Entities.User
            {
                Id = user.Id,
                Login = user.Login,
                FullName = user.FullName
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
                Start = task.Start,
                End = task.End,
                State = task.State,
                UserId = task.UserId,
                File = task.File,
                User = task.User?.ToModelUser()
            };
        }

        public static data.paysimplex.Entities.Task ToEntityTask(this Models.Task task)
        {
            return new data.paysimplex.Entities.Task
            {
                Id = task.Id,
                Description = task.Description,
                Title = task.Title,
                Start = task.Start,
                End = task.End,
                State = task.State,
                UserId = task.UserId,
                File = task.File
            };
        }
        #endregion Task
    }
}
