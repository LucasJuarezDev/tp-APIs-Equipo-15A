using Dominio;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Negocio
{
    public class imagenNegocio
    {
        private AccesoDatos dataImage = new AccesoDatos();
        public List<Imagen> ListarImagenes()
        {
            List<Imagen> ListaImagenes = new List<Imagen>();

            try
            {
                dataImage.SetearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES");
                dataImage.EjecutarLectura();

                while (dataImage.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.Id = dataImage.Lector.GetInt32(0);
                    aux.IdArticulo =  dataImage.Lector.GetInt32(1);
                    aux.Url = (string)dataImage.Lector["ImagenUrl"];
                    ListaImagenes.Add(aux);
                }
                return ListaImagenes;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dataImage.CerrarConeccion();
            }

        }

        public List<Imagen> listImagesById(int id)
        {
            List<Imagen> ListaImagenes = new List<Imagen>();
            try
            {
                dataImage.limpiarParametros();
                dataImage.SetearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo = @IdArticulo");
                dataImage.SetearParametro("@IdArticulo", id);

                dataImage.EjecutarLectura();

                while (dataImage.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.Id = dataImage.Lector.GetInt32(0);
                    aux.IdArticulo = dataImage.Lector.GetInt32(1);
                    aux.Url = (string)dataImage.Lector["ImagenUrl"];
                    ListaImagenes.Add(aux);
                }
                return ListaImagenes;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dataImage.CerrarConeccion();
            }
        }

        //hice este listar para que no sea solo por el ID y poder usarlo en la lista de imagenes que se crea en el form principal
        public List<Imagen> listar()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.Url = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConeccion();
            }
        }

        public void addImage(string url, int id)
        {
            try
            {
                dataImage.limpiarParametros();
                dataImage.SetearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                dataImage.SetearParametro("@IdArticulo", id);
                dataImage.SetearParametro("@ImagenUrl", url);

                dataImage.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dataImage.CerrarConeccion();
            }
        }

        public void modifyImage(string url, int idArticulo, int idImagen)
        {
            try
            {
                dataImage.limpiarParametros();
                dataImage.SetearConsulta("UPDATE IMAGENES SET ImagenUrl = @ImagenUrl WHERE IdArticulo = @IdArticulo AND Id = @Id");
                dataImage.SetearParametro("@ImagenUrl", url);
                dataImage.SetearParametro("@IdArticulo", idArticulo);
                dataImage.SetearParametro("@Id", idImagen);

                dataImage.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dataImage.CerrarConeccion();
            }
        }

        public Imagen getCorrectImageDGV(int idArticulo, int? idImagenSeleccionada = null)
        {
            Imagen img = null;
            try
            {
                dataImage.limpiarParametros();

                if (idImagenSeleccionada.HasValue)
                {
                    // Prioriza la imagen seleccionada
                    dataImage.SetearConsulta(
                        "SELECT TOP 1 Id, IdArticulo, ImagenUrl " +
                        "FROM IMAGENES " +
                        "WHERE IdArticulo = @IdArticulo " +
                        "ORDER BY CASE WHEN Id = @IdImagenSeleccionada THEN 0 ELSE 1 END, Id"
                    );
                    dataImage.SetearParametro("@IdArticulo", idArticulo);
                    dataImage.SetearParametro("@IdImagenSeleccionada", idImagenSeleccionada.Value);
                }
                else
                {
                    // Comportamiento normal si no hay imagen prioritaria
                    dataImage.SetearConsulta(
                        "SELECT TOP 1 Id, IdArticulo, ImagenUrl " +
                        "FROM IMAGENES " +
                        "WHERE IdArticulo = @IdArticulo " +
                        "ORDER BY Id"
                    );
                    dataImage.SetearParametro("@IdArticulo", idArticulo);
                }

                dataImage.EjecutarLectura();
                if (dataImage.Lector.Read())
                {
                    img = new Imagen()
                    {
                        Id = (int)dataImage.Lector["Id"],
                        IdArticulo = (int)dataImage.Lector["IdArticulo"],
                        Url = (string)dataImage.Lector["ImagenUrl"]
                    };
                }

                return img;
            }
            finally
            {
                dataImage.CerrarConeccion();
            }
        }
    }
}
