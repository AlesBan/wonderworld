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
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    AccessToken = table.Column<string>(type: "text", nullable: true),
                    PasswordResetToken = table.Column<string>(type: "text", nullable: true),
                    ResetTokenExpires = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PasswordResetCode = table.Column<string>(type: "text", nullable: true),
                    VerificationCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    IsCreatedAccount = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsInstitutionVerified = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
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
                    UserReceiverId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassSenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassReceiverId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    DateOfInvitation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false, defaultValue: "Pending"),
                    InvitationText = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => x.InvitationId);
                    table.ForeignKey(
                        name: "FK_Invitations_Classes_ClassReceiverId",
                        column: x => x.ClassReceiverId,
                        principalTable: "Classes",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK_Invitations_Classes_ClassSenderId",
                        column: x => x.ClassSenderId,
                        principalTable: "Classes",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK_Invitations_Users_UserReceiverId",
                        column: x => x.UserReceiverId,
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
                    { new Guid("080520c4-f132-4280-a56f-edd8bb5eecef"), "Geography" },
                    { new Guid("0a8b7c59-30c5-431c-8498-00c86ac90d16"), "French as a foreign language" },
                    { new Guid("1063ef8a-5991-44dc-946b-f04ad0b667c7"), "Fine arts" },
                    { new Guid("14f19732-d7ba-422b-abc7-4a53d5c698fd"), "Spanish as a foreign language" },
                    { new Guid("1809d5e0-9242-4f8f-9ede-6911164979b9"), "World art" },
                    { new Guid("25ed0b42-e0c6-445b-9fbc-fd67d4dad47b"), "Natural science" },
                    { new Guid("30e89fcb-ff3d-48ab-b925-6128e67d732c"), "Computer science" },
                    { new Guid("3281a15b-33a1-42ec-bb22-5160385f3d54"), "German as a foreign language" },
                    { new Guid("397880bf-14dd-4d8a-9991-085f742531e0"), "Chinese as a foreign language" },
                    { new Guid("465fdb2e-da4d-4b29-a3b0-8fd837d871cd"), "Italian as a foreign language" },
                    { new Guid("509f610a-e920-47ed-ab07-d6bf91cc8b8b"), "Regional studies" },
                    { new Guid("54a8717f-e4e1-439c-a86a-662aec135f7a"), "Economics" },
                    { new Guid("64f18997-3969-4b94-a9a8-d3a79555f7bd"), "Russian literature" },
                    { new Guid("6fb253d4-16da-4052-8ac2-f814c9fd3329"), "Russian language" },
                    { new Guid("739d6c3f-1c9f-4caa-a317-e2cee1a2e623"), "Music" },
                    { new Guid("825691b3-7b0f-4c68-b8a8-ebbfe5ec0254"), "Biology" },
                    { new Guid("960924c3-2c5f-4eef-bb2d-c39241fd8b43"), "Technology" },
                    { new Guid("98095369-2efb-418c-9f39-e3b2b3bcb064"), "Mathematics" },
                    { new Guid("9b959eed-1113-4c97-8e86-1ff23e1cab14"), "Astronomy" },
                    { new Guid("9c79a7c0-4dbc-4fa0-96b9-1c9b65218026"), "Cultural exchange" },
                    { new Guid("a0fe39d2-b81b-4b44-8612-1f553d6e5efd"), "Project-based learning" },
                    { new Guid("a1d5124a-4034-42c8-8c58-9bc0de7b7a34"), "Crafts" },
                    { new Guid("a8eecc7a-16fd-4ff1-ae4f-a0e5a4070d61"), "Vacation education" },
                    { new Guid("b4e56cde-4221-4b9d-b20a-3a6df1fe1d47"), "Chemistry" },
                    { new Guid("ba5508ee-e118-4538-a7fd-7f79530ba719"), "Physics" },
                    { new Guid("d0e235c0-d11a-4025-affc-d415e59156cd"), "Social science" },
                    { new Guid("d4983188-37e5-4133-8460-0d1bc1c131f9"), "English as a foreign language" },
                    { new Guid("fe506683-cd7a-42a2-b3a2-f46924f1f83f"), "History" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeNumber" },
                values: new object[,]
                {
                    { new Guid("0466947f-6e49-416f-9b05-d93ff4c02367"), 11 },
                    { new Guid("18ff0665-f933-4b1b-8d32-12590eed6b1d"), 9 },
                    { new Guid("40085aa3-198f-47b0-beca-8e435b42c984"), 10 },
                    { new Guid("4d2fb8cd-6c92-4e76-b055-a73283e416b2"), 2 },
                    { new Guid("6e268545-e22b-4098-8a79-b1f9c15cba98"), 1 },
                    { new Guid("7b9eb02b-490f-4d03-a557-75d037a193f2"), 3 },
                    { new Guid("8a148313-acec-4b3e-a695-84dc0a7a844a"), 6 },
                    { new Guid("9a22c893-74cf-4d4e-8dbb-3c8e164d9dc6"), 12 },
                    { new Guid("a550c68e-987c-4607-88b1-e32528d8411e"), 8 },
                    { new Guid("b5ad0209-97cb-4ec0-a84a-72e40ca2bbaf"), 7 },
                    { new Guid("c7c9f197-19d6-412d-b3cf-33ed5b65e752"), 4 },
                    { new Guid("cf644926-9560-46b0-9ccc-1f754ffb53e8"), 5 }
                });

            migrationBuilder.InsertData(
                table: "InstitutionTypes",
                columns: new[] { "InstitutionTypeId", "Title" },
                values: new object[,]
                {
                    { new Guid("38234cb1-ee10-4bc8-96a0-db0507701211"), "College" },
                    { new Guid("6cf2ca2f-6543-4941-91be-338ca0b80355"), "School" },
                    { new Guid("a5d04194-77e1-435c-baee-c072ff236bc8"), "Gymnasium" },
                    { new Guid("cd5a6c82-b02f-4db1-bd7b-8d8b53f6c81c"), "Lyceum" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Title" },
                values: new object[,]
                {
                    { new Guid("0babf7b4-15d2-4f96-bed7-f0844647f895"), "Italian" },
                    { new Guid("0fe96c56-7660-4229-b22f-8e177b200b38"), "French" },
                    { new Guid("1036304c-4517-4bce-b7c6-d16c486d34f5"), "Hungarian" },
                    { new Guid("1455692f-edb6-4517-b7b6-cb5d1c767bd6"), "Armenian" },
                    { new Guid("446443b4-e47d-4ecd-8f1b-a5b870c2bfa9"), "Spanish" },
                    { new Guid("4dc5a364-29ea-4e7f-99e8-9d4dedb21688"), "English" },
                    { new Guid("5a3c650c-47c4-4b10-ba87-2083017c3f9a"), "Belarusian" },
                    { new Guid("69d19cba-6370-4405-84f0-05525321deec"), "Tajik" },
                    { new Guid("725791fb-e61e-482c-bdc5-b14603b098a1"), "Kyrgyz" },
                    { new Guid("8dd1f10c-6257-4461-88db-d801c0c591a8"), "Georgian" },
                    { new Guid("8ea9b377-dc59-4a06-969f-f666f18d6f87"), "Kazakh" },
                    { new Guid("90ab31ef-b716-4d44-8303-d2e1da168485"), "Russian" },
                    { new Guid("a51d353f-3ba3-4236-955c-648059a075cc"), "Portuguese" },
                    { new Guid("c66dc827-6d99-4880-81c8-fc09e351e6ec"), "Azerbaijani" },
                    { new Guid("c9e6a9cf-853b-44e5-b877-3d8d868051c8"), "German" },
                    { new Guid("e391b77d-f3e8-4a64-9a2f-3cb0b593097f"), "Ukrainian" },
                    { new Guid("e5719c16-5dcb-4665-bb60-204d9c846f6e"), "Uzbek" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Title" },
                values: new object[,]
                {
                    { new Guid("085f4fae-ab9f-4e91-a17e-784b2103f05c"), "User" },
                    { new Guid("142148a3-8937-49cf-a9da-732ed516759e"), "Manager" },
                    { new Guid("3e506690-a7fd-48f2-aa04-d8de283e7b94"), "Admin" }
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
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassLanguages_LanguageId_ClassId",
                table: "ClassLanguages",
                columns: new[] { "LanguageId", "ClassId" },
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
                name: "IX_Invitations_ClassReceiverId",
                table: "Invitations",
                column: "ClassReceiverId");

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
                name: "IX_Invitations_UserReceiverId",
                table: "Invitations",
                column: "UserReceiverId");

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
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId_RoleId",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
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
