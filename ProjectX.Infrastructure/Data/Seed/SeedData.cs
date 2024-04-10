using Microsoft.AspNetCore.Identity;
using Salon = ProjectX.Infrastructure.Data.Models.Salon;
using User = ProjectX.Infrastructure.Data.Models.User;

namespace ProjectX.Infrastructure.Data.Seed
{
    internal class SeedData
    {
        public User Admin { get; set; } = new User();
        public User User { get; set; } = new User();

        public User SalonOwnerSv { get; set; } = new User();
        public User SalonOwnerPl { get; set; } = new User();
        public User SalonOwnerSf { get; set; } = new User();
        public User SalonOwnerVt { get; set; } = new User();
        public User SalonOwnerRs { get; set; } = new User();
        public User SalonOwnerVn { get; set; } = new User();
        public User SalonOwnerSz { get; set; } = new User();


        public Salon SalonSv { get; set; } = new Salon();
        public Salon SalonPl { get; set; } = new Salon();
        public Salon SalonSf { get; set; } = new Salon();
        public Salon SalonVt { get; set; } = new Salon();
        public Salon SalonRs { get; set; } = new Salon();
        public Salon SalonVn { get; set; } = new Salon();
        public Salon SalonSz { get; set; } = new Salon();


        
        public SeedData()
        {
            SeedUsers();
            SeedSalons();
        }

        

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<User>();

            Admin = new User()
            {
                Id = "9cb5e437-6f1c-45af-8748-37fab040c133",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                City = "Zion",
                FirstName = "Admin",
                LastName = "Almighty",
                PhoneNumber = "0888000000",
                ProfilePicture = "https://wallpapers.com/images/high/funny-profile-picture-ylwnnorvmvk2lna0.webp"
            };
            User.PasswordHash = hasher.HashPassword(Admin, "Admin123!");

            //Normal User
            User = new User()
            {
                Id = "e0b4f60e-97d7-4d4c-bd9c-af9fdb80a12a",
                UserName = "irina@gmail.com",
                NormalizedUserName = "IRINA@GMAIL.COM",
                Email = "irina@gmail.com",
                NormalizedEmail = "IRINA@GMAIL.COM",
                City = "Svishtov",
                FirstName = "Irina",
                LastName = "Teodosieva",
                PhoneNumber = "0888191919",
                ProfilePicture = "https://i.imgur.com/BxxyXQ3.jpg"
            };
            User.PasswordHash = hasher.HashPassword(User, "Irina123!");

            //SalonOwners
            SalonOwnerSv = new User()
            {
                Id = "7f6d9128-eb2a-4017-9be4-de846f4092a8",
                UserName = "salonownersv@gmail.com",
                NormalizedUserName = "SALONOWNERSV@GMAIL.COM",
                Email = "salonownersv@gmail.com",
                NormalizedEmail = "SALONOWNERSV@GMAIL.COM",
                City = "Svishtov",
                FirstName = "Maria",
                LastName = "Ivanova",
                PhoneNumber = "0878123321",
                ProfilePicture = "https://i.imgur.com/8jIgBan.jpg"
            };
            SalonOwnerSv.PasswordHash = hasher.HashPassword(SalonOwnerSv, "SalonOwnerSv123!");

            SalonOwnerPl = new User()
            {
                Id = "f8c71f1f-00d7-4f20-83d0-af5d2c6ab9e1",
                UserName = "salonownerpl@gmail.com",
                NormalizedUserName = "SALONOWNERPL@GMAIL.COM",
                Email = "salonownerpl@gmail.com",
                NormalizedEmail = "SALONOWNERPL@GMAIL.COM",
                City = "Pleven",
                FirstName = "Ivanka",
                LastName = "Petrova",
                PhoneNumber = "0886998877",
                ProfilePicture = "https://i.imgur.com/hMfYO4Z.jpg"
            };
            SalonOwnerPl.PasswordHash = hasher.HashPassword(SalonOwnerPl, "SalonOwnerPl123!");

            SalonOwnerSf = new User()
            {
                Id = "06af8218-64b2-4d25-ae5f-5b1dcb8ad498",
                UserName = "salonownersf@gmail.com",
                NormalizedUserName = "SALONOWNERSF@GMAIL.COM",
                Email = "salonownersf@gmail.com",
                NormalizedEmail = "SALONOWNERSF@GMAIL.COM",
                City = "Sofia",
                FirstName = "Elena",
                LastName = "Georgieva",
                PhoneNumber = "0883020202",
                ProfilePicture = "https://i.imgur.com/Z9C8Ey2.jpg"
            };
            SalonOwnerSf.PasswordHash = hasher.HashPassword(SalonOwnerSf, "SalonOwnerSf123!");

