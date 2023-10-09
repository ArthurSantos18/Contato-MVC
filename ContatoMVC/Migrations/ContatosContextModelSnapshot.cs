﻿// <auto-generated />
using ContatosMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContatosMVC.Migrations
{
    [DbContext(typeof(ContatoContext))]
    partial class ContatosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ContatosMVC.Models.ContatoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.ToTable("contatos", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}