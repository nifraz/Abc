using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABC.CarTraders.Entities
{
    public abstract class Record
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? CreatedUserId { get; set; }
        public User CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }

        public int? LastModifiedUserId { get; set; }
        public User LastModifiedUser { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public int? DeletedUserId { get; set; }
        public User DeletedUser { get; set; }
        public DateTime? DeletedDate { get; set; }

        public string Notes { get; set; }
    }
}
