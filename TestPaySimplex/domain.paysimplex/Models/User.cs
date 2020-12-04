namespace domain.paysimplex.Models
{
    using domain.paysimplex.Models.Base;

    public class User: BaseModel
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string FullName { get; set; }
    }
}
