using API1.Models;
using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API1.Controllers
{
    public class ImagenController : ApiController
    {

        // POST: api/Imagen  (agregar Imagen)
        public HttpResponseMessage Post([FromBody] ImagenDTO imgDTO)
        {
            try
            {
                if (imgDTO == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No se recibieron datos de la Imagen");

                if (imgDTO.IdArticulo == 0 || string.IsNullOrEmpty(imgDTO.Url))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "La Imagen debe tener el ID del Articulo y la URL de la Imagen.");

                imagenNegocio ImgNegocio = new imagenNegocio();
                Imagen Img = new Imagen();

                bool ArtiExist = ImgNegocio.checkArticulo(imgDTO.IdArticulo); 

                if (!ArtiExist)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "EL Articulo indicado no existe.");

                Img.Id = imgDTO.IdArticulo;
                Img.Url = imgDTO.Url;

                // guardardo la imagen en la base de datos
                ImgNegocio.addImage(imgDTO.Url, imgDTO.IdArticulo);

                return Request.CreateResponse(HttpStatusCode.Created, "Imagen agregada correctamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error del servidor: " + ex.Message);
            }
        }
    }
}
