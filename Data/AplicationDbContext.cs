using couvre_plancher.Models;
namespace couvre_plancher.Data;
using Microsoft.EntityFrameworkCore;
public class AplicationDbContext : DbContext
{
    public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
    {
    }

    public DbSet<SuperviseurModel> Superviseur { get; set; }
    public DbSet<ClientModel> Client { get; set; }
    public DbSet<CommandeModel> Commande { get; set; }
    public DbSet<PackModel> Pack { get; set; }
    public DbSet<PromotionModel> Promotion { get; set; }
    public DbSet<CouvreplancherModel> Couvreplancher { get; set; }
  
}