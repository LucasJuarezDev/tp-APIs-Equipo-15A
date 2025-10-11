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
        public HttpResponseMessage Get()
        {
            articuloNegocio ArtiManager = new articuloNegocio();
            var lista = ArtiManager.listar();

            if (lista == null || lista.Count == 0)
                return Request.CreateResponse(HttpStatusCode.NoContent, "No hay artículos registrados.");

            return Request.CreateResponse(HttpStatusCode.OK, lista);
        }

        // GET: api/Articulo/5  (buscar articulo por ID)
        public HttpResponseMessage Get(int id)
        {
            articuloNegocio ArtiManager = new articuloNegocio();
            var lista = ArtiManager.listar();
            var articulo = lista.Find(x => x.Id == id);

            if (articulo == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "No se encontró el artículo solicitado.");

            return Request.CreateResponse(HttpStatusCode.OK, articulo);
        }

        // POST: api/Articulo   agregar Articulo
        public HttpResponseMessage Post([FromBody] ArticuloDTO ArtiDTO)
        {
            try
            {
                if (ArtiDTO == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No se recibieron datos del artículo.");

                if (string.IsNullOrEmpty(ArtiDTO.Nombre) || string.IsNullOrEmpty(ArtiDTO.Codigo))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "El artículo debe tener un nombre y un código.");

                if (ArtiDTO.Precio <= 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "El precio debe ser mayor que 0.");

                marcaNegocio marcaNeg = new marcaNegocio();
                categoriaNegocio catNeg = new categoriaNegocio();

                bool marcaExiste = marcaNeg.checkMarca(ArtiDTO.IdMarca);
                bool categoriaExiste = catNeg.checkCategoria(ArtiDTO.IdCategoria);

                if (!marcaExiste || !categoriaExiste)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "La marca o la categoría indicada no existe.");

                articuloNegocio ArtiManager = new articuloNegocio();
                Articulo Arti = new Articulo
                {
                    Codigo = ArtiDTO.Codigo,
                    Nombre = ArtiDTO.Nombre,
                    Descripcion = ArtiDTO.Descripcion,
                    TipoMarca = new Marca { Id = ArtiDTO.IdMarca },
                    TipoCategoria = new Categoria { Id = ArtiDTO.IdCategoria },
                    Precio = ArtiDTO.Precio
                };

                ArtiManager.Agregar(Arti);

                return Request.CreateResponse(HttpStatusCode.Created, "Artículo agregado correctamente.");
            }
            catch (Exception ex)
            {
                // 5️⃣ Manejo de errores inesperados
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error del servidor: " + ex.Message);
            }
        }

        // PUT: api/Articulo/5  agregar Articulo
        public HttpResponseMessage Put(int id, [FromBody] ArticuloDTO ArtiDTO)
        {
            try
            {
                if (ArtiDTO == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No se recibieron datos.");

                if (string.IsNullOrWhiteSpace(ArtiDTO.Nombre) || string.IsNullOrWhiteSpace(ArtiDTO.Codigo))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Debe indicar nombre y código.");

                articuloNegocio ArtiManager = new articuloNegocio();
                var lista = ArtiManager.listar();
                var existente = lista.Find(x => x.Id == id);

                if (existente == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "El artículo a modificar no existe.");

                Articulo Arti = new Articulo
                {
                    Id = id,
                    Codigo = ArtiDTO.Codigo,
                    Nombre = ArtiDTO.Nombre,
                    Descripcion = ArtiDTO.Descripcion,
                    TipoMarca = new Marca { Id = ArtiDTO.IdMarca },
                    TipoCategoria = new Categoria { Id = ArtiDTO.IdCategoria },
                    Precio = ArtiDTO.Precio
                };

                ArtiManager.ModifyArt(Arti);
                return Request.CreateResponse(HttpStatusCode.OK, "Artículo modificado correctamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error del servidor: " + ex.Message);
            }
        }

        // DELETE: api/Articulo/5 eliminar 
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                articuloNegocio ArtiManager = new articuloNegocio();
                var lista = ArtiManager.listar();
                var articulo = lista.Find(x => x.Id == id);

                if (articulo == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No existe el artículo que intenta eliminar.");

                ArtiManager.eliminarLogico(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Artículo eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error al eliminar el artículo: " + ex.Message);
            }
        }
    }
}
