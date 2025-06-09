using Microsoft.EntityFrameworkCore;
using ServiSy_v1_Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiSy_v1_Data.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servico>()
                .HasOne(Servico => Servico.Prestador)
                .WithMany(Usuario => Usuario.Servicos)
                .HasForeignKey(Servico => Servico.Prestado_Id).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedback>()
                .HasOne(Feedback => Feedback.Servico)
                .WithMany(Servico => Servico.Feedbacks)
                .HasForeignKey(Feedback => Feedback.Servico_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedback>()
                .HasOne(Feedback => Feedback.Usuario)
                .WithMany()
                .HasForeignKey(Feedback => Feedback.Usuario_Id)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

    }
}
