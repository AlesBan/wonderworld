﻿using System;
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
                name: "InstitutionTypes",
                columns: table => new
                {
                    InstitutionTypeId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Title = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionTypes", x => x.InstitutionTypeId);
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
                name: "Institutions",
                columns: table => new
                {
                    InstitutionId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.InstitutionId);
                    table.ForeignKey(
                        name: "FK_Institutions_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId");
                });

            migrationBuilder.CreateTable(
                name: "InstitutionTypesInstitutions",
                columns: table => new
                {
                    InstitutionTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    InstitutionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionTypesInstitutions", x => new { x.InstitutionTypeId, x.InstitutionId });
                    table.ForeignKey(
                        name: "FK_InstitutionTypesInstitutions_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstitutionTypesInstitutions_InstitutionTypes_InstitutionTy~",
                        column: x => x.InstitutionTypeId,
                        principalTable: "InstitutionTypes",
                        principalColumn: "InstitutionTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    IsCreatedAccount = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    FirstName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    LastName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    IsATeacher = table.Column<bool>(type: "boolean", nullable: true),
                    IsAnExpert = table.Column<bool>(type: "boolean", nullable: true),
                    InstitutionId = table.Column<Guid>(type: "uuid", nullable: true),
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
                        name: "FK_Users_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionId",
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
<<<<<<<< HEAD:Wonderworld.Backend/Wonderworld.Persistence/Migrations/20231012170833_Initial.cs
                    { new Guid("18918edf-9ec8-4b76-a6f5-5f03f9f90451"), "Geography" },
                    { new Guid("2d43dfd1-8283-4afd-bcda-14fbf979e8d4"), "Music" },
                    { new Guid("2e6785f8-37f5-431f-9a06-ddc09e72729f"), "Biology" },
                    { new Guid("2f6d24f5-8f6d-49df-8d28-036349f6a097"), "Physics" },
                    { new Guid("777ae577-900a-46cb-9f78-cafa8f1f74d3"), "Chemistry" },
                    { new Guid("83252af8-4f24-4970-bc4b-06202f11a9f1"), "Art" },
                    { new Guid("8651b278-aaf9-4b5a-9c47-2a6ed5b61c02"), "Mathematics" },
                    { new Guid("8cf0c023-5717-4bcb-8eb2-b310adc98ef9"), "Literature" },
                    { new Guid("b85d0f51-ea28-466e-aa9a-ea70f4a53868"), "ComputerScience" },
                    { new Guid("dc09e61a-107c-434b-909c-d864405762cb"), "History" }
========
                    { new Guid("1012fa7c-13e3-41a9-b48c-50e2083d7580"), "Physics" },
                    { new Guid("1b07a4bc-38e3-4a56-80c4-9c0abbd47271"), "Literature" },
                    { new Guid("20d9f406-6e62-41c7-8d35-2d746e2dae9d"), "Chemistry" },
                    { new Guid("25052923-eea0-4dc4-9eea-3567307fd398"), "Art" },
                    { new Guid("3890b37e-c1af-45c5-836c-99a90d5bac44"), "ComputerScience" },
                    { new Guid("3e2c055f-e9cf-4da4-ac31-ee5807ce84b2"), "Biology" },
                    { new Guid("51b7d7fe-9993-4de7-85a3-9a2d74d2c69d"), "Mathematics" },
                    { new Guid("96f93fad-28f6-4fa3-8c34-fff57d69f075"), "Geography" },
                    { new Guid("9932dd33-dfc4-47c9-8edb-252aec115e8b"), "Music" },
                    { new Guid("ec5ffd0f-080c-4f25-849c-d6e38f101eb7"), "History" }
>>>>>>>> DevelopBackend:Wonderworld.Backend/Wonderworld.Persistence/Migrations/20231016160037_Initial.cs
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeNumber" },
                values: new object[,]
                {
<<<<<<<< HEAD:Wonderworld.Backend/Wonderworld.Persistence/Migrations/20231012170833_Initial.cs
                    { new Guid("07f2cca5-c586-48e8-a779-084baad8ee9b"), 3 },
                    { new Guid("0894be82-effe-4147-a41c-92917125452a"), 9 },
                    { new Guid("1ed89b6e-9da2-4f6f-8b7c-4cb098915226"), 2 },
                    { new Guid("2cb72052-aef3-4e20-90af-348f55537f39"), 7 },
                    { new Guid("30cdc179-bd1b-4088-9a32-e12263c9e5ce"), 5 },
                    { new Guid("4125c72d-3d77-4a6f-b1c0-ea7f7800ef31"), 1 },
                    { new Guid("57ea8377-51d4-4aba-bf67-9beae03cbc3f"), 11 },
                    { new Guid("a1e41239-4597-4875-be6e-c0e63bba2ade"), 8 },
                    { new Guid("c5923ad0-b41c-47a5-b225-1ecfa8fd4042"), 6 },
                    { new Guid("d012865a-7190-4e61-9d3d-565031c32618"), 12 },
                    { new Guid("da69c393-01e6-4bbc-a141-9106806ed4c9"), 4 },
                    { new Guid("e2c174b1-1410-451b-8104-013bbb2c3aa5"), 10 }
========
                    { new Guid("148b2690-e624-4245-9cb6-b2ef35275016"), 8 },
                    { new Guid("393c5e7d-5131-44c1-80a0-78d810c94288"), 7 },
                    { new Guid("44fd6c3c-484e-4adf-ac1c-807b2e608c5e"), 6 },
                    { new Guid("4614dd2a-8799-4118-b8e4-5cc3972c1d63"), 3 },
                    { new Guid("50cb8ae6-be1b-4d20-a8b6-149d4ba3be79"), 12 },
                    { new Guid("6980aa47-a522-4bfa-a035-f0e60ff52031"), 10 },
                    { new Guid("7601508d-cde4-41fc-a5d8-b743acfc5622"), 4 },
                    { new Guid("7bbc567e-33c2-4df3-84f4-0fa02464f124"), 5 },
                    { new Guid("b2733d2d-199f-4d21-91ab-067d498745d2"), 9 },
                    { new Guid("dc63487f-b919-43d2-bfb3-12f1a8030455"), 2 },
                    { new Guid("fc7d5e0b-6039-47bd-84ac-906f0493a96d"), 11 },
                    { new Guid("fd474218-81d2-433f-882f-0a2d1c071b9e"), 1 }
>>>>>>>> DevelopBackend:Wonderworld.Backend/Wonderworld.Persistence/Migrations/20231016160037_Initial.cs
                });

            migrationBuilder.InsertData(
                table: "InstitutionTypes",
                columns: new[] { "InstitutionTypeId", "Title" },
                values: new object[,]
                {
<<<<<<<< HEAD:Wonderworld.Backend/Wonderworld.Persistence/Migrations/20231012170833_Initial.cs
                    { new Guid("3d2a5998-5a06-4dc1-b5c7-c6d57f7c41cd"), "College" },
                    { new Guid("5dea9ea9-4c1d-4584-b224-3224491d0391"), "Gymnasium" },
                    { new Guid("8b2d725f-b557-4e07-95c1-1bbd07a81384"), "School" },
                    { new Guid("a18951e2-c8e4-4e84-82cf-e85334b20d36"), "Lyceum" }
========
                    { new Guid("4d594e01-1c9c-4edd-bcd2-d8ca95d52fdb"), "Gymnasium" },
                    { new Guid("74bc084b-2e66-4955-929b-3bc34be68b32"), "College" },
                    { new Guid("cdbd52d8-ee4f-4758-974c-84e573d3b042"), "School" },
                    { new Guid("e80411df-a2ac-4235-bb89-60bb71f5fcf1"), "Lyceum" }
>>>>>>>> DevelopBackend:Wonderworld.Backend/Wonderworld.Persistence/Migrations/20231016160037_Initial.cs
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Title" },
                values: new object[,]
                {
<<<<<<<< HEAD:Wonderworld.Backend/Wonderworld.Persistence/Migrations/20231012170833_Initial.cs
                    { new Guid("00e6c22b-cf1b-4787-bdb7-b723d97275a9"), "Uzbek" },
                    { new Guid("0d14e1c6-c221-4eb5-93e3-df071e25166f"), "Armenian" },
                    { new Guid("25846d61-18ee-48ea-a101-9fe14c40fe26"), "Belarusian" },
                    { new Guid("393612e4-005c-441c-922f-690190d51520"), "English" },
                    { new Guid("509b8b5a-28b0-4170-bd48-961247cb8029"), "Kyrgyz" },
                    { new Guid("57b42ee1-8662-44eb-b3a9-c9ab3b2d67da"), "Spanish" },
                    { new Guid("65e155f2-8a44-4f87-9b0c-2b179a3cf364"), "Hungarian" },
                    { new Guid("678b43a6-74c8-415a-993f-623490dfc591"), "German" },
                    { new Guid("753d68c9-0d80-41b2-8270-c3f971f94ce7"), "Portuguese" },
                    { new Guid("82a061f6-8fe4-4d38-b397-2b69bbcdf5e5"), "Kazakh" },
                    { new Guid("84c6f09d-f22d-4552-acb4-f0e4918f085c"), "Georgian" },
                    { new Guid("89f2db5a-dad8-4d0d-8b83-e46dbd3be684"), "French" },
                    { new Guid("9cbe5adb-aaac-4e1e-8677-a24cff5aa5ff"), "Russian" },
                    { new Guid("b7664e4a-4fc6-456a-b91d-d068797a422f"), "Italian" },
                    { new Guid("ccc5c4f6-a634-4204-91df-e1b9d206d349"), "Ukrainian" },
                    { new Guid("d0d2bf35-d7d3-48fb-aa19-65d87e785437"), "Tajik" },
                    { new Guid("f18c882f-2582-4d18-8849-7812c7fd2424"), "Azerbaijani" }
========
                    { new Guid("08434faf-3993-4a01-998f-010131f826cc"), "Ukrainian" },
                    { new Guid("159cd2e2-b0d8-4753-9ac2-a1aafa1c62ed"), "Spanish" },
                    { new Guid("1cf953ef-8f0c-45c7-8c5a-a6481708970a"), "Belarusian" },
                    { new Guid("3289538d-dcdb-44b0-8d3c-e691d7f5a44c"), "Kazakh" },
                    { new Guid("32fdfdfd-a357-42ad-bd24-63e406f8681f"), "German" },
                    { new Guid("33e7beeb-c01d-4c71-a850-6ae66dfbf992"), "Tajik" },
                    { new Guid("4b5e3e56-e8d0-4075-9932-11d2d1ecf781"), "Russian" },
                    { new Guid("4d630f97-1e28-4ab0-8eaf-bf374d844304"), "Armenian" },
                    { new Guid("572300a7-ec81-4ecf-9a8f-6cccfa75d0d2"), "Georgian" },
                    { new Guid("5fc6f5be-ea44-4a4f-9668-8d03c79fc5a0"), "English" },
                    { new Guid("73783080-a6d5-4b17-9448-bb77956b1358"), "Hungarian" },
                    { new Guid("8e81bcfb-f256-4bf4-86c2-1116b010794f"), "Azerbaijani" },
                    { new Guid("9127abbb-b393-484e-bc78-6b0d1591da2c"), "Kyrgyz" },
                    { new Guid("9495fbf4-97c5-4191-b279-9de52beb57c3"), "Italian" },
                    { new Guid("ab0cc68c-b75b-4c73-922c-240e8639ffa5"), "French" },
                    { new Guid("b8f794c3-a7a4-4149-b12c-eba7e93919e1"), "Portuguese" },
                    { new Guid("fbbc523c-7f71-4dd7-bdb2-b1459a6b0078"), "Uzbek" }
>>>>>>>> DevelopBackend:Wonderworld.Backend/Wonderworld.Persistence/Migrations/20231016160037_Initial.cs
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Title" },
                values: new object[,]
                {
<<<<<<<< HEAD:Wonderworld.Backend/Wonderworld.Persistence/Migrations/20231012170833_Initial.cs
                    { new Guid("90f21c69-34c6-4f3c-a54e-d88292caec35"), "User" },
                    { new Guid("992b818a-ed7d-4536-badc-23952947abaf"), "Admin" },
                    { new Guid("efa0a773-85d5-410e-a81c-21d120a942f2"), "Manager" }
========
                    { new Guid("2cb8a171-f1f8-474c-a72f-4b3872a84e9a"), "Manager" },
                    { new Guid("7662f593-620f-4d0b-9bdb-6235fe0ddefe"), "Admin" },
                    { new Guid("b1e6a379-f571-498a-ab3d-94d6bba4782a"), "User" }
>>>>>>>> DevelopBackend:Wonderworld.Backend/Wonderworld.Persistence/Migrations/20231016160037_Initial.cs
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
                name: "IX_Grades_GradeId",
                table: "Grades",
                column: "GradeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_CityId",
                table: "Institutions",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_InstitutionId",
                table: "Institutions",
                column: "InstitutionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionTypes_InstitutionTypeId",
                table: "InstitutionTypes",
                column: "InstitutionTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionTypesInstitutions_InstitutionId",
                table: "InstitutionTypesInstitutions",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionTypesInstitutions_InstitutionTypeId_InstitutionId",
                table: "InstitutionTypesInstitutions",
                columns: new[] { "InstitutionTypeId", "InstitutionId" },
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
                name: "IX_Users_InstitutionId",
                table: "Users",
                column: "InstitutionId");

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
                name: "InstitutionTypesInstitutions");

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
                name: "InstitutionTypes");

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
                name: "Institutions");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
