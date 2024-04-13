using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectX.Infrastructure.Migrations
{
    public partial class AdminFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06af8218-64b2-4d25-ae5f-5b1dcb8ad498",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6377466c-3423-4651-a1d8-98d43f27e5bf", "AQAAAAEAACcQAAAAEOQFdDxq9gD/ZdD9Elo8arrxM1rVLQLoXI7VKak7QriTB5FPQOabHYdu5Q9URyEkCA==", "cd10c6e8-4e57-4228-88c0-059ac0c70cac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d1741e7-037a-40fd-bd5a-914eb486a7f2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcb62bc8-b323-4f9a-8e97-9262868ec79c", "AQAAAAEAACcQAAAAEIQ0Qyi/YyRpHbVbfPImXxPvI5I4P2w8/oci/ifsDHs7NRCY0xFsvcVBP4wp662Vfw==", "75b230d5-a25a-4191-a024-79350f6adf02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f6d9128-eb2a-4017-9be4-de846f4092a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "195212b4-95aa-4326-bee7-453ba8a45d11", "AQAAAAEAACcQAAAAEIJFeAmnlbXAA69eERC5hz5DtgRZa/RWxIstr93FO7hWYg8D1eRBdSid6iVmYUwiGQ==", "b2e2d422-b95f-4e46-80cd-db913855292c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9cb5e437-6f1c-45af-8748-37fab040c133",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40a8d059-59a7-4f9c-8041-2c2cb01fd310", "AQAAAAEAACcQAAAAEP3nzeFzHiZDK2BbD30mId0hfXeJNJ+3o9qUx7a5N3dPxBgmhYi39ZsWIk6YGQcerA==", "f9bd22ec-3954-49fc-afdf-aa3cdd70b59c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb5f0982-f2b5-4f59-bf4a-6ff7e5b86aa0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16a6096e-5572-484d-aaef-2dc4b4bd8575", "AQAAAAEAACcQAAAAEB9KpdV9IQthVUCsqNg5mCD9zBjfd/7eqqp65lLe9PWQEkBOdjhgzHIjdTq1X7e18A==", "87fb54dc-a745-4e43-b9ad-259cc030cdc3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0b4f60e-97d7-4d4c-bd9c-af9fdb80a12a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bca7361-aaef-4d92-9fbf-c562f8a65960", "AQAAAAEAACcQAAAAEOpfECEtg6czyWTJNWy1S7cgAGXp0Etg1xYXrpmH5RhlWxs7tJxD/tKFj6q2IvNT0Q==", "ca6f21eb-1ef5-445b-ac88-fb0d2c77f609" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb257b08-cc37-41c6-9bc4-7b85cf4dcb1e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58d00bcc-1ae6-4334-a7fc-d90aa35252dc", "AQAAAAEAACcQAAAAECS6sMf5IiQdVIh+i1UDRpWpKwZBiejHrpEJom3zrklaVc1NE5iJWCthpYm0loEIeQ==", "ad17fa08-da14-4c28-91ed-b266e3567511" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f49b96c1-0e67-4e43-a68e-5cbecc1dd9b6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab0ea8e6-8f11-44f5-aa09-fef089c6e075", "AQAAAAEAACcQAAAAEKCSe8XK+QTCeuOoofS6PM1EzsgMO4cJy81Z3fZGoH+iZZE3/RwI2wwou1f0FF9K/A==", "3a78d911-20fa-48f4-b2c9-b64d15e83986" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8c71f1f-00d7-4f20-83d0-af5d2c6ab9e1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76c4b10d-b30a-4d91-8cb5-8ac398b32a65", "AQAAAAEAACcQAAAAEDdHnHlORI0FguzGqNaf0HRAHtV6LJgXE04+7rjnGa2r6ujNDfklIcIWjESyQOL0tw==", "0011364c-7a34-448f-bafb-8fdbf6841ac7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d781f76-e514-46c6-b647-abe6499ba246", null, "f33dba9c-9b5d-46c2-bd4f-009e85b63d76" });

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
        }
    }
}
