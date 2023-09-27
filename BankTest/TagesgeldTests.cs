using Bank;

namespace BankTest
{
    [TestClass]
    public class TagesgeldTests
    {
        [TestMethod]
        public void Tagesgeld_KannErstelltWerden()
        {
            // Arrange
            Konto verrechnungskonto = new Konto(0.0);

            // Act
            Tagesgeld t = new Tagesgeld(verrechnungskonto);

            // Assert
            Assert.AreEqual(verrechnungskonto.KontoNr, t.VerrechnungsKontoNr);
            Assert.AreEqual(0.0, t.Guthaben);
            Assert.AreEqual(0.0, t.Zinssatz);
        }

        [TestMethod]
        public void Zinssatz_KannVeraendertWerden()
        {
            // Arrange
            Tagesgeld t = new Tagesgeld(new Konto(0.0));
            double neuerZinssatz = 1.0;

            // Act
            double alterZinssatz = t.Zinssatz;
            t.Zinssatz = neuerZinssatz;

            // Assert
            Assert.AreEqual(0.0, alterZinssatz);
            Assert.AreEqual(neuerZinssatz, t.Zinssatz);
        }

        [TestMethod]
        public void Einzahlen_BetragKommtVonVerrechnungskonto()
        {
            // Arrange
            double kontoStartguthaben = 100.00;
            Konto konto = new Konto(kontoStartguthaben);
            Tagesgeld t = new Tagesgeld(konto);
            double einzahlungsBetrag = 70.00;

            // Act
            t.Einzahlen(einzahlungsBetrag);

            // Assert
            Assert.AreEqual(30.00, konto.Guthaben);
            Assert.AreEqual(einzahlungsBetrag, t.Guthaben);
        }


		[TestMethod]
        public void Auszahlen_BetragLandetAufVerrechnungskonto()
        {
            // Arrange
            double kontoStartguthaben = 100.00;
            Konto konto = new Konto(kontoStartguthaben);
            
            Tagesgeld t = new Tagesgeld(konto);
            double einzahlungsBetrag = 70.00;
			t.Einzahlen(einzahlungsBetrag);

            double auszahlungsBetrag = 30.00;

            // Act
            t.Auszahlen(auszahlungsBetrag);

            // Assert
			Assert.AreEqual(60.00, konto.Guthaben);
            Assert.AreEqual(40.00, t.Guthaben);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Auszahlen_ZuGeringesGuthabenUnmoeglich()
        {
            // Arrange
            double kontoStartguthaben = 100.00;
            Konto konto = new Konto(kontoStartguthaben);
            
            Tagesgeld t = new Tagesgeld(konto);
            double einzahlungsBetrag = 70.00;
            t.Einzahlen(einzahlungsBetrag);

            double auszahlungsBetrag = 80.00;

            // Act
            t.Auszahlen(auszahlungsBetrag);

            // Assert
            Assert.AreEqual(kontoStartguthaben, konto.Guthaben);
            Assert.AreEqual(einzahlungsBetrag, t.Guthaben);

        }

    }
}