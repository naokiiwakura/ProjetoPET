﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ProjetoPET.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20190628201810_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("IdentityUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("ProviderKey");

                    b.HasKey("UserId");

                    b.ToTable("IdentityUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId");

                    b.ToTable("IdentityUserTokens");
                });

            modelBuilder.Entity("ProjetoPET.Areas.Identity.Data.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int?>("EnderecoId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int?>("TipoUsuarioId");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("TipoUsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ProjetoPET.Models.Anuncio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnuncianteId");

                    b.Property<string>("CorpoAnuncio");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("EnderecoId");

                    b.Property<string>("Foto");

                    b.Property<int>("PetId");

                    b.Property<int>("TipoAnuncioId");

                    b.Property<string>("Titulo");

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.HasIndex("AnuncianteId");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("PetId");

                    b.HasIndex("TipoAnuncioId");

                    b.ToTable("Anuncio");
                });

            modelBuilder.Entity("ProjetoPET.Models.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("EstadoId");

                    b.Property<string>("Nome");

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("ProjetoPET.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro");

                    b.Property<string>("Cep");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("Numero");

                    b.Property<string>("Rua");

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("ProjetoPET.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Nome");

                    b.Property<string>("Sigla");

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("ProjetoPET.Models.Eventos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro");

                    b.Property<string>("CEP");

                    b.Property<string>("Cidade");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DataHora");

                    b.Property<string>("Descricao");

                    b.Property<string>("Estado");

                    b.Property<string>("Nome");

                    b.Property<int>("Numero");

                    b.Property<string>("Rua");

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("ProjetoPET.Models.Lojas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro");

                    b.Property<int>("CEP");

                    b.Property<int>("CNPj");

                    b.Property<int>("CidadeId");

                    b.Property<string>("Complemento");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("Endereco");

                    b.Property<string>("ImagePath");

                    b.Property<string>("NomeLoja");

                    b.Property<int>("Numero");

                    b.Property<string>("RazaoSocial");

                    b.Property<int>("Telefone");

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.ToTable("Lojas");
                });

            modelBuilder.Entity("ProjetoPET.Models.Pet", b =>
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
                        .HasMaxLength(1);

                    b.Property<string>("Telefone");

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("ProjetoPET.Models.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnuncioId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Numero");

                    b.Property<int?>("TipoId");

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.HasIndex("AnuncioId");

                    b.HasIndex("TipoId");

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("ProjetoPET.Models.TipoAnuncio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Descricao");

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.ToTable("TipoAnuncio");
                });

            modelBuilder.Entity("ProjetoPET.Models.TipoTelefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Descricao");

                    b.Property<DateTime?>("UpdatedData");

                    b.HasKey("Id");

                    b.ToTable("TipoTelefone");
                });

            modelBuilder.Entity("ProjetoPET.Models.TipoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Descricao");

                    b.Property<int>("TipoUsuarioId");

                    b.Property<DateTime?>("UpdatedData");

                    b.Property<int>("UsuarioId");

                    b.Property<string>("UsuarioId1");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId1");

                    b.ToTable("UsuarioBusiness");
                });

            modelBuilder.Entity("ProjetoPET.Areas.Identity.Data.Usuario", b =>
                {
                    b.HasOne("ProjetoPET.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.HasOne("ProjetoPET.Models.TipoUsuario")
                        .WithMany("Usuarios")
                        .HasForeignKey("TipoUsuarioId");
                });

            modelBuilder.Entity("ProjetoPET.Models.Anuncio", b =>
                {
                    b.HasOne("ProjetoPET.Areas.Identity.Data.Usuario", "Anunciante")
                        .WithMany()
                        .HasForeignKey("AnuncianteId");

                    b.HasOne("ProjetoPET.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjetoPET.Models.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjetoPET.Models.TipoAnuncio", "TipoAnuncio")
                        .WithMany()
                        .HasForeignKey("TipoAnuncioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoPET.Models.Cidade", b =>
                {
                    b.HasOne("ProjetoPET.Models.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("EstadoId");
                });

            modelBuilder.Entity("ProjetoPET.Models.Lojas", b =>
                {
                    b.HasOne("ProjetoPET.Models.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoPET.Models.Telefone", b =>
                {
                    b.HasOne("ProjetoPET.Models.Anuncio")
                        .WithMany("Telefones")
                        .HasForeignKey("AnuncioId");

                    b.HasOne("ProjetoPET.Models.TipoTelefone", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoId");
                });

            modelBuilder.Entity("ProjetoPET.Models.TipoUsuario", b =>
                {
                    b.HasOne("ProjetoPET.Areas.Identity.Data.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId1");
                });
#pragma warning restore 612, 618
        }
    }
}