﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ehsproject.Entities;

#nullable disable

namespace ehsproject.Migrations
{
    [DbContext(typeof(EHS_Context))]
    partial class EHS_ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ehsproject.Entities.FovRequest", b =>
                {
                    b.Property<int?>("Count")
                        .HasColumnType("int");

                    b.Property<string>("SupplierCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("FovRequestID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RequestNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Require")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Spec")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Count", "SupplierCode", "FovRequestID", "Status");

                    b.ToTable("FovRequest");
                });

            modelBuilder.Entity("ehsproject.Entities.Result", b =>
                {
                    b.Property<int?>("ResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ResultId"));

                    b.Property<bool?>("IsContain")
                        .HasColumnType("bit");

                    b.Property<string>("NameMaker")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResultId");

                    b.ToTable("Result");
                });

            modelBuilder.Entity("ehsproject.Entities.ResultDetail", b =>
                {
                    b.Property<int?>("DetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("DetailID"));

                    b.Property<string>("Concentration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mineral")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResultId")
                        .HasColumnType("int");

                    b.Property<string>("Substance")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DetailID");

                    b.ToTable("ResultDetail");
                });

            modelBuilder.Entity("ehsproject.Entities.Supplier", b =>
                {
                    b.Property<string>("SupplierCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Pass")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierCode");

                    b.ToTable("Supplier");
                });
#pragma warning restore 612, 618
        }
    }
}
