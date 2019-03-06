namespace KitchenInstallation.Business.KitchenManagement
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Contracts;
    using Entities.Details;
    using Infrastructure.Azure;
    using Interfaces.Business.KitchenManagement;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class TabletopManager: ITabletopManager
    {
        private readonly DbContext _context;

        private readonly DbSet<Tabletop> _tabletops;

        public TabletopManager(ApplicationContext applicationContext)
        {
            _context = applicationContext;
            _tabletops = applicationContext.Tabletops;
        }

        public int Create(string json)
        {
            var tabletop = JsonConvert.DeserializeObject<Tabletop>(json);

            _tabletops.Add(tabletop);
            return _context.SaveChanges();
        }

        public async Task<IEnumerable<Tabletop>> GetAll()
        {
            return await _tabletops.ToListAsync();
        }

        public async Task<Tabletop> GetById(int id)
        {
            return await _tabletops.FindAsync(id);
        }

        public async Task<OperationResult> Delete(int id)
        {
            var tabletop = await GetById(id);
            if (tabletop == null)
            {
                return OperationResult.NotFound;
            }

            _tabletops.Remove(tabletop);
            _context.SaveChanges();
            return OperationResult.Deleted;
        }
    }
}
