using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationSocialMedia.Migrations
{
    /// <inheritdoc />
    public partial class ThirdM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "Communities",
                columns: table => new
                {
                    communityID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communities", x => x.communityID);
                    table.ForeignKey(
                        name: "FK_Communities_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "friendship",
                columns: table => new
                {
                    friendshipID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    friendID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_friendship", x => x.friendshipID);
                    table.ForeignKey(
                        name: "FK_friendship_AspNetUsers_friendID",
                        column: x => x.friendID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_friendship_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    interestID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    intName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.interestID);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    messageID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    senderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    recipientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sent = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.messageID);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_recipientID",
                        column: x => x.recipientID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_senderID",
                        column: x => x.senderID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    organizationID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    orgName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.organizationID);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    postID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    authorID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.postID);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_authorID",
                        column: x => x.authorID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityPosts",
                columns: table => new
                {
                    communityPostID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    communityID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityPosts", x => x.communityPostID);
                    table.ForeignKey(
                        name: "FK_CommunityPosts_Communities_communityID",
                        column: x => x.communityID,
                        principalTable: "Communities",
                        principalColumn: "communityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityUser",
                columns: table => new
                {
                    isOrganizatorcommunityID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    membersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityUser", x => new { x.isOrganizatorcommunityID, x.membersId });
                    table.ForeignKey(
                        name: "FK_CommunityUser_AspNetUsers_membersId",
                        column: x => x.membersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityUser_Communities_isOrganizatorcommunityID",
                        column: x => x.isOrganizatorcommunityID,
                        principalTable: "Communities",
                        principalColumn: "communityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestUser",
                columns: table => new
                {
                    interestsinterestID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    usersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestUser", x => new { x.interestsinterestID, x.usersId });
                    table.ForeignKey(
                        name: "FK_InterestUser_AspNetUsers_usersId",
                        column: x => x.usersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestUser_Interests_interestsinterestID",
                        column: x => x.interestsinterestID,
                        principalTable: "Interests",
                        principalColumn: "interestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationUser",
                columns: table => new
                {
                    membersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    organizationsorganizationID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationUser", x => new { x.membersId, x.organizationsorganizationID });
                    table.ForeignKey(
                        name: "FK_OrganizationUser_AspNetUsers_membersId",
                        column: x => x.membersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationUser_Organizations_organizationsorganizationID",
                        column: x => x.organizationsorganizationID,
                        principalTable: "Organizations",
                        principalColumn: "organizationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    commentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    postID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.commentID);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_postID",
                        column: x => x.postID,
                        principalTable: "Posts",
                        principalColumn: "postID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    likeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    postID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.likeID);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_postID",
                        column: x => x.postID,
                        principalTable: "Posts",
                        principalColumn: "postID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_postID",
                table: "Comments",
                column: "postID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_userID",
                table: "Comments",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Communities_userID",
                table: "Communities",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityPosts_communityID",
                table: "CommunityPosts",
                column: "communityID");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityUser_membersId",
                table: "CommunityUser",
                column: "membersId");

            migrationBuilder.CreateIndex(
                name: "IX_friendship_friendID",
                table: "friendship",
                column: "friendID");

            migrationBuilder.CreateIndex(
                name: "IX_friendship_userID",
                table: "friendship",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_InterestUser_usersId",
                table: "InterestUser",
                column: "usersId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_postID",
                table: "Likes",
                column: "postID");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_userID",
                table: "Likes",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_recipientID",
                table: "Messages",
                column: "recipientID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_senderID",
                table: "Messages",
                column: "senderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationUser_organizationsorganizationID",
                table: "OrganizationUser",
                column: "organizationsorganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_authorID",
                table: "Posts",
                column: "authorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "CommunityPosts");

            migrationBuilder.DropTable(
                name: "CommunityUser");

            migrationBuilder.DropTable(
                name: "friendship");

            migrationBuilder.DropTable(
                name: "InterestUser");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "OrganizationUser");

            migrationBuilder.DropTable(
                name: "Communities");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);
        }
    }
}
