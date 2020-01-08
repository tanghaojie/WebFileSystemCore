using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebFileSystemCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "WebFileSystemCore");

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "WebFileSystemCore",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Filename = table.Column<string>(nullable: false),
                    LocalFilePath = table.Column<string>(nullable: false),
                    Extension = table.Column<string>(nullable: true),
                    Length = table.Column<long>(nullable: false),
                    ContentType = table.Column<string>(nullable: true),
                    PermissionsStr = table.Column<string>(nullable: false),
                    FileTypeStr = table.Column<string>(nullable: false),
                    Owner = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastUpdationTime = table.Column<DateTime>(nullable: true),
                    LastVisitTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files",
                schema: "WebFileSystemCore");
        }
    }
}
