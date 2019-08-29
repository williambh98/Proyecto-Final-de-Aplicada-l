using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EntradaBLL
    {
        public static bool Guardar(Entrada entrada)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                foreach (var item in entrada.Detalle)
                {
                    Articulo articulo = new Articulo();
                    articulo = ArticuloBLL.Buscar(item.ArticuloID);
                    articulo.Cantidad += item.Cantidad;
                    ArticuloBLL.Modificar(articulo);
                }
                if (contexto.Entrada.Add(entrada) != null)
                {
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { contexto.Dispose(); }
            return paso;
        }
        public static bool Modificar(Entrada entrada)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {

                foreach (var item in entrada.Detalle)
                {
                    Articulo articulo = new Articulo();
                    articulo = ArticuloBLL.Buscar(item.ArticuloID);
                    if (item.Id == 0)
                    {
                        articulo.Cantidad += item.Cantidad;
                        contexto.Entry(item).State = EntityState.Added;
                    }

                    ArticuloBLL.Modificar(articulo);
                }
                contexto.Entry(entrada).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { contexto.Dispose(); }
            return paso;
        }


        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            Entrada entrada = contexto.Entrada.Find(id);
            try
            {
                foreach (var item in entrada.Detalle)
                {
                    Articulo articulo = new Articulo();
                    articulo = ArticuloBLL.Buscar(item.ArticuloID);
                    articulo.Cantidad -= item.Cantidad;
                    ArticuloBLL.Modificar(articulo);
                }
                contexto.Entrada.Remove(entrada);
                paso = contexto.SaveChanges() > 0;
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {  contexto.Dispose();}
            return paso;
        }


        public static Entrada Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Entrada entrada = new Entrada();

            try
            {
                entrada = contexto.Entrada.Find(id);
                if (entrada == null)
                    return entrada;
                entrada.Detalle.Count();
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
        public static void EliminarDetalle(Entrada entrada)
        {
            Contexto contexto = new Contexto();
            foreach (var item in entrada.Detalle)
            {
                Articulo articulo = new Articulo();
                articulo = ArticuloBLL.Buscar(item.ArticuloID);

                RepositorioBase<ArticuloDetalle> db = new RepositorioBase<ArticuloDetalle>();
                ArticuloDetalle details = db.Buscar(item.Id);
                if (details is null)
                    return;
                articulo.Cantidad -= details.Cantidad;
                contexto.Entry(item).State = EntityState.Deleted;
                contexto.SaveChanges();
                ArticuloBLL.Modificar(articulo);
            }


        }
    }
}
