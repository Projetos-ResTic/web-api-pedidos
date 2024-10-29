using Microsoft.EntityFrameworkCore;
using WebApiPedidos.Models;
using WebApiPedidos.Models.WebApiPedidos.Models;

namespace WebApiPedidos.Data
{
    public class AppDbContext: DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<StatusPedidoModel> StatusPedido { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<TipoProdutoModel> TipoProduto { get; set;}
        public DbSet<ProdutoModel> Produtos { get;set; }
        public DbSet<ItemPedidoModel> ItensPedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura chave composta
            modelBuilder.Entity<ItemPedidoModel>()
                .HasKey(ip => new { ip.ProdutoId, ip.PedidoId });

            // Configura relacionamentos
            modelBuilder.Entity<ItemPedidoModel>()
                .HasOne(ip => ip.Produto)
                .WithMany(p => p.ItemsPedido)
                .HasForeignKey(ip => ip.ProdutoId);

            modelBuilder.Entity<ItemPedidoModel>()
                .HasOne(ip => ip.Pedido)
                .WithMany(p => p.ItemsPedido)
                .HasForeignKey(ip => ip.PedidoId);

            // Configuração do relacionamento entre ProdutoModel e TipoProdutoModel
            modelBuilder.Entity<ProdutoModel>()
                .HasOne(p => p.Tipo)
                .WithMany(tp => tp.Produtos)
                .HasForeignKey(p => p.TipoId);

            base.OnModelCreating(modelBuilder);
        }
    }

}

