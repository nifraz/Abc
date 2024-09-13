namespace ABC.CarTraders.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //context.Users.AddOrUpdate(u => u.Username,
            //    new User()
            //    {
            //        Username = "nifraz",
            //        Password = User.GetHashSha1("1122"),
            //        Name = "M. Nifraz Navahz",
            //        Sex = UserSex.Male,
            //        EMail = "nifraz@live.com",
            //        PhoneNo = "712319319",
            //        Role = UserRole.Admin,
            //        Notes = "Developer",
            //        //CreatedByUsername = "nifraz"
            //    },
            //    new User()
            //    {
            //        Username = "old_trainees",
            //        Password = User.GetHashSha1("oooo"),
            //        Name = "Old Trainees",
            //        Sex = UserSex.Male,
            //        EMail = null,
            //        PhoneNo = null,
            //        Role = UserRole.Trainee,
            //        Notes = null,
            //        CreatedByUsername = "nifraz"
            //    },
            //    new User()
            //    {
            //        Username = "jayathissa",
            //        Password = User.GetHashSha1("jjjj"),
            //        Name = "S.G.S.K. Jayathissa",
            //        Sex = UserSex.Male,
            //        EMail = null,
            //        PhoneNo = null,
            //        Role = UserRole.Trainee,
            //        Notes = null,
            //        CreatedByUsername = "nifraz"
            //    },
            //    new User() { Username = "rasika", Password = User.GetHashSha1("rrrr"), Name = "Rasika", Sex = UserSex.Male, Role = UserRole.Admin, CreatedByUsername = "nifraz" },
            //    new User() { Username = "nimeshi", Password = User.GetHashSha1("nnnn"), Name = "Nimeshani", Sex = UserSex.Female, Role = UserRole.Staff, CreatedByUsername = "nifraz" },
            //    new User() { Username = "anushika", Password = User.GetHashSha1("aaaa"), Name = "Anushika", Sex = UserSex.Female, Role = UserRole.Staff, CreatedByUsername = "nifraz" },
            //    new User() { Username = "aruni", Password = User.GetHashSha1("aaaa"), Name = "Aruni", Sex = UserSex.Female, Role = UserRole.Doctor, CreatedByUsername = "nifraz" },
            //    new User() { Username = "duleep", Password = User.GetHashSha1("dddd"), Name = "Duleep", Sex = UserSex.Male, Role = UserRole.Doctor, CreatedByUsername = "nifraz" },
            //    new User() { Username = "senavirathne", Password = User.GetHashSha1("ssss"), Name = "Senavirathne", Sex = UserSex.Male, Role = UserRole.Director, CreatedByUsername = "nifraz" },
            //    new User() { Username = "chathu", Password = User.GetHashSha1("cccc"), Name = "Chathuri", Sex = UserSex.Female, Role = UserRole.Trainee, CreatedByUsername = "nifraz" }
            //);

            //context.Provinces.AddOrUpdate(p => p.No,
            //    new Province() { No = 1, Name = "Western", SinhalaName = "බස්නාහිර", TamilName = "மேற்கு" },
            //    new Province() { No = 2, Name = "Central", SinhalaName = "මධ්‍යම", TamilName = "மத்திய" },
            //    new Province() { No = 3, Name = "Southern", SinhalaName = "දකුණු", TamilName = "தெற்கு" },
            //    new Province() { No = 4, Name = "Northern", SinhalaName = "උතුරු", TamilName = "வடக்கு" },
            //    new Province() { No = 5, Name = "Eastern", SinhalaName = "නැගෙනහිර", TamilName = "கிழக்கு" },
            //    new Province() { No = 6, Name = "North Western", SinhalaName = "වයඹ", TamilName = "வடமேற்கு" },
            //    new Province() { No = 7, Name = "North Central", SinhalaName = "උතුරුමැද", TamilName = "வடமத்திய" },
            //    new Province() { No = 8, Name = "Uva", SinhalaName = "ඌව", TamilName = "ஊவா" },
            //    new Province() { No = 9, Name = "Sabaragamuwa", SinhalaName = "සබරගමුව", TamilName = "சபரகமுவா" }
            //);

            //context.Districts.AddOrUpdate(d => new { d.ProvinceNo, d.No },
            //    new District() { ProvinceNo = 1, No = 1, Name = "Colombo", SinhalaName = "කොළඹ", TamilName = "கொழும்பு" },
            //    new District() { ProvinceNo = 1, No = 2, Name = "Gampaha", SinhalaName = "ගම්පහ", TamilName = "கம்பகா" },
            //    new District() { ProvinceNo = 1, No = 3, Name = "Kalutara", SinhalaName = "කළුතර", TamilName = "களுத்துறை" },

            //    new District() { ProvinceNo = 2, No = 1, Name = "Kandy", SinhalaName = "මහනුවර", TamilName = "கண்டி" },
            //    new District() { ProvinceNo = 2, No = 2, Name = "Matale", SinhalaName = "මාතලේ", TamilName = "மாத்தளை" },
            //    new District() { ProvinceNo = 2, No = 3, Name = "Nuwara Eliya", SinhalaName = "නුවරඑළිය", TamilName = "நுவரெலியா" },

            //    new District() { ProvinceNo = 3, No = 1, Name = "Galle", SinhalaName = "ගාල්ල", TamilName = "காலி" },
            //    new District() { ProvinceNo = 3, No = 2, Name = "Matara", SinhalaName = "මාතර", TamilName = "மாத்தறை" },
            //    new District() { ProvinceNo = 3, No = 3, Name = "Hambantota", SinhalaName = "හම්බන්තොට", TamilName = "அம்பாந்தோட்டை" },

            //    new District() { ProvinceNo = 4, No = 1, Name = "Jaffna", SinhalaName = "යාපනය", TamilName = "யாழ்ப்பாணம்" },
            //    new District() { ProvinceNo = 4, No = 2, Name = "Mannar", SinhalaName = "මන්නාරම", TamilName = "மன்னார்" },
            //    new District() { ProvinceNo = 4, No = 3, Name = "Vavuniya", SinhalaName = "වවුනියාව", TamilName = "வவுனியா" },
            //    new District() { ProvinceNo = 4, No = 4, Name = "Mullativu", SinhalaName = "මුලතිව්", TamilName = "முல்லைத்தீவு" },
            //    new District() { ProvinceNo = 4, No = 5, Name = "Killinochchi", SinhalaName = "කිලිනොච්චිය", TamilName = "கிளிநொச்சி" },

            //    new District() { ProvinceNo = 5, No = 1, Name = "Batticaloa", SinhalaName = "මඩකලපුව", TamilName = "மட்டக்களப்பு" },
            //    new District() { ProvinceNo = 5, No = 2, Name = "Ampara", SinhalaName = "අම්පාර", TamilName = "அம்பாறை" },
            //    new District() { ProvinceNo = 5, No = 3, Name = "Trincomalee", SinhalaName = "ත්‍රිකුණාමල", TamilName = "திருகோணமலை" },

            //    new District() { ProvinceNo = 6, No = 1, Name = "Kurunegala", SinhalaName = "කුරුණෑගල", TamilName = "குருநாகல்" },
            //    new District() { ProvinceNo = 6, No = 2, Name = "Puttalam", SinhalaName = "පුත්තලම", TamilName = "புத்தளம்" },

            //    new District() { ProvinceNo = 7, No = 1, Name = "Anuradhapura", SinhalaName = "අනුරාධපුර", TamilName = "அனுராதபுரம்" },
            //    new District() { ProvinceNo = 7, No = 2, Name = "Polonnaruwa", SinhalaName = "පොලොන්නරු", TamilName = "பொலநறுவை" },

            //    new District() { ProvinceNo = 8, No = 1, Name = "Badulla", SinhalaName = "බදුල්ල", TamilName = "பதுளை" },
            //    new District() { ProvinceNo = 8, No = 2, Name = "Moneragala", SinhalaName = "මොණරාගල", TamilName = "மொனராகலை" },

            //    new District() { ProvinceNo = 9, No = 1, Name = "Ratnapura", SinhalaName = "රත්නපුර", TamilName = "இரத்தினபுரி" },
            //    new District() { ProvinceNo = 9, No = 2, Name = "Kegalle", SinhalaName = "කෑගල්ල", TamilName = "கேகாலை" }
            //);
        }
    }
}
