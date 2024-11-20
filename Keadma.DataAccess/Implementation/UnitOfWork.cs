
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
        //public ICategoryRepository Category { get; private set; }
        public IMakhdoumReposiotry Makhdoum { get; private set; }
        public IKoralReposiotry Koral { get; private set; }
        public ITheStageReposiotry TheStage { get; private set; }
        public IAlhanReposiotry Alhan { get; private set; }
        public ILearningReposiotry Learning { get; }
        public ICopticReposiotry Coptic { get; }
        public ITheaterReposiotry Theater { get; }
        public IBooksAndSavesReposiotry BooksAndSaves { get; }
        public IForSingleRepository ForSingle { get; }


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
