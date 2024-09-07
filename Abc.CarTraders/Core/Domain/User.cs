using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Core.Domain
{
    public class User
    {
        //domain props
        public string Username { get; set; } //pk
        public string Password { get; set; } //req
        public string Name { get; set; } //req
        public UserSex Sex { get; set; } //req
        public string EMail { get; set; } //opt
        public string PhoneNo { get; set; } //opt
        public UserRole Role { get; set; } //req
        public string Notes { get; set; } //opt

        //extra domain props
        public DateTime? CreatedOn { get; set; } //gen
        public User CreatedBy { get; set; } //gen
        public DateTime? ModifiedOn { get; set; } //gen
        public User ModifiedBy { get; set; } //gen

        //child props
        public ICollection<VsRange> CreatedVsRanges { get; set; }
        public ICollection<VsRange> ModifiedVsRanges { get; set; }
        public ICollection<Institute> CreatedInstitutes { get; set; }
        public ICollection<Institute> ModifiedInstitutes { get; set; }
        public ICollection<Technician> CreatedTechnicians { get; set; }
        public ICollection<Technician> ModifiedTechnicians { get; set; }
        public ICollection<CalvingSheet> CreatedCalvingSheets { get; set; }
        public ICollection<CalvingSheet> ModifiedCalvingSheets { get; set; }
        public ICollection<User> CreatedUsers { get; set; }
        public ICollection<User> ModifiedUsers { get; set; }
        public ICollection<Log> Logs { get; set; }

        //fk props
        public string CreatedByUsername { get; set; } //fk User
        public string ModifiedByUsername { get; set; } //fk User

        public User()
        {
            CreatedVsRanges = new HashSet<VsRange>();
            ModifiedVsRanges = new HashSet<VsRange>();
            CreatedInstitutes = new HashSet<Institute>();
            ModifiedInstitutes = new HashSet<Institute>();
            CreatedTechnicians = new HashSet<Technician>();
            ModifiedTechnicians = new HashSet<Technician>();
            CreatedCalvingSheets = new HashSet<CalvingSheet>();
            ModifiedCalvingSheets = new HashSet<CalvingSheet>();
            CreatedUsers = new HashSet<User>();
            ModifiedUsers = new HashSet<User>();
            Logs = new HashSet<Log>();
        }

        //methods
        public override string ToString()
        {
            return $"{Username} ({Role})";
        }
        public static string GetHashSha1(string text)
        {
            var sha1 = SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(text);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++) sb.Append(hash[i].ToString("X2"));
            return sb.ToString();
        }
    }

    public enum UserRole : byte
    {
        Admin = 1,
        Director = 2,
        Doctor = 3,
        Staff = 4,
        Trainee = 5
    }

    public enum UserSex : byte
    {
        Female = 0,
        Male = 1
    }
}
