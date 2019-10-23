﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Model.Anuncio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnuncianteId");

                    b.Property<string>("AnuncianteId1");

                    b.Property<int>("CidadeId");

                    b.Property<string>("CorpoAnuncio");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("EnderecoId");

                    b.Property<string>("Foto");

                    b.Property<int>("PetId");

                    b.Property<int>("TipoAnuncioId");

                    b.Property<string>("Titulo")
                        .IsRequired();

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.HasIndex("AnuncianteId1");

                    b.HasIndex("CidadeId");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("PetId");

                    b.HasIndex("TipoAnuncioId");

                    b.ToTable("Anuncios");
                });

            modelBuilder.Entity("Domain.Model.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("EstadoId");

                    b.Property<string>("Nome");

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("Domain.Model.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro");

                    b.Property<string>("Cep")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("Numero");

                    b.Property<string>("Rua")
                        .IsRequired();

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Domain.Model.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("Domain.Model.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CidadeId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DataHoraFim");

                    b.Property<DateTime>("DataHoraInicio");

                    b.Property<string>("Descricao");

                    b.Property<int>("EnderecoId");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("Domain.Model.Loja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CNPJ");

                    b.Property<int>("CidadeId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<int>("EnderecoId");

                    b.Property<string>("ImagePath");

                    b.Property<string>("NomeFantasia")
                        .IsRequired();

                    b.Property<string>("RazaoSocial");

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Lojas");
                });

            modelBuilder.Entity("Domain.Model.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Descricao");

                    b.Property<int>("Idade");

                    b.Property<string>("Nome");

                    b.Property<string>("Raca");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasMaxLength(1);

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("Domain.Model.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnuncioId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("EventoId");

                    b.Property<int>("LojaId");

                    b.Property<string>("Numero");

                    b.Property<int>("TipoTelefoneId");

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.HasIndex("AnuncioId");

                    b.HasIndex("EventoId");

                    b.HasIndex("LojaId");

                    b.HasIndex("TipoTelefoneId");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("Domain.Model.TipoAnuncio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Descricao");

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.ToTable("TipoAnuncios");
                });

            modelBuilder.Entity("Domain.Model.TipoTelefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Descricao");

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.ToTable("TipoTelefones");
                });

            modelBuilder.Entity("Domain.Model.TipoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Descricao");

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.ToTable("TipoUsuarios");
                });

            modelBuilder.Entity("Domain.Model.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("CPF");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int?>("EnderecoId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nome");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("TipoUsuarioId");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("TipoUsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Domain.Model.Anuncio", b =>
                {
                    b.HasOne("Domain.Model.Usuario", "Anunciante")
                        .WithMany("Anuncios")
                        .HasForeignKey("AnuncianteId1");

                    b.HasOne("Domain.Model.Cidade", "Cidade")
                        .WithMany("Anuncios")
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Model.Endereco", "Endereco")
                        .WithMany("Anuncios")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Model.Pet", "Pet")
                        .WithMany("Anuncios")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Model.TipoAnuncio", "TipoAnuncio")
                        .WithMany("Anuncios")
                        .HasForeignKey("TipoAnuncioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Model.Cidade", b =>
                {
                    b.HasOne("Domain.Model.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Model.Evento", b =>
                {
                    b.HasOne("Domain.Model.Cidade", "Cidade")
                        .WithMany("Eventos")
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Model.Endereco", "Endereco")
                        .WithMany("Eventos")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Model.Loja", b =>
                {
                    b.HasOne("Domain.Model.Cidade", "Cidade")
                        .WithMany("Lojas")
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Model.Endereco", "Endereco")
                        .WithMany("Lojas")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Model.Telefone", b =>
                {
                    b.HasOne("Domain.Model.Anuncio", "Anuncio")
                        .WithMany("Telefones")
                        .HasForeignKey("AnuncioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Model.Evento", "Evento")
                        .WithMany("Telefones")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Model.Loja", "Loja")
                        .WithMany("Telefones")
                        .HasForeignKey("LojaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Model.TipoTelefone", "TipoTelefone")
                        .WithMany("Telefones")
                        .HasForeignKey("TipoTelefoneId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Model.Usuario", b =>
                {
                    b.HasOne("Domain.Model.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.HasOne("Domain.Model.TipoUsuario", "TipoUsuario")
                        .WithMany("Usuarios")
                        .HasForeignKey("TipoUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
