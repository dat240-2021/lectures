// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Six.Core.Infrastructure;

namespace Six.Migrations
{
    [DbContext(typeof(InstaContext))]
    partial class InstaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("Six.Core.Domain.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Six.Core.Domain.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Caption")
                        .HasColumnType("TEXT");

                    b.Property<int>("CommentCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfLikes")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Six.Core.Domain.Comment", b =>
                {
                    b.HasOne("Six.Core.Domain.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Six.Core.Domain.Post", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
