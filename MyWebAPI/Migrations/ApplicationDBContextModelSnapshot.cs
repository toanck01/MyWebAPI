// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWebAPI.Data;

#nullable disable

namespace MyWebAPI.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyWebAPI.Models.MyWeb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MyWebs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 2, 18, 22, 51, 34, 254, DateTimeKind.Local).AddTicks(5848),
                            Name = "MyWeb"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 2, 18, 22, 51, 34, 254, DateTimeKind.Local).AddTicks(5861),
                            Name = "MyWeb Van Toan"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 2, 18, 22, 51, 34, 254, DateTimeKind.Local).AddTicks(5862),
                            Name = "ABCXYZ"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
