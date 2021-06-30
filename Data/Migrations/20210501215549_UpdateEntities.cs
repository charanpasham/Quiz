using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz.Data.Migrations
{
    public partial class UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizCategoryType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Quizes",
                columns: table => new
                {
                    QuizesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizes", x => x.QuizesId);
                    table.ForeignKey(
                        name: "FK_Quizes_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quizes_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: true),
                    QuizesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.QuestionsId);
                    table.ForeignKey(
                        name: "FK_Question_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Question_Quizes_QuizesId",
                        column: x => x.QuizesId,
                        principalTable: "Quizes",
                        principalColumn: "QuizesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Taken",
                columns: table => new
                {
                    TakenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizStatus = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    QuizesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taken", x => x.TakenId);
                    table.ForeignKey(
                        name: "FK_Taken_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Taken_Quizes_QuizesId",
                        column: x => x.QuizesId,
                        principalTable: "Quizes",
                        principalColumn: "QuizesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswersId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(nullable: true),
                    IsRight = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: true),
                    QuestionsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswersId);
                    table.ForeignKey(
                        name: "FK_Answers_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_Question_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Question",
                        principalColumn: "QuestionsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    ResponseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswersId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    QuestionsId = table.Column<int>(nullable: true),
                    TakenId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_Response_Answers_AnswersId",
                        column: x => x.AnswersId,
                        principalTable: "Answers",
                        principalColumn: "AnswersId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Response_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Response_Question_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Question",
                        principalColumn: "QuestionsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Response_Taken_TakenId",
                        column: x => x.TakenId,
                        principalTable: "Taken",
                        principalColumn: "TakenId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_CategoryId",
                table: "Answers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionsId",
                table: "Answers",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_CategoryId",
                table: "Question",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuizesId",
                table: "Question",
                column: "QuizesId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizes_ApplicationUserId",
                table: "Quizes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizes_CategoryId",
                table: "Quizes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_AnswersId",
                table: "Response",
                column: "AnswersId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_CategoryId",
                table: "Response",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_QuestionsId",
                table: "Response",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_TakenId",
                table: "Response",
                column: "TakenId");

            migrationBuilder.CreateIndex(
                name: "IX_Taken_ApplicationUserId",
                table: "Taken",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Taken_QuizesId",
                table: "Taken",
                column: "QuizesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Response");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Taken");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Quizes");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.CreateTable(
                name: "QuizCategory",
                columns: table => new
                {
                    QuizCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizCategoryType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizCategory", x => x.QuizCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    QuizId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    QuizCategoryId = table.Column<int>(type: "int", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    QuizQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizCategoryId = table.Column<int>(type: "int", nullable: true),
                    QuizId = table.Column<int>(type: "int", nullable: true)
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
                    QuizTakenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    QuizId = table.Column<int>(type: "int", nullable: true),
                    QuizStatus = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
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
                    QuizAnswersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsRight = table.Column<bool>(type: "bit", nullable: false),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizCategoryId = table.Column<int>(type: "int", nullable: true),
                    QuizQuestionId = table.Column<int>(type: "int", nullable: true)
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
                    QuizResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizAnswersId = table.Column<int>(type: "int", nullable: true),
                    QuizCategoryId = table.Column<int>(type: "int", nullable: true),
                    QuizQuestionId = table.Column<int>(type: "int", nullable: true),
                    QuizTakenId = table.Column<int>(type: "int", nullable: true)
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
    }
}
