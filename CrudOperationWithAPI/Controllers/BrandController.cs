using CrudOperationWithAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationWithAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public BrandController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            if(dbContext.Brands == null)
            {
                return NotFound();
            }
            return await dbContext.Brands.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrands(int id)
        {
            var data = await dbContext.Brands.FindAsync(id);

            if(data == null)
            {
                return NotFound();
            }
            return data;
        }

        [HttpPost]
        public async Task<ActionResult<Brand>> CreateBrands(Brand brand)
        {
            if (brand == null)
            {
                return NotFound();
            }
            await dbContext.Brands.AddAsync(brand);
            await dbContext.SaveChangesAsync();
            return Ok(brand);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Brand>> UpdateBrands(int id, Brand brand)
        {
            if(id != brand.ID)
            {
                return BadRequest();
            }
            dbContext.Entry(brand).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return Ok(brand);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Brand>> DeleteBrands(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var data = await dbContext.Brands.FindAsync(id);
            if(data == null)
            {
                return BadRequest();
            }
            dbContext.Brands.Remove(data);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
