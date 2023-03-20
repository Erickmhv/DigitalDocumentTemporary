using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.ViewModels.Dropdowns;

namespace DataAccess.Configuration
{
    public class AcademicInstitutionConfiguration : IEntityTypeConfiguration<AcademicInstitutionDbModel>
    {
        void IEntityTypeConfiguration<AcademicInstitutionDbModel>.Configure(EntityTypeBuilder<AcademicInstitutionDbModel> builder)
        {
            builder.ToTable("AcademicInstitution");
            builder.HasData(this.BuildAcademicInstitutionList());
        }

        private IEnumerable<AcademicInstitutionDbModel> BuildAcademicInstitutionList()
        {
            return new List<AcademicInstitutionDbModel>()
            {
                new AcademicInstitutionDbModel()
                {
                    Id = Guid.Parse("5bbcb61d-2d3e-4373-8e0e-1c5d5fa66e98"),
                    Name = "Escuela de Alta Dirección BARNA"
                },
                new AcademicInstitutionDbModel()
                {
                    Id = Guid.Parse("2f8b114d-7d72-42d5-8c21-546f95b3349c"),
                    Name = "Escuela Nacional de la Judicatura (ENJ)"
                },
                new AcademicInstitutionDbModel()
                {
                    Id = Guid.Parse("6ca059c6-3d6b-4f70-ba45-72722360f860"),
                    Name = "Escuela Nacional del Ministerio Público (ENMP)"
                },
                new AcademicInstitutionDbModel()
                {
                    Id = Guid.Parse("22d3907e-8b97-4a84-a76c-aa95a84a8a1f"),
                    Name = "Instituto de Educación Superior en Formación Diplomática y Consular (INESDYC)"
                },
                new AcademicInstitutionDbModel()
                {
                    Id = Guid.Parse("3a3bfc81-6d50-470f-b77c-58c73fa01289"),
                    Name = "Instituto Especializado de Estudios Superiores de la Policía Nacional (IEESPON)"
                },
                new AcademicInstitutionDbModel()
                {
                    Id = Guid.Parse("1d134e09-2281-41cb-98f2-0a0b633a1d56"),
                    Name = "Instituto Especializado de Estudios Superiores Loyola (IEESL)"
                },
                new AcademicInstitutionDbModel()
                {
                    Id = Guid.Parse("4b4a47e4-85fa-4e9d-aa01-d30c0a94c676"),
                    Name = "Instituto Global de Altos Estudios en Ciencias Sociales (IGLOBAL)"
                },
                new AcademicInstitutionDbModel()
                {
                    Id = Guid.Parse("870f148a-1b3d-46c3-9d0d-76d3667a14c2"),
                    Name = "Instituto OMG (IOMG)"
                },
                new AcademicInstitutionDbModel()
                {
                    Id = Guid.Parse("c8a7bc92-6cdd-4227-8a8a-2c66a5d6de31"),
                    Name = "Instituto Superior de Formación Docente Salomé Ureña (ISFODOSU)"
                },
                new AcademicInstitutionDbModel()
                {
                    Id = Guid.Parse("5c2cb95f-c4b1-4c02-86ed-fecfbd8a30a4"),
                    Name = "Instituto Superior para la Defensa (INSUDE)"
                },
                new AcademicInstitutionDbModel()
                {
                    Id = Guid.Parse("d80207af-50e8-4b3d-93d3-51dcf7d9d9af"),
                    Name = "Instituto Técnico Superior Comunitario (ITSC)"
                },
                new()
                {
                    Id = Guid.Parse("0f84d674-6925-4b31-a777-47c105d7d297"),
                    Name = "Instituto Técnico Superior Mercy Jácquez (ITESUMJ)"
                },
                new()
                {
                    Id = Guid.Parse("85ec7dc5-aa94-4a4d-b72f-2bbfc283d1b3"),
                    Name = "Instituto Técnico Superior Oscus San Valero (ITSOSV)"
                },
                new()
                {
                    Id = Guid.Parse("ca1916c1-6da3-43da-8cf9-e5788250f906"),
                    Name = "Instituto Tecnológico de las Américas (ITLA)"
                },
                new()
                {
                    Id = Guid.Parse("e098c8b3-2a01-4426-9a6d-cb6fc315e636"),
                    Name = "Instituto Tecnológico de Santo Domingo (INTEC)"
                },
                new()
                {
                    Id = Guid.Parse("b66e30a2-aa97-4cd4-9a4f-03d109160d20"),
                    Name = "Pontificia Universidad Católica Madre y Maestra (PUCMM)"
                },
                new()
                {
                    Id = Guid.Parse("43d3b3fa-c1f1-4dfe-84c9-fb5e98f5c83b"),
                    Name = "Universidad Abierta para Adultos (UAPA)"
                },
                new()
                {
                    Id = Guid.Parse("dd5c7e5d-444a-4ec5-9f09-4fb4af6d3ea8"),
                    Name = "Universidad Adventista Dominicana (UNAD)"
                },
                new()
                {
                    Id = Guid.Parse("a7198e43-358c-41a2-98d2-146eeb8d9509"),
                    Name = "Universidad Agroforestal Fernando Arturo de Meriño (UAFAM)"
                },
                new()
                {
                    Id = Guid.Parse("d354c20f-8f05-470c-86d3-0073f7792f34"),
                    Name = "Universidad APEC (UNAPEC)"
                },
                new()
                {
                    Id = Guid.Parse("70b319fe-54c9-43b1-9aeb-8b510e00f0c7"),
                    Name = "Universidad Autónoma de Santo Domingo (UASD)"
                },
                new()
                {
                    Id = Guid.Parse("7125d6cf-3716-4c6e-9aa4-cd40fc3cb8f8"),
                    Name = "Universidad Católica del Cibao (UCATECI)"
                },
                new()
                {
                    Id = Guid.Parse("5b5f5df7-0990-4aa8-877c-6e4b4fda3ee3"),
                    Name = "Universidad Católica del Este (UCADE)"
                },
                new() { Id = Guid.Parse("e28b6f0e-1c21-4d09-aa11-6a1a8a92b372"), Name = "Universidad Católica Nordestana (UCNE)" },
                new() { Id = Guid.Parse("adfb0a4e-fec7-4618-ae9c-75063efab4a2"), Name = "Universidad Católica Santo Domingo (UCSD)" },
                new() { Id = Guid.Parse("31ebaa1b-013e-4d33-a540-71e7bb9656ea"), Name = "Universidad Católica Tecnológica de Barahona (UCATEBA)" },
                new() { Id = Guid.Parse("0f61b80e-7a29-42ce-a6c1-0a913011aaab"), Name = "Universidad Central del Este (UCE)" },
                new() { Id = Guid.Parse("c28cf17b-c77a-4fcb-9d1c-b0bcb487c6aa"), Name = "Universidad de la Tercera Edad (UTE)" },
                new() { Id = Guid.Parse("7d6236f5-6b3e-4f2e-9f6b-9c7d8bb86c10"), Name = "Universidad del Caribe (UNICARIBE)" },
                new() { Id = Guid.Parse("f48b6d46-e1eb-43b3-a20b-b2fb2f25c1a3"), Name = "Universidad Dominicana O&M" },
                new() { Id = Guid.Parse("a6a2951b-b849-4579-b0d8-73c0f697bde9"), Name = "Universidad Domínico-Americana (UNICDA)" },
                new() { Id = Guid.Parse("3d25a7eb-8dc5-4e50-8d5d-9d57da09c41b"), Name = "Universidad Eugenio María de Hostos (UNIREMHOS)" },
                new() { Id = Guid.Parse("062e5d53-4f01-4c4f-b4f4-491b9c2dc851"), Name = "Universidad Experimental Félix Adam (UNEFA)" },
                new() { Id = Guid.Parse("d1ecbe07-7c90-47dc-836d-bb86f772034e"), Name = "Universidad Federico Henríquez y Carvajal (UFHEC)" },
                new() { Id = Guid.Parse("bd447d92-6225-4a5e-b497-7fa942cd8bf4"), Name = "Universidad Iberoamericana (UNIBE)" },
                new() { Id = Guid.Parse("e53d7b35-8215-4c47-8e8e-9c35c98b0f60"), Name = "Universidad INCE" },
                new() { Id = Guid.Parse("7e192cd9-96b7-4f16-ba27-ff2d2e0bbf87"), Name = "Universidad Superior de Agricultura (UNISA)" },
                new() { Id = Guid.Parse("0b3e85c9-9f2d-48d6-9f89-7c6f3ec8e20c"), Name = "Universidad Nacional Evangélica (UNEV)" },
                new() { Id = Guid.Parse("e1b64823-27d2-480c-b88c-09b35e8d7d05"), Name = "Universidad Nacional Pedro Henríquez Ureña (UNPHU)" },
                new() { Id = Guid.Parse("6d71e0e5-f547-4352-a84e-5d5f082fc51a"), Name = "Universidad Nacional Tecnológica (UNNATEC)" },
                new() { Id = Guid.Parse("7d3d3eb3-7d1b-47ec-b80e-ea48a89b7c99"), Name = "Universidad Odontológica Dominicana (UOD)" },
                new() { Id = Guid.Parse("3ef4645c-47c3-4fb3-b294-9cf7104c262f"), Name = "Universidad Psicología Industrial Dominicana (UPID)" },
                new() { Id = Guid.Parse("4c4d7386-56f8-4e6d-9542-ff71e4b1dc18"), Name = "Universidad Tecnológica de Santiago, UTESA" },
                new() { Id = Guid.Parse("f3c6ec78-88e4-4e4b-b0d4-2f72f1a19c7a"), Name = "Universidad Tecnológica del Cibao Oriental (UTECO)" },
                new() { Id = Guid.Parse("a5a5a5d5-7aa5-45da-8ecf-315e157f6767"), Name = "Universidad Tecnológica del Sur (UTESUR)" }
            };
        }

    }
}
