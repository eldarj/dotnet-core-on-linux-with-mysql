﻿// <auto-generated />
using System;
using DataLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLib.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20190111134007_InitPomelo")]
    partial class InitPomelo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DataLib.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DataLib.Models.Post", b =>
                {
                    b.Property<int>("PostID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<int?>("CategoryID");

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("PostID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("DataLib.Models.Post", b =>
                {
                    b.HasOne("DataLib.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryID");
                });
#pragma warning restore 612, 618
        }
    }
}