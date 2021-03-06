// <auto-generated />
using CarParkAvailability.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarParkAvailability.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20210618081314_CarParkAvailability.Context.UserContextSeed")]
    partial class CarParkAvailabilityContextUserContextSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarParkAvailability.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            ContactNumber = "642946",
                            Email = "bobthecat@email.com",
                            FirstName = "Bob",
                            LastName = "The Cat",
                            Password = "123456"
                        },
                        new
                        {
                            UserId = 2,
                            ContactNumber = "642949",
                            Email = "aslan@email.com",
                            FirstName = "Aslan",
                            LastName = "The Ginger",
                            Password = "123456"
                        },
                        new
                        {
                            UserId = 3,
                            ContactNumber = "642943",
                            Email = "tartee@email.com",
                            FirstName = "Tartee",
                            LastName = "The Shorthair",
                            Password = "123456"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
