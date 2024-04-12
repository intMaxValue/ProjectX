using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectX.Infrastructure.Migrations
{
    public partial class AddedReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Reviews",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06af8218-64b2-4d25-ae5f-5b1dcb8ad498",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8f78188-ae0a-41af-b895-66ff0aecaed3", "AQAAAAEAACcQAAAAEMxZLsArjJs8u/CyzLFVo4iH+ofl5fGfUG5QRqKJHbRpPfsquCqc4xmJ5HEfpl0tMg==", "b5620046-9e82-44b9-8ea9-cac22265ff72" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d1741e7-037a-40fd-bd5a-914eb486a7f2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "179a6d94-dc25-4a7f-8d40-b856841168f9", "AQAAAAEAACcQAAAAEDAAPaMtLtCgN9yDPJwIbFJPrvbHyPXrI9A+tPRYCLkF2Xjb103bjy6UfnDX7sC0rw==", "5be536a1-e9e8-4f70-8760-080c5b6c43d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f6d9128-eb2a-4017-9be4-de846f4092a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0b2013c-7f3e-4112-9bdb-fae93d414dbd", "AQAAAAEAACcQAAAAEBaQuuVgK8C0FS1/Y0cabKXqveLTF9HnRO5/lv7p/E47uZNwdfMA4R+y8KFdYuEjcA==", "74fb5955-65a7-4d71-adb0-50fa31686cb9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9cb5e437-6f1c-45af-8748-37fab040c133",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6d781f76-e514-46c6-b647-abe6499ba246", "f33dba9c-9b5d-46c2-bd4f-009e85b63d76" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb5f0982-f2b5-4f59-bf4a-6ff7e5b86aa0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69964661-fd6e-478c-b6ac-4a8aae46c799", "AQAAAAEAACcQAAAAECOXDUxQ2KvAVmHB3P0B0SXDhrSpw6idoNU1ksu7FNaXlZYsJp8XEKVpTBzNxNo0rg==", "7bc7a927-ea7b-4dae-b0d0-b256b65154e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0b4f60e-97d7-4d4c-bd9c-af9fdb80a12a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "751ca298-a31d-4e6f-8c64-2a46d6e9e9f7", "AQAAAAEAACcQAAAAEDhI6jY6K58CCW6GhH2tJ71NPnLl2PPfF+JrweK/k0wQ2jy1RNYEAJCC+O3oafK/+A==", "da9a2ca1-810e-4cd4-9cfa-e64616bd540d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb257b08-cc37-41c6-9bc4-7b85cf4dcb1e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ba9137d-b68d-4079-abe3-9a991e9714bf", "AQAAAAEAACcQAAAAEN/TmhxmiarknPMvi10cFP6qteWbO4YrlJSnSEv9e/HXw5EtEaknCudw82L5SviiQA==", "d53c2ad9-24c0-4b76-aa1a-0295945f5fd5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f49b96c1-0e67-4e43-a68e-5cbecc1dd9b6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c949f7c7-4894-4931-a969-9ea7777212de", "AQAAAAEAACcQAAAAEIvq5k6bVy7y+d2M6b2YyZ6TCDpJDyJEzZXVOtFzyJuVTqrEoTOclaqf7yXXeQXi7w==", "aa090d01-38b9-4355-8d7d-ff0d51f9629c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8c71f1f-00d7-4f20-83d0-af5d2c6ab9e1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3c671b9-65c6-44eb-b00a-51a6e4b8f2bf", "AQAAAAEAACcQAAAAEKt9xBVTrdtoHbNCrwWd31gjfSdFoWQrd/hGXtw6Obtv2jngqLzY6tUIUDskWjmnfw==", "168c5be8-6a27-4048-993d-26f675fd70b4" });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 20,
                column: "OwnerId",
                value: "7f6d9128-eb2a-4017-9be4-de846f4092a8");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

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

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 20,
                column: "OwnerId",
                value: "e0b4f60e-97d7-4d4c-bd9c-af9fdb80a12a");
        }
    }
}
