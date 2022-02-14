using BusinessLogic.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly MarketDbContext _context;
        public ProductoRepository(MarketDbContext context)
        {
            _context = context;
        }
        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            return await _context.Productos //.FindAsync(id)
                .Include(p => p.Marca)
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Producto>> GetProductosAsync()
        {
            return await _context.Productos    ///.ToListAsync();
                .Include(p => p.Marca)
                .Include(p => p.Categoria)
                .ToListAsync();
        }
    }
}
