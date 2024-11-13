using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DistanceArticle.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VenueGeometries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<Point>(type: "geometry", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueGeometries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "VenueGeometries",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-73.9654 40.7851)"), "Central Park" },
                    { 2, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-74.0445 40.6892)"), "Statue of Liberty" },
                    { 3, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-73.9857 40.7488)"), "Empire State Building" },
                    { 4, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-73.9855 40.758)"), "Times Square" },
                    { 5, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-73.9969 40.7061)"), "Brooklyn Bridge" },
                    { 6, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-74.0134 40.7127)"), "One World Trade Center" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VenueGeometries_Location",
                table: "VenueGeometries",
                column: "Location");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VenueGeometries");
        }
    }
}
