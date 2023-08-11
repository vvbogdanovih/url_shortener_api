using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace url_shortener_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly ILogger<DataController> _logger;

        public DataController(ILogger<DataController> logger, IDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        [HttpGet("GetAllUrls")]
        public async Task<IActionResult> GetAllUrls()
        {
            return Ok(await _dataService.GetAllUrls());
        }

        [HttpPost("SetUrl")]
        public async Task<IActionResult> SetURL([FromBody] URL paramUser)
        {            
            await _dataService.SetURL(paramUser);
            return Ok();
        }

        [HttpPost("UpdateUrl")]
        public async Task<IActionResult> UpdateURL([FromBody] URLsData newUrl)
        {
            await _dataService.UpdateURL(newUrl);
            return Ok();
        }

        [HttpPost("DeleteUrl")]
        public async Task<IActionResult> DeleteURL([FromBody]  int id)
        {
            await _dataService.DeleteURL(id);
            return Ok();
        }

    }
}
