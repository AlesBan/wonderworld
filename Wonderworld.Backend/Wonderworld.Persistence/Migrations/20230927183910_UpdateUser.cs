using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wonderworld.Persistence.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("0e190e73-d559-4831-aa41-402fa8e754c7"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("30ce693a-01cd-4392-88b3-cf192b52c0af"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("41fe2e42-e605-48d5-96de-314a139f5bef"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("45d4f0ae-cbdc-4290-a17e-230f99395b0e"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("5660e95c-02fd-4815-a846-52e2131a5b69"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("58401dbc-658c-4885-9e37-1b51c605fbd3"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("a765e545-cfbd-42c8-aa40-45640481ff12"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("ab9468eb-d723-4ced-b9f3-d7e2cae3062f"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("c1172edd-4e95-4c4d-8637-77e76ac91240"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("ce4f0ffc-6b6a-4698-9f8b-456b7952930d"));

            migrationBuilder.DeleteData(
                table: "EstablishmentTypes",
                keyColumn: "EstablishmentTypeId",
                keyValue: new Guid("460b4a16-7d13-4587-bae8-b4efbb28b096"));

            migrationBuilder.DeleteData(
                table: "EstablishmentTypes",
                keyColumn: "EstablishmentTypeId",
                keyValue: new Guid("5e8a5e0d-a7ea-433d-b061-be061558ae98"));

            migrationBuilder.DeleteData(
                table: "EstablishmentTypes",
                keyColumn: "EstablishmentTypeId",
                keyValue: new Guid("69bcdd4c-8a5b-4408-93c1-c8122aeb254c"));

            migrationBuilder.DeleteData(
                table: "EstablishmentTypes",
                keyColumn: "EstablishmentTypeId",
                keyValue: new Guid("f2315c84-6a71-4956-a2ba-dd3591374ca1"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("02079c0a-1a5a-4a94-9926-9a66a08e1892"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("1bfab4f1-1bfe-4019-a92c-c3bec3b66196"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("44ec880d-0ebd-4ff6-82b9-aaa944ba7db9"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("61a69601-de72-4cea-9868-d855231b98ea"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("9b75bb5d-dedc-4133-89bd-2d925b05105f"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("9b785c0f-1113-4f9f-82f7-9ee2ba85800e"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("a2f15865-54ed-4e32-a4af-b418d588d0ca"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("aa768fb8-f662-4732-918c-37a9584e39f7"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("d378f043-cbda-420e-9fd5-0f1863b1828b"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("db4d7464-b1ef-46ef-933e-092c93d27e2e"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("f3771ef0-97c6-4135-b8d8-7d1fb4e609cd"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("fd327c6c-8ba2-487d-9cbc-7181c265182d"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("03aeed61-9067-401e-b0e7-0e1d602e2a9a"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("3e731e5a-5b73-44d8-bc4c-03601777ee9c"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("4eab363d-f401-4341-9fb2-08d3c5efbbb7"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("72fafbf8-a20e-4c0e-8fea-40c28619569d"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("860a6675-18d0-4ccf-98a6-88192f11b157"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("9bc119e7-7b17-4d0a-9b42-937c26a63bd6"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("b1e44286-5cd8-4076-96e3-89b6d0103e6f"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("b2ea8b5d-57df-4bb9-b5bf-055daabcc221"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("c89ede26-696e-4a95-aa01-a76da716d4ff"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("d0c5bd41-d76a-47ef-8ec4-bdad7ac019e0"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("d349a958-5c02-44d4-b1c3-92f112efb91c"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("e0ed9bf2-8154-4947-a4ab-1cbf2bf66dd5"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("ef9578e5-067a-4530-8498-074e20513c36"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("f02b427d-fe16-4980-96b4-c4720a7d7968"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("f8adc4ae-18cf-478a-8b4b-c820cb5f0845"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("fe00de12-a6ff-451d-8a77-fd9527d8c663"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("fe43f28a-2ce9-4010-8d19-cc1309d35478"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("6fff0d07-bf89-45fd-aaf6-b19cbcabbdcf"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("81c0ec62-42ab-4baa-b880-dcd5c1f3b825"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("9f3c6b54-4ecc-413d-9573-fa1e3538322b"));

            migrationBuilder.AddColumn<bool>(
                name: "IsCreatedAccount",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "DisciplineId", "Title" },
                values: new object[,]
                {
                    { new Guid("127da66f-611d-4a78-a19d-e3b19b750f6e"), "Chemistry" },
                    { new Guid("3a57ce50-958c-4fc7-be4d-4619b1c980b3"), "Physics" },
                    { new Guid("6e3676ee-2fa3-460a-9786-7e352ec3de68"), "Mathematics" },
                    { new Guid("6f5f879a-a749-4980-a386-ca9b5d26632b"), "History" },
                    { new Guid("6feec761-5159-4cf6-89a9-3af37a3736f9"), "Literature" },
                    { new Guid("75024393-0946-492f-a846-c8be62f8c695"), "Music" },
                    { new Guid("7a4a39f8-c512-431c-8938-9df0a44c506a"), "Geography" },
                    { new Guid("80d7e120-d13d-4164-a510-6b4587bb0019"), "Art" },
                    { new Guid("bce0eb66-d98a-42c8-a6f4-87bcc8aee928"), "ComputerScience" },
                    { new Guid("ca21986f-70cd-4752-96b6-be86b07bad82"), "Biology" }
                });

            migrationBuilder.InsertData(
                table: "EstablishmentTypes",
                columns: new[] { "EstablishmentTypeId", "Title" },
                values: new object[,]
                {
                    { new Guid("305e44fb-ffb0-42f7-a4f8-0a3cf0888237"), "College" },
                    { new Guid("33a60446-e606-4ec3-986d-679eb8000c61"), "School" },
                    { new Guid("46909cd1-a1b7-4e52-9a59-2393375dcfbd"), "Lyceum" },
                    { new Guid("a8b8e0e2-6f50-4ba8-8686-5455babb6f3d"), "Gymnasium" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeNumber" },
                values: new object[,]
                {
                    { new Guid("11e756d6-edc3-4d32-ae5b-dade37c337b8"), 12 },
                    { new Guid("11e7d57d-1dc9-4774-8b96-2503b6f1e3fe"), 11 },
                    { new Guid("1c617843-8821-4735-88a4-832add57b8d0"), 8 },
                    { new Guid("30a3c851-9dac-4ce7-85f8-e75c3e58cbc7"), 5 },
                    { new Guid("4669f0d1-52ed-4885-871d-2ea0ba7cc0cc"), 9 },
                    { new Guid("607f48d9-cf66-47f0-9537-f1c2b59d3355"), 3 },
                    { new Guid("7515a20d-cdfb-473e-87ee-a4af6662181d"), 6 },
                    { new Guid("80720fc3-48b2-4f5b-8a5e-54539a76fa8a"), 1 },
                    { new Guid("816996df-42db-4211-93f2-bc082f281b76"), 7 },
                    { new Guid("c4a72629-c853-4d9a-a08c-185393da7ebe"), 2 },
                    { new Guid("dec326c1-60cd-4efa-8fc8-5dd0e5be9510"), 4 },
                    { new Guid("dfc84d7a-7415-44d9-aa6e-c7100bf6bef9"), 10 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Title" },
                values: new object[,]
                {
                    { new Guid("06f235c4-67a9-4ec6-84f4-664bb3675e20"), "Portuguese" },
                    { new Guid("2c7169ba-78a7-48fd-b52a-d2cb57e602b7"), "French" },
                    { new Guid("30f81018-2166-4a32-bd1b-e251c639b467"), "Armenian" },
                    { new Guid("5292e7f0-5b99-4dce-bc89-d7e6253f2ba7"), "Azerbaijani" },
                    { new Guid("7b4c7ef4-7f0b-43b9-8805-eb5f1bcfd871"), "English" },
                    { new Guid("7f347b27-9bad-4086-99ad-bcf921aeac6e"), "Kyrgyz" },
                    { new Guid("844779a5-725c-4d76-8af2-620b0350cbaa"), "Russian" },
                    { new Guid("86637c54-065e-4445-ad13-2f580cd5a21e"), "Spanish" },
                    { new Guid("889442dd-a3a9-4d49-8aa8-4ccd6bcf50bb"), "Italian" },
                    { new Guid("8dc90ce3-a360-4872-bcc4-edec0d0790ca"), "Ukrainian" },
                    { new Guid("8e9277e1-437a-4edc-9e31-4bf2e28bca54"), "Uzbek" },
                    { new Guid("9ca4107f-2c26-4629-a32e-4004b4c789a6"), "German" },
                    { new Guid("a32e58c4-19a8-449e-ba73-0ea311d23c18"), "Kazakh" },
                    { new Guid("af9fc8f1-57fb-44e6-addd-a2aead0e0601"), "Hungarian" },
                    { new Guid("bcc592e4-c96d-4da1-8683-bfb9703088e7"), "Belarusian" },
                    { new Guid("c9766a69-b12b-4a85-b7ab-573dd85601ef"), "Georgian" },
                    { new Guid("fc95158a-1427-40e1-8efe-3d8061b26bf6"), "Tajik" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Title" },
                values: new object[,]
                {
                    { new Guid("0e62c457-e1d3-4b20-8e62-54619efdd6f2"), "User" },
                    { new Guid("715a8901-246d-4868-8719-ca401210f7ad"), "Admin" },
                    { new Guid("b23123f6-5ff7-4616-8a06-13c0026655ca"), "Manager" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("127da66f-611d-4a78-a19d-e3b19b750f6e"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("3a57ce50-958c-4fc7-be4d-4619b1c980b3"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("6e3676ee-2fa3-460a-9786-7e352ec3de68"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("6f5f879a-a749-4980-a386-ca9b5d26632b"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("6feec761-5159-4cf6-89a9-3af37a3736f9"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("75024393-0946-492f-a846-c8be62f8c695"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("7a4a39f8-c512-431c-8938-9df0a44c506a"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("80d7e120-d13d-4164-a510-6b4587bb0019"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("bce0eb66-d98a-42c8-a6f4-87bcc8aee928"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("ca21986f-70cd-4752-96b6-be86b07bad82"));

            migrationBuilder.DeleteData(
                table: "EstablishmentTypes",
                keyColumn: "EstablishmentTypeId",
                keyValue: new Guid("305e44fb-ffb0-42f7-a4f8-0a3cf0888237"));

            migrationBuilder.DeleteData(
                table: "EstablishmentTypes",
                keyColumn: "EstablishmentTypeId",
                keyValue: new Guid("33a60446-e606-4ec3-986d-679eb8000c61"));

            migrationBuilder.DeleteData(
                table: "EstablishmentTypes",
                keyColumn: "EstablishmentTypeId",
                keyValue: new Guid("46909cd1-a1b7-4e52-9a59-2393375dcfbd"));

            migrationBuilder.DeleteData(
                table: "EstablishmentTypes",
                keyColumn: "EstablishmentTypeId",
                keyValue: new Guid("a8b8e0e2-6f50-4ba8-8686-5455babb6f3d"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("11e756d6-edc3-4d32-ae5b-dade37c337b8"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("11e7d57d-1dc9-4774-8b96-2503b6f1e3fe"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("1c617843-8821-4735-88a4-832add57b8d0"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("30a3c851-9dac-4ce7-85f8-e75c3e58cbc7"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("4669f0d1-52ed-4885-871d-2ea0ba7cc0cc"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("607f48d9-cf66-47f0-9537-f1c2b59d3355"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("7515a20d-cdfb-473e-87ee-a4af6662181d"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("80720fc3-48b2-4f5b-8a5e-54539a76fa8a"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("816996df-42db-4211-93f2-bc082f281b76"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("c4a72629-c853-4d9a-a08c-185393da7ebe"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("dec326c1-60cd-4efa-8fc8-5dd0e5be9510"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("dfc84d7a-7415-44d9-aa6e-c7100bf6bef9"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("06f235c4-67a9-4ec6-84f4-664bb3675e20"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("2c7169ba-78a7-48fd-b52a-d2cb57e602b7"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("30f81018-2166-4a32-bd1b-e251c639b467"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("5292e7f0-5b99-4dce-bc89-d7e6253f2ba7"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("7b4c7ef4-7f0b-43b9-8805-eb5f1bcfd871"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("7f347b27-9bad-4086-99ad-bcf921aeac6e"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("844779a5-725c-4d76-8af2-620b0350cbaa"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("86637c54-065e-4445-ad13-2f580cd5a21e"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("889442dd-a3a9-4d49-8aa8-4ccd6bcf50bb"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("8dc90ce3-a360-4872-bcc4-edec0d0790ca"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("8e9277e1-437a-4edc-9e31-4bf2e28bca54"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("9ca4107f-2c26-4629-a32e-4004b4c789a6"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("a32e58c4-19a8-449e-ba73-0ea311d23c18"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("af9fc8f1-57fb-44e6-addd-a2aead0e0601"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("bcc592e4-c96d-4da1-8683-bfb9703088e7"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("c9766a69-b12b-4a85-b7ab-573dd85601ef"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("fc95158a-1427-40e1-8efe-3d8061b26bf6"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("0e62c457-e1d3-4b20-8e62-54619efdd6f2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("715a8901-246d-4868-8719-ca401210f7ad"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("b23123f6-5ff7-4616-8a06-13c0026655ca"));

            migrationBuilder.DropColumn(
                name: "IsCreatedAccount",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "DisciplineId", "Title" },
                values: new object[,]
                {
                    { new Guid("0e190e73-d559-4831-aa41-402fa8e754c7"), "Physics" },
                    { new Guid("30ce693a-01cd-4392-88b3-cf192b52c0af"), "Music" },
                    { new Guid("41fe2e42-e605-48d5-96de-314a139f5bef"), "Literature" },
                    { new Guid("45d4f0ae-cbdc-4290-a17e-230f99395b0e"), "Geography" },
                    { new Guid("5660e95c-02fd-4815-a846-52e2131a5b69"), "Biology" },
                    { new Guid("58401dbc-658c-4885-9e37-1b51c605fbd3"), "Chemistry" },
                    { new Guid("a765e545-cfbd-42c8-aa40-45640481ff12"), "Art" },
                    { new Guid("ab9468eb-d723-4ced-b9f3-d7e2cae3062f"), "ComputerScience" },
                    { new Guid("c1172edd-4e95-4c4d-8637-77e76ac91240"), "History" },
                    { new Guid("ce4f0ffc-6b6a-4698-9f8b-456b7952930d"), "Mathematics" }
                });

            migrationBuilder.InsertData(
                table: "EstablishmentTypes",
                columns: new[] { "EstablishmentTypeId", "Title" },
                values: new object[,]
                {
                    { new Guid("460b4a16-7d13-4587-bae8-b4efbb28b096"), "Gymnasium" },
                    { new Guid("5e8a5e0d-a7ea-433d-b061-be061558ae98"), "College" },
                    { new Guid("69bcdd4c-8a5b-4408-93c1-c8122aeb254c"), "School" },
                    { new Guid("f2315c84-6a71-4956-a2ba-dd3591374ca1"), "Lyceum" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeNumber" },
                values: new object[,]
                {
                    { new Guid("02079c0a-1a5a-4a94-9926-9a66a08e1892"), 10 },
                    { new Guid("1bfab4f1-1bfe-4019-a92c-c3bec3b66196"), 8 },
                    { new Guid("44ec880d-0ebd-4ff6-82b9-aaa944ba7db9"), 3 },
                    { new Guid("61a69601-de72-4cea-9868-d855231b98ea"), 9 },
                    { new Guid("9b75bb5d-dedc-4133-89bd-2d925b05105f"), 11 },
                    { new Guid("9b785c0f-1113-4f9f-82f7-9ee2ba85800e"), 4 },
                    { new Guid("a2f15865-54ed-4e32-a4af-b418d588d0ca"), 7 },
                    { new Guid("aa768fb8-f662-4732-918c-37a9584e39f7"), 12 },
                    { new Guid("d378f043-cbda-420e-9fd5-0f1863b1828b"), 2 },
                    { new Guid("db4d7464-b1ef-46ef-933e-092c93d27e2e"), 1 },
                    { new Guid("f3771ef0-97c6-4135-b8d8-7d1fb4e609cd"), 6 },
                    { new Guid("fd327c6c-8ba2-487d-9cbc-7181c265182d"), 5 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Title" },
                values: new object[,]
                {
                    { new Guid("03aeed61-9067-401e-b0e7-0e1d602e2a9a"), "Kazakh" },
                    { new Guid("3e731e5a-5b73-44d8-bc4c-03601777ee9c"), "Italian" },
                    { new Guid("4eab363d-f401-4341-9fb2-08d3c5efbbb7"), "Ukrainian" },
                    { new Guid("72fafbf8-a20e-4c0e-8fea-40c28619569d"), "English" },
                    { new Guid("860a6675-18d0-4ccf-98a6-88192f11b157"), "Hungarian" },
                    { new Guid("9bc119e7-7b17-4d0a-9b42-937c26a63bd6"), "Kyrgyz" },
                    { new Guid("b1e44286-5cd8-4076-96e3-89b6d0103e6f"), "Belarusian" },
                    { new Guid("b2ea8b5d-57df-4bb9-b5bf-055daabcc221"), "Georgian" },
                    { new Guid("c89ede26-696e-4a95-aa01-a76da716d4ff"), "Azerbaijani" },
                    { new Guid("d0c5bd41-d76a-47ef-8ec4-bdad7ac019e0"), "Russian" },
                    { new Guid("d349a958-5c02-44d4-b1c3-92f112efb91c"), "Tajik" },
                    { new Guid("e0ed9bf2-8154-4947-a4ab-1cbf2bf66dd5"), "French" },
                    { new Guid("ef9578e5-067a-4530-8498-074e20513c36"), "Spanish" },
                    { new Guid("f02b427d-fe16-4980-96b4-c4720a7d7968"), "Portuguese" },
                    { new Guid("f8adc4ae-18cf-478a-8b4b-c820cb5f0845"), "Armenian" },
                    { new Guid("fe00de12-a6ff-451d-8a77-fd9527d8c663"), "Uzbek" },
                    { new Guid("fe43f28a-2ce9-4010-8d19-cc1309d35478"), "German" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Title" },
                values: new object[,]
                {
                    { new Guid("6fff0d07-bf89-45fd-aaf6-b19cbcabbdcf"), "Admin" },
                    { new Guid("81c0ec62-42ab-4baa-b880-dcd5c1f3b825"), "Manager" },
                    { new Guid("9f3c6b54-4ecc-413d-9573-fa1e3538322b"), "User" }
                });
        }
    }
}
