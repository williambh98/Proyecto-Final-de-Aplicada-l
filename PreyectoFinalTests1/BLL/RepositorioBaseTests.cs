using Microsoft.VisualStudio.TestTools.UnitTesting;
using PreyectoFinal.BLL;
using PreyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyectoFinal.BLL.Tests
{
    [TestClass()]
    public class RepositorioBaseTests
    {
        [TestMethod()]
        public void RepositorioBaseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GuardarTest()
        {
            
            TipoArticulo proveedores = new TipoArticulo();
            proveedores.TiposId = 1003;
            proveedores.Nombre = "William";
            proveedores.Descripcion= "sfsazdcsa";
            proveedores.FechaCreacion = DateTime.Now;
            RepositorioBase<TipoArticulo> repositorio;
            repositorio = new RepositorioBase<TipoArticulo>();
            Assert.IsTrue(repositorio.Guardar(proveedores));
            
           
        }
        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
            
            CrearUsuario usuario = new CrearUsuario();
            usuario.UsuarioId = 1002;
            usuario.Nombres = "Willia";
            usuario.Email = "Williamelnene@hotmail.com";
            usuario.NoTelefono = "809-125-445";
            usuario.Contraseña = "polo";
            usuario.FechaCreacion = DateTime.Now;
            RepositorioBase<CrearUsuario> repositorio;
            repositorio = new RepositorioBase<CrearUsuario>();
            Assert.IsTrue(repositorio.Modificar(usuario));
            
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
            /*
            CrearUsuario usuario = new CrearUsuario();
            usuario.UsuarioId = 1002;
            usuario.Nombres = "William";
            usuario.Email = "Williamelnene@hotmail.com";
            usuario.NoTelefono = "809-125-445";
            usuario.Contraseña = "polo";
            usuario.FechaCreacion = DateTime.Now;
            RepositorioBase<CrearUsuario> repositorio;
            repositorio = new RepositorioBase<CrearUsuario>();
            Assert.IsTrue(repositorio.Eliminar(1002));
            */
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
            /*
            CrearUsuario usuario = new CrearUsuario();
            usuario.UsuarioId = 1002;
            usuario.Nombres = "William";
            usuario.Email = "Williamelnene@hotmail.com";
            usuario.NoTelefono = "809-125-445";
            usuario.Contraseña = "polo";
            usuario.FechaCreacion = DateTime.Now;
            RepositorioBase<CrearUsuario> repositorio;
            repositorio = new RepositorioBase<CrearUsuario>();
            Assert.IsTrue(repositorio.Buscar());
            */
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }
    }
}