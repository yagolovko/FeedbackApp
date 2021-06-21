using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedbackApp.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Theme = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                });

            migrationBuilder.CreateTable(
                name: "ThemeFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Theme = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThemeFeedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    UserTelephone = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFeedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackDbs",
                columns: table => new
                {
                    FeedbackDbId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DbMessage = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    ThemeFeedbackId = table.Column<int>(type: "int", nullable: false),
                    UserFeedbackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackDbs", x => x.FeedbackDbId);
                    table.ForeignKey(
                        name: "FK_FeedbackDbs_ThemeFeedbacks_ThemeFeedbackId",
                        column: x => x.ThemeFeedbackId,
                        principalTable: "ThemeFeedbacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedbackDbs_UserFeedbacks_UserFeedbackId",
                        column: x => x.UserFeedbackId,
                        principalTable: "UserFeedbacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackDbs_ThemeFeedbackId",
                table: "FeedbackDbs",
                column: "ThemeFeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackDbs_UserFeedbackId",
                table: "FeedbackDbs",
                column: "UserFeedbackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedbackDbs");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "ThemeFeedbacks");

            migrationBuilder.DropTable(
                name: "UserFeedbacks");
        }
    }
}
