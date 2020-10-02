using AppBasquete.Data;
using AppBasquete.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBasquete.Services
{
    class DbDataStore : IDataStore<Item>
    {
        AppDbContext context;
        public DbDataStore()
        {
            context = new AppDbContext();
        }
        public async Task<bool> AddItemAsync(Item item)
        {
            context.Items.Add(item);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var item = context.Items.Find(id);
            if (item != null)
            {
                context.Items.Remove(item);
                
            }
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<Item> GetItemAsync(string id)
        {
            var item = await context.Items.FindAsync(id);
            return item;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await context.Items.ToListAsync();
        }

        public async Task<bool> ItemExistsAsync(Item item)
        {
            return await context.Items.Where(x => x.Id == item.Id).AnyAsync();
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            if (item != null)
            {
                context.Items.Update(item);

            }
            return await context.SaveChangesAsync() > 0;
        }
    }
}
