﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Wonderworld.Persistence;

#nullable disable

namespace Wonderworld.Persistence.Migrations
{
    [DbContext(typeof(SharedLessonContext))]
    [Migration("20230719160248_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Wonderworld.Domain.ConnectionEntities.ClassDiscipline", b =>
                {
                    b.Property<Guid>("ClassId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DisciplineId")
                        .HasColumnType("uuid");

                    b.HasKey("ClassId", "DisciplineId");

                    b.HasIndex("DisciplineId");

                    b.ToTable("ClassDiscipline");
                });

            modelBuilder.Entity("Wonderworld.Domain.ConnectionEntities.ClassLanguage", b =>
                {
                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uuid");

                    b.HasKey("LanguageId", "ClassId");

                    b.HasIndex("ClassId");

                    b.ToTable("ClassLanguage");
                });

            modelBuilder.Entity("Wonderworld.Domain.ConnectionEntities.TeacherDiscipline", b =>
                {
                    b.Property<Guid>("DisciplineId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.HasKey("DisciplineId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherDiscipline");
                });

            modelBuilder.Entity("Wonderworld.Domain.ConnectionEntities.TeacherLanguage", b =>
                {
                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uuid");

                    b.HasKey("TeacherId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("TeacherLanguage");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Communication.Feedback", b =>
                {
                    b.Property<Guid>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("FeedbackText")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<short>("Rating")
                        .HasColumnType("SMALLINT");

                    b.Property<string>("ReasonForNotConducting")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<Guid?>("TeacherFeedbackRecipientId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TeacherFeedbackSenderId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.Property<bool>("WasTheJointLesson")
                        .HasColumnType("boolean");

                    b.HasKey("FeedbackId");

                    b.HasIndex("FeedbackId")
                        .IsUnique();

                    b.HasIndex("TeacherFeedbackRecipientId");

                    b.HasIndex("TeacherFeedbackSenderId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Communication.Invitation", b =>
                {
                    b.Property<Guid>("TeacherInvitationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime>("DateOfInvitation")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("InvitationText")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("Pending");

                    b.Property<Guid>("TeacherInvitationRecipientId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeacherInvitationSenderId")
                        .HasColumnType("uuid");

                    b.HasKey("TeacherInvitationId");

                    b.HasIndex("TeacherInvitationId")
                        .IsUnique();

                    b.HasIndex("TeacherInvitationRecipientId");

                    b.HasIndex("TeacherInvitationSenderId");

                    b.ToTable("Invitations");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Education.Discipline", b =>
                {
                    b.Property<Guid>("DisciplineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("DisciplineId");

                    b.HasIndex("DisciplineId")
                        .IsUnique();

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Education.Language", b =>
                {
                    b.Property<Guid>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("LanguageId");

                    b.HasIndex("LanguageId")
                        .IsUnique();

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Interface.InterfaceLanguage", b =>
                {
                    b.Property<Guid>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("LanguageId");

                    b.HasIndex("LanguageId")
                        .IsUnique();

                    b.ToTable("InterfaceLanguages");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Job.Appointment", b =>
                {
                    b.Property<Guid>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("AppointmentId");

                    b.HasIndex("AppointmentId")
                        .IsUnique();

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Job.City", b =>
                {
                    b.Property<Guid>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("CityId");

                    b.HasIndex("CityId")
                        .IsUnique();

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Job.Country", b =>
                {
                    b.Property<Guid>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CountryId");

                    b.HasIndex("CountryId")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Job.Establishment", b =>
                {
                    b.Property<Guid>("EstablishmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uuid");

                    b.Property<string>("FullTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("EstablishmentId");

                    b.HasIndex("CityId");

                    b.HasIndex("EstablishmentId")
                        .IsUnique();

                    b.ToTable("Establishments");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Main.Class", b =>
                {
                    b.Property<Guid>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<short>("ClassAge")
                        .HasColumnType("SMALLINT");

                    b.Property<short>("ClassNumber")
                        .HasColumnType("SMALLINT");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.HasKey("ClassId");

                    b.HasIndex("ClassId")
                        .IsUnique();

                    b.HasIndex("TeacherId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Main.Teacher", b =>
                {
                    b.Property<Guid>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Aims")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<Guid?>("AppointmentId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.Property<string>("BannerPhotoUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<Guid?>("EstablishmentId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<Guid>("InterfaceLanguageId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsATeacher")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsAnExpert")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<DateTime>("LastOnlineAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("VerifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("TeacherId");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("EstablishmentId");

                    b.HasIndex("InterfaceLanguageId");

                    b.HasIndex("TeacherId")
                        .IsUnique();

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Wonderworld.Domain.ConnectionEntities.ClassDiscipline", b =>
                {
                    b.HasOne("Wonderworld.Domain.Entities.Main.Class", "Class")
                        .WithMany("ClassDisciplines")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wonderworld.Domain.Entities.Education.Discipline", "Discipline")
                        .WithMany("ClassDisciplines")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Discipline");
                });

            modelBuilder.Entity("Wonderworld.Domain.ConnectionEntities.ClassLanguage", b =>
                {
                    b.HasOne("Wonderworld.Domain.Entities.Main.Class", "Class")
                        .WithMany("ClassLanguages")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wonderworld.Domain.Entities.Education.Language", "Language")
                        .WithMany("ClassLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Wonderworld.Domain.ConnectionEntities.TeacherDiscipline", b =>
                {
                    b.HasOne("Wonderworld.Domain.Entities.Education.Discipline", "Discipline")
                        .WithMany("TeacherDisciplines")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wonderworld.Domain.Entities.Main.Teacher", "Teacher")
                        .WithMany("TeacherDisciplines")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Wonderworld.Domain.ConnectionEntities.TeacherLanguage", b =>
                {
                    b.HasOne("Wonderworld.Domain.Entities.Education.Language", "Language")
                        .WithMany("TeacherLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wonderworld.Domain.Entities.Main.Teacher", "Teacher")
                        .WithMany("TeacherLanguages")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Communication.Feedback", b =>
                {
                    b.HasOne("Wonderworld.Domain.Entities.Main.Teacher", "TeacherFeedbackRecipient")
                        .WithMany("RecievedFeedbacks")
                        .HasForeignKey("TeacherFeedbackRecipientId")
                        .IsRequired();

                    b.HasOne("Wonderworld.Domain.Entities.Main.Teacher", "TeacherFeedbackSender")
                        .WithMany("SentFeedbacks")
                        .HasForeignKey("TeacherFeedbackSenderId")
                        .IsRequired();

                    b.Navigation("TeacherFeedbackRecipient");

                    b.Navigation("TeacherFeedbackSender");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Communication.Invitation", b =>
                {
                    b.HasOne("Wonderworld.Domain.Entities.Main.Teacher", "TeacherInvitationRecipient")
                        .WithMany("RecievedInvitations")
                        .HasForeignKey("TeacherInvitationRecipientId")
                        .IsRequired();

                    b.HasOne("Wonderworld.Domain.Entities.Main.Teacher", "TeacherInvitationSender")
                        .WithMany("SentInvitations")
                        .HasForeignKey("TeacherInvitationSenderId")
                        .IsRequired();

                    b.Navigation("TeacherInvitationRecipient");

                    b.Navigation("TeacherInvitationSender");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Job.City", b =>
                {
                    b.HasOne("Wonderworld.Domain.Entities.Job.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Job.Establishment", b =>
                {
                    b.HasOne("Wonderworld.Domain.Entities.Job.City", "City")
                        .WithMany("Establishments")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Main.Class", b =>
                {
                    b.HasOne("Wonderworld.Domain.Entities.Main.Teacher", "Teacher")
                        .WithMany("Classes")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Main.Teacher", b =>
                {
                    b.HasOne("Wonderworld.Domain.Entities.Job.Appointment", "Appointment")
                        .WithMany("Teachers")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("Wonderworld.Domain.Entities.Job.Establishment", "Establishment")
                        .WithMany("Teachers")
                        .HasForeignKey("EstablishmentId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("Wonderworld.Domain.Entities.Interface.InterfaceLanguage", "InterfaceLanguage")
                        .WithMany("Teachers")
                        .HasForeignKey("InterfaceLanguageId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Establishment");

                    b.Navigation("InterfaceLanguage");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Education.Discipline", b =>
                {
                    b.Navigation("ClassDisciplines");

                    b.Navigation("TeacherDisciplines");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Education.Language", b =>
                {
                    b.Navigation("ClassLanguages");

                    b.Navigation("TeacherLanguages");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Interface.InterfaceLanguage", b =>
                {
                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Job.Appointment", b =>
                {
                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Job.City", b =>
                {
                    b.Navigation("Establishments");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Job.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Job.Establishment", b =>
                {
                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Main.Class", b =>
                {
                    b.Navigation("ClassDisciplines");

                    b.Navigation("ClassLanguages");
                });

            modelBuilder.Entity("Wonderworld.Domain.Entities.Main.Teacher", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("RecievedFeedbacks");

                    b.Navigation("RecievedInvitations");

                    b.Navigation("SentFeedbacks");

                    b.Navigation("SentInvitations");

                    b.Navigation("TeacherDisciplines");

                    b.Navigation("TeacherLanguages");
                });
#pragma warning restore 612, 618
        }
    }
}
