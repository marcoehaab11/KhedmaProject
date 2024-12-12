
using Khedma.Entites.Models;
using Microsoft.EntityFrameworkCore;



namespace Keadma.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             
            modelBuilder.Entity<Koral>()
                .HasKey(k => new { k.MakhdoumID, k.StageID });
            modelBuilder.Entity<UserRole>()
              .HasKey(k => new { k.Id });

            modelBuilder.Entity<UserRole>()
              .HasOne(k => k.TBRole)  
              .WithMany(m => m.TBuserRoles)  
              .HasForeignKey(k => k.RoleId);  
            modelBuilder.Entity<UserRole>()
              .HasOne(k => k.TBUser)  
              .WithMany(m => m.TBuserRoles)  
              .HasForeignKey(k => k.UserId);  
             
            modelBuilder.Entity<Koral>()
                .HasOne(k => k.Makhdoum)  
                .WithMany(m => m.TbKoral)  
                .HasForeignKey(k => k.MakhdoumID);  

           
            modelBuilder.Entity<Koral>()
                .HasOne(k => k.TheStage) 
                .WithMany(s => s.TbKoral) 
                .HasForeignKey(k => k.StageID); 


            modelBuilder.Entity<Alhan>()
            .HasKey(k => new { k.MakhdoumID, k.StageID });

             
            modelBuilder.Entity<Alhan>()
                .HasOne(k => k.Makhdoum)  
                .WithMany(m => m.TbAlhan)  
                .HasForeignKey(k => k.MakhdoumID);  

            // إعداد العلاقة بين Koral و TheStage
            modelBuilder.Entity<Alhan>()
                .HasOne(k => k.TheStage) // Koral لديه Stage واحد
                .WithMany(s => s.TbAlhan) // Stage لديه العديد من Koral
                .HasForeignKey(k => k.StageID); // المفتاح الخارجي هو StageID
            //learning
            modelBuilder.Entity<Learning>()
         .HasKey(k => new { k.MakhdoumID, k.StageID });

             
            modelBuilder.Entity<Learning>()
                .HasOne(k => k.Makhdoum)  
                .WithMany(m => m.TBLearning)  
                .HasForeignKey(k => k.MakhdoumID); 

            // إعداد العلاقة بين Koral و TheStage
            modelBuilder.Entity<Learning>()
                .HasOne(k => k.TheStage) // Koral لديه Stage واحد
                .WithMany(s => s.TBLearning) // Stage لديه العديد من Koral
                .HasForeignKey(k => k.StageID); // المفتاح الخارجي هو StageID
            //coptic
            modelBuilder.Entity<Coptic>()
      .HasKey(k => new { k.MakhdoumID, k.StageID });

             
            modelBuilder.Entity<Coptic>()
                .HasOne(k => k.Makhdoum)  
                .WithMany(m => m.TBCoptic)  
                .HasForeignKey(k => k.MakhdoumID);  

            // إعداد العلاقة بين Koral و TheStage
            modelBuilder.Entity<Coptic>()
                .HasOne(k => k.TheStage) // Koral لديه Stage واحد
                .WithMany(s => s.TBCoptic) // Stage لديه العديد من Koral
                .HasForeignKey(k => k.StageID); // المفتاح الخارجي هو StageID

            //therad

            modelBuilder.Entity<Theater>()
            .HasKey(k => new { k.MakhdoumID, k.StageID ,k.RoleID});

             
            modelBuilder.Entity<Theater>()
                .HasOne(k => k.Makhdoum)  
                .WithMany(m => m.TBTheater)  
                .HasForeignKey(k => k.MakhdoumID);

            modelBuilder.Entity<Theater>()
           .HasOne(k => k.TheaterRole)
           .WithMany(m => m.TBTheaters)
           .HasForeignKey(k => k.RoleID);
            // إعداد العلاقة بين Koral و TheStage
            modelBuilder.Entity<Theater>()
                .HasOne(k => k.TheStage) // Koral لديه Stage واحد
                .WithMany(s => s.TBTheater) // Stage لديه العديد من Koral
                .HasForeignKey(k => k.StageID); // المفتاح الخارجي هو StageID


            //book
            modelBuilder.Entity<BooksAndSaves>()
           .HasKey(k => new { k.MakhdoumID, k.StageID });

             
            modelBuilder.Entity<BooksAndSaves>()
                .HasOne(k => k.Makhdoum)  
                .WithMany(m => m.TBBooksAndSaves)  
                .HasForeignKey(k => k.MakhdoumID);  

            // إعداد العلاقة بين Koral و TheStage
            modelBuilder.Entity<BooksAndSaves>()
                .HasOne(k => k.TheStage) // Koral لديه Stage واحد
                .WithMany(s => s.TBBooksAndSaves) // Stage لديه العديد من Koral
                .HasForeignKey(k => k.StageID); // المفتاح الخارجي هو StageID

          modelBuilder.Entity<ForSingle>()
        .HasKey(k => new { k.MakhdoumID, k.StageID });

             
            modelBuilder.Entity<ForSingle>()
                .HasOne(k => k.Makhdoum)  
                .WithMany(m => m.TBForSingle)  
                .HasForeignKey(k => k.MakhdoumID);  

            // إعداد العلاقة بين Koral و TheStage
            modelBuilder.Entity<ForSingle>()
                .HasOne(k => k.TheStage) // Koral لديه Stage واحد
                .WithMany(s => s.TBForSingle) // Stage لديه العديد من Koral
                .HasForeignKey(k => k.StageID); // المفتاح الخارجي هو StageID
            modelBuilder.Entity<ForSingle>()
                .HasOne(k => k.ForSingleName) // Koral لديه Stage واحد
                .WithMany(s => s.TBForSingle) // Stage لديه العديد من Koral
                .HasForeignKey(k => k.SingleNameId);

            modelBuilder.Entity<Arts>()
      .HasKey(k => new { k.MakhdoumID, k.StageID,k.ArtID ,k.InGroup});

             
            modelBuilder.Entity<Arts>()
                .HasOne(k => k.Makhdoum)  
                .WithMany(m => m.TBArts)  
                .HasForeignKey(k => k.MakhdoumID);  

            // إعداد العلاقة بين Koral و TheStage
            modelBuilder.Entity<Arts>()
                .HasOne(k => k.TheStage) // Koral لديه Stage واحد
                .WithMany(s => s.TBArts) // Stage لديه العديد من Koral
                .HasForeignKey(k => k.StageID); // المفتاح الخارجي هو StageID
            modelBuilder.Entity<Arts>()
               .HasOne(k => k.ArtsName) // Koral لديه Stage واحد
               .WithMany(s => s.TBArts) // Stage لديه العديد من Koral
               .HasForeignKey(k => k.ArtID); // المفتاح الخارجي هو StageID.



            modelBuilder.Entity<ArtsName>()
      .HasKey(k => new {  k.Id });
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(200);

        }
        DbSet<Koral> Tbkoral { get; set; }
        DbSet<Makhdoum> TBMakhdoum { get; set; }
        DbSet<TheStage> TBTheStage { get; set; }
        DbSet<ArtsName> TBArtsName{ get; set; }
        DbSet<ForSingleName> TBForSingleName { get; set; }

        DbSet<User> TBUser { get; set; }
        DbSet<Role> TBRole { get; set; }
    }
    

}
