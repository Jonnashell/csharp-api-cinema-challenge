using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api_cinema_challenge.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    RuntimeMins = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "screenings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScreenNumber = table.Column<int>(type: "integer", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    StartsAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MovieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_screenings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_screenings_movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumSeats = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    ScreeningId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tickets_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tickets_screenings_ScreeningId",
                        column: x => x.ScreeningId,
                        principalTable: "screenings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 20, 12, 0, 0, 0, DateTimeKind.Utc), "jonnabr@hotmail.com", "Jonatan", "+4793277670", new DateTime(2025, 1, 21, 15, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, new DateTime(2025, 1, 20, 12, 0, 0, 0, DateTimeKind.Utc), "Isabel@hotmail.com", "Isabel", "+4792088620", new DateTime(2025, 1, 21, 15, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, new DateTime(2025, 1, 19, 12, 0, 0, 0, DateTimeKind.Utc), "marius@hotmail.com", "Marius", "+4798765432", new DateTime(2025, 1, 21, 17, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, new DateTime(2025, 1, 18, 12, 0, 0, 0, DateTimeKind.Utc), "emma@hotmail.com", "Emma", "+4791234567", new DateTime(2025, 1, 21, 18, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "Id", "CreatedAt", "Description", "Rating", "RuntimeMins", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 11, 10, 0, 0, 0, DateTimeKind.Utc), "A skilled thief is offered a chance to have his past crimes forgiven.", "PG-13", 148, "Inception", new DateTime(2025, 1, 21, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, new DateTime(2025, 1, 9, 14, 0, 0, 0, DateTimeKind.Utc), "A computer hacker learns about the true nature of reality.", "R", 136, "The Matrix", new DateTime(2025, 1, 21, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, new DateTime(2025, 1, 13, 9, 0, 0, 0, DateTimeKind.Utc), "Explorers travel through a wormhole in space.", "PG-13", 169, "Interstellar", new DateTime(2025, 1, 21, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, new DateTime(2025, 1, 6, 16, 0, 0, 0, DateTimeKind.Utc), "Batman faces the Joker in Gotham City.", "PG-13", 152, "The Dark Knight", new DateTime(2025, 1, 21, 12, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "screenings",
                columns: new[] { "Id", "Capacity", "CreatedAt", "MovieId", "ScreenNumber", "StartsAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 100, new DateTime(2025, 1, 20, 11, 0, 0, 0, DateTimeKind.Utc), 1, 1, new DateTime(2025, 1, 23, 18, 30, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 21, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 80, new DateTime(2025, 1, 19, 11, 0, 0, 0, DateTimeKind.Utc), 2, 2, new DateTime(2025, 1, 24, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 21, 12, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "tickets",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "NumSeats", "ScreeningId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 20, 13, 0, 0, 0, DateTimeKind.Utc), 1, 2, 1, new DateTime(2025, 1, 21, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, new DateTime(2025, 1, 20, 14, 0, 0, 0, DateTimeKind.Utc), 2, 1, 1, new DateTime(2025, 1, 21, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, new DateTime(2025, 1, 19, 15, 0, 0, 0, DateTimeKind.Utc), 3, 3, 2, new DateTime(2025, 1, 21, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, new DateTime(2025, 1, 19, 16, 0, 0, 0, DateTimeKind.Utc), 4, 2, 2, new DateTime(2025, 1, 21, 12, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_screenings_MovieId",
                table: "screenings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_CustomerId",
                table: "tickets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_ScreeningId",
                table: "tickets",
                column: "ScreeningId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "screenings");

            migrationBuilder.DropTable(
                name: "movies");
        }
    }
}
