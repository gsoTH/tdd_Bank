using Bank;

namespace BankTest
{
    [TestClass]
    public class KontoTests
    {
        [TestMethod]
        public void Konto_KannErstelltWerden()
        {
            // Arrange
            double guthaben = 100.00;

            // Act
            Konto k = new Konto(guthaben);


            // Assert
            Assert.AreEqual(guthaben, k.Guthaben);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Konto_KannNichtMitNegativemBetragErstelltWerden()
        {
            // Arrange
            double guthaben = -0.1;

            // Act
            Konto k = new Konto(guthaben);
        }

        [TestMethod]
        public void Einzahlen_GuthabenSteigt()
        {
            // Arrange
            double startbetrag = 120.0;
            Konto k = new Konto(startbetrag);
            double einzahlungsbetrag = 80.00;

            // Act
            k.Einzahlen(einzahlungsbetrag);

            // Assert
            Assert.AreEqual(200.00, k.Guthaben);
        }

        [TestMethod]
        public void Auszahlen_GuthabenSinkt()
        {
            // Arrange
            double startbetrag = 120.0;
            Konto k = new Konto(startbetrag);
            double auszahlungsbetrag = 80.00;

            // Act
            k.Auszahlen(auszahlungsbetrag);

            // Assert
            Assert.AreEqual(40.00, k.Guthaben);
        }

        [TestMethod]
        public void KontoNr_KannAbgefragtWerden()
        {
            // Arrange


            // Act
            Konto k = new Konto(0.0);

            //Arrange
            Assert.IsTrue(k.KontoNr > 0);
            Assert.IsInstanceOfType(k.KontoNr, typeof(int));
        }

        [TestMethod]
        public void Nr_WirdAutomatischVergeben()
        {
            // Arrange

            // Act
            Konto k1 = new Konto(0);
            Konto k2 = new Konto(0);
            Konto k3 = new Konto(0);

            // Assert
            Assert.IsTrue(k1.KontoNr > 0);
            Assert.IsTrue(k2.KontoNr > k1.KontoNr);
            Assert.IsTrue(k3.KontoNr > k2.KontoNr);
            Assert.AreNotEqual(k1.KontoNr, k2.KontoNr);
            Assert.AreNotEqual(k1.KontoNr, k3.KontoNr);
            Assert.AreNotEqual(k2.KontoNr, k3.KontoNr);

        }
    }
}