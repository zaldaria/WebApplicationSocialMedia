﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationSocialMedia.Services;

#nullable disable

namespace WebApplicationSocialMedia.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250117085022_Eight")]
    partial class Eight
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CommunityUser", b =>
                {
                    b.Property<string>("isOrganizatorcommunityID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("membersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("isOrganizatorcommunityID", "membersId");

                    b.HasIndex("membersId");

                    b.ToTable("CommunityUser");
                });

            modelBuilder.Entity("InterestUser", b =>
                {
                    b.Property<string>("interestsinterestID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("usersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("interestsinterestID", "usersId");

                    b.HasIndex("usersId");

                    b.ToTable("InterestUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OrganizationUser", b =>
                {
                    b.Property<string>("membersId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("organizationsorganizationID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("membersId", "organizationsorganizationID");

                    b.HasIndex("organizationsorganizationID");

                    b.ToTable("OrganizationUser");
                });

            modelBuilder.Entity("WebApplicationSocialMedia.Models.Message", b =>
                {
                    b.Property<string>("messageID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("recipientID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("senderID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("sent")
                        .HasColumnType("datetime2");

                    b.Property<string>("text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("messageID");

                    b.HasIndex("recipientID");

                    b.HasIndex("senderID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("WebApplicationSocialMedia.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("birth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("residence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("WebSocialMedia.Models.Comment", b =>
                {
                    b.Property<string>("commentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("postID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("commentID");

                    b.HasIndex("postID");

                    b.HasIndex("userID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("WebSocialMedia.Models.Community", b =>
                {
                    b.Property<string>("communityID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("communityID");

                    b.HasIndex("userID");

                    b.ToTable("Communities");
                });

            modelBuilder.Entity("WebSocialMedia.Models.CommunityPost", b =>
                {
                    b.Property<string>("communityPostID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("communityID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("communityPostID");

                    b.HasIndex("communityID");

                    b.ToTable("CommunityPosts");
                });

            modelBuilder.Entity("WebSocialMedia.Models.Friendship", b =>
                {
                    b.Property<string>("friendshipID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("friendID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("userID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("friendshipID");

                    b.HasIndex("friendID");

                    b.HasIndex("userID");

                    b.ToTable("friendship");
                });

            modelBuilder.Entity("WebSocialMedia.Models.Interest", b =>
                {
                    b.Property<string>("interestID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("intName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("interestID");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("WebSocialMedia.Models.Like", b =>
                {
                    b.Property<string>("likeID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("postID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("userID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("likeID");

                    b.HasIndex("postID");

                    b.HasIndex("userID");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("WebSocialMedia.Models.Organization", b =>
                {
                    b.Property<string>("organizationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("orgName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("organizationID");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("WebSocialMedia.Models.Post", b =>
                {
                    b.Property<string>("postID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("authorID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("postID");

                    b.HasIndex("authorID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("CommunityUser", b =>
                {
                    b.HasOne("WebSocialMedia.Models.Community", null)
                        .WithMany()
                        .HasForeignKey("isOrganizatorcommunityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationSocialMedia.Models.User", null)
                        .WithMany()
                        .HasForeignKey("membersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InterestUser", b =>
                {
                    b.HasOne("WebSocialMedia.Models.Interest", null)
                        .WithMany()
                        .HasForeignKey("interestsinterestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationSocialMedia.Models.User", null)
                        .WithMany()
                        .HasForeignKey("usersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebApplicationSocialMedia.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebApplicationSocialMedia.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationSocialMedia.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebApplicationSocialMedia.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrganizationUser", b =>
                {
                    b.HasOne("WebApplicationSocialMedia.Models.User", null)
                        .WithMany()
                        .HasForeignKey("membersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebSocialMedia.Models.Organization", null)
                        .WithMany()
                        .HasForeignKey("organizationsorganizationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplicationSocialMedia.Models.Message", b =>
                {
                    b.HasOne("WebApplicationSocialMedia.Models.User", "recipient")
                        .WithMany("messagesIRecieve")
                        .HasForeignKey("recipientID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApplicationSocialMedia.Models.User", "sender")
                        .WithMany("messagesISent")
                        .HasForeignKey("senderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("recipient");

                    b.Navigation("sender");
                });

            modelBuilder.Entity("WebSocialMedia.Models.Comment", b =>
                {
                    b.HasOne("WebSocialMedia.Models.Post", "post")
                        .WithMany("comments")
                        .HasForeignKey("postID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationSocialMedia.Models.User", "author")
                        .WithMany("comments")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("author");

                    b.Navigation("post");
                });

            modelBuilder.Entity("WebSocialMedia.Models.Community", b =>
                {
                    b.HasOne("WebApplicationSocialMedia.Models.User", "organizator")
                        .WithMany("communities")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("organizator");
                });

            modelBuilder.Entity("WebSocialMedia.Models.CommunityPost", b =>
                {
                    b.HasOne("WebSocialMedia.Models.Community", "community")
                        .WithMany("communityPosts")
                        .HasForeignKey("communityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("community");
                });

            modelBuilder.Entity("WebSocialMedia.Models.Friendship", b =>
                {
                    b.HasOne("WebApplicationSocialMedia.Models.User", "friend")
                        .WithMany("imFriend")
                        .HasForeignKey("friendID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationSocialMedia.Models.User", "user")
                        .WithMany("myFriends")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("friend");

                    b.Navigation("user");
                });

            modelBuilder.Entity("WebSocialMedia.Models.Like", b =>
                {
                    b.HasOne("WebSocialMedia.Models.Post", "post")
                        .WithMany("likes")
                        .HasForeignKey("postID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationSocialMedia.Models.User", "author")
                        .WithMany("likes")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("author");

                    b.Navigation("post");
                });

            modelBuilder.Entity("WebSocialMedia.Models.Post", b =>
                {
                    b.HasOne("WebApplicationSocialMedia.Models.User", "author")
                        .WithMany("posts")
                        .HasForeignKey("authorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");
                });

            modelBuilder.Entity("WebApplicationSocialMedia.Models.User", b =>
                {
                    b.Navigation("comments");

                    b.Navigation("communities");

                    b.Navigation("imFriend");

                    b.Navigation("likes");

                    b.Navigation("messagesIRecieve");

                    b.Navigation("messagesISent");

                    b.Navigation("myFriends");

                    b.Navigation("posts");
                });

            modelBuilder.Entity("WebSocialMedia.Models.Community", b =>
                {
                    b.Navigation("communityPosts");
                });

            modelBuilder.Entity("WebSocialMedia.Models.Post", b =>
                {
                    b.Navigation("comments");

                    b.Navigation("likes");
                });
#pragma warning restore 612, 618
        }
    }
}
