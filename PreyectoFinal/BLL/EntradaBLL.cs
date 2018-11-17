using PreyectoFinal.DAL;
using PreyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PreyectoFinal.BLL
{
    public class EntradaBLL
    {
        public static bool Guardar(Entrada entrada)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Entrada.Add(entrada) != null)
                {
                    contexto._Articulo.Find(entrada.ArticuloID).sumar += entrada.Cantidad;

                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static bool Modificar(Entrada entrada)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Entrada EntrAnt = EntradaBLL.Buscar(entrada.EntradaId);

                if (EntrAnt.ArticuloID != entrada.ArticuloID)
                {
                    ModificarBien(entrada, EntrAnt);
                }

                double modificado = entrada.Cantidad - EntrAnt.Cantidad;

                var Articulo = contexto._Articulo.Find(entrada.ArticuloID);
               // Articulo.CantidadIventario += modificado;
                ArticuloBLL.Modificar(Articulo);

                contexto.Entry(entrada).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Entrada entrada = contexto.Entrada.Find(id);

                //contexto._Articulo.Find(entrada.ArticuloID).CantidadIventario -= entrada.Cantidad;

                contexto.Entrada.Remove(entrada);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static Entrada Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Entrada entrada = new Entrada();

            try
            {
                entrada = contexto.Entrada.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return entrada;
        }


        public static List<Entrada> GetList(Expression<Func<Entrada, bool>> expression)
        {
            List<Entrada> entradas = new List<Entrada>();
            Contexto contexto = new Contexto();

            try
            {
                entradas = contexto.Entrada.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return entradas;
        }

        public static void ModificarBien(Entrada entradas, Entrada EntradasAnteriores)
        {
            Contexto contexto = new Contexto();
            var Producto = contexto._Articulo.Find(entradas.ArticuloID);
            var ProductosAnteriores = contexto._Articulo.Find(EntradasAnteriores.ArticuloID);

            //Producto.CantidadIventario += entradas.Cantidad;
           // ProductosAnteriores.CantidadIventario -= EntradasAnteriores.Cantidad;
            ArticuloBLL.Modificar(Producto);
            ArticuloBLL.Modificar(ProductosAnteriores);
        }

    }
}
