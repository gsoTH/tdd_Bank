using Bank;

namespace BankTest
{
    [TestClass]
    public class KontoTests
    {
        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(10)]
        public void Konto_KannErstelltWerden(int value)
        {
            // Arrange
            int guthaben = value;

            // Act
            Konto k = new Konto(guthaben);


            // Assert
            Assert.AreEqual(guthaben, k.Guthaben);
        }

    }
}