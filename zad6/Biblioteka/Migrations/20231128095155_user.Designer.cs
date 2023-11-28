﻿// <auto-generated />
using System;
using Biblioteka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biblioteka.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231128095155_user")]
    partial class user
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Biblioteka.Auth.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("shared.Books.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfBooks")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Author = "Ernesto",
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            NumberOfBooks = 11,
                            Title = "Intelligent Cotton Cheese"
                        },
                        new
                        {
                            Id = 2L,
                            Author = "Ambrose",
                            Description = "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                            NumberOfBooks = 15,
                            Title = "Tasty Steel Gloves"
                        },
                        new
                        {
                            Id = 3L,
                            Author = "Consuelo",
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            NumberOfBooks = 18,
                            Title = "Unbranded Cotton Ball"
                        },
                        new
                        {
                            Id = 4L,
                            Author = "Niko",
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            NumberOfBooks = 27,
                            Title = "Licensed Granite Car"
                        },
                        new
                        {
                            Id = 5L,
                            Author = "Leopoldo",
                            Description = "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                            NumberOfBooks = 11,
                            Title = "Sleek Plastic Sausages"
                        },
                        new
                        {
                            Id = 6L,
                            Author = "Morton",
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            NumberOfBooks = 11,
                            Title = "Sleek Plastic Fish"
                        },
                        new
                        {
                            Id = 7L,
                            Author = "Eudora",
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            NumberOfBooks = 13,
                            Title = "Handcrafted Soft Pizza"
                        },
                        new
                        {
                            Id = 8L,
                            Author = "Yasmeen",
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            NumberOfBooks = 3,
                            Title = "Handcrafted Wooden Computer"
                        },
                        new
                        {
                            Id = 9L,
                            Author = "Abraham",
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            NumberOfBooks = 15,
                            Title = "Intelligent Wooden Fish"
                        },
                        new
                        {
                            Id = 10L,
                            Author = "Steve",
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            NumberOfBooks = 18,
                            Title = "Refined Cotton Pants"
                        },
                        new
                        {
                            Id = 11L,
                            Author = "Valentin",
                            Description = "The Football Is Good For Training And Recreational Purposes",
                            NumberOfBooks = 15,
                            Title = "Practical Plastic Hat"
                        },
                        new
                        {
                            Id = 12L,
                            Author = "Turner",
                            Description = "The Football Is Good For Training And Recreational Purposes",
                            NumberOfBooks = 17,
                            Title = "Licensed Concrete Chips"
                        },
                        new
                        {
                            Id = 13L,
                            Author = "Madalyn",
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            NumberOfBooks = 27,
                            Title = "Handmade Cotton Ball"
                        },
                        new
                        {
                            Id = 14L,
                            Author = "Ronaldo",
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            NumberOfBooks = 10,
                            Title = "Licensed Granite Ball"
                        },
                        new
                        {
                            Id = 15L,
                            Author = "Delores",
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            NumberOfBooks = 29,
                            Title = "Generic Granite Pants"
                        },
                        new
                        {
                            Id = 16L,
                            Author = "Delphia",
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            NumberOfBooks = 28,
                            Title = "Tasty Soft Sausages"
                        },
                        new
                        {
                            Id = 17L,
                            Author = "Lincoln",
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            NumberOfBooks = 25,
                            Title = "Refined Soft Soap"
                        },
                        new
                        {
                            Id = 18L,
                            Author = "Casimer",
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            NumberOfBooks = 17,
                            Title = "Ergonomic Plastic Tuna"
                        },
                        new
                        {
                            Id = 19L,
                            Author = "Javier",
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            NumberOfBooks = 11,
                            Title = "Intelligent Concrete Pants"
                        },
                        new
                        {
                            Id = 20L,
                            Author = "Cordelia",
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            NumberOfBooks = 3,
                            Title = "Incredible Rubber Sausages"
                        },
                        new
                        {
                            Id = 21L,
                            Author = "Amie",
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            NumberOfBooks = 22,
                            Title = "Rustic Granite Gloves"
                        },
                        new
                        {
                            Id = 22L,
                            Author = "Georgianna",
                            Description = "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                            NumberOfBooks = 10,
                            Title = "Generic Granite Hat"
                        },
                        new
                        {
                            Id = 23L,
                            Author = "Jarvis",
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            NumberOfBooks = 3,
                            Title = "Gorgeous Wooden Ball"
                        },
                        new
                        {
                            Id = 24L,
                            Author = "Orrin",
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            NumberOfBooks = 20,
                            Title = "Handcrafted Granite Bike"
                        },
                        new
                        {
                            Id = 25L,
                            Author = "Kenny",
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            NumberOfBooks = 10,
                            Title = "Awesome Granite Chicken"
                        },
                        new
                        {
                            Id = 26L,
                            Author = "Kaela",
                            Description = "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                            NumberOfBooks = 21,
                            Title = "Tasty Metal Table"
                        },
                        new
                        {
                            Id = 27L,
                            Author = "Thaddeus",
                            Description = "The Football Is Good For Training And Recreational Purposes",
                            NumberOfBooks = 24,
                            Title = "Sleek Steel Pants"
                        },
                        new
                        {
                            Id = 28L,
                            Author = "Andre",
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            NumberOfBooks = 28,
                            Title = "Small Soft Table"
                        },
                        new
                        {
                            Id = 29L,
                            Author = "Rosina",
                            Description = "The Football Is Good For Training And Recreational Purposes",
                            NumberOfBooks = 26,
                            Title = "Ergonomic Fresh Bacon"
                        },
                        new
                        {
                            Id = 30L,
                            Author = "Malvina",
                            Description = "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                            NumberOfBooks = 14,
                            Title = "Refined Plastic Shoes"
                        },
                        new
                        {
                            Id = 31L,
                            Author = "Clarissa",
                            Description = "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                            NumberOfBooks = 4,
                            Title = "Small Steel Towels"
                        },
                        new
                        {
                            Id = 32L,
                            Author = "Lexi",
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            NumberOfBooks = 22,
                            Title = "Refined Soft Chicken"
                        },
                        new
                        {
                            Id = 33L,
                            Author = "Iliana",
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            NumberOfBooks = 9,
                            Title = "Licensed Soft Sausages"
                        },
                        new
                        {
                            Id = 34L,
                            Author = "Nichole",
                            Description = "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                            NumberOfBooks = 4,
                            Title = "Intelligent Granite Gloves"
                        },
                        new
                        {
                            Id = 35L,
                            Author = "Leanna",
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            NumberOfBooks = 5,
                            Title = "Sleek Wooden Keyboard"
                        },
                        new
                        {
                            Id = 36L,
                            Author = "Spencer",
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            NumberOfBooks = 15,
                            Title = "Intelligent Soft Towels"
                        },
                        new
                        {
                            Id = 37L,
                            Author = "Erwin",
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            NumberOfBooks = 15,
                            Title = "Intelligent Fresh Pants"
                        },
                        new
                        {
                            Id = 38L,
                            Author = "Bradly",
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            NumberOfBooks = 24,
                            Title = "Gorgeous Cotton Pizza"
                        },
                        new
                        {
                            Id = 39L,
                            Author = "Clarabelle",
                            Description = "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                            NumberOfBooks = 29,
                            Title = "Unbranded Cotton Soap"
                        },
                        new
                        {
                            Id = 40L,
                            Author = "Hunter",
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            NumberOfBooks = 10,
                            Title = "Rustic Plastic Towels"
                        },
                        new
                        {
                            Id = 41L,
                            Author = "Kaitlyn",
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            NumberOfBooks = 6,
                            Title = "Tasty Concrete Car"
                        },
                        new
                        {
                            Id = 42L,
                            Author = "Jamil",
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            NumberOfBooks = 27,
                            Title = "Rustic Fresh Salad"
                        },
                        new
                        {
                            Id = 43L,
                            Author = "Rita",
                            Description = "The Football Is Good For Training And Recreational Purposes",
                            NumberOfBooks = 2,
                            Title = "Unbranded Fresh Gloves"
                        },
                        new
                        {
                            Id = 44L,
                            Author = "Francis",
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            NumberOfBooks = 9,
                            Title = "Gorgeous Cotton Chair"
                        },
                        new
                        {
                            Id = 45L,
                            Author = "Lesly",
                            Description = "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                            NumberOfBooks = 18,
                            Title = "Awesome Steel Pants"
                        },
                        new
                        {
                            Id = 46L,
                            Author = "Andres",
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            NumberOfBooks = 28,
                            Title = "Unbranded Soft Keyboard"
                        },
                        new
                        {
                            Id = 47L,
                            Author = "Madison",
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            NumberOfBooks = 7,
                            Title = "Practical Metal Car"
                        },
                        new
                        {
                            Id = 48L,
                            Author = "Melody",
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            NumberOfBooks = 17,
                            Title = "Unbranded Cotton Mouse"
                        },
                        new
                        {
                            Id = 49L,
                            Author = "Josh",
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            NumberOfBooks = 10,
                            Title = "Generic Plastic Cheese"
                        },
                        new
                        {
                            Id = 50L,
                            Author = "Okey",
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            NumberOfBooks = 12,
                            Title = "Gorgeous Rubber Towels"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
