using System;
using System.Collections.Generic;
using System.Linq;
using MadeUpStats.Domain;
using MadeUpStats.Web.Models;
using MadeUpStats.Web.Services;
using Xunit;

namespace MadeUpStats.Tests.Services
{
    public class MadeUpStatsMapperTests
    {
        [Fact]
        public void MadeUpStatsMapper_should_map_many_Stats_to_StatDisplays()
        {
            // Arrange
            var stats = new[] {new Stat("a", "", null, DateTime.Now), new Stat("b", "", null, DateTime.Now)};

            // Act
            var statDisplays = GetMapper().Map<Stat, StatDisplay>(stats);

            // Assert
            var firstStatDisplay = statDisplays.First();
            var secondStatDisplay = statDisplays.Last();
            Assert.Equal(firstStatDisplay.Title, "a");
            Assert.Equal(secondStatDisplay.Title, "b");
        }

        private static IMapper GetMapper()
        {
            return new MadeUpStatsMapper();
        }
    }
}