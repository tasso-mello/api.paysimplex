namespace data.paysimplex.Entities
{
    using Base;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public class User : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public string Login { get; set; }
        public string FullName { get; set; }
    }
}
