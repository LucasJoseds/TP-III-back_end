using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pedidos_back_end.Model;

namespace pedidos_back_end.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cardapio> Cardapios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<ItemPedido> ItensPedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define a sequência compartilhada
            modelBuilder.HasSequence<int>("minha_sequencia", schema: "public")
                .StartsAt(1)
                .IncrementsBy(1);


            // Configura auto incremento para todas as classes que possuem propriedade 'Id'
            var entityTypes = modelBuilder.Model.GetEntityTypes();
            foreach (var entityType in entityTypes)
            {
                var idProperty = entityType.FindProperty("Id");
                if (idProperty != null && idProperty.ClrType == typeof(int))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property<int>("Id")
                        .HasDefaultValueSql("nextval('public.minha_sequencia')");
                }
            }

            modelBuilder.Entity<Pedido>()
        .Property(e => e.Status)
        .HasConversion(
            v => v.ToString(), // Converter enum para string
            v => (StatusPedido)Enum.Parse(typeof(StatusPedido), v));
        }

    }
}