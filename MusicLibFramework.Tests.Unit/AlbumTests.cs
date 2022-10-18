using MusicLibFramework.Services;
using MusicLibFramework.Repositories.Interfaces;
using MusicLibDbCtx.Model;
using NSubstitute;
using Microsoft.Extensions.Logging;
using FluentAssertions;

namespace MusicLibFramework.Tests.Unit
{
    public class AlbumServiceTests
    {
        private readonly AlbumService _sut;
        private readonly IAlbumRepository _repository = Substitute.For<IAlbumRepository>();
        private readonly ILogger<AlbumService> _logger = Substitute.For<ILogger<AlbumService>>();

        public AlbumServiceTests()
        {
            _sut = new AlbumService(_logger, _repository);
        }

        [Fact]
        public void GetAll_ShouldReturnAlbums_IfAnyExist()
        {
            //Arrange
            List<Album> expectedAlbums = new()
            {
                new Album { Name = "Rio", YearReleased = 1982 }
            };

            _repository.GetAll().Returns(expectedAlbums);

            //Act
            var albums = _sut.GetAll();

            //Assert
            albums.Should().HaveCount(1);
            albums.Should().ContainSingle(x => x.Name == "Rio");
        }

        [Fact]
        public void SearchByName_ShouldReturnOneAlbum_WhenNameIsValidAlbumName()
        {

        }

        [Fact]
        public void SearchByReleaseYear_ShouldReturnPositiveInt_WhenYearIsValid()
        {

        }

        [Fact]
        public void SearchByReleaseYear_ShouldReturnErrorMsg_WhenYearIsLessThan1800()
        {

        }

        [Fact]
        public void SearchByReleaseYear_ShouldReturnErrorMsg_WhenYearIsAfterNextYear()
        {

        }

    }
}