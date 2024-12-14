// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using MyLibrary;

namespace FactoryTests
{
    public class MyFactory
    {
        [Fact]
        public void create_privateResidentBuilding_from_arguments()
        {
            var expected = new PrivateResidentBuilding("Федор Федоров Федорович", new DateTime(2020, 05, 06), 25000);
            var actual = Factory.CreatePrivateResidentBuilding("ЧастныйЖилДом \"Федор Федоров Федорович\" 2020.05.06  25000");

            Assert.True(expected.Equals(actual));
        }

        [Fact]
        public void create_countryHouse_from_arguments()
        {
            var expected = new CountryHouse("Федор Федоров Федорович", new DateTime(2020, 05, 06), 25000, 100);
            var actual = Factory.CreateCountryHouse("ДачныйДом \"Федор Федоров Федорович\" 2020.05.06  25000 100");

            Assert.True(expected.Equals(actual));
        }

        [Fact]
        public void create_apartmentBuilding_from_arguments()
        {
            var expected = new ApartmentBuilding("Федор Федоров Федорович", new DateTime(2020, 05, 06), 25000, 50);
            var actual = Factory.CreateApartmentBuilding("ДачныйДом \"Федор Федоров 1Федорович\" 2020.05.06  25000 50");

            Assert.True(expected.Equals(actual));
        }

        [Fact]
        public void ApartmentBuilding_ThrowsException_WhenFloorIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new ApartmentBuilding("Иван Иванов", DateTime.Now, 500000, -1));
        }

        [Fact]
        public void CountryHouse_ThrowsException_WhenPlotAreaOutsideSegment()
        {
            Assert.Throws<ArgumentException>(() => new CountryHouse("Иван Иванов", DateTime.Now, 500000, 140));
        }

        [Fact]
        public void PrivateResidentBuilding_ThrowsException_WhenCostLessThan1000()
        {
            Assert.Throws<ArgumentException>(() => new PrivateResidentBuilding("Иван Иванов", DateTime.Now, 500));
        }

        [Fact]
        public void CreatePrivateResidentBuilding_FromArguments_ThrowException()
        {
            Assert.Throws<Exception>(() => Factory.CreatePrivateResidentBuilding("ЧастныйЖилДом \"Федор Федоров 2020.555.06  25000"));
        }

        [Fact]
        public void ApartmentBuilding_FromArguments_ThrowException()
        {
            Assert.Throws<Exception>(() => Factory.CreateApartmentBuilding("\"Федор Федоров 2020  25000"));
        }

        [Fact]
        public void CreateCountryHouse_FromArguments_ThrowException()
        {
            Assert.Throws<Exception>(() => Factory.CreateCountryHouse("ЧастныйЖилДом \"Федор Федоров 2020  25000"));
        }
    }
}