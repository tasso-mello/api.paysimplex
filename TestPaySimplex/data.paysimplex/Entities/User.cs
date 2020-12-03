namespace data.paysimplex.Entities
{
    using Base;

    public class User : BaseEntity
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string FullName { get; set; }
    }
}
