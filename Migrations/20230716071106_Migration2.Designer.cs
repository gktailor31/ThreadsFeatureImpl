﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThreadsFeature.Data;

#nullable disable

namespace ThreadsFeature.Migrations
{
    [DbContext(typeof(ThreadsFeatureDbContext))]
    [Migration("20230716071106_Migration2")]
    partial class Migration2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ThreadsFeature.Models.Comment", b =>
                {
                    b.Property<string>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Attachment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreaterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ParentCommentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CommentId");

                    b.HasIndex("CreaterId");

                    b.HasIndex("ParentCommentId");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("ThreadsFeature.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CommentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("CommentId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("ThreadsFeature.Models.Comment", b =>
                {
                    b.HasOne("ThreadsFeature.Models.User", "Creator")
                        .WithMany("Comments")
                        .HasForeignKey("CreaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThreadsFeature.Models.Comment", "Parent")
                        .WithMany("Child")
                        .HasForeignKey("ParentCommentId");

                    b.Navigation("Creator");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("ThreadsFeature.Models.User", b =>
                {
                    b.HasOne("ThreadsFeature.Models.Comment", null)
                        .WithMany("Likes")
                        .HasForeignKey("CommentId");
                });

            modelBuilder.Entity("ThreadsFeature.Models.Comment", b =>
                {
                    b.Navigation("Child");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("ThreadsFeature.Models.User", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
