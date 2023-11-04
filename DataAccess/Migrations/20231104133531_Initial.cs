using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CofeeShops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenningHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CofeeShops", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CofeeShops",
                columns: new[] { "Id", "Address", "Name", "OpenningHours" },
                values: new object[,]
                {
                    { 1, "Bismarck, North Dakota", "The Mighty Missouri Coffee", null },
                    { 2, "Bismarck, North Dakota", "Mighty Missouri Coffee Company", null },
                    { 3, "St. Paul, Minnesota", "Spyhouse Coffee", null },
                    { 4, "Las Vegas, Nevada", "Sambalatte", null },
                    { 5, "Columbus, Ohio ", "Fox in the Snow", null },
                    { 6, "Salt Lake City, Utah", "Three Pines Coffee", null },
                    { 7, "NYC, New York", "Abraco", null },
                    { 8, "San Francisco ", "Sightglass Coffee", null },
                    { 9, "Naples, Florida", "Narrative Coffee Roasters", null },
                    { 10, "Honolulu, Hawaii", "Morning Glass", null },
                    { 11, "St. Cloud, Minnesota", "Kinder Coffee Lab", null },
                    { 12, "Chicago, Illinois", "Sip & Savor", null },
                    { 13, "Waynesville, North Carolina", "Orchard Coffee", null },
                    { 14, "Harrison, New Jersey", "Coperaco", null },
                    { 15, "San Diego, California", "Communal Coffee", null },
                    { 16, "Cleveland, Ohio", "Rising Star Coffee Roasters", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CofeeShops");
        }
    }
}
