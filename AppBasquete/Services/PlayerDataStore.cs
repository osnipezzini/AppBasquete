using AppBasquete.Data;
using AppBasquete.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBasquete.Services
{
    class PlayerDataStore : IDataStore<Player>
    {
        AppDbContext context;
        public PlayerDataStore()
        {
            context = new AppDbContext();
        }
        /// <summary>
        /// Insert a player in database.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> AddItemAsync(Player item)
        {
            context.Players.Add(item);
            return await context.SaveChangesAsync() > 0;
        }
        /// <summary>
        /// Remove a player from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteItemAsync(string id)
        {
            var player = await context.Players.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (player == null)
                throw new Exception("Player not found");
            context.Players.Remove(player);
            return await context.SaveChangesAsync() > 0;
        }
        /// <summary>
        /// Get a player from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Player> GetItemAsync(string id)
        {
            return await context.Players.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        /// <summary>
        /// Get all players from database.
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Player>> GetItemsAsync(bool forceRefresh = false)
        {
            return await context.Players.ToListAsync();
        }
        /// <summary>
        /// Check if player exists in database.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> ItemExistsAsync(Player item)
        {
            return await context.Players.Where(x => x.Id == item.Id).AnyAsync();
        }
        /// <summary>
        /// Update a player in database.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> UpdateItemAsync(Player item)
        {
            context.Players.Update(item);
            return await context.SaveChangesAsync() > 0;
        }
    }
}
