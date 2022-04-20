﻿// <auto-generated />
using System;
using Entity_Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entity_Classes.Migrations
{
    [DbContext(typeof(ChatDB))]
    partial class ChatDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Entity_Classes.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("GroupPicId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("UsersCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupPicId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Entity_Classes.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTimeOfSend")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Entity_Classes.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductImage");
                });

            modelBuilder.Entity("Entity_Classes.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("ProfilePicId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ProfilePicId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entity_Classes.UserToChat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersToChats");
                });

            modelBuilder.Entity("Entity_Classes.Chat", b =>
                {
                    b.HasOne("Entity_Classes.ProductImage", "GroupPic")
                        .WithMany()
                        .HasForeignKey("GroupPicId");

                    b.Navigation("GroupPic");
                });

            modelBuilder.Entity("Entity_Classes.Message", b =>
                {
                    b.HasOne("Entity_Classes.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity_Classes.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entity_Classes.User", b =>
                {
                    b.HasOne("Entity_Classes.ProductImage", "ProfilePic")
                        .WithMany()
                        .HasForeignKey("ProfilePicId");

                    b.Navigation("ProfilePic");
                });

            modelBuilder.Entity("Entity_Classes.UserToChat", b =>
                {
                    b.HasOne("Entity_Classes.Chat", "Chat")
                        .WithMany("UsersToChats")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity_Classes.User", "User")
                        .WithMany("UsersToChats")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entity_Classes.Chat", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("UsersToChats");
                });

            modelBuilder.Entity("Entity_Classes.User", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("UsersToChats");
                });
#pragma warning restore 612, 618
        }
    }
}
