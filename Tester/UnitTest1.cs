using ObjednavkaProjekt.Třídy;
using System.Globalization;
using Xunit;

namespace Tester
{
    public class ObjednavkaTests
    {
        [Theory]
        [Xunit.InlineData("T1", "1000", 0, "0", "99", "1099")]
        [Xunit.InlineData("T2", "1499", 0, "0", "99", "1598")]
        [Xunit.InlineData("T3", "1500", 0, "0", "0", "1500")]
        [Xunit.InlineData("T4", "1999", 0, "0", "0", "1999")]
        [Xunit.InlineData("T5", "2000", 0, "100", "0", "1900")]
        [Xunit.InlineData("T6", "4999", 0, "249.95", "0", "4749.05")]
        [Xunit.InlineData("T7", "5000", 0, "500", "0", "4500")]
        [Xunit.InlineData("T8", "5000", 1, "500", "199", "4699")]
        [Xunit.InlineData("T9", "1000", 2, "0", "0", "1000")]
        public void VypocitejCeny_VsechnyTesty(
            string test,
            string cenaZbozi,
            int typDopravy,
            string expectedSleva,
            string expectedDoprava,
            string expectedCelkem)
        {
            // Arrange
            var objednavka = new Objednavka(
                decimal.Parse(cenaZbozi, CultureInfo.InvariantCulture),
                typDopravy
            );

            // Act
            decimal skutecnaSleva = objednavka.VypocitejSlevu();
            decimal skutecnaDoprava = objednavka.VypocitejDopravu();
            decimal skutecneCelkem = objednavka.VypocitejCelkem();

            // Assert
            Assert.Equal(
                decimal.Parse(expectedSleva, CultureInfo.InvariantCulture),
                skutecnaSleva);

            Assert.Equal(
                decimal.Parse(expectedDoprava, CultureInfo.InvariantCulture),
                skutecnaDoprava);

            Assert.Equal(
                decimal.Parse(expectedCelkem, CultureInfo.InvariantCulture),
                skutecneCelkem);
        }
    }
}
