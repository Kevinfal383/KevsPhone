using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KevinfalsPhone.Migrations
{
    /// <inheritdoc />
    public partial class deuxiememigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreation", "Image" },
                values: new object[] { new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6697), "h1.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreation", "Description", "Image", "Nom", "Prix", "Stock" },
                values: new object[] { new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6768), "Smartphone puissant et élégant", "h2.png", "Huawei Mate 40 Pro", 799.99m, 8 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "DateCreation", "Description", "Image", "Nom", "Prix", "Stock" },
                values: new object[] { 1, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6775), "Excellent rapport qualité-prix", "h3.png", "Huawei Nova 11", 499.99m, 12 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "DateCreation", "Description", "Image", "Nom", "Prix", "Stock" },
                values: new object[] { 1, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6781), "Smartphone milieu de gamme", "h4.png", "Huawei P40 Lite", 299.99m, 20 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "DateCreation", "Description", "Image", "Nom", "Prix", "Stock" },
                values: new object[] { 1, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6787), "Écran FullView et bonne autonomie", "h5.png", "Huawei Y9a", 259.99m, 15 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "DateCreation", "Description", "Image", "Nom", "Prix", "Stock" },
                values: new object[] { 1, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6793), "Nouveauté avec caméra avancée", "h6.png", "Huawei P60 Pro", 999.99m, 6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "DateCreation", "Description", "Image", "Nom", "Prix", "Stock" },
                values: new object[] { 1, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6799), "Design moderne et performant", "h7.png", "Huawei Nova 10 SE", 379.99m, 9 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "DateCreation", "Description", "Image", "Nom", "Prix", "Stock" },
                values: new object[] { 1, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6805), "Flagship innovant", "h8.png", "Huawei Mate 50", 1099.99m, 5 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreation", "Description", "Image", "Nom", "Prix", "Stock" },
                values: new object[,]
                {
                    { 9, 2, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6810), "Smartphone haut de gamme", "s1.png", "Samsung Galaxy S24 Ultra", 1399.99m, 10 },
                    { 10, 2, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6816), "Écran pliable", "s2.png", "Samsung Galaxy Z Fold5", 1799.99m, 3 },
                    { 11, 2, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6821), "Excellent en photo", "s3.png", "Samsung Galaxy S23", 999.99m, 7 },
                    { 12, 2, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6827), "Milieu de gamme puissant", "s4.png", "Samsung Galaxy A54", 449.99m, 14 },
                    { 13, 2, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6832), "Bonne autonomie", "s5.png", "Samsung Galaxy M14", 199.99m, 18 },
                    { 14, 2, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6838), "Design pliable compact", "s6.png", "Samsung Galaxy Z Flip5", 1199.99m, 6 },
                    { 15, 2, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6844), "Stylet intégré", "s7.png", "Samsung Galaxy S22 Ultra", 1249.99m, 4 },
                    { 16, 2, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6849), "Productivité et performance", "s8.png", "Samsung Galaxy Note 20", 949.99m, 5 },
                    { 17, 3, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6855), "Dernier modèle haut de gamme", "a1.png", "iPhone 15 Pro Max", 1599.99m, 10 },
                    { 18, 3, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6860), "Modèle standard 2023", "a2.png", "iPhone 15", 1099.99m, 8 },
                    { 19, 3, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6866), "Technologie avancée", "a3.png", "iPhone 14 Pro", 1299.99m, 6 },
                    { 20, 3, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6873), "Performance et autonomie", "a4.png", "iPhone 13", 899.99m, 10 },
                    { 21, 3, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6879), "Compact et rapide", "a5.png", "iPhone SE (2022)", 479.99m, 12 },
                    { 22, 3, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6885), "Bon rapport qualité/prix", "a6.png", "iPhone 12", 749.99m, 9 },
                    { 23, 3, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6890), "Encore performant", "a7.png", "iPhone 11", 599.99m, 11 },
                    { 24, 3, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6895), "Coloré et accessible", "a8.png", "iPhone XR", 399.99m, 7 },
                    { 25, 4, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6901), "IA intégrée et caméra top", "g1.png", "Google Pixel 8 Pro", 1099.99m, 7 },
                    { 26, 4, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6906), "Version compacte", "g2.png", "Google Pixel 8", 799.99m, 10 },
                    { 27, 4, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6912), "Caméra exceptionnelle", "g3.png", "Google Pixel 7 Pro", 899.99m, 6 },
                    { 28, 4, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6917), "Bon prix et performances", "g4.png", "Google Pixel 7a", 499.99m, 12 },
                    { 29, 4, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6923), "Excellent appareil photo", "g5.png", "Google Pixel 6 Pro", 799.99m, 8 },
                    { 30, 4, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6928), "Petit prix, grande valeur", "g6.png", "Google Pixel 6a", 399.99m, 13 },
                    { 31, 4, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6934), "Bonne autonomie", "g7.png", "Google Pixel 5", 349.99m, 10 },
                    { 32, 4, new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6939), "Compact et fluide", "g8.png", "Google Pixel 4a", 299.99m, 14 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreation", "Image" },
                values: new object[] { new DateTime(2025, 6, 7, 16, 27, 26, 936, DateTimeKind.Local).AddTicks(7937), "huawei-p50.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreation", "Description", "Image", "Nom", "Prix", "Stock" },
                values: new object[] { new DateTime(2025, 6, 7, 16, 27, 26, 936, DateTimeKind.Local).AddTicks(7996), "Tablette performante", "huawei-matepad.jpg", "Huawei MatePad", 449.99m, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "DateCreation", "Description", "Image", "Nom", "Prix", "Stock" },
                values: new object[] { 2, new DateTime(2025, 6, 7, 16, 27, 26, 936, DateTimeKind.Local).AddTicks(8003), "Dernier flagship Samsung", "samsung-s24.jpg", "Samsung Galaxy S24", 1099.99m, 8 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "DateCreation", "Description", "Image", "Nom", "Prix", "Stock" },
                values: new object[] { 2, new DateTime(2025, 6, 7, 16, 27, 26, 936, DateTimeKind.Local).AddTicks(8009), "Tablette premium", "samsung-tabs9.jpg", "Samsung Galaxy Tab S9", 649.99m, 6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "DateCreation", "Description", "Image", "Nom", "Prix", "Stock" },
                values: new object[] { 3, new DateTime(2025, 6, 7, 16, 27, 26, 936, DateTimeKind.Local).AddTicks(8014), "iPhone dernière génération", "iphone15pro.jpg", "iPhone 15 Pro", 1299.99m, 12 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "DateCreation", "Description", "Image", "Nom", "Prix", "Stock" },
                values: new object[] { 3, new DateTime(2025, 6, 7, 16, 27, 26, 936, DateTimeKind.Local).AddTicks(8022), "Ordinateur portable léger", "macbook-air.jpg", "MacBook Air M2", 1499.99m, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "DateCreation", "Description", "Image", "Nom", "Prix", "Stock" },
                values: new object[] { 4, new DateTime(2025, 6, 7, 16, 27, 26, 936, DateTimeKind.Local).AddTicks(8027), "Smartphone Google avec IA", "pixel8pro.jpg", "Google Pixel 8 Pro", 999.99m, 7 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "DateCreation", "Description", "Image", "Nom", "Prix", "Stock" },
                values: new object[] { 4, new DateTime(2025, 6, 7, 16, 27, 26, 936, DateTimeKind.Local).AddTicks(8033), "Écouteurs sans fil", "pixel-buds.jpg", "Google Pixel Buds", 199.99m, 15 });
        }
    }
}