            SalonOwnerVt = new User()
            {
                Id = "f49b96c1-0e67-4e43-a68e-5cbecc1dd9b6",
                UserName = "salonownervt@gmail.com",
                NormalizedUserName = "SALONOWNERVT@GMAIL.COM",
                Email = "salonownervt@gmail.com",
                NormalizedEmail = "SALONOWNERVT@GMAIL.COM",
                City = "Veliko Tarnovo",
                FirstName = "Stefka",
                LastName = "Dimitrova",
                PhoneNumber = "0886456456",
                ProfilePicture = "https://i.imgur.com/2uYHs01.jpg"
            };
            SalonOwnerVt.PasswordHash = hasher.HashPassword(SalonOwnerVt, "SalonOwnerVt123!");

            SalonOwnerRs = new User()
            {
                Id = "eb257b08-cc37-41c6-9bc4-7b85cf4dcb1e",
                UserName = "salonownerrs@gmail.com",
                NormalizedUserName = "SALONOWNERRS@GMAIL.COM",
                Email = "salonownerrs@gmail.com",
                NormalizedEmail = "SALONOWNERRS@GMAIL.COM",
                City = "Ruse",
                FirstName = "Penka",
                LastName = "Stoyanova",
                PhoneNumber = "0878359953",
                ProfilePicture = "https://i.imgur.com/1B3E0us.jpg"
            };
            SalonOwnerRs.PasswordHash = hasher.HashPassword(SalonOwnerRs, "SalonOwnerRs123!");

            SalonOwnerVn = new User()
            {
                Id = "bb5f0982-f2b5-4f59-bf4a-6ff7e5b86aa0",
                UserName = "salonownervn@gmail.com",
                NormalizedUserName = "SALONOWNERVN@GMAIL.COM",
                Email = "salonownervn@gmail.com",
                NormalizedEmail = "SALONOWNERVN@GMAIL.COM",
                City = "Varna",
                FirstName = "Tanya",
                LastName = "Koleva",
                PhoneNumber = "0888699699",
                ProfilePicture = "https://i.imgur.com/oiKMnVI.jpg"
            };
            SalonOwnerVn.PasswordHash = hasher.HashPassword(SalonOwnerVn, "SalonOwnerVn123!");

            SalonOwnerSz = new User()
            {
                Id = "6d1741e7-037a-40fd-bd5a-914eb486a7f2",
                UserName = "salonownersz@gmail.com",
                NormalizedUserName = "SALONOWNERSZ@GMAIL.COM",
                Email = "salonownersz@gmail.com",
                NormalizedEmail = "SALONOWNERSZ@GMAIL.COM",
                City = "Stara Zagora",
                FirstName = "Ani",
                LastName = "Todorova",
                PhoneNumber = "0883789456",
                ProfilePicture = "https://i.imgur.com/IzSbYjB.jpg"
            };
            SalonOwnerSz.PasswordHash = hasher.HashPassword(SalonOwnerSz, "SalonOwnerSz123!");



        }

