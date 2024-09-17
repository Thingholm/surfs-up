﻿// <auto-generated />
using EntityFramework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFramework.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("EntityFramework.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Equipment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Length")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Thickness")
                        .HasColumnType("REAL");

                    b.Property<double>("Volume")
                        .HasColumnType("REAL");

                    b.Property<double>("Width")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EntityFramework.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("EntityFramework.Models.Product", b =>
                {
                    b.HasOne("EntityFramework.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");
                });
#pragma warning restore 612, 618
        }
    }
}
