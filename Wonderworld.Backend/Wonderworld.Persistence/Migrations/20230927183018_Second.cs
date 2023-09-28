using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wonderworld.Persistence.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("12e32ab4-4bd6-41a5-a6a1-17677cb22f14"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("2ba503e0-f36a-4070-aafe-58f3a581988c"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("39489292-5bf2-4926-af41-a35e096291c0"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("3a03b7ed-003f-4488-a2da-5b960925e14c"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("51bf8b2e-f1a4-4fa5-b159-879838a31d29"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("77c1dc25-aa92-4b8f-8bcb-61e8980300ba"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("7a5d5f21-9219-4198-ad91-0088b6d3c4c7"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("8488a267-b965-4f17-afff-310f36fb03b0"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("892c19b4-ff96-460b-984d-de42c3e07011"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("c826c4d0-086a-4ad5-8653-380dd0fbe860"));

            migrationBuilder.DeleteData(
                table: "EstablishmentTypes",
                keyColumn: "EstablishmentTypeId",
                keyValue: new Guid("211bb15d-890f-47f4-98c9-b697b219b685"));

            migrationBuilder.DeleteData(
                table: "EstablishmentTypes",
                keyColumn: "EstablishmentTypeId",
                keyValue: new Guid("3508b455-92b2-45e6-b9fe-df3a28bf4c3d"));

            migrationBuilder.DeleteData(
                table: "EstablishmentTypes",
                keyColumn: "EstablishmentTypeId",
                keyValue: new Guid("9b4c1626-1590-4fa4-9378-77217f8f2ded"));

            migrationBuilder.DeleteData(
                table: "EstablishmentTypes",
                keyColumn: "EstablishmentTypeId",
                keyValue: new Guid("cd5a11d0-32ba-4abf-a69d-6db22e0ca57c"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("0720b107-634e-4fac-8cc2-f4fd719fcb8f"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("27a9e2ce-2d6b-4693-927d-708f8f80054d"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("33bab36d-e5a7-460d-81b8-757aa6d08ccf"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("3cb1506a-3363-476b-97d9-b3c76e4b84fc"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("46737a11-05e4-42a8-bf66-49756596e621"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("4a752de7-2b5c-4602-8d57-beb82192a078"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("5191f049-608e-4af3-806d-44928f204534"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("972bc893-6473-43b7-aa66-47e78836a17d"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("ba07b451-b8d9-498e-8295-553957d25398"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("c27ec8be-d437-417d-bd72-924793436185"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("f74ea891-6af5-4d55-8df6-c8b84ed056d5"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("fe4d4dfa-0401-4bdd-a807-d3b0cdc66b3e"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("01da0636-73c2-4064-832b-b08507f7185d"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("1b5321fa-9c05-4f5f-b79d-c97eab597d13"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("553d380f-efa6-4449-9611-8520c7950bcb"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("56adfde8-ff38-41d8-8b5f-5841ed8bb0e7"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("7665b51b-fa3e-4fa4-8de0-f6ac5f84c048"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("acd9653a-36fd-4589-8623-caa69465ac2b"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("af4d3401-029e-4d32-a11b-57bde67f36bd"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("afd0c237-ea5c-4c74-9c3c-f5bcf8c4b4b2"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("ca7cc77e-56e9-422e-9481-e6f827a84bbf"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("cedbe0ce-67eb-45c6-b6e1-24b175e959b9"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("cee18000-7962-4589-b921-6073d973bcab"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("cf15b52b-550a-4232-8b23-beda393a7678"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("d2e170fa-b628-40f7-986e-6a1ebe5090a4"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("d6a99ba6-57fa-48c8-8154-112f79ea644d"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("e80a9f55-cb6c-46d9-8f4f-ac9ab3a10522"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("ee149c52-1462-465a-aee5-c55c59b525e1"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("fb61c794-d6cc-4862-8f64-be406e0c2f4c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("5f42ec30-36b8-4a62-89d3-b95f903f8c96"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("5fb8d71c-c043-4668-a9ac-d6393b82454e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("d26feb00-7f02-495b-9647-aa9213f7093f"));

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Establishments");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Establishments",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "DisciplineId", "Title" },
                values: new object[,]
                {
                    { new Guid("12e32ab4-4bd6-41a5-a6a1-17677cb22f14"), "Chemistry" },
                    { new Guid("2ba503e0-f36a-4070-aafe-58f3a581988c"), "History" },
                    { new Guid("39489292-5bf2-4926-af41-a35e096291c0"), "Geography" },
                    { new Guid("3a03b7ed-003f-4488-a2da-5b960925e14c"), "ComputerScience" },
                    { new Guid("51bf8b2e-f1a4-4fa5-b159-879838a31d29"), "Art" },
                    { new Guid("77c1dc25-aa92-4b8f-8bcb-61e8980300ba"), "Mathematics" },
                    { new Guid("7a5d5f21-9219-4198-ad91-0088b6d3c4c7"), "Physics" },
                    { new Guid("8488a267-b965-4f17-afff-310f36fb03b0"), "Music" },
                    { new Guid("892c19b4-ff96-460b-984d-de42c3e07011"), "Biology" },
                    { new Guid("c826c4d0-086a-4ad5-8653-380dd0fbe860"), "Literature" }
                });

            migrationBuilder.InsertData(
                table: "EstablishmentTypes",
                columns: new[] { "EstablishmentTypeId", "Title" },
                values: new object[,]
                {
                    { new Guid("211bb15d-890f-47f4-98c9-b697b219b685"), "Lyceum" },
                    { new Guid("3508b455-92b2-45e6-b9fe-df3a28bf4c3d"), "College" },
                    { new Guid("9b4c1626-1590-4fa4-9378-77217f8f2ded"), "School" },
                    { new Guid("cd5a11d0-32ba-4abf-a69d-6db22e0ca57c"), "Gymnasium" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeNumber" },
                values: new object[,]
                {
                    { new Guid("0720b107-634e-4fac-8cc2-f4fd719fcb8f"), 6 },
                    { new Guid("27a9e2ce-2d6b-4693-927d-708f8f80054d"), 9 },
                    { new Guid("33bab36d-e5a7-460d-81b8-757aa6d08ccf"), 2 },
                    { new Guid("3cb1506a-3363-476b-97d9-b3c76e4b84fc"), 12 },
                    { new Guid("46737a11-05e4-42a8-bf66-49756596e621"), 3 },
                    { new Guid("4a752de7-2b5c-4602-8d57-beb82192a078"), 5 },
                    { new Guid("5191f049-608e-4af3-806d-44928f204534"), 7 },
                    { new Guid("972bc893-6473-43b7-aa66-47e78836a17d"), 4 },
                    { new Guid("ba07b451-b8d9-498e-8295-553957d25398"), 1 },
                    { new Guid("c27ec8be-d437-417d-bd72-924793436185"), 10 },
                    { new Guid("f74ea891-6af5-4d55-8df6-c8b84ed056d5"), 8 },
                    { new Guid("fe4d4dfa-0401-4bdd-a807-d3b0cdc66b3e"), 11 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Title" },
                values: new object[,]
                {
                    { new Guid("01da0636-73c2-4064-832b-b08507f7185d"), "Portuguese" },
                    { new Guid("1b5321fa-9c05-4f5f-b79d-c97eab597d13"), "Italian" },
                    { new Guid("553d380f-efa6-4449-9611-8520c7950bcb"), "Armenian" },
                    { new Guid("56adfde8-ff38-41d8-8b5f-5841ed8bb0e7"), "Spanish" },
                    { new Guid("7665b51b-fa3e-4fa4-8de0-f6ac5f84c048"), "Ukrainian" },
                    { new Guid("acd9653a-36fd-4589-8623-caa69465ac2b"), "Kyrgyz" },
                    { new Guid("af4d3401-029e-4d32-a11b-57bde67f36bd"), "German" },
                    { new Guid("afd0c237-ea5c-4c74-9c3c-f5bcf8c4b4b2"), "Belarusian" },
                    { new Guid("ca7cc77e-56e9-422e-9481-e6f827a84bbf"), "English" },
                    { new Guid("cedbe0ce-67eb-45c6-b6e1-24b175e959b9"), "Tajik" },
                    { new Guid("cee18000-7962-4589-b921-6073d973bcab"), "Azerbaijani" },
                    { new Guid("cf15b52b-550a-4232-8b23-beda393a7678"), "Russian" },
                    { new Guid("d2e170fa-b628-40f7-986e-6a1ebe5090a4"), "French" },
                    { new Guid("d6a99ba6-57fa-48c8-8154-112f79ea644d"), "Georgian" },
                    { new Guid("e80a9f55-cb6c-46d9-8f4f-ac9ab3a10522"), "Hungarian" },
                    { new Guid("ee149c52-1462-465a-aee5-c55c59b525e1"), "Kazakh" },
                    { new Guid("fb61c794-d6cc-4862-8f64-be406e0c2f4c"), "Uzbek" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Title" },
                values: new object[,]
                {
                    { new Guid("5f42ec30-36b8-4a62-89d3-b95f903f8c96"), "User" },
                    { new Guid("5fb8d71c-c043-4668-a9ac-d6393b82454e"), "Manager" },
                    { new Guid("d26feb00-7f02-495b-9647-aa9213f7093f"), "Admin" }
                });
        }
    }
}
