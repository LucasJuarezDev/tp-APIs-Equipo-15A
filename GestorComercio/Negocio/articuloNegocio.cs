using Dominio;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Negocio
{
    public class articuloNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Articulo> listar(Dictionary<int, int> imagenesSeleccionadas = null)
        {
            List<Articulo> lista = new List<Articulo>();

            try
            {
                datos.SetearConsulta(
                    "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, " +
                    "M.Descripcion AS MarcaDescripcion, A.IdCategoria, CAT.Descripcion AS CategoriaDescripcion, " +
                    "A.Precio " +
                    "FROM ARTICULOS A " +
                    "INNER JOIN MARCAS M ON M.Id = A.IdMarca " +
                    "INNER JOIN CATEGORIAS CAT ON CAT.Id = A.IdCategoria " +
                    "WHERE A.Precio > 0"
                );
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.TipoMarca = new Marca
                    {
                        Id = (int)datos.Lector["IdMarca"],
                        Descripcion = (string)datos.Lector["MarcaDescripcion"]
                    };
                    aux.TipoCategoria = new Categoria
                    {
                        Id = (int)datos.Lector["IdCategoria"],
                        Descripcion = (string)datos.Lector["CategoriaDescripcion"]
                    };
                    aux.Precio = Math.Round((decimal)datos.Lector["Precio"], 2);

                    // Aquí obtenemos la imagen prioritaria si existe
                    int? idImagenPrioritaria = null;
                    if (imagenesSeleccionadas != null && imagenesSeleccionadas.ContainsKey(aux.Id))
                        idImagenPrioritaria = imagenesSeleccionadas[aux.Id];

                    aux.imagenArticulo = new imagenNegocio().getCorrectImageDGV(aux.Id, idImagenPrioritaria);

                    lista.Add(aux);
                }

                return lista;
            }
            finally
            {
                datos.CerrarConeccion();
            }
        }

        public void Agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");
                datos.SetearParametro("@Codigo", nuevo.Codigo);
                datos.SetearParametro("@Nombre", nuevo.Nombre);
                datos.SetearParametro("@Descripcion", nuevo.Descripcion);
                datos.SetearParametro("@IdMarca", nuevo.TipoMarca.Id);
                datos.SetearParametro("@IdCategoria", nuevo.TipoCategoria.Id);
                datos.SetearParametro("@Precio", nuevo.Precio);
                datos.ejecutarAccion();
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

        public void ModifyArt(Articulo articulo)
        {
            try
            {
                datos.SetearConsulta
               (
                "UPDATE ARTICULOS " +
                "SET  Codigo = @Codigo, " +
                "Nombre = @Nombre, " +
                "Descripcion = @Descripcion, " +
                "IdMarca = @IdMarca, " +
                "IdCategoria = @IdCategoria, " +
                "Precio = @Precio " +
                "WHERE Id = @Id "
               );
                datos.SetearParametro("@Codigo", articulo.Codigo);
                datos.SetearParametro("@Nombre", articulo.Nombre);
                datos.SetearParametro("@Descripcion", articulo.Descripcion);
                datos.SetearParametro("@IdMarca", articulo.TipoMarca.Id);
                datos.SetearParametro("@IdCategoria", articulo.TipoCategoria.Id);
                datos.SetearParametro("@Precio", articulo.Precio);
                datos.SetearParametro("@Id", articulo.Id);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.CerrarConeccion();
            }
        }

        public void eliminarLogico(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.SetearConsulta("update ARTICULOS set Precio = 0 Where id = @id");
                datos.SetearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ReturnID()
        {
            int CodigoRetorno = 0;
            try
            {
                datos.SetearConsulta("SELECT ISNULL(MAX(Id), 0) + 1 AS Id FROM ARTICULOS");
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    CodigoRetorno = (int)datos.Lector["Id"];
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.CerrarConeccion();
            }
            return CodigoRetorno;
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {                      //no indique que traiga la imagen para que podamos definir primero como vamos a hacer
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion AS MarcaDescripcion, A.IdCategoria, C.Descripcion AS CategoriaDescripcion, A.Precio from ARTICULOS A, MARCAS M, CATEGORIAS C Where A.IdMarca = M.Id and A.IdCategoria = C.Id and Precio > 0 AND ";
                if (campo == "precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "A.Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "A.Precio < " + filtro;
                            break;
                        default:
                            consulta += "A.Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A.Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "A.Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "A.Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "C.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "C.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "C.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.TipoMarca = new Marca();
                    aux.TipoMarca.Id = (int)datos.Lector["IdMarca"];
                    aux.TipoMarca.Descripcion = (string)datos.Lector["MarcaDescripcion"];

                    aux.TipoCategoria = new Categoria();
                    aux.TipoCategoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.TipoCategoria.Descripcion = (string)datos.Lector["CategoriaDescripcion"];


                    aux.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
