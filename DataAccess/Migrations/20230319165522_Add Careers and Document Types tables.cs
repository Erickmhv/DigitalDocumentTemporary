using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCareersandDocumentTypestables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Careers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Careers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("09f9894e-9464-4f5c-9f47-92b14ff7032a"), "Ingeniería Electrónica" },
                    { new Guid("1d6f78a6-52d8-4de3-9b7a-33ecdf177c8d"), "Ingeniería Industrial" },
                    { new Guid("2f1e6c92-6a33-4a4b-82da-8a92e6d82b6f"), "Licenciatura en Educación Media" },
                    { new Guid("38dd9b33-28d5-4f8a-91f1-1ef067cd98d8"), "Ingeniería Electromecánica" },
                    { new Guid("4eb0384c-2a10-4d4b-9e14-b9a9d3b3c8f7"), "Técnico en Diseño Gráfico" },
                    { new Guid("51859a38-18d5-4ea8-b2c2-3cc9fae0f8b1"), "Licenciatura en Psicología" },
                    { new Guid("5a5b10cc-5db5-4a52-bab9-f0765a5f5b2d"), "Licenciatura en Administración de Empresas" },
                    { new Guid("5bbcb61d-2d3e-4373-8e0e-1c5d5fa66e98"), "Contabilidad" },
                    { new Guid("5f5d5e47-2363-40da-aaab-1de1568c356a"), "Técnico en Informática" },
                    { new Guid("61de9a34-6d43-424e-bc6a-f7a10438f1d2"), "Enfermería" },
                    { new Guid("64a39cc8-8d02-4cc9-9a2d-5b5e0970f58e"), "Ingeniería en Sistemas y Computación" },
                    { new Guid("6dd77a4a-4e0f-4a18-869d-cf6d89a463a8"), "Licenciatura en Educación Básica" },
                    { new Guid("6f8f6e88-3c3f-45af-b1dc-8a0e84004e9f"), "Técnico Soporte Tecnologías" },
                    { new Guid("a1fb2cb1-3a85-40a5-b75b-d3e736b820cc"), "Ingeniería Telemática" },
                    { new Guid("a8226c15-c6d7-4f13-9e56-6e35b6f4c4ea"), "Administración de Empresas" },
                    { new Guid("a86a2cc3-3c36-456a-a8b6-7c1d078efeb5"), "Licenciatura en Mercadotecnia" },
                    { new Guid("aa58e11f-227f-4dc4-a3f3-6ee7d6d4ad6f"), "Licenciatura en Gestión Financiera y Auditoría" },
                    { new Guid("c5a174b8-04a7-4bdc-9d17-1a8e01cbe98c"), "Medicina" },
                    { new Guid("c674d812-02a7-4163-88f3-789bf0d3e9c9"), "Licenciatura en Administración Hotelera" },
                    { new Guid("e8a1876c-34f5-4c39-a1ce-c8e179b7c0b9"), "Administración de Empresas Turísticas Hoteleras" },
                    { new Guid("fbd0423b-0f51-46d8-bf3d-9dcdaa188a71"), "Ingeniería Civil" }
                });

            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0d5a5f3b-83b8-4f1b-b41f-d7eb28d41cf8"), "Certificación de Titulo" },
                    { new Guid("11bc2d8e-59df-42e7-a7a8-79c0f455ca61"), "Certificación de Egresado" },
                    { new Guid("1a06a139-0d0b-4c8d-99bb-b95c2f7d6e25"), "Titulo Original" },
                    { new Guid("2c26f09d-0a2f-41e6-94c6-cd51b77e0e71"), "Certificación de Pensum" },
                    { new Guid("2db49abf-1679-427e-a28a-5c19a33a5a4d"), "Calculo de Horas" },
                    { new Guid("30c8fa7e-2dd1-4c5e-8928-5e3db9b3c3b5"), "Certificación de Constancia de Equivalencia" },
                    { new Guid("59dd09de-4437-4d31-8be7-3c2345a3a177"), "Copia de Titulo" },
                    { new Guid("5bbcb61d-2d3e-4373-8e0e-1c5d5fa66e98"), "Record de Notas" },
                    { new Guid("5d7048f1-7482-4269-bf17-bc6da8fb66ed"), "Certificación de Índice" },
                    { new Guid("6b455a6b-f74d-455c-80a8-6b646931ca9f"), "Certificación de Estudios" },
                    { new Guid("79e7d9d2-2aa7-4b34-9307-95a278c0ed24"), "Finalización de Estudios" },
                    { new Guid("82de1e7b-16f5-4d24-a9e5-4ed4ea4dfc8e"), "Constancia de Titulo" },
                    { new Guid("96b2a44d-9c9e-4c39-8ce6-0d0e58c61de1"), "Internado Rotatorio" },
                    { new Guid("99d83754-c764-47db-bb9c-7c2cb2dfc52d"), "Certificación de Personaduría Jurídica" },
                    { new Guid("b2c7d08b-4c3e-4d37-a8e7-c75f67c78dce"), "Carta de Grado" },
                    { new Guid("bd5f5c5e-4a2d-4c4c-bad9-fa7b0a30a8c7"), "Practicas Hospitalarias" },
                    { new Guid("c80e6d64-d6f7-4641-a221-2af522f1e4a9"), "Rotación de Clínica" },
                    { new Guid("d5266e7f-9302-43a8-a22b-b5239f7c2dbf"), "Certificación de Programas de Estudios" },
                    { new Guid("e1673586-3db6-4613-82a3-8560d2597a9a"), "Revalida de Titulo" },
                    { new Guid("e2da1539-6989-4f81-8cd3-42cb3d3a3b1d"), "Certificación de Tesis" },
                    { new Guid("e621cac7-7553-465d-87c1-9271f546af2d"), "Certificación De No Tesis" },
                    { new Guid("f8b68a25-18d1-44c6-a33a-24c2d18f5d5f"), "Carta de Última Materia" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Careers");

            migrationBuilder.DropTable(
                name: "DocumentTypes");
        }
    }
}
