using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Core.Entities;

namespace BusinessLogic.Data
{
    public class MarketDbContextData
    {
        public static async Task CargarDataAsync(MarketDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Marca.Any())
                {
                    var marcaData = File.ReadAllText("../BusinessLogic/CargarData/marca.json");
                    var marcas = JsonSerializer.Deserialize<List<Marca>>(marcaData);

                    foreach (var marca in marcas)
                    {
                        context.Marca.Add(marca);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Categorias.Any())
                {
                    var categoriasData = File.ReadAllText("../BusinessLogic/CargarData/categoria.json");
                    var categorias = JsonSerializer.Deserialize<List<Categoria>>(categoriasData);

                    foreach (var categoria in categorias)
                    {
                        context.Categorias.Add(categoria);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Productos.Any())
                {
                    var productosData = File.ReadAllText("../BusinessLogic/CargarData/producto.json");
                    var productos = JsonSerializer.Deserialize<List<Producto>>(productosData);

                    foreach (var producto in productos)
                    {
                        context.Productos.Add(producto);
                    }

                    await context.SaveChangesAsync();
                }

            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<MarketDbContextData>();
                logger.LogError(e.Message);
            }
        }
    }
}
