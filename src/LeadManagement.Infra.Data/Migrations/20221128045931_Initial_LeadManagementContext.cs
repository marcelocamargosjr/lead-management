using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeadManagement.Infra.Data.Migrations
{
    public partial class Initial_LeadManagementContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactFirstName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ContactFullName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ContactPhoneNumber = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ContactEmail = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Suburb = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Category = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    JobId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leads");
        }
    }
}
