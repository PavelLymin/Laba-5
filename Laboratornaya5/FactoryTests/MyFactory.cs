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
            var expected = new PrivateResidentBuilding("����� ������� ���������", new DateTime(2020, 05, 06), 25000);
            var actual = Factory.CreatePrivateResidentBuilding("������������� \"����� ������� ���������\" 2020.05.06  25000");

            Assert.True(expected.Equals(actual));
        }

        [Fact]
        public void create_countryHouse_from_arguments()
        {
            var expected = new CountryHouse("����� ������� ���������", new DateTime(2020, 05, 06), 25000, 100);
            var actual = Factory.CreateCountryHouse("��������� \"����� ������� ���������\" 2020.05.06  25000 100");

            Assert.True(expected.Equals(actual));
        }

        [Fact]
        public void create_apartmentBuilding_from_arguments()
        {
            var expected = new ApartmentBuilding("����� ������� ���������", new DateTime(2020, 05, 06), 25000, 50);
            var actual = Factory.CreateApartmentBuilding("��������� \"����� ������� 1���������\" 2020.05.06  25000 50");

            Assert.True(expected.Equals(actual));
        }

        [Fact]
        public void ApartmentBuilding_ThrowsException_WhenFloorIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new ApartmentBuilding("���� ������", DateTime.Now, 500000, -1));
        }

        [Fact]
        public void CountryHouse_ThrowsException_WhenPlotAreaOutsideSegment()
        {
            Assert.Throws<ArgumentException>(() => new CountryHouse("���� ������", DateTime.Now, 500000, 140));
        }

        [Fact]
        public void PrivateResidentBuilding_ThrowsException_WhenCostLessThan1000()
        {
            Assert.Throws<ArgumentException>(() => new PrivateResidentBuilding("���� ������", DateTime.Now, 500));
        }

        [Fact]
        public void CreatePrivateResidentBuilding_FromArguments_ThrowException()
        {
            Assert.Throws<Exception>(() => Factory.CreatePrivateResidentBuilding("������������� \"����� ������� 2020.555.06  25000"));
        }

        [Fact]
        public void ApartmentBuilding_FromArguments_ThrowException()
        {
            Assert.Throws<Exception>(() => Factory.CreateApartmentBuilding("\"����� ������� 2020  25000"));
        }

        [Fact]
        public void CreateCountryHouse_FromArguments_ThrowException()
        {
            Assert.Throws<Exception>(() => Factory.CreateCountryHouse("������������� \"����� ������� 2020  25000"));
        }
    }
}