using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wonderworld.Persistence.Migrations
{
    public partial class UpdatecityLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Classes_ClassId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Classes_ClassId1",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cities_CityLocationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ClassId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ClassId1",
                table: "Reviews");

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("079c7079-790c-42fb-9aa6-3fb5e8cb19d1"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("3a0a1de4-ffeb-4d5a-b4ad-9f59f8eac4e1"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("3ad01af1-e427-4e01-96c5-3f588962cbad"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("3d5727f5-5f00-4451-a071-9b676ad72674"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("3e4c5283-caa7-4ec4-868c-7084437f45a9"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("5eb96a67-b401-4c06-b534-73fc258cb889"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("74271aed-d7b5-42c7-ade1-257f6b579b7d"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("8c84e458-1bf9-45aa-be81-285a316f5448"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("9a237aec-287c-4e7b-924e-12fa450111f3"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("9dce7aa6-4257-4e8a-b1dd-251d6858f569"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("0fdffa52-0cc4-4afb-8ba7-1cc028b54463"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("14e0a7e1-567a-4d6a-9f3d-e083dc15e073"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("1c432a79-a0fd-44d8-b7dc-ee084f9c5ae3"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("33ec3053-c39b-4843-b5ea-e7691fc49f71"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("3b08834b-5d5d-497d-8938-654165c229fe"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("412d6b5d-0727-44ee-b6c0-74f946ac4482"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("42fa1162-249d-4839-804e-28440e4647d4"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("5ecc4c4d-db0f-45f7-ac66-a0f28e0b6be8"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("c7dc09ad-7815-4c2e-a506-9112fff5261c"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("d873c31b-d970-41b8-b610-f9a4b4f3f176"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("ea0e4efc-3384-49e4-a13b-f373d3914dae"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("fc4533f2-2e62-4aa0-a902-cfb83d499a31"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("10de7872-b5e1-423c-8aec-977db281c98c"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("15f7c90f-d837-4cc8-b02a-e6e4005d9c22"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("3643da37-3a60-48fb-81ab-ad71ed128bb6"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("467566d2-9aef-4b64-867b-bee87f2f1645"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("49ccb003-7dae-41a8-bdc9-d5ebfa4924de"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("4ad7013e-8c33-49c2-b077-b5bf66c8f78b"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("6bf631b9-46eb-4664-bd0a-9bbd7ad49ec1"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("8439fca7-ba23-49aa-a6c4-cef6ae7df847"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("a9f0f801-5ede-40fe-8b3e-fbdd726c416c"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("c597a8ba-cfc3-4ace-af30-6dd8e7840a3d"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("c61c2b63-d5ff-4bc1-981d-58d4646b1653"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("c7d03534-1b7b-4f24-a0c8-5bfad8f7d20a"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("cef6bbee-1cbd-4441-b5d3-ba17a8c8289a"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("da5d4550-477c-4ba3-8fa6-10d6f96798ba"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("e351e5eb-98f0-41c2-ac5b-4ad37280ab6c"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("fbde1f10-dd53-4a08-937e-c2120d117cc6"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("fec319b7-edae-4222-854e-286002d11c3f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("424ef62a-0d0f-412e-818a-a948c539b6c6"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("5a82ebe9-ad47-462f-ac41-9c60757a1365"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("93f03086-0ab0-4314-bb93-beabf968fb4e"));

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ClassId1",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "CityLocationId",
                table: "Users",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CityLocationId",
                table: "Users",
                newName: "IX_Users_CountryId");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "DisciplineId", "Title" },
                values: new object[,]
                {
                    { new Guid("0981f8de-c2f2-4045-8efa-05483269e183"), "History" },
                    { new Guid("0c6e3f58-8143-4de5-9ccc-b32b25ffec47"), "Biology" },
                    { new Guid("19448dc8-75a4-4c2a-9805-8546e88379b9"), "Music" },
                    { new Guid("5fc0699d-e9f1-4440-be92-655da8a386ea"), "ComputerScience" },
                    { new Guid("aeab206b-e21b-452e-9d14-0dbd09b7b602"), "Geography" },
                    { new Guid("b5a52cd5-6486-4279-9825-e88526f105e8"), "Literature" },
                    { new Guid("d7cc1a26-fb65-46a1-8e2c-21e4e5dccf1c"), "Physics" },
                    { new Guid("ed073876-7ad4-4095-bd51-8270fcf7b2c6"), "Art" },
                    { new Guid("f7d59fc6-d177-437a-add5-721b7f4c16c7"), "Chemistry" },
                    { new Guid("fe015cbc-c7f3-498a-83f3-8a303b0889cc"), "Mathematics" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeNumber" },
                values: new object[,]
                {
                    { new Guid("14bb71ef-97d1-4481-9b00-3ebc8e7123a8"), 3 },
                    { new Guid("3a128386-aea0-4b8d-9d04-06d85e163b9a"), 9 },
                    { new Guid("3e4e8b51-3535-42b6-bbb1-ff6ddf2b9da2"), 11 },
                    { new Guid("43f8cb08-a303-4afd-974d-1f2274d55225"), 8 },
                    { new Guid("5fe0b6d1-b9d1-4a4c-a159-693472175c89"), 4 },
                    { new Guid("63fcc4bf-64a3-4d95-a111-28c2b4de21f0"), 6 },
                    { new Guid("87c61a8e-e763-4055-83f2-35236f19b608"), 5 },
                    { new Guid("8894d094-a9fe-44b0-8418-dd580d004f39"), 2 },
                    { new Guid("b0f4b2a6-ef47-4ac3-88cb-2357f0942b7a"), 12 },
                    { new Guid("bd543e28-48e9-4bf8-b29a-91344ea44db7"), 10 },
                    { new Guid("dd3941e5-4a0d-4212-b80a-466eab14dda5"), 7 },
                    { new Guid("e6dbaec7-eac0-4475-9aa2-1cff5598b245"), 1 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Title" },
                values: new object[,]
                {
                    { new Guid("08ef04f5-54b0-46a9-93fa-8d2aaba16e6f"), "Kyrgyz" },
                    { new Guid("0913135a-0586-45f9-873c-9a894c7a8b76"), "English" },
                    { new Guid("20d68d68-fae1-4dd2-bfa4-b1b22da764d9"), "French" },
                    { new Guid("29725c06-8aa0-41b1-bb52-ad692d36b290"), "Armenian" },
                    { new Guid("37b6fc47-6256-4af5-9ff2-c855b5777956"), "Spanish" },
                    { new Guid("479b8bd5-1965-4d15-b7f7-e09d996035f4"), "Italian" },
                    { new Guid("7f239815-b8e1-49fb-8adc-66bb08bfc16f"), "Kazakh" },
                    { new Guid("83aac05c-5ab4-450f-898d-32a9bdc039e4"), "Tajik" },
                    { new Guid("940199cd-d1b3-4928-8f2a-da85ea3edbb7"), "Hungarian" },
                    { new Guid("9dff528f-90dd-494b-9350-9197567b25a5"), "Portuguese" },
                    { new Guid("a3edb394-ab54-4fcf-afc7-e793de4b784a"), "German" },
                    { new Guid("ad7dad23-b756-49c8-ade0-8672f1026114"), "Belarusian" },
                    { new Guid("b74aa414-ce17-4ed4-96c3-d3f54b83dc66"), "Uzbek" },
                    { new Guid("c37a5f2f-56b8-47d2-ba44-2b4ae4aa7b11"), "Russian" },
                    { new Guid("e084300b-05d3-45d2-9af3-e4ddde31c4fc"), "Azerbaijani" },
                    { new Guid("e58e993c-2988-420d-b897-072cff8d9d56"), "Georgian" },
                    { new Guid("fc191ed5-e996-4491-881e-b6f39b3da0d9"), "Ukrainian" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Title" },
                values: new object[,]
                {
                    { new Guid("9b9389bc-27be-4cf9-8a28-1925226fa6c8"), "User" },
                    { new Guid("a641c8d5-3930-44b8-827f-f3bb7030702a"), "Admin" },
                    { new Guid("dba656ac-05bd-4af6-bc39-67121e1c2733"), "Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cities_CityId",
                table: "Users",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cities_CityId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CityId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("0981f8de-c2f2-4045-8efa-05483269e183"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("0c6e3f58-8143-4de5-9ccc-b32b25ffec47"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("19448dc8-75a4-4c2a-9805-8546e88379b9"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("5fc0699d-e9f1-4440-be92-655da8a386ea"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("aeab206b-e21b-452e-9d14-0dbd09b7b602"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("b5a52cd5-6486-4279-9825-e88526f105e8"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("d7cc1a26-fb65-46a1-8e2c-21e4e5dccf1c"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("ed073876-7ad4-4095-bd51-8270fcf7b2c6"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("f7d59fc6-d177-437a-add5-721b7f4c16c7"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("fe015cbc-c7f3-498a-83f3-8a303b0889cc"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("14bb71ef-97d1-4481-9b00-3ebc8e7123a8"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("3a128386-aea0-4b8d-9d04-06d85e163b9a"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("3e4e8b51-3535-42b6-bbb1-ff6ddf2b9da2"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("43f8cb08-a303-4afd-974d-1f2274d55225"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("5fe0b6d1-b9d1-4a4c-a159-693472175c89"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("63fcc4bf-64a3-4d95-a111-28c2b4de21f0"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("87c61a8e-e763-4055-83f2-35236f19b608"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("8894d094-a9fe-44b0-8418-dd580d004f39"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("b0f4b2a6-ef47-4ac3-88cb-2357f0942b7a"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("bd543e28-48e9-4bf8-b29a-91344ea44db7"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("dd3941e5-4a0d-4212-b80a-466eab14dda5"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("e6dbaec7-eac0-4475-9aa2-1cff5598b245"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("08ef04f5-54b0-46a9-93fa-8d2aaba16e6f"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("0913135a-0586-45f9-873c-9a894c7a8b76"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("20d68d68-fae1-4dd2-bfa4-b1b22da764d9"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("29725c06-8aa0-41b1-bb52-ad692d36b290"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("37b6fc47-6256-4af5-9ff2-c855b5777956"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("479b8bd5-1965-4d15-b7f7-e09d996035f4"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("7f239815-b8e1-49fb-8adc-66bb08bfc16f"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("83aac05c-5ab4-450f-898d-32a9bdc039e4"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("940199cd-d1b3-4928-8f2a-da85ea3edbb7"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("9dff528f-90dd-494b-9350-9197567b25a5"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("a3edb394-ab54-4fcf-afc7-e793de4b784a"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("ad7dad23-b756-49c8-ade0-8672f1026114"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("b74aa414-ce17-4ed4-96c3-d3f54b83dc66"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("c37a5f2f-56b8-47d2-ba44-2b4ae4aa7b11"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("e084300b-05d3-45d2-9af3-e4ddde31c4fc"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("e58e993c-2988-420d-b897-072cff8d9d56"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("fc191ed5-e996-4491-881e-b6f39b3da0d9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("9b9389bc-27be-4cf9-8a28-1925226fa6c8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("a641c8d5-3930-44b8-827f-f3bb7030702a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("dba656ac-05bd-4af6-bc39-67121e1c2733"));

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Users",
                newName: "CityLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CountryId",
                table: "Users",
                newName: "IX_Users_CityLocationId");

            migrationBuilder.AddColumn<Guid>(
                name: "ClassId",
                table: "Reviews",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClassId1",
                table: "Reviews",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "DisciplineId", "Title" },
                values: new object[,]
                {
                    { new Guid("079c7079-790c-42fb-9aa6-3fb5e8cb19d1"), "Biology" },
                    { new Guid("3a0a1de4-ffeb-4d5a-b4ad-9f59f8eac4e1"), "Music" },
                    { new Guid("3ad01af1-e427-4e01-96c5-3f588962cbad"), "Geography" },
                    { new Guid("3d5727f5-5f00-4451-a071-9b676ad72674"), "Chemistry" },
                    { new Guid("3e4c5283-caa7-4ec4-868c-7084437f45a9"), "Physics" },
                    { new Guid("5eb96a67-b401-4c06-b534-73fc258cb889"), "Art" },
                    { new Guid("74271aed-d7b5-42c7-ade1-257f6b579b7d"), "Literature" },
                    { new Guid("8c84e458-1bf9-45aa-be81-285a316f5448"), "Mathematics" },
                    { new Guid("9a237aec-287c-4e7b-924e-12fa450111f3"), "History" },
                    { new Guid("9dce7aa6-4257-4e8a-b1dd-251d6858f569"), "ComputerScience" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeNumber" },
                values: new object[,]
                {
                    { new Guid("0fdffa52-0cc4-4afb-8ba7-1cc028b54463"), 10 },
                    { new Guid("14e0a7e1-567a-4d6a-9f3d-e083dc15e073"), 9 },
                    { new Guid("1c432a79-a0fd-44d8-b7dc-ee084f9c5ae3"), 2 },
                    { new Guid("33ec3053-c39b-4843-b5ea-e7691fc49f71"), 5 },
                    { new Guid("3b08834b-5d5d-497d-8938-654165c229fe"), 3 },
                    { new Guid("412d6b5d-0727-44ee-b6c0-74f946ac4482"), 8 },
                    { new Guid("42fa1162-249d-4839-804e-28440e4647d4"), 4 },
                    { new Guid("5ecc4c4d-db0f-45f7-ac66-a0f28e0b6be8"), 1 },
                    { new Guid("c7dc09ad-7815-4c2e-a506-9112fff5261c"), 6 },
                    { new Guid("d873c31b-d970-41b8-b610-f9a4b4f3f176"), 11 },
                    { new Guid("ea0e4efc-3384-49e4-a13b-f373d3914dae"), 12 },
                    { new Guid("fc4533f2-2e62-4aa0-a902-cfb83d499a31"), 7 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Title" },
                values: new object[,]
                {
                    { new Guid("10de7872-b5e1-423c-8aec-977db281c98c"), "Russian" },
                    { new Guid("15f7c90f-d837-4cc8-b02a-e6e4005d9c22"), "Kyrgyz" },
                    { new Guid("3643da37-3a60-48fb-81ab-ad71ed128bb6"), "Italian" },
                    { new Guid("467566d2-9aef-4b64-867b-bee87f2f1645"), "Ukrainian" },
                    { new Guid("49ccb003-7dae-41a8-bdc9-d5ebfa4924de"), "Belarusian" },
                    { new Guid("4ad7013e-8c33-49c2-b077-b5bf66c8f78b"), "Kazakh" },
                    { new Guid("6bf631b9-46eb-4664-bd0a-9bbd7ad49ec1"), "Uzbek" },
                    { new Guid("8439fca7-ba23-49aa-a6c4-cef6ae7df847"), "Spanish" },
                    { new Guid("a9f0f801-5ede-40fe-8b3e-fbdd726c416c"), "Georgian" },
                    { new Guid("c597a8ba-cfc3-4ace-af30-6dd8e7840a3d"), "Tajik" },
                    { new Guid("c61c2b63-d5ff-4bc1-981d-58d4646b1653"), "Portuguese" },
                    { new Guid("c7d03534-1b7b-4f24-a0c8-5bfad8f7d20a"), "English" },
                    { new Guid("cef6bbee-1cbd-4441-b5d3-ba17a8c8289a"), "German" },
                    { new Guid("da5d4550-477c-4ba3-8fa6-10d6f96798ba"), "French" },
                    { new Guid("e351e5eb-98f0-41c2-ac5b-4ad37280ab6c"), "Hungarian" },
                    { new Guid("fbde1f10-dd53-4a08-937e-c2120d117cc6"), "Armenian" },
                    { new Guid("fec319b7-edae-4222-854e-286002d11c3f"), "Azerbaijani" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Title" },
                values: new object[,]
                {
                    { new Guid("424ef62a-0d0f-412e-818a-a948c539b6c6"), "User" },
                    { new Guid("5a82ebe9-ad47-462f-ac41-9c60757a1365"), "Manager" },
                    { new Guid("93f03086-0ab0-4314-bb93-beabf968fb4e"), "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ClassId",
                table: "Reviews",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ClassId1",
                table: "Reviews",
                column: "ClassId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Classes_ClassId",
                table: "Reviews",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Classes_ClassId1",
                table: "Reviews",
                column: "ClassId1",
                principalTable: "Classes",
                principalColumn: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cities_CityLocationId",
                table: "Users",
                column: "CityLocationId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
