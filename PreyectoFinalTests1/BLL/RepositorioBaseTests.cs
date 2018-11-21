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
            CrearUsuario usuario = new CrearUsuario();
            usuario.UsuarioId = 1002;
            usuario.Nombres = "William";
            usuario.Email = "Williamelnene@hotmail.com";
            usuario.NoTelefono = "809-125-445";
            usuario.Contraseña = "polo";
            usuario.FechaCreacion = DateTime.Now;
            RepositorioBase<CrearUsuario> repositorio;
            repositorio = new RepositorioBase<CrearUsuario>();
            Assert.IsTrue(repositorio.Guardar(usuario));
           
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
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