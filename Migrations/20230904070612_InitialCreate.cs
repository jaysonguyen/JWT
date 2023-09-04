using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ehsproject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FovRequest",
                columns: table => new
                {
                    FovRequestID = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SupplierCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Require = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FovRequest", x => new { x.Count, x.SupplierCode, x.FovRequestID, x.Status });
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    ResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMaker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsContain = table.Column<bool>(type: "bit", nullable: true),
                    SupplierCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.ResultId);
                });

            migrationBuilder.CreateTable(
                name: "ResultDetail",
                columns: table => new
                {
                    DetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResultId = table.Column<int>(type: "int", nullable: true),
                    Mineral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Substance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Concentration = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultDetail", x => x.DetailID);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierCode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FovRequest");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "ResultDetail");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
