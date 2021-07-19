using EFCore.WebAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Data
{
    // Scaffold - precisamos passar alguns parãmentros durante a criação de um projeto EFCore DB First
    // scaffold-dbcontext -provider microsoft.entityframeworkcore.sqlserver -connection ""

    // para rodarmos esse comando em uma consoleapp precisaremos rodar  install-package entityframeworkcore.design

    public class HeroiContext : DbContext
    {
        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<HeroiBatalha> HeroisBatalhas { get; set; }
        public DbSet<identidadeSecreta> IdentidadesSecretas { get; set; }

        // o contexto é responsável por criar as tabelas no nosso banco de dados quando temos classes e utilizamos code-first
        // As propriedades precisam estar no plural por ser um elemento List que contém N elementos.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HeroApp;Data Source=DESKTOP-FKC65HE");
            // Catalog é o nome do banco de dados
        }

        /* Tivemos um erro na criação da tabela de HeroiBatalha, o contexto não identifica sozinho que se trata de uma chave composta e cobra a
        especificação de uma chave primária, então faremos o override abaixo. */

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<HeroiBatalha>(entity => 
            {
                entity.HasKey(e => new { e.BatalhaId, e.HeroiId });
                // usamos uma lambda expression declarando um objeto anônimo e em seguida especificamos a nossa chave composta
            });
        }
    }
}
