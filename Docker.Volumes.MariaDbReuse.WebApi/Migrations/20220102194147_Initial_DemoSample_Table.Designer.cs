﻿// <auto-generated />
using System;
using Docker.Volumes.MariaDbReuse.WebApi.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Docker.Volumes.MariaDbReuse.WebApi.Migrations
{
    [DbContext(typeof(SamplesContext))]
    [Migration("20220102194147_Initial_DemoSample_Table")]
    partial class Initial_DemoSample_Table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Docker.Volumes.MariaDbReuse.WebApi.Models.DemoSample", b =>
                {
                    b.Property<int?>("SampleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("SampleId");

                    b.ToTable("Samples");
                });
#pragma warning restore 612, 618
        }
    }
}
