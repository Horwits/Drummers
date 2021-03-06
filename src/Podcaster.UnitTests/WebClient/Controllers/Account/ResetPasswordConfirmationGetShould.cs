﻿using NUnit.Framework;

using Podcaster.Web.Controllers;

using TestStack.FluentMVCTesting;

namespace Podcaster.UnitTests.WebClient.Controllers.Account
{
    [TestFixture]
    public class ResetPasswordConfirmationGetShould
    {
        [Test]
        public void RenderDefaultView()
        {
            var controller = new AccountController();
            controller.WithCallTo(x => x.ResetPasswordConfirmation()).ShouldRenderDefaultView();
        }
    }
}