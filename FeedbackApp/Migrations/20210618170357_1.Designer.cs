﻿// <auto-generated />
using FeedbackApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FeedbackApp.Migrations
{
    [DbContext(typeof(FeedbackContext))]
    [Migration("20210618170357_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FeedbackApp.Models.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Theme")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("FeedbackId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("FeedbackApp.Models.FeedbackDb", b =>
                {
                    b.Property<int>("FeedbackDbId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DbMessage")
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ThemeFeedbackId")
                        .HasColumnType("int");

                    b.Property<int>("UserFeedbackId")
                        .HasColumnType("int");

                    b.HasKey("FeedbackDbId");

                    b.HasIndex("ThemeFeedbackId");

                    b.HasIndex("UserFeedbackId");

                    b.ToTable("FeedbackDbs");
                });

            modelBuilder.Entity("FeedbackApp.Models.ThemeFeedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Theme")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ThemeFeedbacks");
                });

            modelBuilder.Entity("FeedbackApp.Models.UserFeedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserTelephone")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("UserFeedbacks");
                });

            modelBuilder.Entity("FeedbackApp.Models.FeedbackDb", b =>
                {
                    b.HasOne("FeedbackApp.Models.ThemeFeedback", "ThemeFeedback")
                        .WithMany()
                        .HasForeignKey("ThemeFeedbackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FeedbackApp.Models.UserFeedback", "UserFeedback")
                        .WithMany()
                        .HasForeignKey("UserFeedbackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ThemeFeedback");

                    b.Navigation("UserFeedback");
                });
#pragma warning restore 612, 618
        }
    }
}
