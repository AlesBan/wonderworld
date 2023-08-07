using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wonderworld.Persistence.Migrations
{
    public partial class UserRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("3604bd66-32fc-46af-9320-98fef1e49ff1"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("4d6703f4-c141-4788-b1e0-235ebc71ae92"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("58b4d3e3-9d50-47b9-8d56-12ca6a8f7e77"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("6c6401ab-9939-48ad-a7d4-a25d16eca3e7"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("d443a848-1a75-4b6f-9b1a-5361709f926e"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("d9d3da8f-157f-4bed-9fc8-979f4fb66588"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("da39a581-2f46-4d36-9d4b-02c850888af5"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("ddb9dd2a-e067-4153-8d3a-954d4c1bea5b"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("e1d5e9f2-8af9-4382-bad8-705d4164be5f"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("fe285971-e678-4fca-8f95-0c8811a4ed30"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("1cca28de-6793-462b-8771-8902da208b74"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("35329f95-ff11-4300-93ad-7c5e55d3217a"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("3f802bac-465d-400a-bf58-2f42a52eac92"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("4025dfcd-404d-4079-984d-66ee2dc7e4d3"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("6bb0652d-f876-45d5-a29e-2aa7964a4509"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("781d4bdf-2598-4090-beea-790284a9a9cf"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("7eca9ed7-8dd8-4afe-9768-35705c0b5ae5"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("85de5a69-36e1-476a-9ac4-9127ab897876"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("8dfdc761-7f89-46bf-ba77-a911f65f8c0d"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("e8125c3f-a991-4f27-afcf-8b602b8e41e0"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("e89dff44-c8e1-459a-b24b-a27182bab21f"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("fa6b2fb0-e3ca-42a1-a653-b0b58daab49b"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("03c1d9e2-be82-45a8-b433-f04da67cc337"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("0979721b-e87d-4f15-b76c-db3c26fb6678"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("098c4434-8383-40f5-a7b8-e690cababf0e"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("17a0df72-6a36-4e19-8d64-a4c6cbda2154"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("2a65bdf2-066a-4222-a081-4f92512aecaa"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("2b1af419-fdf7-413d-92fd-5904543c7538"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("3518b2f2-ca73-4b2d-afdc-4d92949807a6"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("425eb6e6-6235-41df-a3e9-eaaf163dca8a"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("6ac08058-e9fa-4237-a8d1-78376de48056"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("7560466f-8157-453f-adc4-05c39f537b4e"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("80667a98-572e-46e0-9b13-298eaad6f0e3"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("86c91199-8e16-42f5-89df-4a9ac472b6ea"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("c3d4d62a-5439-415d-868f-c4a55717d8e2"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("d3e012a1-22fe-4a91-8d6c-5ddc1e6b1f9f"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("da4bebb0-2c1a-400f-898a-c33b304810cb"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("f1a408d7-c90a-460a-b6f9-3d930e2200cb"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("f25c7659-2939-4631-961f-aec1877370cc"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("30d16e73-9667-4cdd-b7dd-8313437e758a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("49e5b9d4-c3e6-42a8-89d0-b58fc2b09f5e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("532e25b2-b098-4046-8ba5-bda5cf56f362"));

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "Users",
                type: "numeric(3,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "DisciplineId", "Title" },
                values: new object[,]
                {
                    { new Guid("10bc58ac-b2e9-4a6d-aef0-47631f8baa3b"), "Art" },
                    { new Guid("17261967-5430-4b39-9a71-2314410d713d"), "Physics" },
                    { new Guid("876e4ebc-b62f-4e21-a0d8-371e46cea175"), "Biology" },
                    { new Guid("a2b8e692-d712-4d62-b764-40c90317cda7"), "History" },
                    { new Guid("a8dca757-e0ce-4afc-8a9f-d6cd36a04e18"), "Mathematics" },
                    { new Guid("ab79262c-0cb8-4195-875c-429067e8c5af"), "Geography" },
                    { new Guid("c2e72167-d906-44a8-8775-5683581010a5"), "Literature" },
                    { new Guid("c5a94e73-22c7-4839-8733-a9920149e74d"), "Music" },
                    { new Guid("cd8e5173-2b37-43af-96c7-332c6bab1cbe"), "ComputerScience" },
                    { new Guid("dfe6a137-5bb6-4266-aac2-dbd46d65b830"), "Chemistry" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeNumber" },
                values: new object[,]
                {
                    { new Guid("1ed95a2c-ffa8-47e5-afe5-f696ce4448ff"), 10 },
                    { new Guid("36862d5e-6975-4410-90c6-372d4269b9d9"), 8 },
                    { new Guid("36c9c3e5-b33d-41a8-914b-a45611f5c651"), 9 },
                    { new Guid("37b12385-6566-4f2e-bb88-85fe0a49906a"), 1 },
                    { new Guid("39afa5e9-5e81-4203-9c57-390f8d64eed8"), 2 },
                    { new Guid("4927c060-f4b4-4468-bf58-8a381df728cd"), 4 },
                    { new Guid("4d1f08e5-1b3e-4c03-9a08-2aab6a197dcc"), 11 },
                    { new Guid("67ba432c-5c8d-480d-9ed5-50770bcf4ddf"), 5 },
                    { new Guid("69ff09c7-9c34-492b-b12b-ba5528c86568"), 6 },
                    { new Guid("b4e831b3-ad93-4f80-a6b4-344b0b20567d"), 3 },
                    { new Guid("c13e7b05-55b5-4289-bd51-34e85b54911e"), 12 },
                    { new Guid("d0748120-3140-4bc0-8995-5d7646cfcb5c"), 7 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Title" },
                values: new object[,]
                {
                    { new Guid("0965e471-0b7a-42da-8f92-802426733d7a"), "Georgian" },
                    { new Guid("15068c7f-065c-4d4f-812c-58130c5d93b2"), "Russian" },
                    { new Guid("177d3899-7844-4e80-9306-4acca3b57659"), "Armenian" },
                    { new Guid("26825faa-362f-44dc-9f14-0ded9c6d84cb"), "Kyrgyz" },
                    { new Guid("2caae185-5b63-4318-aeb5-44a3cee99de1"), "Spanish" },
                    { new Guid("45bb9828-f5fd-4791-b8a9-49bfe26bc6a4"), "English" },
                    { new Guid("57fb634d-e535-4b31-a413-f228af83ae4c"), "Tajik" },
                    { new Guid("5e7aed81-7996-4cb7-a3e3-04a6ffd459a4"), "Uzbek" },
                    { new Guid("687e539f-6bfa-45ac-affc-04a6744992bf"), "Italian" },
                    { new Guid("a70ef02e-45ae-4855-8e36-c7f068b32025"), "Belarusian" },
                    { new Guid("b645184f-b13f-4f2c-9276-f312dcbe5159"), "Ukrainian" },
                    { new Guid("cb7058a8-4c4e-497c-93b9-245e3da12a28"), "Azerbaijani" },
                    { new Guid("cc76d849-d298-4424-89de-07d85f674d34"), "Hungarian" },
                    { new Guid("d0758937-8c73-4812-8c63-acf01763e2ec"), "French" },
                    { new Guid("d27de042-a0de-4794-a704-489cbd5fc7aa"), "Portuguese" },
                    { new Guid("dddc4db6-6a04-4cc7-940c-1333e2f84a80"), "German" },
                    { new Guid("ecd5f22c-38b5-4801-a2da-d6a5ddbb969c"), "Kazakh" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Title" },
                values: new object[,]
                {
                    { new Guid("b319e2d0-c5bb-47c9-ae8b-4cd160aaa44b"), "Manager" },
                    { new Guid("bf357e3a-08cb-437f-a255-36d38b921a4c"), "User" },
                    { new Guid("e5cf0f25-b720-421d-b7c0-a5f7fcc849b1"), "Admin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("10bc58ac-b2e9-4a6d-aef0-47631f8baa3b"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("17261967-5430-4b39-9a71-2314410d713d"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("876e4ebc-b62f-4e21-a0d8-371e46cea175"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("a2b8e692-d712-4d62-b764-40c90317cda7"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("a8dca757-e0ce-4afc-8a9f-d6cd36a04e18"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("ab79262c-0cb8-4195-875c-429067e8c5af"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("c2e72167-d906-44a8-8775-5683581010a5"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("c5a94e73-22c7-4839-8733-a9920149e74d"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("cd8e5173-2b37-43af-96c7-332c6bab1cbe"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("dfe6a137-5bb6-4266-aac2-dbd46d65b830"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("1ed95a2c-ffa8-47e5-afe5-f696ce4448ff"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("36862d5e-6975-4410-90c6-372d4269b9d9"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("36c9c3e5-b33d-41a8-914b-a45611f5c651"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("37b12385-6566-4f2e-bb88-85fe0a49906a"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("39afa5e9-5e81-4203-9c57-390f8d64eed8"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("4927c060-f4b4-4468-bf58-8a381df728cd"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("4d1f08e5-1b3e-4c03-9a08-2aab6a197dcc"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("67ba432c-5c8d-480d-9ed5-50770bcf4ddf"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("69ff09c7-9c34-492b-b12b-ba5528c86568"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("b4e831b3-ad93-4f80-a6b4-344b0b20567d"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("c13e7b05-55b5-4289-bd51-34e85b54911e"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("d0748120-3140-4bc0-8995-5d7646cfcb5c"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("0965e471-0b7a-42da-8f92-802426733d7a"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("15068c7f-065c-4d4f-812c-58130c5d93b2"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("177d3899-7844-4e80-9306-4acca3b57659"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("26825faa-362f-44dc-9f14-0ded9c6d84cb"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("2caae185-5b63-4318-aeb5-44a3cee99de1"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("45bb9828-f5fd-4791-b8a9-49bfe26bc6a4"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("57fb634d-e535-4b31-a413-f228af83ae4c"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("5e7aed81-7996-4cb7-a3e3-04a6ffd459a4"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("687e539f-6bfa-45ac-affc-04a6744992bf"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("a70ef02e-45ae-4855-8e36-c7f068b32025"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("b645184f-b13f-4f2c-9276-f312dcbe5159"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("cb7058a8-4c4e-497c-93b9-245e3da12a28"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("cc76d849-d298-4424-89de-07d85f674d34"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("d0758937-8c73-4812-8c63-acf01763e2ec"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("d27de042-a0de-4794-a704-489cbd5fc7aa"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("dddc4db6-6a04-4cc7-940c-1333e2f84a80"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("ecd5f22c-38b5-4801-a2da-d6a5ddbb969c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("b319e2d0-c5bb-47c9-ae8b-4cd160aaa44b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("bf357e3a-08cb-437f-a255-36d38b921a4c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("e5cf0f25-b720-421d-b7c0-a5f7fcc849b1"));

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "DisciplineId", "Title" },
                values: new object[,]
                {
                    { new Guid("3604bd66-32fc-46af-9320-98fef1e49ff1"), "History" },
                    { new Guid("4d6703f4-c141-4788-b1e0-235ebc71ae92"), "Chemistry" },
                    { new Guid("58b4d3e3-9d50-47b9-8d56-12ca6a8f7e77"), "ComputerScience" },
                    { new Guid("6c6401ab-9939-48ad-a7d4-a25d16eca3e7"), "Physics" },
                    { new Guid("d443a848-1a75-4b6f-9b1a-5361709f926e"), "Geography" },
                    { new Guid("d9d3da8f-157f-4bed-9fc8-979f4fb66588"), "Literature" },
                    { new Guid("da39a581-2f46-4d36-9d4b-02c850888af5"), "Music" },
                    { new Guid("ddb9dd2a-e067-4153-8d3a-954d4c1bea5b"), "Art" },
                    { new Guid("e1d5e9f2-8af9-4382-bad8-705d4164be5f"), "Mathematics" },
                    { new Guid("fe285971-e678-4fca-8f95-0c8811a4ed30"), "Biology" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeNumber" },
                values: new object[,]
                {
                    { new Guid("1cca28de-6793-462b-8771-8902da208b74"), 9 },
                    { new Guid("35329f95-ff11-4300-93ad-7c5e55d3217a"), 5 },
                    { new Guid("3f802bac-465d-400a-bf58-2f42a52eac92"), 10 },
                    { new Guid("4025dfcd-404d-4079-984d-66ee2dc7e4d3"), 12 },
                    { new Guid("6bb0652d-f876-45d5-a29e-2aa7964a4509"), 6 },
                    { new Guid("781d4bdf-2598-4090-beea-790284a9a9cf"), 7 },
                    { new Guid("7eca9ed7-8dd8-4afe-9768-35705c0b5ae5"), 3 },
                    { new Guid("85de5a69-36e1-476a-9ac4-9127ab897876"), 4 },
                    { new Guid("8dfdc761-7f89-46bf-ba77-a911f65f8c0d"), 11 },
                    { new Guid("e8125c3f-a991-4f27-afcf-8b602b8e41e0"), 8 },
                    { new Guid("e89dff44-c8e1-459a-b24b-a27182bab21f"), 2 },
                    { new Guid("fa6b2fb0-e3ca-42a1-a653-b0b58daab49b"), 1 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Title" },
                values: new object[,]
                {
                    { new Guid("03c1d9e2-be82-45a8-b433-f04da67cc337"), "German" },
                    { new Guid("0979721b-e87d-4f15-b76c-db3c26fb6678"), "Ukrainian" },
                    { new Guid("098c4434-8383-40f5-a7b8-e690cababf0e"), "Armenian" },
                    { new Guid("17a0df72-6a36-4e19-8d64-a4c6cbda2154"), "Azerbaijani" },
                    { new Guid("2a65bdf2-066a-4222-a081-4f92512aecaa"), "Tajik" },
                    { new Guid("2b1af419-fdf7-413d-92fd-5904543c7538"), "Georgian" },
                    { new Guid("3518b2f2-ca73-4b2d-afdc-4d92949807a6"), "Belarusian" },
                    { new Guid("425eb6e6-6235-41df-a3e9-eaaf163dca8a"), "Russian" },
                    { new Guid("6ac08058-e9fa-4237-a8d1-78376de48056"), "Kazakh" },
                    { new Guid("7560466f-8157-453f-adc4-05c39f537b4e"), "Uzbek" },
                    { new Guid("80667a98-572e-46e0-9b13-298eaad6f0e3"), "Italian" },
                    { new Guid("86c91199-8e16-42f5-89df-4a9ac472b6ea"), "French" },
                    { new Guid("c3d4d62a-5439-415d-868f-c4a55717d8e2"), "Hungarian" },
                    { new Guid("d3e012a1-22fe-4a91-8d6c-5ddc1e6b1f9f"), "Kyrgyz" },
                    { new Guid("da4bebb0-2c1a-400f-898a-c33b304810cb"), "English" },
                    { new Guid("f1a408d7-c90a-460a-b6f9-3d930e2200cb"), "Spanish" },
                    { new Guid("f25c7659-2939-4631-961f-aec1877370cc"), "Portuguese" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Title" },
                values: new object[,]
                {
                    { new Guid("30d16e73-9667-4cdd-b7dd-8313437e758a"), "Manager" },
                    { new Guid("49e5b9d4-c3e6-42a8-89d0-b58fc2b09f5e"), "Admin" },
                    { new Guid("532e25b2-b098-4046-8ba5-bda5cf56f362"), "User" }
                });
        }
    }
}