        private void SeedSalons()
        {
            SalonSv = new Salon()
            {
                Id = 20,
                OwnerId = "e0b4f60e-97d7-4d4c-bd9c-af9fdb80a12a",
                Name = "La Famme",
                Address = "Център, ул. Александър Стамболийски 9",
                City = "Свищов",
                PhoneNumber = "0879425962",
                Description = "Салон за маникюр",
                MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d5777.085309706417!2d25.3442666!3d43.6160633!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40aea1f74f8db6d7%3A0xd99b65173dd11469!2z4oCcTGEgZmFtbWXigJ0!5e0!3m2!1sbg!2sbg!4v1711382622231!5m2!1sbg!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>",
                ProfilePictureUrl = "https://i.imgur.com/gqbirC4.jpeg",
            };

            SalonPl = new Salon()
            {
                Id = 21,
                OwnerId = "f8c71f1f-00d7-4f20-83d0-af5d2c6ab9e1",
                Name = "Mystic",
                Address = "Плевен Център, бул. „Русе“ 41",
                City = "Плевен",
                PhoneNumber = "0877494952",
                Description = "Качествено обслужване и любезно отношение",
                MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d11593.032916301672!2d24.618113!3d43.4134312!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40abf5b3df4f8007%3A0x6f67c2632e3dd468!2zIk15c3RpYyI!5e0!3m2!1sbg!2sbg!4v1711382732592!5m2!1sbg!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>",
                ProfilePictureUrl = "https://i.imgur.com/vfnVhfJ.jpeg",
            };

            SalonSf = new Salon()
            {
                Id = 22,
                OwnerId = "06af8218-64b2-4d25-ae5f-5b1dcb8ad498",
                Name = "Indigo Nails Lab",
                Address = "Hadzhi Dimitar, ul. \"Macgahan\", 1510 Sofia",
                City = "София",
                PhoneNumber = "0892949291",
                Description = "We are doing it fine",
                MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d46920.113329192274!2d23.241646648632805!3d42.69298260000001!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40aa8fde4811e841%3A0x6da382afd9afe86a!2sIndigo%20Nails%20Lab%20Sofia!5e0!3m2!1sen!2sbg!4v1712669308291!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>",
                ProfilePictureUrl = "https://lh5.googleusercontent.com/p/AF1QipPPINiy2hRdxKK4QXVY258Al3PuOhLUB17xzTMk=w427-h240-k-no",
            };

            SalonVt = new Salon()
            {
                Id = 23,
                OwnerId = "f49b96c1-0e67-4e43-a68e-5cbecc1dd9b6",
                Name = "Creative Nails Studio",
                Address = "Велико Търново, Център",
                City = "Велико Търново",
                PhoneNumber = "0886772005",
                Description = "A charming salon! Just enough space for two clients at a time.",
                MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d2888.5254050277763!2d25.3385685!3d43.6164224!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40ae61d70f2a5bf1%3A0x3966bc48c4813196!2z0JzQkNCd0JjQmtCu0KDQndCY0KbQqiBWSVZJIE5BSUxT!5e0!3m2!1sen!2sbg!4v1711374877328!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>",
                ProfilePictureUrl = "https://i.imgur.com/raORBFS.jpeg",
            };

            SalonRs = new Salon()
            {
                Id = 24,
                OwnerId = "eb257b08-cc37-41c6-9bc4-7b85cf4dcb1e",
                Name = "Nail Art & Make Up Atelie Maya Ilieva",
                Address = "Ruse Center, ul. \"Chavdar voyvoda\" 14, 7002 Ruse",
                City = "Русе",
                PhoneNumber = "0895338842",
                Description = "The best manicurist in town",
                MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d46033.183433977734!2d25.880205548632812!3d43.85429559999999!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40ae60cc33356905%3A0x5b71f9abc1296973!2sNail%20Art%20%26%20Make%20Up%20Atelie%20Maya%20Ilieva!5e0!3m2!1sen!2sbg!4v1712669597567!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>",
                ProfilePictureUrl = "https://cdn.oink.bg/gallery/48108/007c1ac7-47db-4e6d-bb86-08e4ecc52b4f_large.webp",
            };

            SalonVn = new Salon()
            {
                Id = 25,
                OwnerId = "bb5f0982-f2b5-4f59-bf4a-6ff7e5b86aa0",
                Name = "Beauty Lounge Laque",
                Address = "Varna CenterPrimorski, ul. \"Felix Kanitz\" 11, 9000 Varna",
                City = "Варна",
                PhoneNumber = "0899255285",
                Description = "A wonderful center for beauty and relaxation! https://laquebg.com/",
                MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d46526.144999075295!2d27.852192348632826!3d43.211921!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a453526da6d625%3A0xc0e67b2ed38f22c5!2sBeauty%20Lounge%20Laque!5e0!3m2!1sen!2sbg!4v1712670000030!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>",
                ProfilePictureUrl = "https://lh5.googleusercontent.com/p/AF1QipO0W6HfRQKDRoGMBy0aD3FLCZHy7sKLNV8SXtov=w426-h240-k-no",
            };

            SalonSz = new Salon()
            {
                Id = 26,
                OwnerId = "6d1741e7-037a-40fd-bd5a-914eb486a7f2",
                Name = "Къщата на ноктите",
                Address = "кв. Опълченски, bul. \"Sveti Patriarh Evtimiy\" 80a, 6000 Stara Zagora",
                City = "Стара Загора",
                PhoneNumber = "0877111584",
                Description = "Refined, cozy and always ready to surprise you with something new!",
                MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d23561.145796981284!2d25.60807998875483!3d42.42468618489927!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a8698ad981f835%3A0xa789d87f594807b1!2z0JrRitGJ0LDRgtCwINC90LAg0L3QvtC60YLQuNGC0LU!5e0!3m2!1sen!2sbg!4v1712670161018!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>",
                ProfilePictureUrl = "https://lh5.googleusercontent.com/p/AF1QipPhPrguBRa_NBhsHYEVaMGODr5fsO1vW0SbWQrk=w408-h725-k-no",
            };
        }

    }
}
