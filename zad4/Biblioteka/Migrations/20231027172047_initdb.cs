using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Biblioteka.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfBooks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "NumberOfBooks", "Title" },
                values: new object[,]
                {
                    { 1L, "Ernesto", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 11, "Intelligent Cotton Cheese" },
                    { 2L, "Ambrose", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 15, "Tasty Steel Gloves" },
                    { 3L, "Consuelo", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 18, "Unbranded Cotton Ball" },
                    { 4L, "Niko", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 27, "Licensed Granite Car" },
                    { 5L, "Leopoldo", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 11, "Sleek Plastic Sausages" },
                    { 6L, "Morton", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 11, "Sleek Plastic Fish" },
                    { 7L, "Eudora", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 13, "Handcrafted Soft Pizza" },
                    { 8L, "Yasmeen", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 3, "Handcrafted Wooden Computer" },
                    { 9L, "Abraham", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 15, "Intelligent Wooden Fish" },
                    { 10L, "Steve", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 18, "Refined Cotton Pants" },
                    { 11L, "Valentin", "The Football Is Good For Training And Recreational Purposes", 15, "Practical Plastic Hat" },
                    { 12L, "Turner", "The Football Is Good For Training And Recreational Purposes", 17, "Licensed Concrete Chips" },
                    { 13L, "Madalyn", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 27, "Handmade Cotton Ball" },
                    { 14L, "Ronaldo", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 10, "Licensed Granite Ball" },
                    { 15L, "Delores", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 29, "Generic Granite Pants" },
                    { 16L, "Delphia", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 28, "Tasty Soft Sausages" },
                    { 17L, "Lincoln", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 25, "Refined Soft Soap" },
                    { 18L, "Casimer", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 17, "Ergonomic Plastic Tuna" },
                    { 19L, "Javier", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 11, "Intelligent Concrete Pants" },
                    { 20L, "Cordelia", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 3, "Incredible Rubber Sausages" },
                    { 21L, "Amie", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 22, "Rustic Granite Gloves" },
                    { 22L, "Georgianna", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 10, "Generic Granite Hat" },
                    { 23L, "Jarvis", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 3, "Gorgeous Wooden Ball" },
                    { 24L, "Orrin", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 20, "Handcrafted Granite Bike" },
                    { 25L, "Kenny", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 10, "Awesome Granite Chicken" },
                    { 26L, "Kaela", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 21, "Tasty Metal Table" },
                    { 27L, "Thaddeus", "The Football Is Good For Training And Recreational Purposes", 24, "Sleek Steel Pants" },
                    { 28L, "Andre", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 28, "Small Soft Table" },
                    { 29L, "Rosina", "The Football Is Good For Training And Recreational Purposes", 26, "Ergonomic Fresh Bacon" },
                    { 30L, "Malvina", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 14, "Refined Plastic Shoes" },
                    { 31L, "Clarissa", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 4, "Small Steel Towels" },
                    { 32L, "Lexi", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 22, "Refined Soft Chicken" },
                    { 33L, "Iliana", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 9, "Licensed Soft Sausages" },
                    { 34L, "Nichole", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 4, "Intelligent Granite Gloves" },
                    { 35L, "Leanna", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 5, "Sleek Wooden Keyboard" },
                    { 36L, "Spencer", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 15, "Intelligent Soft Towels" },
                    { 37L, "Erwin", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 15, "Intelligent Fresh Pants" },
                    { 38L, "Bradly", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 24, "Gorgeous Cotton Pizza" },
                    { 39L, "Clarabelle", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 29, "Unbranded Cotton Soap" },
                    { 40L, "Hunter", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 10, "Rustic Plastic Towels" },
                    { 41L, "Kaitlyn", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 6, "Tasty Concrete Car" },
                    { 42L, "Jamil", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 27, "Rustic Fresh Salad" },
                    { 43L, "Rita", "The Football Is Good For Training And Recreational Purposes", 2, "Unbranded Fresh Gloves" },
                    { 44L, "Francis", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 9, "Gorgeous Cotton Chair" },
                    { 45L, "Lesly", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 18, "Awesome Steel Pants" },
                    { 46L, "Andres", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 28, "Unbranded Soft Keyboard" },
                    { 47L, "Madison", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 7, "Practical Metal Car" },
                    { 48L, "Melody", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 17, "Unbranded Cotton Mouse" },
                    { 49L, "Josh", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 10, "Generic Plastic Cheese" },
                    { 50L, "Okey", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 12, "Gorgeous Rubber Towels" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
