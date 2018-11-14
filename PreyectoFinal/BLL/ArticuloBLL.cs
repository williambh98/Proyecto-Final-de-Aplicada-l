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
   public  class ArticuloBLL
    {
        public static bool Guardar(Articulo articulo)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto._Articulo.Add(articulo) != null)
                {
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


        public static bool Modificar(Articulo articulo)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(articulo).State = EntityState.Modified;
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
                Articulo articulo = contexto._Articulo.Find(id);

                contexto._Articulo.Remove(articulo);

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


        public static Articulo Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Articulo articulo = new Articulo();
            try
            {
                articulo = contexto._Articulo.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return articulo;
        }


        public static List<Articulo> GetList(Expression<Func<Articulo, bool>> expression)
        {
            List<Articulo> articulos = new List<Articulo>();
            Contexto contexto = new Contexto();

            try
            {
                articulos = contexto._Articulo.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return articulos;
        }

        public static double PorcientoGanancia(double costo, double precio)
        {
            double PctGanancia;

            PctGanancia = precio - costo;
            PctGanancia = PctGanancia / costo;
            PctGanancia *= 100;

            return PctGanancia;
        }
    }
}
