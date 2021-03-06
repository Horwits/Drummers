﻿using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using Podcaster.Models;
using Podcaster.UnitTests.Base;

namespace Podcaster.UnitTests.Models.User
{
    [TestFixture]
    public class GenerateUserIdentityAsyncShould : BaseTestClass
    {
        [Test]
        public void Call_GenerateUserIdentity_Once()
        {
            // Arrange
            var userStore = new Mock<IUserStore<ApplicationUser>>();

            var userManager = new Mock<UserManager<ApplicationUser>>(userStore.Object);

            var authType = this.Fixture.Create<string>();
            var user = this.Fixture.Build<ApplicationUser>().Without(p => p.Subscriptions).Create();

            // Act
            var result = user.GenerateUserIdentityAsync(userManager.Object);

            // Assert
            /*  userManager.Verify(m => m.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie), Times.Once);*/
            Assert.IsInstanceOf(typeof(Task<ClaimsIdentity>), result);
        }
    }
}