using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wonderworld.Persistence.Migrations
{
    public partial class UpdateReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

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

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    InvitationId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserSenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserRecipientId = table.Column<Guid>(type: "uuid", nullable: false),
                    WasTheJointLesson = table.Column<bool>(type: "boolean", nullable: false),
                    ReasonForNotConducting = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ReviewText = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Rating = table.Column<short>(type: "SMALLINT", nullable: true),
                    ClassId = table.Column<Guid>(type: "uuid", nullable: true),
                    ClassId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK_Reviews_Classes_ClassId1",
                        column: x => x.ClassId1,
                        principalTable: "Classes",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK_Reviews_Invitations_InvitationId",
                        column: x => x.InvitationId,
                        principalTable: "Invitations",
                        principalColumn: "InvitationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserRecipientId",
                        column: x => x.UserRecipientId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserSenderId",
                        column: x => x.UserSenderId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "DisciplineId", "Title" },
                values: new object[,]
                {
                    { new Guid("1db934fd-2fc3-422a-a0ea-669c9ad4f35c"), "ComputerScience" },
                    { new Guid("2afabb21-5ab4-4e0a-8245-1566791bc7c0"), "Mathematics" },
                    { new Guid("38c24084-94bf-461d-92a3-c46d8729d8cb"), "Biology" },
                    { new Guid("70e99448-e82f-4265-86ff-47c560a6ad2b"), "Art" },
                    { new Guid("74dae866-71b1-46dd-9a8c-a90dbdd78b68"), "Chemistry" },
                    { new Guid("79cebcaf-8312-40e3-a8c4-d714106b33a0"), "History" },
                    { new Guid("8ea25808-f5c3-423c-ab1f-d4b10f469e3a"), "Physics" },
                    { new Guid("c32fcf1e-38be-43d5-9c59-2327ce3b3333"), "Geography" },
                    { new Guid("c710f1c7-e143-4dc0-9e8a-8343171cd100"), "Music" },
                    { new Guid("eadd7558-ace7-4f8d-91b2-15ed34585f57"), "Literature" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeNumber" },
                values: new object[,]
                {
                    { new Guid("0196f4ec-6768-44fb-aa56-1d81269c4a3d"), 6 },
                    { new Guid("140904c7-7401-46b5-b522-8b0fa5bacc11"), 12 },
                    { new Guid("48c74812-4aa9-426e-b391-db5a8359084d"), 8 },
                    { new Guid("507882b2-0bf6-4ae5-84a7-737803ee5089"), 3 },
                    { new Guid("52604350-733e-4271-84bc-dec3b0687b42"), 11 },
                    { new Guid("53b971e0-2f01-40f3-a07b-1b82466ba777"), 4 },
                    { new Guid("925c2390-7956-4314-a5c4-41620598bb11"), 7 },
                    { new Guid("97506b5d-adcd-46ca-83e3-c1d9b895706f"), 5 },
                    { new Guid("a0fa1a0f-f268-455c-afce-adfe0ff4f560"), 2 },
                    { new Guid("a765de5a-952a-47a9-a1f7-d1ce08f17ecf"), 1 },
                    { new Guid("a81a6590-e134-4472-a5af-4d5f9cc95a4b"), 9 },
                    { new Guid("aced8558-62ca-441c-b64f-0279537925b6"), 10 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Title" },
                values: new object[,]
                {
                    { new Guid("134a3e6b-16b5-4c65-9201-0bc50fa1aa34"), "English" },
                    { new Guid("475cc861-fa37-4b9c-a3f8-4b30ec911fbe"), "Uzbek" },
                    { new Guid("5276d207-0188-4cca-94d8-01b9994a517b"), "Hungarian" },
                    { new Guid("58e18160-964b-4086-8c9a-c9652d52fce8"), "Spanish" },
                    { new Guid("704c9ff6-685b-45f6-9450-316bbf41748f"), "Russian" },
                    { new Guid("968885dc-2bc2-432d-8ea7-0e01a1c65f6b"), "German" },
                    { new Guid("a0413b60-9e47-49c3-9a48-8d1378087bc1"), "Italian" },
                    { new Guid("b80b2d4f-6a03-40d7-b957-567bc46b1f95"), "Azerbaijani" },
                    { new Guid("b96a410a-8b8c-413e-b102-787994d4d1c8"), "Ukrainian" },
                    { new Guid("bbb3cf09-ea5e-414d-88a9-a0ce856c3b5a"), "Kyrgyz" },
                    { new Guid("c046dac8-7d98-4111-8048-73239a39f020"), "Belarusian" },
                    { new Guid("c971d79c-4596-4095-95ce-21a7e5aa5536"), "Georgian" },
                    { new Guid("c9ec3816-8a36-4232-9b08-54635c9ce42c"), "French" },
                    { new Guid("d8ef7f9a-3d50-4bad-b823-fbb64e3b51fc"), "Portuguese" },
                    { new Guid("dc205507-7eec-4884-ba77-8856b7b32047"), "Kazakh" },
                    { new Guid("e63ae731-9c7d-47c3-9898-a23a7792c54f"), "Tajik" },
                    { new Guid("eb1b1fbe-3f32-4b56-88e7-68d77460a405"), "Armenian" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Title" },
                values: new object[,]
                {
                    { new Guid("5d0b5633-ca42-40e5-9120-9bb177cb7a61"), "User" },
                    { new Guid("9e7cd14e-bb16-40d8-aadc-05ea92b2f238"), "Manager" },
                    { new Guid("c2c70a60-e267-476a-8d1f-a27340b81138"), "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ClassId",
                table: "Reviews",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ClassId1",
                table: "Reviews",
                column: "ClassId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_InvitationId",
                table: "Reviews",
                column: "InvitationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewId",
                table: "Reviews",
                column: "ReviewId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserRecipientId",
                table: "Reviews",
                column: "UserRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserSenderId",
                table: "Reviews",
                column: "UserSenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("1db934fd-2fc3-422a-a0ea-669c9ad4f35c"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("2afabb21-5ab4-4e0a-8245-1566791bc7c0"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("38c24084-94bf-461d-92a3-c46d8729d8cb"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("70e99448-e82f-4265-86ff-47c560a6ad2b"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("74dae866-71b1-46dd-9a8c-a90dbdd78b68"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("79cebcaf-8312-40e3-a8c4-d714106b33a0"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("8ea25808-f5c3-423c-ab1f-d4b10f469e3a"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("c32fcf1e-38be-43d5-9c59-2327ce3b3333"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("c710f1c7-e143-4dc0-9e8a-8343171cd100"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "DisciplineId",
                keyValue: new Guid("eadd7558-ace7-4f8d-91b2-15ed34585f57"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("0196f4ec-6768-44fb-aa56-1d81269c4a3d"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("140904c7-7401-46b5-b522-8b0fa5bacc11"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("48c74812-4aa9-426e-b391-db5a8359084d"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("507882b2-0bf6-4ae5-84a7-737803ee5089"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("52604350-733e-4271-84bc-dec3b0687b42"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("53b971e0-2f01-40f3-a07b-1b82466ba777"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("925c2390-7956-4314-a5c4-41620598bb11"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("97506b5d-adcd-46ca-83e3-c1d9b895706f"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("a0fa1a0f-f268-455c-afce-adfe0ff4f560"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("a765de5a-952a-47a9-a1f7-d1ce08f17ecf"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("a81a6590-e134-4472-a5af-4d5f9cc95a4b"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: new Guid("aced8558-62ca-441c-b64f-0279537925b6"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("134a3e6b-16b5-4c65-9201-0bc50fa1aa34"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("475cc861-fa37-4b9c-a3f8-4b30ec911fbe"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("5276d207-0188-4cca-94d8-01b9994a517b"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("58e18160-964b-4086-8c9a-c9652d52fce8"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("704c9ff6-685b-45f6-9450-316bbf41748f"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("968885dc-2bc2-432d-8ea7-0e01a1c65f6b"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("a0413b60-9e47-49c3-9a48-8d1378087bc1"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("b80b2d4f-6a03-40d7-b957-567bc46b1f95"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("b96a410a-8b8c-413e-b102-787994d4d1c8"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("bbb3cf09-ea5e-414d-88a9-a0ce856c3b5a"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("c046dac8-7d98-4111-8048-73239a39f020"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("c971d79c-4596-4095-95ce-21a7e5aa5536"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("c9ec3816-8a36-4232-9b08-54635c9ce42c"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("d8ef7f9a-3d50-4bad-b823-fbb64e3b51fc"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("dc205507-7eec-4884-ba77-8856b7b32047"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("e63ae731-9c7d-47c3-9898-a23a7792c54f"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: new Guid("eb1b1fbe-3f32-4b56-88e7-68d77460a405"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("5d0b5633-ca42-40e5-9120-9bb177cb7a61"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("9e7cd14e-bb16-40d8-aadc-05ea92b2f238"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("c2c70a60-e267-476a-8d1f-a27340b81138"));

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    InvitationId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassId = table.Column<Guid>(type: "uuid", nullable: true),
                    ClassId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    FeedbackText = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Rating = table.Column<short>(type: "SMALLINT", nullable: true),
                    ReasonForNotConducting = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    WasTheJointLesson = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK_Feedbacks_Classes_ClassId1",
                        column: x => x.ClassId1,
                        principalTable: "Classes",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK_Feedbacks_Invitations_InvitationId",
                        column: x => x.InvitationId,
                        principalTable: "Invitations",
                        principalColumn: "InvitationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ClassId",
                table: "Feedbacks",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ClassId1",
                table: "Feedbacks",
                column: "ClassId1");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FeedbackId",
                table: "Feedbacks",
                column: "FeedbackId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_InvitationId",
                table: "Feedbacks",
                column: "InvitationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId1",
                table: "Feedbacks",
                column: "UserId1");
        }
    }
}
