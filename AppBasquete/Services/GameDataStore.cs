using AppBasquete.Data;
using AppBasquete.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBasquete.Services
{
    class GameDataStore : IDataStore<Game>
    {
        AppDbContext context;
        public GameDataStore()
        {
            context = new AppDbContext();
        }
        public async Task<bool> AddItemAsync(Game item)
        {
            context.Games.Add(item);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var item = await context.Games.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (item != null)
            {
                context.Games.Remove(item);
            }
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<Game> GetItemAsync(string id)
        {
            return await context.Games.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Game>> GetItemsAsync(bool forceRefresh = false)
        {
            return await context.Games.ToListAsync();
        }

        public async Task<bool> ItemExistsAsync(Game item)
        {
            return await context.Games.Where(x => x.Id == item.Id).AnyAsync();
        }

        public async Task<bool> UpdateItemAsync(Game item)
        {
            context.Games.Update(item);
            return await context.SaveChangesAsync() > 0;
        }
    }
}
