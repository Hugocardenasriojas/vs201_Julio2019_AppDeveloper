using App_Data.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.DataAccessTest
{
    [TestClass]
    public class ArtistDATest
    {
        [TestMethod]
        public void Count()
        {
            var da = new ArtistDA();
            var cantidad = da.GetCount();
            Assert.IsTrue(cantidad >= 0);
        }
        [TestMethod]
        public void GetArtists()
        {
            var da = new ArtistDA();
            var listado = da.GetArtists();
            Assert.IsTrue(listado.Count > 0);
        }
        /*public void GetArtistsa(filtroPorNombre)
        {
            var da = new ArtistDA();
            var listado = da.GetArtists();
            Assert.IsTrue(listado.Count > 0);
        }*/
    }
}
