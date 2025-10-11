using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Manager;


namespace Negocio
{
    public class categoriaNegocio
    {
        private AccesoDatos DataBaseCat = new AccesoDatos();
        public List<Categoria> ListarCategorias()
        {
            List<Categoria> ListaCategorias = new List<Categoria>();

            try
            {
                DataBaseCat.SetearConsulta("select Id, Descripcion from Categorias");
                DataBaseCat.EjecutarLectura();

                while (DataBaseCat.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = DataBaseCat.Lector.GetInt32(0);
                    aux.Descripcion = (string)DataBaseCat.Lector["Descripcion"];
                    ListaCategorias.Add(aux);
                }
                return ListaCategorias;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                DataBaseCat.CerrarConeccion();
            }

        }


        public void Agregar(string descripcion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO CATEGORIAS(Descripcion) VALUES ( @Descripcion )");
                datos.SetearParametro("@Descripcion", descripcion);
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

        public bool checkCategoria(int id)
        {
            try
            {
                DataBaseCat.SetearConsulta("SELECT COUNT(*) FROM Categorias WHERE Id = @id");
                DataBaseCat.SetearParametro("@id", id);
                DataBaseCat.EjecutarLectura();

                if (DataBaseCat.Lector.Read())
                {
                    int cantidad = (int)DataBaseCat.Lector[0];
                    return cantidad > 0;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                DataBaseCat.CerrarConeccion();
            }
        }
    }
}
