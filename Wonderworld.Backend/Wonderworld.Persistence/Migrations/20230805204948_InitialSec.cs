using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wonderworld.Persistence.Migrations
{
    public partial class InitialSec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("02740c6d-223b-4953-8a01-c54c16436dd9"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("06c8ddea-2321-46a4-beb4-5b7947791e56"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("0eee2d64-54e8-4fbc-9224-4defb5fb2ddf"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("24ac3cc5-9335-48db-901b-e581bdf839b8"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("2b10cd21-a61a-4cf6-8b3e-c1273bf52617"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("6293b70d-fcf5-42cd-9933-9db08a160e7a"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("a754f80a-c1c0-4aec-9d42-ab6e30fb37ce"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("c551e9bc-a9cd-47e8-9a16-687a2027002c"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("ce529ac1-89e1-4095-a553-a90943f7790c"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("ed43be3e-1341-4857-843a-5b47b55306f5"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("1e3df4d9-fcc3-49c6-be71-5e5a1c8a6b13"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("32344afe-a4b3-4137-b050-b5fc4ec869b1"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("58476213-5bdd-46dd-a904-76166bea5581"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("5a476302-3dea-4a7b-b42e-6c1eb891bdec"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("7825f406-cdd6-4647-ae7e-9ffc26177de4"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("9410550c-7df7-4fd5-ac8f-a71372d18816"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("a0d91032-b371-498a-a5c3-9e59341d7a0e"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("a1a9c2e6-f39a-472f-9c6e-d64e86ea3b8a"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("b1473ff4-39ef-40f1-bb1a-23c7cf036fac"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("c917c332-2c30-494c-b4c4-93f0fa152946"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("cdaca36c-f273-4bd9-b2fe-726f86435fe1"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("f528e6f7-b918-4c2c-8b31-4837b19b5cc5"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("226b0693-354e-4108-aa33-c6410ae7d700"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("557b8744-294f-44a9-92a8-83479e8989f5"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("66a720d0-9dca-4048-bb00-29df003440d1"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("821cb7ef-7033-44b9-b32e-2d043bda62b4"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("8ce2d8f1-0136-4ad5-ab8a-569264c7dcb2"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("9636cf4d-8b67-4061-8ead-ef0b482b60d7"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("9af93013-c9f3-48f7-8935-9079072f6554"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("a1dc162a-8756-4246-bde0-0cd3f662827a"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("aa722dc8-8c62-43e9-b466-98304fca89a0"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("ace16174-815f-4661-92e1-e8eb23d1ffff"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("c427c334-4468-4b17-b3d3-d17a4fc76c26"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("c6502dad-5d49-4a35-8015-f6acd3d7492a"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("ca140106-79c5-4709-a5b2-eda25f364f6d"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("ccfb7ab5-c80f-4b54-a6f1-cf476bbc6f1e"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("d1f148af-85b8-4d38-8c1a-7effcf660499"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("ef826e19-452d-407c-a1d3-5be893831713"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("efc99b67-b235-440d-af0c-9807653f10a8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("1ca81997-86ef-4379-a40f-b25370c50676"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("3568f759-6b29-425f-82a3-2084b52e2c68"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("4db5b138-f32e-4aee-a63c-ee6e752a936a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "EstablishmentId",
                table: "Users",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CityLocationId",
                table: "Users",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "EstablishmentId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CityLocationId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "DisciplineId", "Title" },
                values: new object[,]
                {
                    { new Guid("02740c6d-223b-4953-8a01-c54c16436dd9"), "Biology" },
                    { new Guid("06c8ddea-2321-46a4-beb4-5b7947791e56"), "Music" },
                    { new Guid("0eee2d64-54e8-4fbc-9224-4defb5fb2ddf"), "Chemistry" },
                    { new Guid("24ac3cc5-9335-48db-901b-e581bdf839b8"), "Geography" },
                    { new Guid("2b10cd21-a61a-4cf6-8b3e-c1273bf52617"), "History" },
                    { new Guid("6293b70d-fcf5-42cd-9933-9db08a160e7a"), "ComputerScience" },
                    { new Guid("a754f80a-c1c0-4aec-9d42-ab6e30fb37ce"), "Literature" },
                    { new Guid("c551e9bc-a9cd-47e8-9a16-687a2027002c"), "Mathematics" },
                    { new Guid("ce529ac1-89e1-4095-a553-a90943f7790c"), "Art" },
                    { new Guid("ed43be3e-1341-4857-843a-5b47b55306f5"), "Physics" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeNumber" },
                values: new object[,]
                {
                    { new Guid("1e3df4d9-fcc3-49c6-be71-5e5a1c8a6b13"), 3 },
                    { new Guid("32344afe-a4b3-4137-b050-b5fc4ec869b1"), 4 },
                    { new Guid("58476213-5bdd-46dd-a904-76166bea5581"), 2 },
                    { new Guid("5a476302-3dea-4a7b-b42e-6c1eb891bdec"), 6 },
                    { new Guid("7825f406-cdd6-4647-ae7e-9ffc26177de4"), 7 },
                    { new Guid("9410550c-7df7-4fd5-ac8f-a71372d18816"), 8 },
                    { new Guid("a0d91032-b371-498a-a5c3-9e59341d7a0e"), 11 },
                    { new Guid("a1a9c2e6-f39a-472f-9c6e-d64e86ea3b8a"), 10 },
                    { new Guid("b1473ff4-39ef-40f1-bb1a-23c7cf036fac"), 1 },
                    { new Guid("c917c332-2c30-494c-b4c4-93f0fa152946"), 9 },
                    { new Guid("cdaca36c-f273-4bd9-b2fe-726f86435fe1"), 12 },
                    { new Guid("f528e6f7-b918-4c2c-8b31-4837b19b5cc5"), 5 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Title" },
                values: new object[,]
                {
                    { new Guid("226b0693-354e-4108-aa33-c6410ae7d700"), "Belarusian" },
                    { new Guid("557b8744-294f-44a9-92a8-83479e8989f5"), "English" },
                    { new Guid("66a720d0-9dca-4048-bb00-29df003440d1"), "Azerbaijani" },
                    { new Guid("821cb7ef-7033-44b9-b32e-2d043bda62b4"), "Portuguese" },
                    { new Guid("8ce2d8f1-0136-4ad5-ab8a-569264c7dcb2"), "German" },
                    { new Guid("9636cf4d-8b67-4061-8ead-ef0b482b60d7"), "Russian" },
                    { new Guid("9af93013-c9f3-48f7-8935-9079072f6554"), "Georgian" },
                    { new Guid("a1dc162a-8756-4246-bde0-0cd3f662827a"), "French" },
                    { new Guid("aa722dc8-8c62-43e9-b466-98304fca89a0"), "Uzbek" },
                    { new Guid("ace16174-815f-4661-92e1-e8eb23d1ffff"), "Spanish" },
                    { new Guid("c427c334-4468-4b17-b3d3-d17a4fc76c26"), "Hungarian" },
                    { new Guid("c6502dad-5d49-4a35-8015-f6acd3d7492a"), "Tajik" },
                    { new Guid("ca140106-79c5-4709-a5b2-eda25f364f6d"), "Kazakh" },
                    { new Guid("ccfb7ab5-c80f-4b54-a6f1-cf476bbc6f1e"), "Kyrgyz" },
                    { new Guid("d1f148af-85b8-4d38-8c1a-7effcf660499"), "Armenian" },
                    { new Guid("ef826e19-452d-407c-a1d3-5be893831713"), "Italian" },
                    { new Guid("efc99b67-b235-440d-af0c-9807653f10a8"), "Ukrainian" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Title" },
                values: new object[,]
                {
                    { new Guid("1ca81997-86ef-4379-a40f-b25370c50676"), "Manager" },
                    { new Guid("3568f759-6b29-425f-82a3-2084b52e2c68"), "User" },
                    { new Guid("4db5b138-f32e-4aee-a63c-ee6e752a936a"), "Admin" }
                });
        }
    }
}
