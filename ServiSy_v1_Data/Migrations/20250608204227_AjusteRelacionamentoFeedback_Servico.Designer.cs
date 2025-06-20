﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiSy_v1_Data.Context;

#nullable disable

namespace ServiSy_v1_Data.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20250608204227_AjusteRelacionamentoFeedback_Servico")]
    partial class AjusteRelacionamentoFeedback_Servico
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ServiSy_v1_Business.Models.Feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Comentario")
                        .HasColumnType("longtext");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.Property<Guid>("Servico_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Usuario_Id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("Servico_Id");

                    b.HasIndex("Usuario_Id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("ServiSy_v1_Business.Models.Servico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("Prestado_Id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("Prestado_Id");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("ServiSy_v1_Business.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Prestador")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ServiSy_v1_Business.Models.Feedback", b =>
                {
                    b.HasOne("ServiSy_v1_Business.Models.Servico", "Servico")
                        .WithMany("Feedbacks")
                        .HasForeignKey("Servico_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ServiSy_v1_Business.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("Usuario_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Servico");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ServiSy_v1_Business.Models.Servico", b =>
                {
                    b.HasOne("ServiSy_v1_Business.Models.Usuario", "Prestador")
                        .WithMany("Servicos")
                        .HasForeignKey("Prestado_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Prestador");
                });

            modelBuilder.Entity("ServiSy_v1_Business.Models.Servico", b =>
                {
                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("ServiSy_v1_Business.Models.Usuario", b =>
                {
                    b.Navigation("Servicos");
                });
#pragma warning restore 612, 618
        }
    }
}
