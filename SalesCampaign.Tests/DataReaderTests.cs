using Xunit;
using SalesCampaign.Core;
using System;

namespace SalesCampaign.Tests
{
    public class DataReaderFixture : IDisposable
    {
        public DataReader Sut
        {
            get;
            private set;
        }

        public DataReaderFixture()
        {
            Sut = new DataReader();
        }

        public void Dispose()
        {
            Sut.Dispose();
        }
    }

    public class DataReaderTests : IClassFixture<DataReaderFixture>
    {
        // To demonstrate a use of fixture
        private readonly DataReaderFixture _fixture;

        public DataReaderTests(DataReaderFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [InlineData("")]
		[InlineData("abc")]
		public void ReadCompaignDuration_InvalidNumber_ThrowException(string text)
        {
            Assert.Throws<ArgumentException>(() => _fixture.Sut.ReadCampaignDuration(text));
        }

        [Fact]
        public void ReadCampaignDuration_ValidNumber_ReturnsIntegerDuration()
        {
            object duration = _fixture.Sut.ReadCampaignDuration("5");

            Assert.IsType(typeof(int), duration);
            Assert.Equal(5, duration);
        }

        [Theory]
        [InlineData("")]
        [InlineData("5 A")]
        [InlineData("a b c")]
        public void ReadOrderAmounts_InvalidNumber_ThrowException(string text)
        {
            Assert.Throws<ArgumentException>(() => _fixture.Sut.ReadOrderAmounts(text));
        }

		[Theory]
		[InlineData("0 1")]
		[InlineData("3 1 2")]
        public void ReadOrderAmounts_NumberOfOrderNotMatchWithNumberOfAmounts_ThrowException(string text)
        {
			Assert.Throws<FormatException>(() => _fixture.Sut.ReadOrderAmounts(text));
		}
    }
}
