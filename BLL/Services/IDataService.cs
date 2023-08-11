using BLL.DTO;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IDataService
    {
        public Task<List<URLsData>> GetAllUrls();
        public Task SetURL(URL url);
        public Task UpdateURL(URLsData newUrl);
        public Task DeleteURL(int id);
    }
}
