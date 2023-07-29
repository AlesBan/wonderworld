using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wonderworld.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    DisciplineId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.DisciplineId);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    GradeNumber = table.Column<int>(type: "integer", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Establishments",
                columns: table => new
                {
                    EstablishmentId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Establishments", x => x.EstablishmentId);
                    table.ForeignKey(
                        name: "FK_Establishments_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    IsATeacher = table.Column<bool>(type: "boolean", nullable: false),
                    IsAnExpert = table.Column<bool>(type: "boolean", nullable: false),
                    EstablishmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CityLocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    PhotoUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    BannerPhotoUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    RegisteredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    VerifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastOnlineAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityLocationId",
                        column: x => x.CityLocationId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Users_Establishments_EstablishmentId",
                        column: x => x.EstablishmentId,
                        principalTable: "Establishments",
                        principalColumn: "EstablishmentId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    GradeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Age = table.Column<short>(type: "smallint", nullable: false),
                    PhotoUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_Classes_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDisciplines",
                columns: table => new
                {
                    DisciplineId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDisciplines", x => new { x.UserId, x.DisciplineId });
                    table.ForeignKey(
                        name: "FK_UserDisciplines_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "DisciplineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDisciplines_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGrades",
                columns: table => new
                {
                    GradeId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGrades", x => new { x.UserId, x.GradeId });
                    table.ForeignKey(
                        name: "FK_UserGrades_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGrades_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLanguages",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguages", x => new { x.UserId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_UserLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLanguages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassDisciplines",
                columns: table => new
                {
                    DisciplineId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassDisciplines", x => new { x.ClassId, x.DisciplineId });
                    table.ForeignKey(
                        name: "FK_ClassDisciplines_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassDisciplines_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "DisciplineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassLanguages",
                columns: table => new
                {
                    LanguageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassLanguages", x => new { x.LanguageId, x.ClassId });
                    table.ForeignKey(
                        name: "FK_ClassLanguages_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    UserFeedbackSenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserFeedbackRecipientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassSenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassRecipientId = table.Column<Guid>(type: "uuid", nullable: false),
                    WasTheJointLesson = table.Column<bool>(type: "boolean", nullable: false),
                    ReasonForNotConducting = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    FeedbackText = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Rating = table.Column<short>(type: "SMALLINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Classes_ClassRecipientId",
                        column: x => x.ClassRecipientId,
                        principalTable: "Classes",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK_Feedbacks_Classes_ClassSenderId",
                        column: x => x.ClassSenderId,
                        principalTable: "Classes",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_UserFeedbackRecipientId",
                        column: x => x.UserFeedbackRecipientId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_UserFeedbackSenderId",
                        column: x => x.UserFeedbackSenderId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Invitations",
                columns: table => new
                {
                    InvitationId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    UserSenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserRecipientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassSenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassRecipientId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    DateOfInvitation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false, defaultValue: "Pending"),
                    InvitationText = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => x.InvitationId);
                    table.ForeignKey(
                        name: "FK_Invitations_Classes_ClassRecipientId",
                        column: x => x.ClassRecipientId,
                        principalTable: "Classes",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK_Invitations_Classes_ClassSenderId",
                        column: x => x.ClassSenderId,
                        principalTable: "Classes",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK_Invitations_Users_UserRecipientId",
                        column: x => x.UserRecipientId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Invitations_Users_UserSenderId",
                        column: x => x.UserSenderId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "DisciplineId", "Title" },
                values: new object[,]
                {
                    { new Guid("1dd70b4b-f65a-4757-bb0c-9f69f92eb311"), "Chemistry" },
                    { new Guid("210c7fa7-e584-4d28-a53b-f51827b59a49"), "Biology" },
                    { new Guid("3c5d14c2-0aa7-49a5-b6b6-c05a74de3e3d"), "Mathematics" },
                    { new Guid("5d538e74-800b-4a3e-94e3-621bdfab7f62"), "History" },
                    { new Guid("74dfac2b-3489-485d-adca-caed39c667ea"), "Art" },
                    { new Guid("89a7358a-4c48-4a3f-a03a-bb68d3d72d05"), "ComputerScience" },
                    { new Guid("a449d6db-12b0-4517-81d7-1d8c6f1bb4c1"), "Music" },
                    { new Guid("ae90dff5-c5ec-4a5c-9874-54fc393998ae"), "Geography" },
                    { new Guid("c3f6aaca-c905-4b90-a7da-ba74ad9cfcd5"), "Physics" },
                    { new Guid("ca495284-9383-47b0-b11a-bd111d4e7e93"), "Literature" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeNumber" },
                values: new object[,]
                {
                    { new Guid("09027cf3-754a-4cc7-9052-000dab729a51"), 4 },
                    { new Guid("0f11fb01-5628-4033-8490-17da8cf3821a"), 10 },
                    { new Guid("2749e600-bacd-431d-8071-7afe465ce50f"), 1 },
                    { new Guid("49380a47-e7ec-4f81-8e88-7cf330b66249"), 9 },
                    { new Guid("5b701a8c-9419-42f5-ad58-a1ab7051d1e1"), 3 },
                    { new Guid("6a0ad83b-dcc0-407f-a5d2-1f3d1a11c40e"), 2 },
                    { new Guid("72e71abc-f4eb-46d1-a1f0-b09600752ee3"), 12 },
                    { new Guid("8b1c79a4-d87e-4f1d-a7a1-6258d8c12daa"), 6 },
                    { new Guid("a38a50b5-2b7c-4647-9813-ec758b253e84"), 8 },
                    { new Guid("c1c28e01-e281-40fd-b23c-089c6bc33811"), 7 },
                    { new Guid("c1d4fd81-aae8-4406-b702-631460d4dd00"), 5 },
                    { new Guid("d5921de8-25fd-4d1d-b653-47708ce6c9cd"), 11 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Title" },
                values: new object[,]
                {
                    { new Guid("03c3f2a0-a612-47bd-92a5-d44df9b63919"), "Belarusian" },
                    { new Guid("27d918b7-fb44-4abf-b136-9cd82f6264ed"), "Georgian" },
                    { new Guid("2f370863-bef0-45e0-9a2a-2eaf14deefab"), "Spanish" },
                    { new Guid("35d9b3aa-bf48-4067-a01d-9330fd8783fc"), "German" },
                    { new Guid("3a15bfee-15c2-4ad5-9525-c3ad8c8d1c32"), "Kyrgyz" },
                    { new Guid("40caa9a4-d062-4957-95da-ded74ea0a550"), "Armenian" },
                    { new Guid("4580419a-ef29-4628-a85e-e5126432e604"), "Portuguese" },
                    { new Guid("47064fce-d6a2-4ea3-aa1e-69a007ad3147"), "Ukrainian" },
                    { new Guid("4c202ff5-862e-4eb6-9105-d1d0c9e4369b"), "Hungarian" },
                    { new Guid("57d1061f-3098-440f-a7e9-526d6a173c71"), "French" },
                    { new Guid("65b7ebc1-a346-48d1-b3a0-65401f130a4a"), "English" },
                    { new Guid("8cb10c20-3e67-40fb-b59e-6be3b6ca995f"), "Russian" },
                    { new Guid("a4845518-73bb-4c3f-a8c9-680a70b434cc"), "Kazakh" },
                    { new Guid("bb052a60-395c-4564-b31e-ea3b1fc3182b"), "Uzbek" },
                    { new Guid("e8c19ece-b1ce-4aa9-9349-b5ada2d04090"), "Azerbaijani" },
                    { new Guid("fd7300c7-e7ae-4b5c-8de7-58c49bca235d"), "Tajik" },
                    { new Guid("ff1e82a2-4af8-411a-b080-2e91174b7ba6"), "Italian" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Title" },
                values: new object[,]
                {
                    { new Guid("237de451-58a5-4781-9f52-fa54683e2b03"), "Manager" },
                    { new Guid("8306c127-f9be-43ab-8a17-6382d6246690"), "User" },
                    { new Guid("b6a0a95b-642f-465d-9d18-6b6c48e7ab2b"), "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CityId",
                table: "Cities",
                column: "CityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassDisciplines_ClassId_DisciplineId",
                table: "ClassDisciplines",
                columns: new[] { "ClassId", "DisciplineId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassDisciplines_DisciplineId",
                table: "ClassDisciplines",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClassId",
                table: "Classes",
                column: "ClassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_GradeId",
                table: "Classes",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_UserId",
                table: "Classes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassLanguages_ClassId",
                table: "ClassLanguages",
                column: "ClassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CountryId",
                table: "Countries",
                column: "CountryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_DisciplineId",
                table: "Disciplines",
                column: "DisciplineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Establishments_CityId",
                table: "Establishments",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Establishments_EstablishmentId",
                table: "Establishments",
                column: "EstablishmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ClassRecipientId",
                table: "Feedbacks",
                column: "ClassRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ClassSenderId",
                table: "Feedbacks",
                column: "ClassSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FeedbackId",
                table: "Feedbacks",
                column: "FeedbackId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserFeedbackRecipientId",
                table: "Feedbacks",
                column: "UserFeedbackRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserFeedbackSenderId",
                table: "Feedbacks",
                column: "UserFeedbackSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_GradeId",
                table: "Grades",
                column: "GradeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_ClassRecipientId",
                table: "Invitations",
                column: "ClassRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_ClassSenderId",
                table: "Invitations",
                column: "ClassSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_InvitationId",
                table: "Invitations",
                column: "InvitationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_UserRecipientId",
                table: "Invitations",
                column: "UserRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_UserSenderId",
                table: "Invitations",
                column: "UserSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_LanguageId",
                table: "Languages",
                column: "LanguageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleId",
                table: "Roles",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDisciplines_DisciplineId",
                table: "UserDisciplines",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDisciplines_UserId_DisciplineId",
                table: "UserDisciplines",
                columns: new[] { "UserId", "DisciplineId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGrades_GradeId",
                table: "UserGrades",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGrades_UserId_GradeId",
                table: "UserGrades",
                columns: new[] { "UserId", "GradeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguages_LanguageId",
                table: "UserLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguages_UserId_LanguageId",
                table: "UserLanguages",
                columns: new[] { "UserId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityLocationId",
                table: "Users",
                column: "CityLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EstablishmentId",
                table: "Users",
                column: "EstablishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassDisciplines");

            migrationBuilder.DropTable(
                name: "ClassLanguages");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Invitations");

            migrationBuilder.DropTable(
                name: "UserDisciplines");

            migrationBuilder.DropTable(
                name: "UserGrades");

            migrationBuilder.DropTable(
                name: "UserLanguages");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Establishments");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
