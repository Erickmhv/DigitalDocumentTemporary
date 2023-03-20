using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicInstitution",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicInstitution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdentificationType = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Addresss = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PasswordChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordChanges_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AcademicInstitution",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("062e5d53-4f01-4c4f-b4f4-491b9c2dc851"), "Universidad Experimental Félix Adam (UNEFA)" },
                    { new Guid("0b3e85c9-9f2d-48d6-9f89-7c6f3ec8e20c"), "Universidad Nacional Evangélica (UNEV)" },
                    { new Guid("0f61b80e-7a29-42ce-a6c1-0a913011aaab"), "Universidad Central del Este (UCE)" },
                    { new Guid("0f84d674-6925-4b31-a777-47c105d7d297"), "Instituto Técnico Superior Mercy Jácquez (ITESUMJ)" },
                    { new Guid("1d134e09-2281-41cb-98f2-0a0b633a1d56"), "Instituto Especializado de Estudios Superiores Loyola (IEESL)" },
                    { new Guid("22d3907e-8b97-4a84-a76c-aa95a84a8a1f"), "Instituto de Educación Superior en Formación Diplomática y Consular (INESDYC)" },
                    { new Guid("2f8b114d-7d72-42d5-8c21-546f95b3349c"), "Escuela Nacional de la Judicatura (ENJ)" },
                    { new Guid("31ebaa1b-013e-4d33-a540-71e7bb9656ea"), "Universidad Católica Tecnológica de Barahona (UCATEBA)" },
                    { new Guid("3a3bfc81-6d50-470f-b77c-58c73fa01289"), "Instituto Especializado de Estudios Superiores de la Policía Nacional (IEESPON)" },
                    { new Guid("3d25a7eb-8dc5-4e50-8d5d-9d57da09c41b"), "Universidad Eugenio María de Hostos (UNIREMHOS)" },
                    { new Guid("3ef4645c-47c3-4fb3-b294-9cf7104c262f"), "Universidad Psicología Industrial Dominicana (UPID)" },
                    { new Guid("43d3b3fa-c1f1-4dfe-84c9-fb5e98f5c83b"), "Universidad Abierta para Adultos (UAPA)" },
                    { new Guid("4b4a47e4-85fa-4e9d-aa01-d30c0a94c676"), "Instituto Global de Altos Estudios en Ciencias Sociales (IGLOBAL)" },
                    { new Guid("4c4d7386-56f8-4e6d-9542-ff71e4b1dc18"), "Universidad Tecnológica de Santiago, UTESA" },
                    { new Guid("5b5f5df7-0990-4aa8-877c-6e4b4fda3ee3"), "Universidad Católica del Este (UCADE)" },
                    { new Guid("5bbcb61d-2d3e-4373-8e0e-1c5d5fa66e98"), "Escuela de Alta Dirección BARNA" },
                    { new Guid("5c2cb95f-c4b1-4c02-86ed-fecfbd8a30a4"), "Instituto Superior para la Defensa (INSUDE)" },
                    { new Guid("6ca059c6-3d6b-4f70-ba45-72722360f860"), "Escuela Nacional del Ministerio Público (ENMP)" },
                    { new Guid("6d71e0e5-f547-4352-a84e-5d5f082fc51a"), "Universidad Nacional Tecnológica (UNNATEC)" },
                    { new Guid("70b319fe-54c9-43b1-9aeb-8b510e00f0c7"), "Universidad Autónoma de Santo Domingo (UASD)" },
                    { new Guid("7125d6cf-3716-4c6e-9aa4-cd40fc3cb8f8"), "Universidad Católica del Cibao (UCATECI)" },
                    { new Guid("7d3d3eb3-7d1b-47ec-b80e-ea48a89b7c99"), "Universidad Odontológica Dominicana (UOD)" },
                    { new Guid("7d6236f5-6b3e-4f2e-9f6b-9c7d8bb86c10"), "Universidad del Caribe (UNICARIBE)" },
                    { new Guid("7e192cd9-96b7-4f16-ba27-ff2d2e0bbf87"), "Universidad Superior de Agricultura (UNISA)" },
                    { new Guid("85ec7dc5-aa94-4a4d-b72f-2bbfc283d1b3"), "Instituto Técnico Superior Oscus San Valero (ITSOSV)" },
                    { new Guid("870f148a-1b3d-46c3-9d0d-76d3667a14c2"), "Instituto OMG (IOMG)" },
                    { new Guid("a5a5a5d5-7aa5-45da-8ecf-315e157f6767"), "Universidad Tecnológica del Sur (UTESUR)" },
                    { new Guid("a6a2951b-b849-4579-b0d8-73c0f697bde9"), "Universidad Domínico-Americana (UNICDA)" },
                    { new Guid("a7198e43-358c-41a2-98d2-146eeb8d9509"), "Universidad Agroforestal Fernando Arturo de Meriño (UAFAM)" },
                    { new Guid("adfb0a4e-fec7-4618-ae9c-75063efab4a2"), "Universidad Católica Santo Domingo (UCSD)" },
                    { new Guid("b66e30a2-aa97-4cd4-9a4f-03d109160d20"), "Pontificia Universidad Católica Madre y Maestra (PUCMM)" },
                    { new Guid("bd447d92-6225-4a5e-b497-7fa942cd8bf4"), "Universidad Iberoamericana (UNIBE)" },
                    { new Guid("c28cf17b-c77a-4fcb-9d1c-b0bcb487c6aa"), "Universidad de la Tercera Edad (UTE)" },
                    { new Guid("c8a7bc92-6cdd-4227-8a8a-2c66a5d6de31"), "Instituto Superior de Formación Docente Salomé Ureña (ISFODOSU)" },
                    { new Guid("ca1916c1-6da3-43da-8cf9-e5788250f906"), "Instituto Tecnológico de las Américas (ITLA)" },
                    { new Guid("d1ecbe07-7c90-47dc-836d-bb86f772034e"), "Universidad Federico Henríquez y Carvajal (UFHEC)" },
                    { new Guid("d354c20f-8f05-470c-86d3-0073f7792f34"), "Universidad APEC (UNAPEC)" },
                    { new Guid("d80207af-50e8-4b3d-93d3-51dcf7d9d9af"), "Instituto Técnico Superior Comunitario (ITSC)" },
                    { new Guid("dd5c7e5d-444a-4ec5-9f09-4fb4af6d3ea8"), "Universidad Adventista Dominicana (UNAD)" },
                    { new Guid("e098c8b3-2a01-4426-9a6d-cb6fc315e636"), "Instituto Tecnológico de Santo Domingo (INTEC)" },
                    { new Guid("e1b64823-27d2-480c-b88c-09b35e8d7d05"), "Universidad Nacional Pedro Henríquez Ureña (UNPHU)" },
                    { new Guid("e28b6f0e-1c21-4d09-aa11-6a1a8a92b372"), "Universidad Católica Nordestana (UCNE)" },
                    { new Guid("e53d7b35-8215-4c47-8e8e-9c35c98b0f60"), "Universidad INCE" },
                    { new Guid("f3c6ec78-88e4-4e4b-b0d4-2f72f1a19c7a"), "Universidad Tecnológica del Cibao Oriental (UTECO)" },
                    { new Guid("f48b6d46-e1eb-43b3-a20b-b2fb2f25c1a3"), "Universidad Dominicana O&M" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PasswordChanges_UserId",
                table: "PasswordChanges",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicInstitution");

            migrationBuilder.DropTable(
                name: "PasswordChanges");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
