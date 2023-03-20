using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class CareersConfiguration : IEntityTypeConfiguration<CareersDbModel>
    {
        void IEntityTypeConfiguration<CareersDbModel>.Configure(EntityTypeBuilder<CareersDbModel> builder)
        {
            builder.ToTable("Careers");
            builder.HasData(this.BuildCareersList());
        }

        private IEnumerable<CareersDbModel> BuildCareersList()
        {
            return new List<CareersDbModel>()
            {
                new CareersDbModel()
                {
                    Id = Guid.Parse("5bbcb61d-2d3e-4373-8e0e-1c5d5fa66e98"),
                    Name = "Contabilidad"},
                new CareersDbModel() { Id = Guid.Parse("4eb0384c-2a10-4d4b-9e14-b9a9d3b3c8f7"), Name = "Técnico en Diseño Gráfico" },
                new CareersDbModel() { Id = Guid.Parse("5f5d5e47-2363-40da-aaab-1de1568c356a"), Name = "Técnico en Informática" },
                new CareersDbModel() { Id = Guid.Parse("6f8f6e88-3c3f-45af-b1dc-8a0e84004e9f"), Name = "Técnico Soporte Tecnologías" },
                new CareersDbModel() { Id = Guid.Parse("61de9a34-6d43-424e-bc6a-f7a10438f1d2"), Name = "Enfermería" },
                new CareersDbModel() { Id = Guid.Parse("fbd0423b-0f51-46d8-bf3d-9dcdaa188a71"), Name = "Ingeniería Civil" },
                new CareersDbModel() { Id = Guid.Parse("38dd9b33-28d5-4f8a-91f1-1ef067cd98d8"), Name = "Ingeniería Electromecánica" },
                new CareersDbModel() { Id = Guid.Parse("09f9894e-9464-4f5c-9f47-92b14ff7032a"), Name = "Ingeniería Electrónica" },
                new CareersDbModel() { Id = Guid.Parse("64a39cc8-8d02-4cc9-9a2d-5b5e0970f58e"), Name = "Ingeniería en Sistemas y Computación" },
                new CareersDbModel() { Id = Guid.Parse("1d6f78a6-52d8-4de3-9b7a-33ecdf177c8d"), Name = "Ingeniería Industrial" },
                new CareersDbModel() { Id = Guid.Parse("a1fb2cb1-3a85-40a5-b75b-d3e736b820cc"), Name = "Ingeniería Telemática" },
                new CareersDbModel() { Id = Guid.Parse("5a5b10cc-5db5-4a52-bab9-f0765a5f5b2d"), Name = "Licenciatura en Administración de Empresas" },
                new CareersDbModel() { Id = Guid.Parse("c674d812-02a7-4163-88f3-789bf0d3e9c9"), Name = "Licenciatura en Administración Hotelera" },
                new CareersDbModel() { Id = Guid.Parse("6dd77a4a-4e0f-4a18-869d-cf6d89a463a8"), Name = "Licenciatura en Educación Básica" },
                new CareersDbModel() { Id = Guid.Parse("2f1e6c92-6a33-4a4b-82da-8a92e6d82b6f"), Name = "Licenciatura en Educación Media" },
                new CareersDbModel() { Id = Guid.Parse("aa58e11f-227f-4dc4-a3f3-6ee7d6d4ad6f"), Name = "Licenciatura en Gestión Financiera y Auditoría" },
                new CareersDbModel() { Id = Guid.Parse("a86a2cc3-3c36-456a-a8b6-7c1d078efeb5"), Name = "Licenciatura en Mercadotecnia" },
                new CareersDbModel() { Id = Guid.Parse("51859a38-18d5-4ea8-b2c2-3cc9fae0f8b1"), Name = "Licenciatura en Psicología" },
                new CareersDbModel() { Id = Guid.Parse("c5a174b8-04a7-4bdc-9d17-1a8e01cbe98c"), Name = "Medicina" },
                new CareersDbModel() { Id = Guid.Parse("a8226c15-c6d7-4f13-9e56-6e35b6f4c4ea"), Name = "Administración de Empresas" },
                new CareersDbModel() { Id = Guid.Parse("e8a1876c-34f5-4c39-a1ce-c8e179b7c0b9"), Name = "Administración de Empresas Turísticas Hoteleras" }
            };
        }

    }
}
