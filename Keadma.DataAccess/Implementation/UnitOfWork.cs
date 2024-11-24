
using Keadma.DataAccess.Data;
using Khedma.Entites.Models;
using Khedma.Entites.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keadma.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IMakhdoumReposiotry Makhdoum { get; private set; }
        public IKoralReposiotry Koral { get; private set; }
        public ITheStageReposiotry TheStage { get; private set; }
        public IAlhanReposiotry Alhan { get; private set; }
        public ILearningReposiotry Learning { get; private set; }
        public ICopticReposiotry Coptic { get; private set; }
        public ITheaterReposiotry Theater { get; private set; }
        public IBooksAndSavesReposiotry BooksAndSaves { get; private set; }
        public IForSingleRepository ForSingle { get; private set; }
        public IArtsReposiotry Arts { get; private set; }
        public IArtsNameReposiotry ArtsName { get; private set; }
        public IForSingleNameReposiotry ForSingleName { get; private set; }
        public IUserReposiotry User { get; private set; }
        public IRoleReposiotry Role { get; private set; }
        public IUserRoleReposiotry UserRole { get; private set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Makhdoum = new MakhdoumReposiotry(context);
            Koral = new KoralReposiotry(context);
            TheStage= new TheStageReposiotry(context);
            Alhan = new AlhanReposiotry(context);
            Learning = new LearningReposiotry(context);
            Coptic = new CopticReposiotry(context);
            Theater=new TheaterReposiotry(context);
            BooksAndSaves = new BooksAndSavesReposiotry(context);
            ForSingle= new ForSingleRepository(context);
            Arts = new ArtsReposiotry(context);
            ArtsName= new ArtsNameReposiotry(context);
            ForSingleName= new ForSingleNameReposiotry(context);
            User= new UserReposiotry(context);
            Role = new RoleReposiotry(context);
            UserRole = new UserRoleReposiotry(context);
        }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
