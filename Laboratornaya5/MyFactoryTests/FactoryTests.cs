// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibrary;
using System;

namespace MyFactoryTests
{
    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void create_privateResidentBuilding_from_arguments()
        {
            var expected = new PrivateResidentBuilding("Федор Федоров Федорович", new DateTime(2020, 05, 06), 25000);
            var actual = Factory.CreatePrivateResidentBuilding("ЧастныйЖилДом \"Федор Федоров Федорович\" 2020.05.06  25000");

            Assert.IsTrue(expected.Equals(actual));
        }

        [TestMethod]
        public void create_countryHouse_from_arguments()
        {
            var expected = new CountryHouse("Федор Федоров Федорович", new DateTime(2020, 05, 06), 25000, 100);
            var actual = Factory.CreateCountryHouse("ДачныйДом \"Федор Федоров Федорович\" 2020.05.06  25000 100");

            Assert.IsTrue(expected.Equals(actual));
        }

        [TestMethod]
        public void create_apartmentBuilding_from_arguments()
        {
            var expected = new ApartmentBuilding("Федор Федоров Федорович", new DateTime(2020, 05, 06), 25000, 50);
            var actual = Factory.CreateApartmentBuilding("ДачныйДом \"Федор Федоров Федорович\" 2020.05.06  25000 50");

            Assert.IsTrue(expected.Equals(actual));
        }

        [TestMethod]
        public void ApartmentBuilding_ThrowsException_WhenFloorIsNegative()
        {
            Assert.ThrowsException<ArgumentException>(() => new ApartmentBuilding("Иван Иванов", DateTime.Now, 500000, -1));
        }

        [TestMethod]
        public void CountryHouse_ThrowsException_WhenPlotAreaOutsideSegment()
        {
            Assert.ThrowsException<ArgumentException>(() => new CountryHouse("Иван Иванов", DateTime.Now, 500000, 140));
        }

        [TestMethod]
        public void PrivateResidentBuilding_ThrowsException_WhenCostLessThan1000()
        {
            Assert.ThrowsException<ArgumentException>(() => new PrivateResidentBuilding("Иван Иванов", DateTime.Now, 500));
        }

        [TestMethod]
        public void CreatePrivateResidentBuilding_FromArguments_ThrowException()
        {
            Assert.ThrowsException<Exception>(() => Factory.CreatePrivateResidentBuilding("ЧастныйЖилДом \"Федор Федоров 2020.555.06  25000"));
        }

        [TestMethod]
        public void ApartmentBuilding_FromArguments_ThrowException()
        {
            Assert.ThrowsException<Exception>(() => Factory.CreateApartmentBuilding("\"Федор Федоров 2020  25000"));
        }

        [TestMethod]
        public void CreateCountryHouse_FromArguments_ThrowException()
        {
            Assert.ThrowsException<Exception>(() => Factory.CreateCountryHouse("ЧастныйЖилДом \"Федор Федоров 2020  25000"));
        }
    }
}
