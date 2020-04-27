using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aPIS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    apiName = table.Column<string>(maxLength: 100, nullable: true),
                    apiDisplayName = table.Column<string>(maxLength: 50, nullable: true),
                    Group = table.Column<string>(maxLength: 50, nullable: true),
                    FServiceName = table.Column<string>(maxLength: 50, nullable: true),
                    FServiceID = table.Column<string>(maxLength: 50, nullable: true),
                    apiStart = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aPIS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "userAllowedScopes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(nullable: true),
                    aPIID = table.Column<int>(nullable: false),
                    scopesStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAllowedScopes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "userClient",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(nullable: true),
                    ClientId = table.Column<string>(nullable: true),
                    AllowedGrantTypes = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userClient", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<string>(nullable: true),
                    uName = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "userSecret",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    secretName = table.Column<string>(maxLength: 100, nullable: true),
                    pwType = table.Column<string>(maxLength: 30, nullable: true),
                    clientId = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userSecret", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aPIS");

            migrationBuilder.DropTable(
                name: "userAllowedScopes");

            migrationBuilder.DropTable(
                name: "userClient");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "userSecret");
        }
    }
}
