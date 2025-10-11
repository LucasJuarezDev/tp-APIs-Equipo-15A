using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Manager;

namespace Negocio
{
    public class marcaNegocio
    {
        private AccesoDatos DataBaseMarca = new AccesoDatos();
        public List<Marca> ListarMarcas()
        {
            List<Marca> ListaMarca = new List<Marca>();

            try
            {
                DataBaseMarca.SetearConsulta("select Id, Descripcion from Marcas");
                DataBaseMarca.EjecutarLectura();

                while (DataBaseMarca.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = DataBaseMarca.Lector.GetInt32(0);
                    aux.Descripcion = (string)DataBaseMarca.Lector["Descripcion"];

                    ListaMarca.Add(aux);
                }
                return ListaMarca;
            }
            catch (Exception exp)
            {

                throw exp;
            }
            finally
            {
                DataBaseMarca.CerrarConeccion();
            }

        }


        public void Agregar(string descripcion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO MARCAS(Descripcion) VALUES ( @Descripcion )");
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

        public bool checkMarca(int id)
        {
            try
            {
                DataBaseMarca.SetearConsulta("SELECT COUNT(*) FROM Marcas WHERE Id = @id");
                DataBaseMarca.SetearParametro("@id", id);
                DataBaseMarca.EjecutarLectura();

                if (DataBaseMarca.Lector.Read())
                {
                    int cantidad = (int)DataBaseMarca.Lector[0];
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
                DataBaseMarca.CerrarConeccion();
            }
        }
    }
}
