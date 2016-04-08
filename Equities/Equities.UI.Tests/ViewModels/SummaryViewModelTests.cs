using System.Collections.Generic;
using Equities.Builders;
using Equities.Models;
using Equities.ViewModels;
using Moq;
using NUnit.Framework;

namespace Equities.UI.Tests.ViewModels
{
    /// <summary>
    /// Nope, not testable.
    /// </summary>
    [TestFixture]
    public class SummaryViewModelTests
    {
        private Mock<ISummaryBuilderFactory> _summaryBuilderFactoryMock;
        private Mock<ISummaryBuilder> _summaryBuilderMock;

        [SetUp]
        public void Setup()
        {
            _summaryBuilderFactoryMock = new Mock<ISummaryBuilderFactory>();
            _summaryBuilderFactoryMock.Setup(x => x.Create()).Returns(() => _summaryBuilderMock.Object);
            _summaryBuilderMock = new Mock<ISummaryBuilder>();
            _summaryBuilderMock.Setup(x => x.WithBonds()).Returns(() => _summaryBuilderMock.Object);
            _summaryBuilderMock.Setup(x => x.WithEquities()).Returns(() => _summaryBuilderMock.Object);
            _summaryBuilderMock.Setup(x => x.WithTotal()).Returns(() => _summaryBuilderMock.Object);
            _summaryBuilderMock.Setup(x => x.Build()).Returns(() => new List<SummaryModel>());
        }

        [TestCase]
        public void UpdateCreatesASummaryBuilder()
        {
            var sut = new SummaryViewModel(_summaryBuilderFactoryMock.Object);
            sut.Update();
            _summaryBuilderFactoryMock.Verify(x => x.Create());
        }

        [TestCase]
        public void UpdateBuildsSummaryWithEquities()
        {
            var sut = new SummaryViewModel(_summaryBuilderFactoryMock.Object);
            sut.Update();
            _summaryBuilderMock.Verify(x => x.WithEquities());
        }

        [TestCase]
        public void UpdateBuildsSummaryWithBonds()
        {
            var sut = new SummaryViewModel(_summaryBuilderFactoryMock.Object);
            sut.Update();
            _summaryBuilderMock.Verify(x => x.WithBonds());
        }

        [TestCase]
        public void UpdateBuildsSummaryWithTotal()
        {
            var sut = new SummaryViewModel(_summaryBuilderFactoryMock.Object);
            sut.Update();
            _summaryBuilderMock.Verify(x => x.WithTotal());
        }
    }
}
