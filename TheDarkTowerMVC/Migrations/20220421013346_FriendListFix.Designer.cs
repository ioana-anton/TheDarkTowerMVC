﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TheDarkTowerMVC.Data;

#nullable disable

namespace TheDarkTowerMVC.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220421013346_FriendListFix")]
    partial class FriendListFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CardDeckGameCard", b =>
                {
                    b.Property<string>("CardDeckId")
                        .HasColumnType("text");

                    b.Property<string>("CardsId")
                        .HasColumnType("text");

                    b.HasKey("CardDeckId", "CardsId");

                    b.HasIndex("CardsId");

                    b.ToTable("CardDeckGameCard");
                });

            modelBuilder.Entity("FriendListUser", b =>
                {
                    b.Property<string>("FriendsId")
                        .HasColumnType("text");

                    b.Property<string>("UsersId")
                        .HasColumnType("text");

                    b.HasKey("FriendsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("FriendListUser");
                });

            modelBuilder.Entity("InboxRecipient", b =>
                {
                    b.Property<string>("InboxId")
                        .HasColumnType("text");

                    b.Property<string>("RecipientsId")
                        .HasColumnType("text");

                    b.HasKey("InboxId", "RecipientsId");

                    b.HasIndex("RecipientsId");

                    b.ToTable("InboxRecipient");
                });

            modelBuilder.Entity("TheDarkTowerMVC.Entity.CardDeck", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("byAdmin")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CardDecks");
                });

            modelBuilder.Entity("TheDarkTowerMVC.Entity.FriendList", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FriendList");
                });

            modelBuilder.Entity("TheDarkTowerMVC.Entity.GameCard", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Health")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Power")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("GameCards");
                });

            modelBuilder.Entity("TheDarkTowerMVC.Entity.Inbox", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SenderId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SenderId");

                    b.ToTable("Inboxes");
                });

            modelBuilder.Entity("TheDarkTowerMVC.Entity.Recipient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ReceiverId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.ToTable("Recipients");
                });

            modelBuilder.Entity("TheDarkTowerMVC.Entity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("CardDeckGameCard", b =>
                {
                    b.HasOne("TheDarkTowerMVC.Entity.CardDeck", null)
                        .WithMany()
                        .HasForeignKey("CardDeckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheDarkTowerMVC.Entity.GameCard", null)
                        .WithMany()
                        .HasForeignKey("CardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FriendListUser", b =>
                {
                    b.HasOne("TheDarkTowerMVC.Entity.FriendList", null)
                        .WithMany()
                        .HasForeignKey("FriendsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheDarkTowerMVC.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InboxRecipient", b =>
                {
                    b.HasOne("TheDarkTowerMVC.Entity.Inbox", null)
                        .WithMany()
                        .HasForeignKey("InboxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheDarkTowerMVC.Entity.Recipient", null)
                        .WithMany()
                        .HasForeignKey("RecipientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TheDarkTowerMVC.Entity.CardDeck", b =>
                {
                    b.HasOne("TheDarkTowerMVC.Entity.User", "User")
                        .WithMany("Decks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TheDarkTowerMVC.Entity.Inbox", b =>
                {
                    b.HasOne("TheDarkTowerMVC.Entity.User", "Sender")
                        .WithMany("Inboxes")
                        .HasForeignKey("SenderId");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("TheDarkTowerMVC.Entity.Recipient", b =>
                {
                    b.HasOne("TheDarkTowerMVC.Entity.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId");

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("TheDarkTowerMVC.Entity.User", b =>
                {
                    b.Navigation("Decks");

                    b.Navigation("Inboxes");
                });
#pragma warning restore 612, 618
        }
    }
}