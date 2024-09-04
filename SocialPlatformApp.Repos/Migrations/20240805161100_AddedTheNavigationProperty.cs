using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialPlatformApp.Repos.Migrations
{
    /// <inheritdoc />
    public partial class AddedTheNavigationProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequest_User_RecipientId",
                schema: "SocialPlatformAppSchema",
                table: "FriendRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequest_User_SenderId",
                schema: "SocialPlatformAppSchema",
                table: "FriendRequest");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequest_User_RecipientId",
                schema: "SocialPlatformAppSchema",
                table: "FriendRequest",
                column: "RecipientId",
                principalSchema: "SocialPlatformAppSchema",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequest_User_SenderId",
                schema: "SocialPlatformAppSchema",
                table: "FriendRequest",
                column: "SenderId",
                principalSchema: "SocialPlatformAppSchema",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequest_User_RecipientId",
                schema: "SocialPlatformAppSchema",
                table: "FriendRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequest_User_SenderId",
                schema: "SocialPlatformAppSchema",
                table: "FriendRequest");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequest_User_RecipientId",
                schema: "SocialPlatformAppSchema",
                table: "FriendRequest",
                column: "RecipientId",
                principalSchema: "SocialPlatformAppSchema",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequest_User_SenderId",
                schema: "SocialPlatformAppSchema",
                table: "FriendRequest",
                column: "SenderId",
                principalSchema: "SocialPlatformAppSchema",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
