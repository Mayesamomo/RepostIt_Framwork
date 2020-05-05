using Microsoft.EntityFrameworkCore.Migrations;

namespace RepostIt.Migrations
{
    public partial class AdditionalSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "community",
                columns: new[] { "Id", "communityType", "name" },
                values: new object[,]
                {
                    { 200, "Funny", "Admin" },
                    { 201, "Sad", "Admin" },
                    { 202, "Trololo", "Admin" },
                    { 203, "Sport", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "likes",
                columns: new[] { "id", "postId", "username" },
                values: new object[,]
                {
                    { 300, 100, "Admin" },
                    { 301, 101, "Admin" },
                    { 302, 103, "Admin" },
                    { 303, 104, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "id", "communityId", "description", "name", "showTitle", "url" },
                values: new object[,]
                {
                    { 100, 200, "2020 was awesome", "Admin", "Office MEME", "../img/office.jpg" },
                    { 101, 200, "Big COVID-19 Bang", "Admin", "Sheldon", "../img/sheldon.jpg" },
                    { 102, 200, "Magic", "Admin", "WOW", "../img/spmagic.jpg" },
                    { 104, 200, "Awesome", "Admin", "Great MEME", "../img/spsqp.png" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "community",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "community",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "community",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "likes",
                keyColumn: "id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "likes",
                keyColumn: "id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "likes",
                keyColumn: "id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "likes",
                keyColumn: "id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "community",
                keyColumn: "Id",
                keyValue: 200);
        }
    }
}
