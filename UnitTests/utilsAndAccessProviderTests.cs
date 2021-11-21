using NUnit.Framework;
using System;
using XBattlePongRestAPI.Controllers;
using XBattlePongRestAPI.DataAccessAndDBContext;
using XBattlePongRestAPI.Models;
using XBattlePongRestAPI.Utils;

namespace UnitTests
{
    public class utilsAndAccessProviderTests
    {
        TokenManager tokenManager;
        [SetUp]
        public void Setup()
        {
            tokenManager = new TokenManager();
            
        }
        [Test]
        public void isInEventDays_InRangeWorks()
        {
            //Arrange
            //  10/11/2021 19:00:00 P.M
            DateTime deadline = new DateTime(2021, 11, 10, 19, 0, 0);

            //Act
            bool isInEventDays = tokenManager.isInEventDays(deadline);

            //Assert
            Assert.IsFalse(isInEventDays);

        }
        [Test]
        public void isInEventDays_NotInRangeWorks()
        {
            //Arrange
            //  10/11/2022 19:00:00 P.M
            DateTime deadline2 = new DateTime(2022, 11, 10, 19, 0, 0);

            //Act
            bool IsInEventDays = tokenManager.isInEventDays(deadline2);

            //Assert
            Assert.IsTrue(IsInEventDays);
        }

    }
}
