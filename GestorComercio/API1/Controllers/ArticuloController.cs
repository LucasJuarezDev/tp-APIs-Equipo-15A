using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dominio;
using Manager;
using Negocio;
using API1.Models;

namespace API1.Controllers
{
    public class ArticuloController : ApiController
    {
        // GET: api/Articulo  (listar todos los articulos)
        public IEnumerable<Articulo> Get()
        {
            articuloNegocio ArtiManager = new articuloNegocio();
            return ArtiManager.listar();
        }

        // GET: api/Articulo/5  (buscar articulo por ID)
        public  Articulo Get(int id)
        {
            articuloNegocio ArtiManager = new articuloNegocio();

            List<Articulo> Lista = new List<Articulo>();
            return Lista.Find(x=> x.Id == id);
        }

        // POST: api/Articulo   agregar Articulo
        public void Post([FromBody]ArticuloDTO ArtiDTO)
        {
            articuloNegocio ArtiManager = new articuloNegocio();
            Articulo Arti = new Articulo();

            Arti.Codigo = ArtiDTO.Codigo;
            Arti.Nombre = ArtiDTO.Nombre;
            Arti.Descripcion = ArtiDTO.Descripcion;
            Arti.TipoMarca = new Marca { Id = ArtiDTO.IdMarca };
            Arti.TipoCategoria = new Categoria { Id = ArtiDTO.IdCategoria };
            Arti.Precio = ArtiDTO.Precio;

            ArtiManager.Agregar(Arti);
        }

        // PUT: api/Articulo/5  agregar Articulo
        public void Put(int id, [FromBody] ArticuloDTO ArtiDTO)
        {
            articuloNegocio ArtiManager = new articuloNegocio();
            Articulo Arti = new Articulo();

            Arti.Codigo = ArtiDTO.Codigo;
            Arti.Nombre = ArtiDTO.Nombre;
            Arti.Descripcion = ArtiDTO.Descripcion;
            Arti.TipoMarca = new Marca { Id = ArtiDTO.IdMarca };
            Arti.TipoCategoria = new Categoria { Id = ArtiDTO.IdCategoria };
            Arti.Precio = ArtiDTO.Precio;

            Arti.Id = id;

            ArtiManager.ModifyArt(Arti);

        }

        // DELETE: api/Articulo/5 eliminar 
        public void Delete(int id)
        {
            articuloNegocio ArtiManager = new articuloNegocio();
            ArtiManager.eliminarLogico(id);
        }
    }
}
