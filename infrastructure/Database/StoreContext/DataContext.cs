using core.Entities;
using core.Entities.Model;
using Microsoft.EntityFrameworkCore;


namespace infrastructure.Database.StoreContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options) {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<Project>()
            //     .HasOne(project => project.Category)
            //     .WithMany(category => category.Projects)
            //     .HasForeignKey(categoryId => categoryId.CategoryId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<AffiliatedAgency>()
            //     .HasMany(project => project.Projects)
            //     .WithMany(aff => aff.AffiliatedAgencies);
            

            // modelBuilder.Entity<Product>()
            //     .HasOne( user => user.Ownner)
            //     .WithMany( product => product.Product)
            //     .HasForeignKey( product => product.OwnnerId)
            //     .OnDelete( DeleteBehavior.Cascade);
            
            //  modelBuilder.Entity<Product>()
            //     .HasOne(user => user.Type)
            //     .WithMany(product => product.Product)
            //     .HasForeignKey(product => product.TypeId)
            //     .OnDelete( DeleteBehavior.Cascade);
            
            
            // modelBuilder.Entity<Photo>()
            //     .HasOne( product => product.Product)
            //     .WithMany( picture => picture.Photos)
            //     .HasForeignKey( product => product.ProductId)
            //     .OnDelete(DeleteBehavior.Cascade); 


            // modelBuilder.Entity<ProductBid>()
            //     .HasOne( product => product.Product)
            //     .WithMany( bid => bid.Biddings)
            //     .HasForeignKey ( bit => bit.ProductId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<ProductBid>()
            //     .HasOne(bid => bid.User)
            //     .WithMany( user => user.Biddings)
            //     .HasForeignKey( key => key.UserId)
            //     .OnDelete(DeleteBehavior.Cascade);
                

            // modelBuilder.Entity<Message>()
            //     .HasOne( user => user.ReceiverUser)
            //     .WithMany( message => message.Messages)
            //     .HasForeignKey( key => key.ReceiverId)
            //     .OnDelete(DeleteBehavior.Cascade);
        

            // modelBuilder.Entity<UserRatting>()
            //     .HasOne(seller => seller.Seller)
            //     .WithMany(Ratting => Ratting.Rattings)
            //     .HasForeignKey(key => key.SellerId)
            //   .OnDelete(DeleteBehavior.Cascade);          
        }
        public DbSet<Project> Projects {get;set;}
        public DbSet<Proposals> Proposals {get;set;}
        public DbSet<Agency> Agencies{get;set;}
        public DbSet<Citizen> Citizens {get;set;}
        public DbSet<ProjectRatting> Rattings {get;set;}

    }
}