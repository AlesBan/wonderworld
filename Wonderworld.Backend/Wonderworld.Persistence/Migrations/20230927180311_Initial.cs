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
                name: "EstablishmentTypes",
                columns: table => new
                {
                    EstablishmentTypeId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Title = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstablishmentTypes", x => x.EstablishmentTypeId);
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
                    Address = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Establishments", x => x.EstablishmentId);
                    table.ForeignKey(
                        name: "FK_Establishments_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId");
                });

            migrationBuilder.CreateTable(
                name: "EstablishmentTypesEstablishments",
                columns: table => new
                {
                    EstablishmentTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    EstablishmentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstablishmentTypesEstablishments", x => new { x.EstablishmentTypeId, x.EstablishmentId });
                    table.ForeignKey(
                        name: "FK_EstablishmentTypesEstablishments_Establishments_Establishme~",
                        column: x => x.EstablishmentId,
                        principalTable: "Establishments",
                        principalColumn: "EstablishmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstablishmentTypesEstablishments_EstablishmentTypes_Establi~",
                        column: x => x.EstablishmentTypeId,
                        principalTable: "EstablishmentTypes",
                        principalColumn: "EstablishmentTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    LastName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    IsATeacher = table.Column<bool>(type: "boolean", nullable: true),
                    IsAnExpert = table.Column<bool>(type: "boolean", nullable: true),
                    EstablishmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    CityId = table.Column<Guid>(type: "uuid", nullable: true),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: true),
                    Rating = table.Column<decimal>(type: "numeric(3,2)", nullable: false, defaultValue: 0m),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    PhotoUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BannerPhotoUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    RegisteredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: true),
                    VerifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastOnlineAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Users_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
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
                    PhotoUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                    Rating = table.Column<short>(type: "SMALLINT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
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
                name: "IX_EstablishmentTypes_EstablishmentTypeId",
                table: "EstablishmentTypes",
                column: "EstablishmentTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstablishmentTypesEstablishments_EstablishmentId",
                table: "EstablishmentTypesEstablishments",
                column: "EstablishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EstablishmentTypesEstablishments_EstablishmentTypeId_Establ~",
                table: "EstablishmentTypesEstablishments",
                columns: new[] { "EstablishmentTypeId", "EstablishmentId" },
                unique: true);

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
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId",
                table: "Users",
                column: "CountryId");

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
                name: "EstablishmentTypesEstablishments");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "UserDisciplines");

            migrationBuilder.DropTable(
                name: "UserGrades");

            migrationBuilder.DropTable(
                name: "UserLanguages");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "EstablishmentTypes");

            migrationBuilder.DropTable(
                name: "Invitations");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Classes");

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
