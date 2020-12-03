namespace data.paysimplex.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Base;

    [Table("Task")]
    public class Task: BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int State { get; set; } = 1;
        public DateTime? Start { get; set; } = DateTime.Today;
        public DateTime? End { get; set; }
        public string File { get; set; } //Blob

        [ForeignKey("User")]
        public long? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
