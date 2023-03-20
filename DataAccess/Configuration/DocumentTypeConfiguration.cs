using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentTypeDbModel>
    {
        void IEntityTypeConfiguration<DocumentTypeDbModel>.Configure(EntityTypeBuilder<DocumentTypeDbModel> builder)
        {
            builder.ToTable("DocumentTypes");
            builder.HasData(this.BuildDocumentTypeList());
        }

        private IEnumerable<DocumentTypeDbModel> BuildDocumentTypeList()
        {
            return new List<DocumentTypeDbModel>()
            {
                new DocumentTypeDbModel()
                {
                    Id = Guid.Parse("5bbcb61d-2d3e-4373-8e0e-1c5d5fa66e98"),
                    Name = "Record de Notas"
                },
                new DocumentTypeDbModel() { Id = Guid.Parse("b2c7d08b-4c3e-4d37-a8e7-c75f67c78dce"), Name = "Carta de Grado" },
                new DocumentTypeDbModel() { Id = Guid.Parse("1a06a139-0d0b-4c8d-99bb-b95c2f7d6e25"), Name = "Titulo Original" },
                new DocumentTypeDbModel() { Id = Guid.Parse("59dd09de-4437-4d31-8be7-3c2345a3a177"), Name = "Copia de Titulo" },
                new DocumentTypeDbModel() { Id = Guid.Parse("0d5a5f3b-83b8-4f1b-b41f-d7eb28d41cf8"), Name = "Certificación de Titulo" },
                new DocumentTypeDbModel() { Id = Guid.Parse("c80e6d64-d6f7-4641-a221-2af522f1e4a9"), Name = "Rotación de Clínica" },
                new DocumentTypeDbModel() { Id = Guid.Parse("f8b68a25-18d1-44c6-a33a-24c2d18f5d5f"), Name = "Carta de Última Materia" },
                new DocumentTypeDbModel() { Id = Guid.Parse("96b2a44d-9c9e-4c39-8ce6-0d0e58c61de1"), Name = "Internado Rotatorio" },
                new DocumentTypeDbModel() { Id = Guid.Parse("d5266e7f-9302-43a8-a22b-b5239f7c2dbf"), Name = "Certificación de Programas de Estudios" },
                new DocumentTypeDbModel()
                {
                    Id = Guid.Parse("2c26f09d-0a2f-41e6-94c6-cd51b77e0e71"),
                    Name = "Certificación de Pensum"
                },
                new DocumentTypeDbModel()
                {
                    Id = Guid.Parse("2db49abf-1679-427e-a28a-5c19a33a5a4d"),
                    Name = "Calculo de Horas"
                },
                new DocumentTypeDbModel()
                {
                    Id = Guid.Parse("79e7d9d2-2aa7-4b34-9307-95a278c0ed24"),
                    Name = "Finalización de Estudios"
                },
                new DocumentTypeDbModel()
                {
                    Id = Guid.Parse("5d7048f1-7482-4269-bf17-bc6da8fb66ed"),
                    Name = "Certificación de Índice"
                },
                new DocumentTypeDbModel()
                {
                    Id = Guid.Parse("6b455a6b-f74d-455c-80a8-6b646931ca9f"),
                    Name = "Certificación de Estudios"
                },
                new DocumentTypeDbModel()
                {
                    Id = Guid.Parse("e2da1539-6989-4f81-8cd3-42cb3d3a3b1d"),
                    Name = "Certificación de Tesis"
                },
                new DocumentTypeDbModel()
                {
                    Id = Guid.Parse("e621cac7-7553-465d-87c1-9271f546af2d"),
                    Name = "Certificación De No Tesis"
                },
                new DocumentTypeDbModel()
                {
                    Id = Guid.Parse("82de1e7b-16f5-4d24-a9e5-4ed4ea4dfc8e"),
                    Name = "Constancia de Titulo"
                },
                new DocumentTypeDbModel()
                {
                    Id = Guid.Parse("e1673586-3db6-4613-82a3-8560d2597a9a"),
                    Name = "Revalida de Titulo"
                },
                new DocumentTypeDbModel()
                {
                    Id = Guid.Parse("99d83754-c764-47db-bb9c-7c2cb2dfc52d"),
                    Name = "Certificación de Personaduría Jurídica"
                },
                new DocumentTypeDbModel()
                {
                    Id = Guid.Parse("bd5f5c5e-4a2d-4c4c-bad9-fa7b0a30a8c7"),
                    Name = "Practicas Hospitalarias"
                },
                new DocumentTypeDbModel()
                {
                    Id = Guid.Parse("30c8fa7e-2dd1-4c5e-8928-5e3db9b3c3b5"),
                    Name = "Certificación de Constancia de Equivalencia"
                },
                new DocumentTypeDbModel()
                {
                    Id = Guid.Parse("11bc2d8e-59df-42e7-a7a8-79c0f455ca61"),
                    Name = "Certificación de Egresado"
                },
            };
        }

    }
}
