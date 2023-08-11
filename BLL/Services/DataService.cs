using BLL.DTO;
using DAL.Models;
using DAL.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DataService : IDataService
    {
        private readonly ILogger<AuthorizeService> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _options;
        private readonly ShortenerDbContext _context;
        public DataService(ShortenerDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration options, ILogger<AuthorizeService> logger)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _options = options;
            _logger = logger;
        }

        public async Task<List<URLsData>> GetAllUrls()
        {
            try
            {                
                var all_urls = _context.Urls.Select(t => new URLsData()
                {
                    Id = t.Id,
                    LongUrl = t.LongUrl,
                    ShortUrl = t.ShortUrl,
                    Creator = t.Creator,
                    DateTime = t.DateTime
                }).ToListAsync();
                _logger.LogInformation("Urls got at:" + DateTime.Now);
                return await all_urls;
            }
            catch
            (DbUpdateException ex)
            {
                _logger.LogError(ex, "Failed to get at:" + DateTime.Now);
                throw new Exception(ex.Message);
            }
        }

        public async Task SetURL(URL url)
        {
            try
            {
                var newUrl = new URLsModel()
                {
                    LongUrl = url.LongUrl,
                    ShortUrl = "Shorted Link",
                    //ShortUrl = url.ShortUrl,
                    Creator = url.Creator,
                    DateTime = ((DateTime)url.DateTime)
                };

                _context.Urls.Add(newUrl);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Url setted at:" + DateTime.Now);
            }
            catch
            (DbUpdateException ex)
            {
                _logger.LogError(ex, "Failed to set at:" + DateTime.Now);
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateURL(URLsData newUrl)
        {
            try
            {                
                var entity = await _context.Urls.FindAsync(newUrl.Id);
                if (entity != null)
                {
                    entity.LongUrl = newUrl.LongUrl;
                    entity.ShortUrl = "new url";
                    entity.Creator = newUrl.Creator;
                    entity.DateTime = (DateTime)newUrl.DateTime;
                }
                await _context.SaveChangesAsync();
                _logger.LogInformation("Url updated at:" + DateTime.Now);
            }
            catch
            (DbUpdateException ex)
            {
                _logger.LogError(ex, "Failed to updated at:" + DateTime.Now);
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteURL(int id)
        {
            try
            {
                var entity = await _context.Urls.FindAsync(id);
                if (entity != null)
                {
                    _context.Urls.Remove(entity);
                    await _context.SaveChangesAsync();
                }
                await _context.SaveChangesAsync();
                _logger.LogInformation("Task deleted at:" + DateTime.Now);
            }
            catch
            (DbUpdateException ex)
            {
                _logger.LogError(ex, "Failed to updated at:" + DateTime.Now);
                throw new Exception(ex.Message);
            }
        }

    }
}
