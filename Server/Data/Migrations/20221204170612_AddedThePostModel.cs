using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    public partial class AddedThePostModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ThumbnailImagePath = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Excerpt = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 65536, nullable: false),
                    PublishDate = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Published = table.Column<bool>(type: "INTEGER", nullable: false),
                    Author = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "CategoryId", "Content", "Excerpt", "PublishDate", "Published", "ThumbnailImagePath", "Title" },
                values: new object[] { 1, "Fredy", 1, "", "This is excerpt for post1. An excerpt ia a little extraction from a larger piece of text. Sort of like preview.", "04/12/2022 05:06", true, "uploads/placeholder.jpg", "First post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "CategoryId", "Content", "Excerpt", "PublishDate", "Published", "ThumbnailImagePath", "Title" },
                values: new object[] { 2, "Fredy", 2, "", "This is excerpt for post2. An excerpt ia a little extraction from a larger piece of text. Sort of like preview.", "04/12/2022 05:06", true, "uploads/placeholder.jpg", "Second post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "CategoryId", "Content", "Excerpt", "PublishDate", "Published", "ThumbnailImagePath", "Title" },
                values: new object[] { 3, "Fredy", 3, "", "This is excerpt for post3. An excerpt ia a little extraction from a larger piece of text. Sort of like preview.", "04/12/2022 05:06", true, "uploads/placeholder.jpg", "Third post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "CategoryId", "Content", "Excerpt", "PublishDate", "Published", "ThumbnailImagePath", "Title" },
                values: new object[] { 4, "Fredy", 1, "", "This is excerpt for post4. An excerpt ia a little extraction from a larger piece of text. Sort of like preview.", "04/12/2022 05:06", true, "uploads/placeholder.jpg", "Fourth post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "CategoryId", "Content", "Excerpt", "PublishDate", "Published", "ThumbnailImagePath", "Title" },
                values: new object[] { 5, "Fredy", 2, "", "This is excerpt for post5. An excerpt ia a little extraction from a larger piece of text. Sort of like preview.", "04/12/2022 05:06", true, "uploads/placeholder.jpg", "Five post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "CategoryId", "Content", "Excerpt", "PublishDate", "Published", "ThumbnailImagePath", "Title" },
                values: new object[] { 6, "Fredy", 3, "", "This is excerpt for post6. An excerpt ia a little extraction from a larger piece of text. Sort of like preview.", "04/12/2022 05:06", true, "uploads/placeholder.jpg", "Six post" });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
