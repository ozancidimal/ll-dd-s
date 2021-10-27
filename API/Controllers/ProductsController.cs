using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _storecontext;
        public ProductsController(StoreContext storecontext)
        {
            _storecontext = storecontext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            var product = await _storecontext.ProDucts.ToListAsync();
            return Ok(product);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id){

            return await _storecontext.ProDucts.FindAsync(id);
        }
    }
}