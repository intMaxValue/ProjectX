using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectX.Infrastructure.Migrations
{
    public partial class SeedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "06af8218-64b2-4d25-ae5f-5b1dcb8ad498", 0, "Sofia", "483a163d-5526-4998-aa8f-0aae5e9aaeec", "salonownersf@gmail.com", false, "Elena", "Georgieva", false, null, "SALONOWNERSF@GMAIL.COM", "SALONOWNERSF@GMAIL.COM", "AQAAAAEAACcQAAAAEFl/9XcFLjZVzPeYQcR642QIzW+WqVj2O+ZL9n5gjEIEE0U4JSvTg1xOdv3gbe3/Sg==", "0883020202", false, "https://i.imgur.com/Z9C8Ey2.jpg", "c9090616-147b-4051-ab80-4588723e201d", false, "salonownersf@gmail.com" },
                    { "6d1741e7-037a-40fd-bd5a-914eb486a7f2", 0, "Stara Zagora", "c235668e-6e7f-4727-9be6-499c0b69b7ee", "salonownersz@gmail.com", false, "Ani", "Todorova", false, null, "SALONOWNERSZ@GMAIL.COM", "SALONOWNERSZ@GMAIL.COM", "AQAAAAEAACcQAAAAELGwHK5tB3fkuigsyh63J7mtaT/tA2qPdFVWyjtElKs4EI9Gobgr0AeftMOFbyWA/w==", "0883789456", false, "https://i.imgur.com/IzSbYjB.jpg", "2dcd1229-49ce-4dfa-91ec-aec14dc51076", false, "salonownersz@gmail.com" },
                    { "7f6d9128-eb2a-4017-9be4-de846f4092a8", 0, "Svishtov", "c55bba16-39c1-4e0a-baf1-a4714aad1bd1", "salonownersv@gmail.com", false, "Maria", "Ivanova", false, null, "SALONOWNERSV@GMAIL.COM", "SALONOWNERSV@GMAIL.COM", "AQAAAAEAACcQAAAAEHqM2+zTDxnqEMEG50JZnwqz2iO2Cu8WpCEewWfAbVR2UHIyrWPXHAxpFRwXAchqZQ==", "0878123321", false, "https://i.imgur.com/8jIgBan.jpg", "744c73ff-2e8d-4fb9-b672-52f5d9273b21", false, "salonownersv@gmail.com" },
                    { "9cb5e437-6f1c-45af-8748-37fab040c133", 0, "Zion", "763fb6c0-4e35-490f-a736-468151e64005", "admin@gmail.com", false, "Admin", "Almighty", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", null, "0888000000", false, "https://wallpapers.com/images/high/funny-profile-picture-ylwnnorvmvk2lna0.webp", "509e4df2-883b-4112-9092-26cb8ad8db96", false, "admin@gmail.com" },
                    { "bb5f0982-f2b5-4f59-bf4a-6ff7e5b86aa0", 0, "Varna", "0e2c08d2-c9df-42c3-bbf4-67f3878aa5c8", "salonownervn@gmail.com", false, "Tanya", "Koleva", false, null, "SALONOWNERVN@GMAIL.COM", "SALONOWNERVN@GMAIL.COM", "AQAAAAEAACcQAAAAEMFwCh1ncpNTndU258GcsBVAzaGC8Q0HdyrD1M/1sbKyesDmX2E+LytxYWgx87Pjog==", "0888699699", false, "https://i.imgur.com/oiKMnVI.jpg", "9f28f4a5-60d2-461e-a5cc-88f40501c307", false, "salonownervn@gmail.com" },
                    { "e0b4f60e-97d7-4d4c-bd9c-af9fdb80a12a", 0, "Svishtov", "8860c1b1-59a3-4cd9-9e8e-49812b52687d", "irina@gmail.com", false, "Irina", "Teodosieva", false, null, "IRINA@GMAIL.COM", "IRINA@GMAIL.COM", "AQAAAAEAACcQAAAAEAHRi9Y3EvCdxWJPuQBeCEXc9gJss2YFTiPYai/X3AG7KeEsksRfszdzNsWpNhmSjg==", "0888191919", false, "https://i.imgur.com/BxxyXQ3.jpg", "347cf964-0fd8-4c8c-8a4f-0a037c9e11f7", false, "irina@gmail.com" },
                    { "eb257b08-cc37-41c6-9bc4-7b85cf4dcb1e", 0, "Ruse", "4f4f38c2-3284-40e0-8af6-b2f7f6eb4de9", "salonownerrs@gmail.com", false, "Penka", "Stoyanova", false, null, "SALONOWNERRS@GMAIL.COM", "SALONOWNERRS@GMAIL.COM", "AQAAAAEAACcQAAAAELmifV/lX8GAd8DUVdPT/NJ++93mNsp9Y2XKBgv60G3Nvtn4IwZmpTmbdSK3rJipeA==", "0878359953", false, "https://i.imgur.com/1B3E0us.jpg", "5e843566-c67f-4d74-8b47-201e14c057d2", false, "salonownerrs@gmail.com" },
                    { "f49b96c1-0e67-4e43-a68e-5cbecc1dd9b6", 0, "Veliko Tarnovo", "7778ad01-4fd9-4d1c-ba27-d1782525008a", "salonownervt@gmail.com", false, "Stefka", "Dimitrova", false, null, "SALONOWNERVT@GMAIL.COM", "SALONOWNERVT@GMAIL.COM", "AQAAAAEAACcQAAAAEO+1AWBhtNDH5A5FQTXNuGCC2h1un6ze2/BhAuicpyT36oM56aIsiKFg7y4Ntto/kA==", "0886456456", false, "https://i.imgur.com/2uYHs01.jpg", "7cbb3e85-8414-4253-bca0-7b42f08481a3", false, "salonownervt@gmail.com" },
                    { "f8c71f1f-00d7-4f20-83d0-af5d2c6ab9e1", 0, "Pleven", "377078ee-3800-4a9a-8d97-215322bb9219", "salonownerpl@gmail.com", false, "Ivanka", "Petrova", false, null, "SALONOWNERPL@GMAIL.COM", "SALONOWNERPL@GMAIL.COM", "AQAAAAEAACcQAAAAEGlmqK+EcCQ5/tShh2DL7KGyjrfVh9ZxYHuHuJaxZ3ncc6RfphYz+NU5aTL2pat7fA==", "0886998877", false, "https://i.imgur.com/hMfYO4Z.jpg", "e831f014-9c6a-4d69-8ff7-f4667c8b1d96", false, "salonownerpl@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Salons",
                columns: new[] { "Id", "Address", "City", "Description", "MapUrl", "Name", "OwnerId", "PhoneNumber", "ProfilePictureUrl" },
                values: new object[,]
                {
                    { 20, "Център, ул. Александър Стамболийски 9", "Свищов", "Салон за маникюр", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d5777.085309706417!2d25.3442666!3d43.6160633!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40aea1f74f8db6d7%3A0xd99b65173dd11469!2z4oCcTGEgZmFtbWXigJ0!5e0!3m2!1sbg!2sbg!4v1711382622231!5m2!1sbg!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "La Famme", "e0b4f60e-97d7-4d4c-bd9c-af9fdb80a12a", "0879425962", "https://i.imgur.com/gqbirC4.jpeg" },
                    { 21, "Плевен Център, бул. „Русе“ 41", "Плевен", "Качествено обслужване и любезно отношение", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d11593.032916301672!2d24.618113!3d43.4134312!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40abf5b3df4f8007%3A0x6f67c2632e3dd468!2zIk15c3RpYyI!5e0!3m2!1sbg!2sbg!4v1711382732592!5m2!1sbg!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "Mystic", "f8c71f1f-00d7-4f20-83d0-af5d2c6ab9e1", "0877494952", "https://i.imgur.com/vfnVhfJ.jpeg" },
                    { 22, "Hadzhi Dimitar, ul. \"Macgahan\", 1510 Sofia", "София", "We are doing it fine", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d46920.113329192274!2d23.241646648632805!3d42.69298260000001!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40aa8fde4811e841%3A0x6da382afd9afe86a!2sIndigo%20Nails%20Lab%20Sofia!5e0!3m2!1sen!2sbg!4v1712669308291!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "Indigo Nails Lab", "06af8218-64b2-4d25-ae5f-5b1dcb8ad498", "0892949291", "https://lh5.googleusercontent.com/p/AF1QipPPINiy2hRdxKK4QXVY258Al3PuOhLUB17xzTMk=w427-h240-k-no" },
                    { 23, "Велико Търново, Център", "Велико Търново", "A charming salon! Just enough space for two clients at a time.", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d2888.5254050277763!2d25.3385685!3d43.6164224!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40ae61d70f2a5bf1%3A0x3966bc48c4813196!2z0JzQkNCd0JjQmtCu0KDQndCY0KbQqiBWSVZJIE5BSUxT!5e0!3m2!1sen!2sbg!4v1711374877328!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "Creative Nails Studio", "f49b96c1-0e67-4e43-a68e-5cbecc1dd9b6", "0886772005", "https://i.imgur.com/raORBFS.jpeg" },
                    { 24, "Ruse Center, ul. \"Chavdar voyvoda\" 14, 7002 Ruse", "Русе", "The best manicurist in town", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d46033.183433977734!2d25.880205548632812!3d43.85429559999999!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40ae60cc33356905%3A0x5b71f9abc1296973!2sNail%20Art%20%26%20Make%20Up%20Atelie%20Maya%20Ilieva!5e0!3m2!1sen!2sbg!4v1712669597567!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "Nail Art & Make Up Atelie Maya Ilieva", "eb257b08-cc37-41c6-9bc4-7b85cf4dcb1e", "0895338842", "https://cdn.oink.bg/gallery/48108/007c1ac7-47db-4e6d-bb86-08e4ecc52b4f_large.webp" },
                    { 25, "Varna CenterPrimorski, ul. \"Felix Kanitz\" 11, 9000 Varna", "Варна", "A wonderful center for beauty and relaxation! https://laquebg.com/", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d46526.144999075295!2d27.852192348632826!3d43.211921!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a453526da6d625%3A0xc0e67b2ed38f22c5!2sBeauty%20Lounge%20Laque!5e0!3m2!1sen!2sbg!4v1712670000030!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "Beauty Lounge Laque", "bb5f0982-f2b5-4f59-bf4a-6ff7e5b86aa0", "0899255285", "https://lh5.googleusercontent.com/p/AF1QipO0W6HfRQKDRoGMBy0aD3FLCZHy7sKLNV8SXtov=w426-h240-k-no" },
                    { 26, "кв. Опълченски, bul. \"Sveti Patriarh Evtimiy\" 80a, 6000 Stara Zagora", "Стара Загора", "Refined, cozy and always ready to surprise you with something new!", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d23561.145796981284!2d25.60807998875483!3d42.42468618489927!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a8698ad981f835%3A0xa789d87f594807b1!2z0JrRitGJ0LDRgtCwINC90LAg0L3QvtC60YLQuNGC0LU!5e0!3m2!1sen!2sbg!4v1712670161018!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "Къщата на ноктите", "6d1741e7-037a-40fd-bd5a-914eb486a7f2", "0877111584", "https://lh5.googleusercontent.com/p/AF1QipPhPrguBRa_NBhsHYEVaMGODr5fsO1vW0SbWQrk=w408-h725-k-no" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f6d9128-eb2a-4017-9be4-de846f4092a8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9cb5e437-6f1c-45af-8748-37fab040c133");

            migrationBuilder.DeleteData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06af8218-64b2-4d25-ae5f-5b1dcb8ad498");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d1741e7-037a-40fd-bd5a-914eb486a7f2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb5f0982-f2b5-4f59-bf4a-6ff7e5b86aa0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0b4f60e-97d7-4d4c-bd9c-af9fdb80a12a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb257b08-cc37-41c6-9bc4-7b85cf4dcb1e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f49b96c1-0e67-4e43-a68e-5cbecc1dd9b6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8c71f1f-00d7-4f20-83d0-af5d2c6ab9e1");
        }
    }
}
