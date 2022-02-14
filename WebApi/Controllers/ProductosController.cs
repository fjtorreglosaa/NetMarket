using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductosController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        //http://localhost:51071/ EndPoint para obtener toda la lista de productos
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            var productos = await _productoRepository.GetProductosAsync();
            return Ok(productos); //Cada vez que se retorna una coleccion de objetos de tipo readonly, el resultado devuelto debe estar rodeado de un Ok
        }
        //http://localhost:51071/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            return await _productoRepository.GetProductoByIdAsync(id); //Como devuelve un solo dato no es necesario envolvero dentro de un ok
        }
    }
}
