using Microsoft.EntityFrameworkCore.Migrations;

namespace BM_Blazor_Nov20.Migrations
{
    public partial class ClientListTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    ConnectionString = table.Column<string>(nullable: true),
                    ExtraColumn1 = table.Column<string>(nullable: true),
                    ExtraColumn2 = table.Column<string>(nullable: true),
                    ExtraColumn3 = table.Column<string>(nullable: true),
                    ExtraColumn4 = table.Column<string>(nullable: true),
                    ExtraColumn5 = table.Column<string>(nullable: true),
                    ExtraColumn6 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
