using FakeItEasy;
using NUnit.Framework;
using HelloCore;
using HelloCore.Models;
using HelloCore.Data;
using System.Collections.ObjectModel;


namespace HelloCore_Test.Data.UnitOfWork
{
    public class Tests
    {
        [TestFixture]
        public class UnitOfWorkBestellingRepoTests
        {
            private IUnitOfWork unitOfWork = A.Fake<IUnitOfWork>();

            [Test]
            public void Ophalen_ReturnsObservableCollectionOfTypeBestelling()
            {
                //Arrange
                ObservableCollection<Bestelling> bestellingen;

                //Act
                bestellingen = new ObservableCollection<Bestelling>(unitOfWork.BestellingRepository.Find(p => p.klant));


                //Assert
                Assert.NotNull(bestellingen);
                Assert.IsInstanceOf<ObservableCollection<Bestelling>>(bestellingen);
            }

            [Test]
            public async Task GetByIdAsync_Returns1Bestelling()
            {
                //Arrange
                Bestelling? bestelling = A.Fake<Bestelling>();

                //Act
                bestelling = await unitOfWork.BestellingRepository.GetByIdAsync(bestelling.BestellingID);

                //Assert
                Assert.NotNull(bestelling);
                Assert.IsInstanceOf<Bestelling>(bestelling);

                //Handig bij het testen van de methode die bijvoorbeeld aan een knop gebonden is
                //Hiermee kan je controleren of het klikken op die knop de database operatie heeft uitgevoerd die je zou verwachten
                A.CallTo(() => unitOfWork.BestellingRepository.GetByIdAsync(bestelling.BestellingID)).MustHaveHappened();
            }
        }
    }
}