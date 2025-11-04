using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persona3Compendium.Web.Migrations
{
    /// <inheritdoc />
    public partial class FixRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Absorbs",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Nullifies",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Reflects",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Resists",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Weak",
                table: "Personas");

            migrationBuilder.CreateTable(
                name: "PersonaAbsorb",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaAbsorb", x => new { x.PersonaId, x.ElementId });
                    table.ForeignKey(
                        name: "FK_PersonaAbsorb_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaAbsorb_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonaNullify",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaNullify", x => new { x.PersonaId, x.ElementId });
                    table.ForeignKey(
                        name: "FK_PersonaNullify_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaNullify_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonaReflect",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaReflect", x => new { x.PersonaId, x.ElementId });
                    table.ForeignKey(
                        name: "FK_PersonaReflect_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaReflect_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonaResist",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaResist", x => new { x.PersonaId, x.ElementId });
                    table.ForeignKey(
                        name: "FK_PersonaResist_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaResist_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonaWeakness",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaWeakness", x => new { x.PersonaId, x.ElementId });
                    table.ForeignKey(
                        name: "FK_PersonaWeakness_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaWeakness_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonaAbsorb_ElementId",
                table: "PersonaAbsorb",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaNullify_ElementId",
                table: "PersonaNullify",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaReflect_ElementId",
                table: "PersonaReflect",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaResist_ElementId",
                table: "PersonaResist",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaWeakness_ElementId",
                table: "PersonaWeakness",
                column: "ElementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonaAbsorb");

            migrationBuilder.DropTable(
                name: "PersonaNullify");

            migrationBuilder.DropTable(
                name: "PersonaReflect");

            migrationBuilder.DropTable(
                name: "PersonaResist");

            migrationBuilder.DropTable(
                name: "PersonaWeakness");

            migrationBuilder.AddColumn<string>(
                name: "Absorbs",
                table: "Personas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nullifies",
                table: "Personas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reflects",
                table: "Personas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Resists",
                table: "Personas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Weak",
                table: "Personas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
