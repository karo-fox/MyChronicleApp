﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyChronicle.Infrastructure;

#nullable disable

namespace MyChronicle.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("MyChronicle.Domain.AkcessToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Expired")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AkcessTokens");
                });

            modelBuilder.Entity("MyChronicle.Domain.FamilyTree", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.ToTable("FamilyTrees");
                });

            modelBuilder.Entity("MyChronicle.Domain.FamilyTreePermision", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("FamilyTreeId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("FamilyTreeId");

                    b.ToTable("FamilyTreePermisions");
                });

            modelBuilder.Entity("MyChronicle.Domain.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<int>("FileExtension")
                        .HasColumnType("int");

                    b.Property<int>("FileType")
                        .HasColumnType("int");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("MyChronicle.Domain.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("BirthPlace")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<DateOnly?>("DeathDate")
                        .HasColumnType("date");

                    b.Property<string>("DeathPlace")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<Guid>("FamilyTreeId")
                        .HasColumnType("char(36)");

                    b.Property<int?>("Gender")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(3);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Note")
                        .HasColumnType("LONGTEXT");

                    b.Property<string>("Occupation")
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.HasIndex("FamilyTreeId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("MyChronicle.Domain.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Expired")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("MyChronicle.Domain.Relation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PersonId_1")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PersonId_2")
                        .HasColumnType("char(36)");

                    b.Property<int>("RelationType")
                        .HasColumnType("int");

                    b.Property<DateOnly>("endDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("startDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("PersonId_1");

                    b.HasIndex("PersonId_2");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("MyChronicle.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("FamilyTreePermisionId")
                        .HasColumnType("char(36)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FamilyTreePermisionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyChronicle.Domain.AkcessToken", b =>
                {
                    b.HasOne("MyChronicle.Domain.User", null)
                        .WithMany("AkcessTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyChronicle.Domain.FamilyTreePermision", b =>
                {
                    b.HasOne("MyChronicle.Domain.FamilyTree", "FamilyTree")
                        .WithMany("FamilyTreePermision")
                        .HasForeignKey("FamilyTreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FamilyTree");
                });

            modelBuilder.Entity("MyChronicle.Domain.File", b =>
                {
                    b.HasOne("MyChronicle.Domain.Person", "Person")
                        .WithMany("Files")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MyChronicle.Domain.Person", b =>
                {
                    b.HasOne("MyChronicle.Domain.FamilyTree", null)
                        .WithMany("Person")
                        .HasForeignKey("FamilyTreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyChronicle.Domain.RefreshToken", b =>
                {
                    b.HasOne("MyChronicle.Domain.User", null)
                        .WithMany("RefreshToken")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyChronicle.Domain.Relation", b =>
                {
                    b.HasOne("MyChronicle.Domain.Person", "Person_1")
                        .WithMany("RelationsAsPerson1")
                        .HasForeignKey("PersonId_1")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MyChronicle.Domain.Person", "Person_2")
                        .WithMany("RelationsAsPerson2")
                        .HasForeignKey("PersonId_2")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Person_1");

                    b.Navigation("Person_2");
                });

            modelBuilder.Entity("MyChronicle.Domain.User", b =>
                {
                    b.HasOne("MyChronicle.Domain.FamilyTreePermision", null)
                        .WithMany("Users")
                        .HasForeignKey("FamilyTreePermisionId");
                });

            modelBuilder.Entity("MyChronicle.Domain.FamilyTree", b =>
                {
                    b.Navigation("FamilyTreePermision");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MyChronicle.Domain.FamilyTreePermision", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MyChronicle.Domain.Person", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("RelationsAsPerson1");

                    b.Navigation("RelationsAsPerson2");
                });

            modelBuilder.Entity("MyChronicle.Domain.User", b =>
                {
                    b.Navigation("AkcessTokens");

                    b.Navigation("RefreshToken");
                });
#pragma warning restore 612, 618
        }
    }
}
