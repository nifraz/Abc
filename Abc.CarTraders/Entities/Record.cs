using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABC.CarTraders.Entities
{
    public class Record
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public long CreatedUserId { get; set; }
        [Required]
        public User CreatedUser { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public long? LastModifiedUserId { get; set; }
        public User LastModifiedUser { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public long? DeletedUserId { get; set; }
        public User DeletedUser { get; set; }
        public DateTime? DeletedDate { get; set; }

        public string Notes { get; set; }
    }
}
