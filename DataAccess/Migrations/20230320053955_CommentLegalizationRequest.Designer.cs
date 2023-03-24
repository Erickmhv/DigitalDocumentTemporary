﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    [Migration("20230320053955_CommentLegalizationRequest")]
    partial class CommentLegalizationRequest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Models.AcademicInstitutionDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("AcademicInstitution", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("5bbcb61d-2d3e-4373-8e0e-1c5d5fa66e98"),
                            Name = "Escuela de Alta Dirección BARNA"
                        },
                        new
                        {
                            Id = new Guid("2f8b114d-7d72-42d5-8c21-546f95b3349c"),
                            Name = "Escuela Nacional de la Judicatura (ENJ)"
                        },
                        new
                        {
                            Id = new Guid("6ca059c6-3d6b-4f70-ba45-72722360f860"),
                            Name = "Escuela Nacional del Ministerio Público (ENMP)"
                        },
                        new
                        {
                            Id = new Guid("22d3907e-8b97-4a84-a76c-aa95a84a8a1f"),
                            Name = "Instituto de Educación Superior en Formación Diplomática y Consular (INESDYC)"
                        },
                        new
                        {
                            Id = new Guid("3a3bfc81-6d50-470f-b77c-58c73fa01289"),
                            Name = "Instituto Especializado de Estudios Superiores de la Policía Nacional (IEESPON)"
                        },
                        new
                        {
                            Id = new Guid("1d134e09-2281-41cb-98f2-0a0b633a1d56"),
                            Name = "Instituto Especializado de Estudios Superiores Loyola (IEESL)"
                        },
                        new
                        {
                            Id = new Guid("4b4a47e4-85fa-4e9d-aa01-d30c0a94c676"),
                            Name = "Instituto Global de Altos Estudios en Ciencias Sociales (IGLOBAL)"
                        },
                        new
                        {
                            Id = new Guid("870f148a-1b3d-46c3-9d0d-76d3667a14c2"),
                            Name = "Instituto OMG (IOMG)"
                        },
                        new
                        {
                            Id = new Guid("c8a7bc92-6cdd-4227-8a8a-2c66a5d6de31"),
                            Name = "Instituto Superior de Formación Docente Salomé Ureña (ISFODOSU)"
                        },
                        new
                        {
                            Id = new Guid("5c2cb95f-c4b1-4c02-86ed-fecfbd8a30a4"),
                            Name = "Instituto Superior para la Defensa (INSUDE)"
                        },
                        new
                        {
                            Id = new Guid("d80207af-50e8-4b3d-93d3-51dcf7d9d9af"),
                            Name = "Instituto Técnico Superior Comunitario (ITSC)"
                        },
                        new
                        {
                            Id = new Guid("0f84d674-6925-4b31-a777-47c105d7d297"),
                            Name = "Instituto Técnico Superior Mercy Jácquez (ITESUMJ)"
                        },
                        new
                        {
                            Id = new Guid("85ec7dc5-aa94-4a4d-b72f-2bbfc283d1b3"),
                            Name = "Instituto Técnico Superior Oscus San Valero (ITSOSV)"
                        },
                        new
                        {
                            Id = new Guid("ca1916c1-6da3-43da-8cf9-e5788250f906"),
                            Name = "Instituto Tecnológico de las Américas (ITLA)"
                        },
                        new
                        {
                            Id = new Guid("e098c8b3-2a01-4426-9a6d-cb6fc315e636"),
                            Name = "Instituto Tecnológico de Santo Domingo (INTEC)"
                        },
                        new
                        {
                            Id = new Guid("b66e30a2-aa97-4cd4-9a4f-03d109160d20"),
                            Name = "Pontificia Universidad Católica Madre y Maestra (PUCMM)"
                        },
                        new
                        {
                            Id = new Guid("43d3b3fa-c1f1-4dfe-84c9-fb5e98f5c83b"),
                            Name = "Universidad Abierta para Adultos (UAPA)"
                        },
                        new
                        {
                            Id = new Guid("dd5c7e5d-444a-4ec5-9f09-4fb4af6d3ea8"),
                            Name = "Universidad Adventista Dominicana (UNAD)"
                        },
                        new
                        {
                            Id = new Guid("a7198e43-358c-41a2-98d2-146eeb8d9509"),
                            Name = "Universidad Agroforestal Fernando Arturo de Meriño (UAFAM)"
                        },
                        new
                        {
                            Id = new Guid("d354c20f-8f05-470c-86d3-0073f7792f34"),
                            Name = "Universidad APEC (UNAPEC)"
                        },
                        new
                        {
                            Id = new Guid("70b319fe-54c9-43b1-9aeb-8b510e00f0c7"),
                            Name = "Universidad Autónoma de Santo Domingo (UASD)"
                        },
                        new
                        {
                            Id = new Guid("7125d6cf-3716-4c6e-9aa4-cd40fc3cb8f8"),
                            Name = "Universidad Católica del Cibao (UCATECI)"
                        },
                        new
                        {
                            Id = new Guid("5b5f5df7-0990-4aa8-877c-6e4b4fda3ee3"),
                            Name = "Universidad Católica del Este (UCADE)"
                        },
                        new
                        {
                            Id = new Guid("e28b6f0e-1c21-4d09-aa11-6a1a8a92b372"),
                            Name = "Universidad Católica Nordestana (UCNE)"
                        },
                        new
                        {
                            Id = new Guid("adfb0a4e-fec7-4618-ae9c-75063efab4a2"),
                            Name = "Universidad Católica Santo Domingo (UCSD)"
                        },
                        new
                        {
                            Id = new Guid("31ebaa1b-013e-4d33-a540-71e7bb9656ea"),
                            Name = "Universidad Católica Tecnológica de Barahona (UCATEBA)"
                        },
                        new
                        {
                            Id = new Guid("0f61b80e-7a29-42ce-a6c1-0a913011aaab"),
                            Name = "Universidad Central del Este (UCE)"
                        },
                        new
                        {
                            Id = new Guid("c28cf17b-c77a-4fcb-9d1c-b0bcb487c6aa"),
                            Name = "Universidad de la Tercera Edad (UTE)"
                        },
                        new
                        {
                            Id = new Guid("7d6236f5-6b3e-4f2e-9f6b-9c7d8bb86c10"),
                            Name = "Universidad del Caribe (UNICARIBE)"
                        },
                        new
                        {
                            Id = new Guid("f48b6d46-e1eb-43b3-a20b-b2fb2f25c1a3"),
                            Name = "Universidad Dominicana O&M"
                        },
                        new
                        {
                            Id = new Guid("a6a2951b-b849-4579-b0d8-73c0f697bde9"),
                            Name = "Universidad Domínico-Americana (UNICDA)"
                        },
                        new
                        {
                            Id = new Guid("3d25a7eb-8dc5-4e50-8d5d-9d57da09c41b"),
                            Name = "Universidad Eugenio María de Hostos (UNIREMHOS)"
                        },
                        new
                        {
                            Id = new Guid("062e5d53-4f01-4c4f-b4f4-491b9c2dc851"),
                            Name = "Universidad Experimental Félix Adam (UNEFA)"
                        },
                        new
                        {
                            Id = new Guid("d1ecbe07-7c90-47dc-836d-bb86f772034e"),
                            Name = "Universidad Federico Henríquez y Carvajal (UFHEC)"
                        },
                        new
                        {
                            Id = new Guid("bd447d92-6225-4a5e-b497-7fa942cd8bf4"),
                            Name = "Universidad Iberoamericana (UNIBE)"
                        },
                        new
                        {
                            Id = new Guid("e53d7b35-8215-4c47-8e8e-9c35c98b0f60"),
                            Name = "Universidad INCE"
                        },
                        new
                        {
                            Id = new Guid("7e192cd9-96b7-4f16-ba27-ff2d2e0bbf87"),
                            Name = "Universidad Superior de Agricultura (UNISA)"
                        },
                        new
                        {
                            Id = new Guid("0b3e85c9-9f2d-48d6-9f89-7c6f3ec8e20c"),
                            Name = "Universidad Nacional Evangélica (UNEV)"
                        },
                        new
                        {
                            Id = new Guid("e1b64823-27d2-480c-b88c-09b35e8d7d05"),
                            Name = "Universidad Nacional Pedro Henríquez Ureña (UNPHU)"
                        },
                        new
                        {
                            Id = new Guid("6d71e0e5-f547-4352-a84e-5d5f082fc51a"),
                            Name = "Universidad Nacional Tecnológica (UNNATEC)"
                        },
                        new
                        {
                            Id = new Guid("7d3d3eb3-7d1b-47ec-b80e-ea48a89b7c99"),
                            Name = "Universidad Odontológica Dominicana (UOD)"
                        },
                        new
                        {
                            Id = new Guid("3ef4645c-47c3-4fb3-b294-9cf7104c262f"),
                            Name = "Universidad Psicología Industrial Dominicana (UPID)"
                        },
                        new
                        {
                            Id = new Guid("4c4d7386-56f8-4e6d-9542-ff71e4b1dc18"),
                            Name = "Universidad Tecnológica de Santiago, UTESA"
                        },
                        new
                        {
                            Id = new Guid("f3c6ec78-88e4-4e4b-b0d4-2f72f1a19c7a"),
                            Name = "Universidad Tecnológica del Cibao Oriental (UTECO)"
                        },
                        new
                        {
                            Id = new Guid("a5a5a5d5-7aa5-45da-8ecf-315e157f6767"),
                            Name = "Universidad Tecnológica del Sur (UTESUR)"
                        });
                });

            modelBuilder.Entity("DataAccess.Models.CareersDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Careers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("5bbcb61d-2d3e-4373-8e0e-1c5d5fa66e98"),
                            Name = "Contabilidad"
                        },
                        new
                        {
                            Id = new Guid("4eb0384c-2a10-4d4b-9e14-b9a9d3b3c8f7"),
                            Name = "Técnico en Diseño Gráfico"
                        },
                        new
                        {
                            Id = new Guid("5f5d5e47-2363-40da-aaab-1de1568c356a"),
                            Name = "Técnico en Informática"
                        },
                        new
                        {
                            Id = new Guid("6f8f6e88-3c3f-45af-b1dc-8a0e84004e9f"),
                            Name = "Técnico Soporte Tecnologías"
                        },
                        new
                        {
                            Id = new Guid("61de9a34-6d43-424e-bc6a-f7a10438f1d2"),
                            Name = "Enfermería"
                        },
                        new
                        {
                            Id = new Guid("fbd0423b-0f51-46d8-bf3d-9dcdaa188a71"),
                            Name = "Ingeniería Civil"
                        },
                        new
                        {
                            Id = new Guid("38dd9b33-28d5-4f8a-91f1-1ef067cd98d8"),
                            Name = "Ingeniería Electromecánica"
                        },
                        new
                        {
                            Id = new Guid("09f9894e-9464-4f5c-9f47-92b14ff7032a"),
                            Name = "Ingeniería Electrónica"
                        },
                        new
                        {
                            Id = new Guid("64a39cc8-8d02-4cc9-9a2d-5b5e0970f58e"),
                            Name = "Ingeniería en Sistemas y Computación"
                        },
                        new
                        {
                            Id = new Guid("1d6f78a6-52d8-4de3-9b7a-33ecdf177c8d"),
                            Name = "Ingeniería Industrial"
                        },
                        new
                        {
                            Id = new Guid("a1fb2cb1-3a85-40a5-b75b-d3e736b820cc"),
                            Name = "Ingeniería Telemática"
                        },
                        new
                        {
                            Id = new Guid("5a5b10cc-5db5-4a52-bab9-f0765a5f5b2d"),
                            Name = "Licenciatura en Administración de Empresas"
                        },
                        new
                        {
                            Id = new Guid("c674d812-02a7-4163-88f3-789bf0d3e9c9"),
                            Name = "Licenciatura en Administración Hotelera"
                        },
                        new
                        {
                            Id = new Guid("6dd77a4a-4e0f-4a18-869d-cf6d89a463a8"),
                            Name = "Licenciatura en Educación Básica"
                        },
                        new
                        {
                            Id = new Guid("2f1e6c92-6a33-4a4b-82da-8a92e6d82b6f"),
                            Name = "Licenciatura en Educación Media"
                        },
                        new
                        {
                            Id = new Guid("aa58e11f-227f-4dc4-a3f3-6ee7d6d4ad6f"),
                            Name = "Licenciatura en Gestión Financiera y Auditoría"
                        },
                        new
                        {
                            Id = new Guid("a86a2cc3-3c36-456a-a8b6-7c1d078efeb5"),
                            Name = "Licenciatura en Mercadotecnia"
                        },
                        new
                        {
                            Id = new Guid("51859a38-18d5-4ea8-b2c2-3cc9fae0f8b1"),
                            Name = "Licenciatura en Psicología"
                        },
                        new
                        {
                            Id = new Guid("c5a174b8-04a7-4bdc-9d17-1a8e01cbe98c"),
                            Name = "Medicina"
                        },
                        new
                        {
                            Id = new Guid("a8226c15-c6d7-4f13-9e56-6e35b6f4c4ea"),
                            Name = "Administración de Empresas"
                        },
                        new
                        {
                            Id = new Guid("e8a1876c-34f5-4c39-a1ce-c8e179b7c0b9"),
                            Name = "Administración de Empresas Turísticas Hoteleras"
                        });
                });

            modelBuilder.Entity("DataAccess.Models.DocumentTypeDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("DocumentTypes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("5bbcb61d-2d3e-4373-8e0e-1c5d5fa66e98"),
                            Name = "Record de Notas"
                        },
                        new
                        {
                            Id = new Guid("b2c7d08b-4c3e-4d37-a8e7-c75f67c78dce"),
                            Name = "Carta de Grado"
                        },
                        new
                        {
                            Id = new Guid("1a06a139-0d0b-4c8d-99bb-b95c2f7d6e25"),
                            Name = "Titulo Original"
                        },
                        new
                        {
                            Id = new Guid("59dd09de-4437-4d31-8be7-3c2345a3a177"),
                            Name = "Copia de Titulo"
                        },
                        new
                        {
                            Id = new Guid("0d5a5f3b-83b8-4f1b-b41f-d7eb28d41cf8"),
                            Name = "Certificación de Titulo"
                        },
                        new
                        {
                            Id = new Guid("c80e6d64-d6f7-4641-a221-2af522f1e4a9"),
                            Name = "Rotación de Clínica"
                        },
                        new
                        {
                            Id = new Guid("f8b68a25-18d1-44c6-a33a-24c2d18f5d5f"),
                            Name = "Carta de Última Materia"
                        },
                        new
                        {
                            Id = new Guid("96b2a44d-9c9e-4c39-8ce6-0d0e58c61de1"),
                            Name = "Internado Rotatorio"
                        },
                        new
                        {
                            Id = new Guid("d5266e7f-9302-43a8-a22b-b5239f7c2dbf"),
                            Name = "Certificación de Programas de Estudios"
                        },
                        new
                        {
                            Id = new Guid("2c26f09d-0a2f-41e6-94c6-cd51b77e0e71"),
                            Name = "Certificación de Pensum"
                        },
                        new
                        {
                            Id = new Guid("2db49abf-1679-427e-a28a-5c19a33a5a4d"),
                            Name = "Calculo de Horas"
                        },
                        new
                        {
                            Id = new Guid("79e7d9d2-2aa7-4b34-9307-95a278c0ed24"),
                            Name = "Finalización de Estudios"
                        },
                        new
                        {
                            Id = new Guid("5d7048f1-7482-4269-bf17-bc6da8fb66ed"),
                            Name = "Certificación de Índice"
                        },
                        new
                        {
                            Id = new Guid("6b455a6b-f74d-455c-80a8-6b646931ca9f"),
                            Name = "Certificación de Estudios"
                        },
                        new
                        {
                            Id = new Guid("e2da1539-6989-4f81-8cd3-42cb3d3a3b1d"),
                            Name = "Certificación de Tesis"
                        },
                        new
                        {
                            Id = new Guid("e621cac7-7553-465d-87c1-9271f546af2d"),
                            Name = "Certificación De No Tesis"
                        },
                        new
                        {
                            Id = new Guid("82de1e7b-16f5-4d24-a9e5-4ed4ea4dfc8e"),
                            Name = "Constancia de Titulo"
                        },
                        new
                        {
                            Id = new Guid("e1673586-3db6-4613-82a3-8560d2597a9a"),
                            Name = "Revalida de Titulo"
                        },
                        new
                        {
                            Id = new Guid("99d83754-c764-47db-bb9c-7c2cb2dfc52d"),
                            Name = "Certificación de Personaduría Jurídica"
                        },
                        new
                        {
                            Id = new Guid("bd5f5c5e-4a2d-4c4c-bad9-fa7b0a30a8c7"),
                            Name = "Practicas Hospitalarias"
                        },
                        new
                        {
                            Id = new Guid("30c8fa7e-2dd1-4c5e-8928-5e3db9b3c3b5"),
                            Name = "Certificación de Constancia de Equivalencia"
                        },
                        new
                        {
                            Id = new Guid("11bc2d8e-59df-42e7-a7a8-79c0f455ca61"),
                            Name = "Certificación de Egresado"
                        });
                });

            modelBuilder.Entity("DataAccess.Models.LegalizationRequestDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AcademicInstitutionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("CareerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DocumentTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AcademicInstitutionId");

                    b.HasIndex("CareerId");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("LegalizationRequests");
                });

            modelBuilder.Entity("DataAccess.Models.PasswordChangeDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PasswordChanges");
                });

            modelBuilder.Entity("DataAccess.Models.RoleDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("RoleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3a1760d7-20a2-4a05-8939-497984e38cf4"),
                            Name = "Administrador",
                            RoleType = 0
                        },
                        new
                        {
                            Id = new Guid("b6c977e9-09da-4454-94b1-58c22a7da7ab"),
                            Name = "Student",
                            RoleType = 1
                        });
                });

            modelBuilder.Entity("DataAccess.Models.UserDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Addresss")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("IdentificationType")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataAccess.Models.LegalizationRequestDbModel", b =>
                {
                    b.HasOne("DataAccess.Models.AcademicInstitutionDbModel", "AcademicInstitution")
                        .WithMany()
                        .HasForeignKey("AcademicInstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.CareersDbModel", "Career")
                        .WithMany()
                        .HasForeignKey("CareerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.DocumentTypeDbModel", "DocumentType")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.UserDbModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicInstitution");

                    b.Navigation("Career");

                    b.Navigation("DocumentType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Models.PasswordChangeDbModel", b =>
                {
                    b.HasOne("DataAccess.Models.UserDbModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Models.UserDbModel", b =>
                {
                    b.HasOne("DataAccess.Models.RoleDbModel", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}