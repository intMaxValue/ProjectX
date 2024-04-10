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
        public Salon SalonSv1 { get; set; } = new Salon();
        public Salon SalonSv2 { get; set; } = new Salon();
        public Salon SalonSv3 { get; set; } = new Salon();


        public Salon SalonPl { get; set; } = new Salon();
        public Salon SalonPl1 { get; set; } = new Salon();
        public Salon SalonPl2 { get; set; } = new Salon();

        public Salon SalonSf { get; set; } = new Salon();
        public Salon SalonSf1 { get; set; } = new Salon();
        public Salon SalonSf2 { get; set; } = new Salon();
        public Salon SalonSf3 { get; set; } = new Salon();

        public Salon SalonVt { get; set; } = new Salon();
        public Salon SalonVt1 { get; set; } = new Salon();

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

            SalonSv1 = new Salon()
            {
                Id = 27,
                OwnerId = "7f6d9128-eb2a-4017-9be4-de846f4092a8",
                Name = "МАНИКЮРНИЦЪ VIVI NAILS",
                Address = "блок 4, Tsentar, ul. \"27-mi yuni\" 1, вход А",
                City = "Свищов",
                PhoneNumber = "0877277879",
                Description = "Identifies as women-owned",
                MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d5776.887118560986!2d25.3326450935791!3d43.6181262!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40ae61d70f2a5bf1%3A0x3966bc48c4813196!2z0JzQkNCd0JjQmtCu0KDQndCY0KbQqiBWSVZJIE5BSUxT!5e0!3m2!1sen!2sbg!4v1712749078365!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>",
                ProfilePictureUrl = "https://img.freepik.com/free-photo/manicurist-master-makes-manicure-woman-s-hands-spa-treatment-concept_186202-7778.jpg",
            };

            SalonSv2 = new Salon()
            {
                Id = 28,
                OwnerId = "7f6d9128-eb2a-4017-9be4-de846f4092a8",
                Name = "Салон ДаМако",
                Address = "Tsentar, \" Хр. Ботев \" 3",
                City = "Свищов",
                PhoneNumber = "0893348878",
                Description = "The best medical treatment for nail issues  in the district.",
                MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d5777.210144474986!2d25.343323393579098!3d43.6147639!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40aea16f96ef181b%3A0xf92742122d7eca0a!2z0KHQsNC70L7QvSDQlNCw0JzQsNC60L4!5e0!3m2!1sen!2sbg!4v1712750214361!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>",
                ProfilePictureUrl = "https://static.wixstatic.com/media/b8583971442d48568f1d10b9554b4238.jpg/v1/fill/w_640,h_1044,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/b8583971442d48568f1d10b9554b4238.jpg",
            };

            SalonSv3 = new Salon()
            {
                Id = 29,
                OwnerId = "7f6d9128-eb2a-4017-9be4-de846f4092a8",
                Name = "Студио \"With Love\"",
                Address = "ул. Княз Борис I, No 11",
                City = "Свищов",
                PhoneNumber = "0886410904",
                Description = "Discover the perfect blend of style and sophistication at our nail boutique, offering personalized nail treatments.",
                MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d5777.210144474986!2d25.343323393579098!3d43.6147639!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40aea1deaa3b9ef5%3A0x5779bb4be7474e1!2z0KHRgtGD0LTQuNC-ICJXaXRoIExvdmUi!5e0!3m2!1sen!2sbg!4v1712750122920!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>",
                ProfilePictureUrl = "https://enchantedspadc.com/wp-content/uploads/2020/12/Enchanted-Nails-and-Spa-manicure-20009.jpg",
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

            SalonPl1 = new Salon()
            {
                Id = 30,
                OwnerId = "f8c71f1f-00d7-4f20-83d0-af5d2c6ab9e1",
                Name = "Studio Nails PT",
                Address = "Pleven Center, ul. \"Odesa\" 27",
                City = "Плевен",
                PhoneNumber = "0988786214",
                Description = "Experience the ultimate pampering session at our nail studio, where skilled technicians create stunning nail art.",
                MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2967656.6814909396!2d19.7401186125!3d43.41669079999999!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40abf579ee774fe5%3A0x85ce62a9032b49f5!2sStudio%20Nails%20PT!5e0!3m2!1sen!2sbg!4v1712750422891!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>",
                ProfilePictureUrl = "https://images.fresha.com/locations/location-profile-images/490308/856148/bebd02a5-2ec0-48e1-8926-d35c9f0f7df4.jpg",
            };

            SalonPl2 = new Salon()
            {
                Id = 31,
                OwnerId = "f8c71f1f-00d7-4f20-83d0-af5d2c6ab9e1",
                Name = "PrimaDonna Nails Salon & School",
                Address = "Pleven Center, ul. \"Veslets\" 3",
                City = "Плевен",
                PhoneNumber = "0884325852",
                Description = "Indulge in luxury nail care at our salon, where every detail is meticulously attended to for a flawless finish.",
                MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2967656.6814909396!2d19.7401186125!3d43.41669079999999!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40abf5c74d35386b%3A0xa04293a144d688fa!2sPrimaDonna%20Nails%20Salon%20%26%20School!5e0!3m2!1sen!2sbg!4v1712750810148!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>",
                ProfilePictureUrl = "https://images.squarespace-cdn.com/content/v1/5a28c1a349fc2b8ed19e1b3a/1684020222208-OTUNGEXDQK9SGKU74RC2/image-asset.jpeg",
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
                ProfilePictureUrl = "https://img.freepik.com/free-photo/hands-with-beautiful-nails_23-2149936852.jpg",
            };

            SalonSf1 = new Salon()
            {
                Id = 32,
                OwnerId = "06af8218-64b2-4d25-ae5f-5b1dcb8ad498",
                Name = "Nika Nails Factory",
                Address = "Sofia Center, Vitosha Blvd 1",
                City = "София",
                PhoneNumber = "0899389949",
                Description = "Escape the hustle and bustle and unwind at our cozy nail lounge, where comfort meets professionalism.",
                MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2970241.0822246317!2d19.73989057359654!3d43.363931983567646!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40aa85a43ce24eb7%3A0xafbc60f53f14030a!2sNika%20Nails%20Factory!5e0!3m2!1sen!2sbg!4v1712751063496!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>",
                ProfilePictureUrl = "https://studio24.bg/pictures/studios/9/9036/thumbs/0x630/47866.jpg",
            };

            SalonSf2 = new Salon()
            {
                Id = 33,
                OwnerId = "06af8218-64b2-4d25-ae5f-5b1dcb8ad498",
                Name = "Luxury Nails by Desislava Gancheva",
                Address = "Oborishte, ul. \"Cherkovna\" 54",
                City = "София",
                PhoneNumber = "0898761300",
                Description = "Transform your nails into works of art at our trendy nail bar, where creativity knows no bounds.",
                MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2970241.0822246317!2d19.73989057359654!3d43.363931983567646!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40aa85f6b92c4bf1%3A0x695f9b31aa2a9db6!2sLuxury%20Nails%20by%20Desislava%20Gancheva!5e0!3m2!1sen!2sbg!4v1712751187294!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>",
                ProfilePictureUrl = "https://i.pinimg.com/originals/b4/79/d7/b479d7e3f43418eee4a5af526cc96239.jpg",
            };

            SalonSf3 = new Salon()
            {
                Id = 34,
                OwnerId = "06af8218-64b2-4d25-ae5f-5b1dcb8ad498",
                Name = "Nail bar Bibi",
                Address = "Ул.Любен Каравелов 38, Партер",
                City = "София",
                PhoneNumber = "0889188570",
                Description = "Experience top-notch nail care in a welcoming atmosphere at our boutique salon, dedicated to exceeding expectations.",
                MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3003186.551918595!2d18.449533312500016!3d42.68679210000003!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40aa8593f06fa7bd%3A0xd8296a26c5d2ac08!2sNail%20bar%20Bibi!5e0!3m2!1sen!2sbg!4v1712751359574!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>",
                ProfilePictureUrl = "https://studio24.bg/pictures/studios/0/910/thumbs/0x630/10784.jpeg",
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

            SalonVt1 = new Salon()
            {
                Id = 35,
                OwnerId = "f49b96c1-0e67-4e43-a68e-5cbecc1dd9b6",
                Name = "FunStyle MS",
                Address = "g.k. Akatsia, ul. \"Tsvetarska\" 14",
                City = "Велико Търново",
                PhoneNumber = "0888989462",
                Description = "Step into our modern nail studio and leave feeling refreshed, rejuvenated, and ready to conquer the world.",
                MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d11657.330144674672!2d25.61236910644684!3d43.076503761847725!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a9260fde459edf%3A0xdc0ea8d72de85eb9!2sFunStyle%20MS!5e0!3m2!1sen!2sbg!4v1712751825383!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>",
                ProfilePictureUrl = "https://annassalonelite.com/blog/wp-content/uploads/2020/05/Annas-5.31.jpg",
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
                ProfilePictureUrl = "https://assets.isu.pub/document-structure/230303101435-3c94967ebc548d2d2d70b12a8e02701f/v1/0b209de76d246f148c6f588f808daec7.jpeg",
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
                ProfilePictureUrl = "https://holrmagazine.com/wp-content/uploads/2021/07/nail-bar1-759x500.jpeg",
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
                ProfilePictureUrl = "https://imgrabo.com/pics/deals/14855085809332.jpeg",
            };
        }

    }
}
