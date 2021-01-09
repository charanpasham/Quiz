using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuizCategory",
                columns: table => new
                {
                    QuizCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizCategoryType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizCategory", x => x.QuizCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    QuizId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    QuizCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.QuizId);
                    table.ForeignKey(
                        name: "FK_Quiz_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quiz_QuizCategory_QuizCategoryId",
                        column: x => x.QuizCategoryId,
                        principalTable: "QuizCategory",
                        principalColumn: "QuizCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestion",
                columns: table => new
                {
                    QuizQuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    QuizCategoryId = table.Column<int>(nullable: true),
                    QuizId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestion", x => x.QuizQuestionId);
                    table.ForeignKey(
                        name: "FK_QuizQuestion_QuizCategory_QuizCategoryId",
                        column: x => x.QuizCategoryId,
                        principalTable: "QuizCategory",
                        principalColumn: "QuizCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizQuestion_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizTaken",
                columns: table => new
                {
                    QuizTakenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizStatus = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    QuizId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizTaken", x => x.QuizTakenId);
                    table.ForeignKey(
                        name: "FK_QuizTaken_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizTaken_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizAnswers",
                columns: table => new
                {
                    QuizAnswersId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(nullable: true),
                    IsRight = table.Column<bool>(nullable: false),
                    QuizCategoryId = table.Column<int>(nullable: true),
                    QuizQuestionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizAnswers", x => x.QuizAnswersId);
                    table.ForeignKey(
                        name: "FK_QuizAnswers_QuizCategory_QuizCategoryId",
                        column: x => x.QuizCategoryId,
                        principalTable: "QuizCategory",
                        principalColumn: "QuizCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizAnswers_QuizQuestion_QuizQuestionId",
                        column: x => x.QuizQuestionId,
                        principalTable: "QuizQuestion",
                        principalColumn: "QuizQuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizResponse",
                columns: table => new
                {
                    QuizResponseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizAnswersId = table.Column<int>(nullable: true),
                    QuizCategoryId = table.Column<int>(nullable: true),
                    QuizQuestionId = table.Column<int>(nullable: true),
                    QuizTakenId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizResponse", x => x.QuizResponseId);
                    table.ForeignKey(
                        name: "FK_QuizResponse_QuizAnswers_QuizAnswersId",
                        column: x => x.QuizAnswersId,
                        principalTable: "QuizAnswers",
                        principalColumn: "QuizAnswersId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizResponse_QuizCategory_QuizCategoryId",
                        column: x => x.QuizCategoryId,
                        principalTable: "QuizCategory",
                        principalColumn: "QuizCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizResponse_QuizQuestion_QuizQuestionId",
                        column: x => x.QuizQuestionId,
                        principalTable: "QuizQuestion",
                        principalColumn: "QuizQuestionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizResponse_QuizTaken_QuizTakenId",
                        column: x => x.QuizTakenId,
                        principalTable: "QuizTaken",
                        principalColumn: "QuizTakenId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_ApplicationUserId",
                table: "Quiz",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_QuizCategoryId",
                table: "Quiz",
                column: "QuizCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAnswers_QuizCategoryId",
                table: "QuizAnswers",
                column: "QuizCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAnswers_QuizQuestionId",
                table: "QuizAnswers",
                column: "QuizQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_QuizCategoryId",
                table: "QuizQuestion",
                column: "QuizCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_QuizId",
                table: "QuizQuestion",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizResponse_QuizAnswersId",
                table: "QuizResponse",
                column: "QuizAnswersId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizResponse_QuizCategoryId",
                table: "QuizResponse",
                column: "QuizCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizResponse_QuizQuestionId",
                table: "QuizResponse",
                column: "QuizQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizResponse_QuizTakenId",
                table: "QuizResponse",
                column: "QuizTakenId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizTaken_ApplicationUserId",
                table: "QuizTaken",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizTaken_QuizId",
                table: "QuizTaken",
                column: "QuizId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizResponse");

            migrationBuilder.DropTable(
                name: "QuizAnswers");

            migrationBuilder.DropTable(
                name: "QuizTaken");

            migrationBuilder.DropTable(
                name: "QuizQuestion");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "QuizCategory");
        }
    }
}
