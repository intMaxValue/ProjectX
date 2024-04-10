using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectX.Infrastructure.Migrations
{
    public partial class MoreSalonsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06af8218-64b2-4d25-ae5f-5b1dcb8ad498",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9105a2c6-d628-40e4-9c01-1de055c49fd0", "AQAAAAEAACcQAAAAEJRIl0NKziUK2UUZRSFWYHIhxuVWl2i8D+j6Wh+hqdMQPmbOKpZNsT0+OsnkRAatcQ==", "56346228-ff33-46b7-aed3-279aaaf5da63" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d1741e7-037a-40fd-bd5a-914eb486a7f2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29e06f26-6b1d-4370-9c65-719abfd04498", "AQAAAAEAACcQAAAAEKiSfNw8HyiU/zZlMbd0Ihw0J+ltba0VzmdmohPelSmy6rh+xgRGQg0QUEKbKOkiAQ==", "9fc58388-a33b-4dae-a37d-3cbab3cc250a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f6d9128-eb2a-4017-9be4-de846f4092a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d568d49-9982-4054-953a-5931489d6335", "AQAAAAEAACcQAAAAEAAzCYFhJEoFHbzUeJIb39MaC8YXfFJgtjA+BqDfsASDNpdTjreLvF9Yds4xC8E+hw==", "575ba30a-cea5-41e2-b663-d39d91f30fa4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9cb5e437-6f1c-45af-8748-37fab040c133",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6e762696-9cdf-40c8-9b84-b75646bfc36e", "a00d88e8-24da-4fa7-97c8-f08a7a71532d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb5f0982-f2b5-4f59-bf4a-6ff7e5b86aa0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "831e4546-1719-45df-b187-d64b9aa94b9d", "AQAAAAEAACcQAAAAEGtiQU8BrY0B/Zc9zHjVeH+7cy92MN2AWEX2tRckPIOSJNULSZdCjrQim/iQQcu7zg==", "e2ba49d3-e372-46eb-a6d4-4f5f5a0c6d5b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0b4f60e-97d7-4d4c-bd9c-af9fdb80a12a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca036579-6b83-4600-89d3-02e5ab329324", "AQAAAAEAACcQAAAAEHZVt75dueV8HnUNPPV/NvWaRlN53Lj8C/Qi3ssKHA4uz5OfjhxSrqTZeyy3fokFSg==", "8a4f039c-2b19-4062-92a6-337d56260296" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb257b08-cc37-41c6-9bc4-7b85cf4dcb1e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6dd08de5-1ce3-4853-b233-72d7c575bc4a", "AQAAAAEAACcQAAAAELl6LLhbd7nDWizCA8J97781Ml/Z+OP3kezT1d2Ce/QOQNSPFjob2B8KW9Ny2Vqv4g==", "5233c3b9-f6cd-43f0-98ca-63284c1bfa51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f49b96c1-0e67-4e43-a68e-5cbecc1dd9b6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c9b854b-eddd-4ddf-959d-188ebc195d23", "AQAAAAEAACcQAAAAEGDv5XPBn5lLx/zlD8jaF204Vx1mjUgFOBG+xUIBqZcaAIRqc0IKA8QSLqN5Dn5Mpg==", "6df55961-0a7d-4fee-9382-5dcca95a5eb9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8c71f1f-00d7-4f20-83d0-af5d2c6ab9e1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e5cda6c-b035-477f-a466-8491902066c2", "AQAAAAEAACcQAAAAEFuMNDwbeiLibWHbQU6yubKXT5bN4UYHooJvPcGzchU1nzg6RF76GpIIJP+dfd5Ouw==", "187c5133-fac2-4335-8429-75b82cfbca3d" });

            migrationBuilder.InsertData(
                table: "Salons",
                columns: new[] { "Id", "Address", "City", "Description", "MapUrl", "Name", "OwnerId", "PhoneNumber", "ProfilePictureUrl" },
                values: new object[,]
                {
                    { 30, "Pleven Center, ul. \"Odesa\" 27", "Плевен", "Experience the ultimate pampering session at our nail studio, where skilled technicians create stunning nail art.", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2967656.6814909396!2d19.7401186125!3d43.41669079999999!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40abf579ee774fe5%3A0x85ce62a9032b49f5!2sStudio%20Nails%20PT!5e0!3m2!1sen!2sbg!4v1712750422891!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "Studio Nails PT", "f8c71f1f-00d7-4f20-83d0-af5d2c6ab9e1", "0988786214", "https://images.fresha.com/locations/location-profile-images/490308/856148/bebd02a5-2ec0-48e1-8926-d35c9f0f7df4.jpg" },
                    { 31, "Pleven Center, ul. \"Veslets\" 3", "Плевен", "Indulge in luxury nail care at our salon, where every detail is meticulously attended to for a flawless finish.", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2967656.6814909396!2d19.7401186125!3d43.41669079999999!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40abf5c74d35386b%3A0xa04293a144d688fa!2sPrimaDonna%20Nails%20Salon%20%26%20School!5e0!3m2!1sen!2sbg!4v1712750810148!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "PrimaDonna Nails Salon & School", "f8c71f1f-00d7-4f20-83d0-af5d2c6ab9e1", "0884325852", "https://images.squarespace-cdn.com/content/v1/5a28c1a349fc2b8ed19e1b3a/1684020222208-OTUNGEXDQK9SGKU74RC2/image-asset.jpeg" },
                    { 32, "Sofia Center, Vitosha Blvd 1", "София", "Escape the hustle and bustle and unwind at our cozy nail lounge, where comfort meets professionalism.", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2970241.0822246317!2d19.73989057359654!3d43.363931983567646!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40aa85a43ce24eb7%3A0xafbc60f53f14030a!2sNika%20Nails%20Factory!5e0!3m2!1sen!2sbg!4v1712751063496!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "Nika Nails Factory", "06af8218-64b2-4d25-ae5f-5b1dcb8ad498", "0899389949", "https://studio24.bg/pictures/studios/9/9036/thumbs/0x630/47866.jpg" },
                    { 33, "Oborishte, ul. \"Cherkovna\" 54", "София", "Transform your nails into works of art at our trendy nail bar, where creativity knows no bounds.", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2970241.0822246317!2d19.73989057359654!3d43.363931983567646!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40aa85f6b92c4bf1%3A0x695f9b31aa2a9db6!2sLuxury%20Nails%20by%20Desislava%20Gancheva!5e0!3m2!1sen!2sbg!4v1712751187294!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "Luxury Nails by Desislava Gancheva", "06af8218-64b2-4d25-ae5f-5b1dcb8ad498", "0898761300", "https://i.pinimg.com/originals/b4/79/d7/b479d7e3f43418eee4a5af526cc96239.jpg" },
                    { 34, "Ул.Любен Каравелов 38, Партер", "София", "Experience top-notch nail care in a welcoming atmosphere at our boutique salon, dedicated to exceeding expectations.", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3003186.551918595!2d18.449533312500016!3d42.68679210000003!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40aa8593f06fa7bd%3A0xd8296a26c5d2ac08!2sNail%20bar%20Bibi!5e0!3m2!1sen!2sbg!4v1712751359574!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "Nail bar Bibi", "06af8218-64b2-4d25-ae5f-5b1dcb8ad498", "0889188570", "https://studio24.bg/pictures/studios/0/910/thumbs/0x630/10784.jpeg" },
                    { 35, "g.k. Akatsia, ul. \"Tsvetarska\" 14", "Велико Търново", "Step into our modern nail studio and leave feeling refreshed, rejuvenated, and ready to conquer the world.", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d11657.330144674672!2d25.61236910644684!3d43.076503761847725!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a9260fde459edf%3A0xdc0ea8d72de85eb9!2sFunStyle%20MS!5e0!3m2!1sen!2sbg!4v1712751825383!5m2!1sen!2sbg\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "FunStyle MS", "f49b96c1-0e67-4e43-a68e-5cbecc1dd9b6", "0888989462", "https://annassalonelite.com/blog/wp-content/uploads/2020/05/Annas-5.31.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06af8218-64b2-4d25-ae5f-5b1dcb8ad498",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc508e37-7396-4a21-9df4-27982068a65a", "AQAAAAEAACcQAAAAENKTxkef3oGC45lB6OlsK3enlBgyn32Ans8bFogC4nRtKs1ffRPyaLOBRBkZw+w6DA==", "f12aaa2e-f2e0-45c4-8d9e-776bc9377b9a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d1741e7-037a-40fd-bd5a-914eb486a7f2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4fea11b8-b5fd-420d-bafe-3c1d3f08eff1", "AQAAAAEAACcQAAAAEIJZFbwYq9PQ7jwvQvJRCiw9OhLO7iZCdOn18NrKV/55I9b/B+CHw6scTJwD43GD+Q==", "7eac1018-592b-4fd1-a363-a43f295e448c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f6d9128-eb2a-4017-9be4-de846f4092a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f18c008-cea9-46d5-a546-e5b5996396f7", "AQAAAAEAACcQAAAAEJZZbURNyK9G5f/nykS3zd8q9NsreKg5E71LaPzn7Wa6kMSKz9jnJ0COOoerFOpm6w==", "cc19d94d-eeee-4089-b4fc-1bafcdfc5f12" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9cb5e437-6f1c-45af-8748-37fab040c133",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2be2734e-f954-4a02-9263-ecd05734b880", "257df5d6-00e0-4f00-9d31-41614e434616" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb5f0982-f2b5-4f59-bf4a-6ff7e5b86aa0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "395b0dd5-af40-447c-8a47-0b136fcc4fea", "AQAAAAEAACcQAAAAEA7pLpNYfcDuo4CObLvPowZVs02lNBRJqPjc/nGSoWdZxJPyyTKP5jp13geFUBvRCA==", "064e2355-e8f1-4e74-a486-d57bbd1011c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0b4f60e-97d7-4d4c-bd9c-af9fdb80a12a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e85189e-2eb4-4b76-a315-b2e6dbfc9640", "AQAAAAEAACcQAAAAEL99yHeT3JHI49Rp5cPwD091dZjy1MtLTBqvcaRjay6RTPnMZl0tgdCeTgzPD6tMgg==", "ba57c8ef-6d5a-4899-93ff-8d67b8fc8207" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb257b08-cc37-41c6-9bc4-7b85cf4dcb1e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c75b1ac-596a-436e-8d04-699cdc6d7170", "AQAAAAEAACcQAAAAEPCb/gbx9q58AxEZnHEkR2fnhpRb7OK0v2NIp7WPMesyIGV1NXna18KZt6+vIadbgA==", "d747fa96-8f0e-454e-a141-1fcf49ab6d49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f49b96c1-0e67-4e43-a68e-5cbecc1dd9b6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4942d20d-9c67-4693-b081-09740658cb7f", "AQAAAAEAACcQAAAAEAwEMOfAQONQFZX0KgtpE2U+jb61Ik5bzB7ReNwJC9otIWXnsyW7xCnvzLEQA2zdKQ==", "7d812437-b360-4bd7-930f-124d7dfd56d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8c71f1f-00d7-4f20-83d0-af5d2c6ab9e1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "114e8cd2-ec71-447f-a78d-53cab553212d", "AQAAAAEAACcQAAAAEP8vOc5/SKjmsJdbOtbZma1afWawbe7kVb1ERNSKNAeIdcvZa1LaRW5/OWl6sdEh5A==", "7214e8b3-e51a-47f7-9fdd-c2c143d7fa44" });
        }
    }
}
