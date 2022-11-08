using Microsoft.EntityFrameworkCore;

namespace PieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly PieShopDbContext _dbContext;

        public PieRepository(PieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get { return _dbContext.Pies.Include(c=>c.Category); }
        }


        public IEnumerable<Pie> PiesOfTheWeek
        {
            get { return _dbContext.Pies.Include(c => c.Category).Where(c=>c.IsPieOfTheWeek); }
        }

        public Pie? GetPieById(int pieId)
        {
            return _dbContext.Pies.FirstOrDefault(c => c.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _dbContext.Pies.Where(p => p.Name.Contains(searchQuery));
        }
    }
}
