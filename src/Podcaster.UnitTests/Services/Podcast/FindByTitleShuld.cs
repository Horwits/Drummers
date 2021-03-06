﻿using System;

using NUnit.Framework;

using Ploeh.AutoFixture;

using Podcaster.Services.Podcast;
using Podcaster.UnitTests.Base;
using Podcaster.UnitTests.Mocks;

namespace Podcaster.UnitTests.Services.Podcast
{
    [TestFixture]
    public class FindByTitleShuld : BaseTestClass
    {
        [Test]
        public void NotThrow_WhenArgument_IsValid()
        {
            // Arrange
            var fakeEntityFactory = new FakePodcastEntityFactory();
            var repoFaktory = new FakeRepositoriesFactory(fakeEntityFactory);
            var fakeData = new FakePodcasterDataFactory(repoFaktory).GetPodcasterData();

            var title = this.Fixture.Create<string>();

            // Act & Assert
            Assert.DoesNotThrow(() => new PodcastService(fakeData.Object).FindByTitle(title));
        }

        [Test]
        public void Throw_WhenArgument_IsEmpty()
        {
            // Arrange
            var fakeEntityFactory = new FakePodcastEntityFactory();
            var repoFaktory = new FakeRepositoriesFactory(fakeEntityFactory);
            var fakeData = new FakePodcasterDataFactory(repoFaktory).GetPodcasterData();

            string title = string.Empty;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new PodcastService(fakeData.Object).FindByTitle(title));
        }

        [Test]
        public void Throw_WhenArgument_IsNull()
        {
            // Arrange
            var fakeEntityFactory = new FakePodcastEntityFactory();
            var repoFaktory = new FakeRepositoriesFactory(fakeEntityFactory);
            var fakeData = new FakePodcasterDataFactory(repoFaktory).GetPodcasterData();

            string title = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PodcastService(fakeData.Object).FindByTitle(title));
        }

        [Test]
        public void Throw_WhenArgument_IsWhiteSpace()
        {
            // Arrange
            var fakeEntityFactory = new FakePodcastEntityFactory();
            var repoFaktory = new FakeRepositoriesFactory(fakeEntityFactory);
            var fakeData = new FakePodcasterDataFactory(repoFaktory).GetPodcasterData();

            string title = "\n\r";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new PodcastService(fakeData.Object).FindByTitle(title));
        }
    }
}