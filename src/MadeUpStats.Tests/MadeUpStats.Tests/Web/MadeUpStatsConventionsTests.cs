using System;
using MadeUpStats.Domain;
using MadeUpStats.Web;
using MadeUpStats.Web.Services;
using Moq;
using Xunit;

namespace MadeUpStats.Tests.Web
{
    public class MadeUpStatsConventionsTests
    {
        [Fact]
        public void MadeUpStatsConventions_should_call_DateFormatter_for_DateTime_property()
        {
            // Arrange
            var mockDateFormatter = new Mock<DateFormatter>();
            var conventions = new MadeUpStatsConventions(mockDateFormatter.Object);

            var stat = new Stat("title", "desc", new Author("a"), DateTime.Now);
            var propertyInfo = stat.GetType().GetProperty("CreateDate");

            // Act
            conventions.ModelPropertyBuilder(propertyInfo, stat.CreateDate);

            // Assert
            mockDateFormatter.Verify(x => x.GetFormat(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once());
        }
    }
}