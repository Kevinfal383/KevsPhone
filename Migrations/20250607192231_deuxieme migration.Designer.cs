﻿// <auto-generated />
using System;
using KevinfalsPhone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KevinfalsPhone.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250607192231_deuxieme migration")]
    partial class deuxiememigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("KevinfalsPhone.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nom = "Huawei"
                        },
                        new
                        {
                            Id = 2,
                            Nom = "Samsung"
                        },
                        new
                        {
                            Id = 3,
                            Nom = "Apple"
                        },
                        new
                        {
                            Id = 4,
                            Nom = "GooglePixel"
                        });
                });

            modelBuilder.Entity("KevinfalsPhone.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdresseLivraison")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("DateCommande")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("NombreProduits")
                        .HasColumnType("int");

                    b.Property<string>("NumeroFacture")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("PrixTotal")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("KevinfalsPhone.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("PrixUnitaire")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("KevinfalsPhone.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Image")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("Prix")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6697),
                            Description = "Smartphone haut de gamme",
                            Image = "h1.png",
                            Nom = "Huawei P50 Pro",
                            Prix = 899.99m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6768),
                            Description = "Smartphone puissant et élégant",
                            Image = "h2.png",
                            Nom = "Huawei Mate 40 Pro",
                            Prix = 799.99m,
                            Stock = 8
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6775),
                            Description = "Excellent rapport qualité-prix",
                            Image = "h3.png",
                            Nom = "Huawei Nova 11",
                            Prix = 499.99m,
                            Stock = 12
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6781),
                            Description = "Smartphone milieu de gamme",
                            Image = "h4.png",
                            Nom = "Huawei P40 Lite",
                            Prix = 299.99m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6787),
                            Description = "Écran FullView et bonne autonomie",
                            Image = "h5.png",
                            Nom = "Huawei Y9a",
                            Prix = 259.99m,
                            Stock = 15
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6793),
                            Description = "Nouveauté avec caméra avancée",
                            Image = "h6.png",
                            Nom = "Huawei P60 Pro",
                            Prix = 999.99m,
                            Stock = 6
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6799),
                            Description = "Design moderne et performant",
                            Image = "h7.png",
                            Nom = "Huawei Nova 10 SE",
                            Prix = 379.99m,
                            Stock = 9
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 1,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6805),
                            Description = "Flagship innovant",
                            Image = "h8.png",
                            Nom = "Huawei Mate 50",
                            Prix = 1099.99m,
                            Stock = 5
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 2,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6810),
                            Description = "Smartphone haut de gamme",
                            Image = "s1.png",
                            Nom = "Samsung Galaxy S24 Ultra",
                            Prix = 1399.99m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6816),
                            Description = "Écran pliable",
                            Image = "s2.png",
                            Nom = "Samsung Galaxy Z Fold5",
                            Prix = 1799.99m,
                            Stock = 3
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 2,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6821),
                            Description = "Excellent en photo",
                            Image = "s3.png",
                            Nom = "Samsung Galaxy S23",
                            Prix = 999.99m,
                            Stock = 7
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 2,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6827),
                            Description = "Milieu de gamme puissant",
                            Image = "s4.png",
                            Nom = "Samsung Galaxy A54",
                            Prix = 449.99m,
                            Stock = 14
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 2,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6832),
                            Description = "Bonne autonomie",
                            Image = "s5.png",
                            Nom = "Samsung Galaxy M14",
                            Prix = 199.99m,
                            Stock = 18
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 2,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6838),
                            Description = "Design pliable compact",
                            Image = "s6.png",
                            Nom = "Samsung Galaxy Z Flip5",
                            Prix = 1199.99m,
                            Stock = 6
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 2,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6844),
                            Description = "Stylet intégré",
                            Image = "s7.png",
                            Nom = "Samsung Galaxy S22 Ultra",
                            Prix = 1249.99m,
                            Stock = 4
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 2,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6849),
                            Description = "Productivité et performance",
                            Image = "s8.png",
                            Nom = "Samsung Galaxy Note 20",
                            Prix = 949.99m,
                            Stock = 5
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 3,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6855),
                            Description = "Dernier modèle haut de gamme",
                            Image = "a1.png",
                            Nom = "iPhone 15 Pro Max",
                            Prix = 1599.99m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 3,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6860),
                            Description = "Modèle standard 2023",
                            Image = "a2.png",
                            Nom = "iPhone 15",
                            Prix = 1099.99m,
                            Stock = 8
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 3,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6866),
                            Description = "Technologie avancée",
                            Image = "a3.png",
                            Nom = "iPhone 14 Pro",
                            Prix = 1299.99m,
                            Stock = 6
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 3,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6873),
                            Description = "Performance et autonomie",
                            Image = "a4.png",
                            Nom = "iPhone 13",
                            Prix = 899.99m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 3,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6879),
                            Description = "Compact et rapide",
                            Image = "a5.png",
                            Nom = "iPhone SE (2022)",
                            Prix = 479.99m,
                            Stock = 12
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 3,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6885),
                            Description = "Bon rapport qualité/prix",
                            Image = "a6.png",
                            Nom = "iPhone 12",
                            Prix = 749.99m,
                            Stock = 9
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 3,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6890),
                            Description = "Encore performant",
                            Image = "a7.png",
                            Nom = "iPhone 11",
                            Prix = 599.99m,
                            Stock = 11
                        },
                        new
                        {
                            Id = 24,
                            CategoryId = 3,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6895),
                            Description = "Coloré et accessible",
                            Image = "a8.png",
                            Nom = "iPhone XR",
                            Prix = 399.99m,
                            Stock = 7
                        },
                        new
                        {
                            Id = 25,
                            CategoryId = 4,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6901),
                            Description = "IA intégrée et caméra top",
                            Image = "g1.png",
                            Nom = "Google Pixel 8 Pro",
                            Prix = 1099.99m,
                            Stock = 7
                        },
                        new
                        {
                            Id = 26,
                            CategoryId = 4,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6906),
                            Description = "Version compacte",
                            Image = "g2.png",
                            Nom = "Google Pixel 8",
                            Prix = 799.99m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 27,
                            CategoryId = 4,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6912),
                            Description = "Caméra exceptionnelle",
                            Image = "g3.png",
                            Nom = "Google Pixel 7 Pro",
                            Prix = 899.99m,
                            Stock = 6
                        },
                        new
                        {
                            Id = 28,
                            CategoryId = 4,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6917),
                            Description = "Bon prix et performances",
                            Image = "g4.png",
                            Nom = "Google Pixel 7a",
                            Prix = 499.99m,
                            Stock = 12
                        },
                        new
                        {
                            Id = 29,
                            CategoryId = 4,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6923),
                            Description = "Excellent appareil photo",
                            Image = "g5.png",
                            Nom = "Google Pixel 6 Pro",
                            Prix = 799.99m,
                            Stock = 8
                        },
                        new
                        {
                            Id = 30,
                            CategoryId = 4,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6928),
                            Description = "Petit prix, grande valeur",
                            Image = "g6.png",
                            Nom = "Google Pixel 6a",
                            Prix = 399.99m,
                            Stock = 13
                        },
                        new
                        {
                            Id = 31,
                            CategoryId = 4,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6934),
                            Description = "Bonne autonomie",
                            Image = "g7.png",
                            Nom = "Google Pixel 5",
                            Prix = 349.99m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 32,
                            CategoryId = 4,
                            DateCreation = new DateTime(2025, 6, 7, 21, 22, 30, 60, DateTimeKind.Local).AddTicks(6939),
                            Description = "Compact et fluide",
                            Image = "g8.png",
                            Nom = "Google Pixel 4a",
                            Prix = 299.99m,
                            Stock = 14
                        });
                });

            modelBuilder.Entity("KevinfalsPhone.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Pays")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KevinfalsPhone.Models.Order", b =>
                {
                    b.HasOne("KevinfalsPhone.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KevinfalsPhone.Models.OrderItem", b =>
                {
                    b.HasOne("KevinfalsPhone.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KevinfalsPhone.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KevinfalsPhone.Models.Product", b =>
                {
                    b.HasOne("KevinfalsPhone.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("KevinfalsPhone.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("KevinfalsPhone.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
