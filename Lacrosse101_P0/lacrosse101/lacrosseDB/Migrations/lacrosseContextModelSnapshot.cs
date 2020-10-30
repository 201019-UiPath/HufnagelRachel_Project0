﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using lacrosseDB;

namespace lacrosseDB.Migrations
{
    [DbContext(typeof(lacrosseContext))]
    partial class lacrosseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("lacrosseDB.Models.Balls", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ProdName")
                        .HasColumnType("text");

                    b.Property<int?>("locationsId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("locationsId");

                    b.ToTable("balls");
                });

            modelBuilder.Entity("lacrosseDB.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CustAddress")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("lacrosseDB.Models.Locations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("StoreLocation")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("lacrosseDB.Models.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("managers");
                });

            modelBuilder.Entity("lacrosseDB.Models.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CustomersId")
                        .HasColumnType("integer");

                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.Property<string>("OrderNum")
                        .HasColumnType("text");

                    b.Property<int>("Quanity")
                        .HasColumnType("integer");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("lacrosseDB.Models.Sticks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ProdName")
                        .HasColumnType("text");

                    b.Property<bool>("isMensStick")
                        .HasColumnType("boolean");

                    b.Property<int?>("locationsId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("locationsId");

                    b.ToTable("sticks");
                });

            modelBuilder.Entity("lacrosseDB.Models.Balls", b =>
                {
                    b.HasOne("lacrosseDB.Models.Locations", "locations")
                        .WithMany()
                        .HasForeignKey("locationsId");
                });

            modelBuilder.Entity("lacrosseDB.Models.Manager", b =>
                {
                    b.HasOne("lacrosseDB.Models.Locations", "location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("lacrosseDB.Models.Sticks", b =>
                {
                    b.HasOne("lacrosseDB.Models.Locations", "locations")
                        .WithMany()
                        .HasForeignKey("locationsId");
                });
#pragma warning restore 612, 618
        }
    }
}
