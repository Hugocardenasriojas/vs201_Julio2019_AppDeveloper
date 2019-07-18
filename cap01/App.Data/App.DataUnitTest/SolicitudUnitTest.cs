using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Data;
using App.Data.Base;

namespace App.DataUnitTest
{
    [TestClass]
    public class SolicitudUnitTest
    {
        [TestMethod]
        public void SolicitudHWTest()
        {
            SolicitudAcceso obj1 = new SolicitudAcceso();
            obj1.NivelAcceso = 3;
            Assert.IsTrue(obj1.Aprobar(), "El usuario administrador no puede aprobar");
            Solicitud obj2 = new SolicitudAcceso()
            {
            NivelAcceso=4
                    };

            Assert.IsTrue(obj2.Aprobar(), "El usuario administrador no puede aprobar");
            // Assert.IsTrue(true);//Identifica si el resultado de la prueba es verdadero o falso.
            //Assert es una asercion, es checklist
        }
        [TestMethod]
        public void SolicitudesTest()
        {
            SolicitudHardware obj1 = new SolicitudHardware();
            obj1.Fecha = DateTime.Now;
            Assert.IsTrue(VerificarAprobacion(obj1));
        }
        [TestMethod]
        public void Solicitudes2Test()
        {
            SolicitudAcceso obj1 = new SolicitudAcceso();
            obj1.Fecha = DateTime.Now;
            obj1.NivelAcceso = 5;
            Assert.IsTrue(VerificarAprobacion(obj1));
        }
        private bool VerificarAprobacion(Solicitud solicitud)
        {
            return solicitud.Aprobar();
        }
    }
}
