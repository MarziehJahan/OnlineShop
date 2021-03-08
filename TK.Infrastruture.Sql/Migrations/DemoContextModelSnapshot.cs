﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TK.Infrastruture.Sql;

namespace TK.Infrastruture.Sql.Migrations
{
    [DbContext(typeof(DemoContext))]
    partial class DemoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TK.Core.Entites.CartLine", b =>
                {
                    b.Property<int>("CartLineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrderID");

                    b.Property<int?>("ProductID");

                    b.Property<int>("Quantity");

                    b.HasKey("CartLineId");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("CartLine");
                });

            modelBuilder.Entity("TK.Core.Entites.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TK.Core.Entites.Dealer", b =>
                {
                    b.Property<int>("DealerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.Property<int>("phoneNumber")
                        .HasAnnotation("RegularExpression", @"0 |\+98) ? ([ ] |,| -|[()]){ 0,2}
            9[1 | 2 | 3 | 4]([ ] |,| -|[()]){ 0,2}
            (?:[0 - 9]([ ] |,| -|[()]){ 0,2}){ 8}");

                    b.HasKey("DealerId");

                    b.ToTable("Dealers");
                });

            modelBuilder.Entity("TK.Core.Entites.Media", b =>
                {
                    b.Property<int>("MediaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Path");

                    b.Property<int?>("ProductID");

                    b.HasKey("MediaId");

                    b.HasIndex("ProductID");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("TK.Core.Entites.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<DateTime?>("PaymentDate");

                    b.Property<string>("PaymentId");

                    b.Property<string>("PaymentNote");

                    b.Property<string>("Phone");

                    b.Property<string>("Surname");

                    b.Property<Guid>("UserId");

                    b.Property<string>("ZipCode");

                    b.Property<string>("paymentToken");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TK.Core.Entites.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("InseretTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Price");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TK.Core.Entites.CartLine", b =>
                {
                    b.HasOne("TK.Core.Entites.Order")
                        .WithMany("Lines")
                        .HasForeignKey("OrderID");

                    b.HasOne("TK.Core.Entites.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");
                });

            modelBuilder.Entity("TK.Core.Entites.Media", b =>
                {
                    b.HasOne("TK.Core.Entites.Product")
                        .WithMany("Medias")
                        .HasForeignKey("ProductID");
                });

            modelBuilder.Entity("TK.Core.Entites.Product", b =>
                {
                    b.HasOne("TK.Core.Entites.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
