using System;
using System.Windows.Input;
using Equities.Helpers;
using Equities.Models;
using Equities.ViewModels;
using Moq;
using NUnit.Framework;

namespace Equities.UI.Tests.ViewModels
{
    [TestFixture]
    public class AddStockViewModelTests
    {
        private Mock<IAddStockHelper> _addStockHelperMock;

        [SetUp]
        public void Setup()
        {
            _addStockHelperMock = new Mock<IAddStockHelper>();
        }

        [TestCase]
        public void AddCommandCallsAddStockHelper()
        {
            _addStockHelperMock.Setup(x => x.AddStock(It.IsAny<StockInputModel>()));
            var sut = new AddStockViewModel(_addStockHelperMock.Object);
            sut.Price = "10";
            sut.Quantity = "10";
            sut.AddCommand.Execute(null);
            _addStockHelperMock.Verify(x => x.AddStock(It.IsAny<StockInputModel>()));
        }

        [TestCase]
        public void AddCommandCanExecuteIfPriceIsDecimalAndQuantityIsDecimal()
        {
            var sut = new AddStockViewModel(_addStockHelperMock.Object);
            sut.Price = "10,0";
            sut.Quantity = "10";
            Assert.IsTrue(sut.AddCommand.CanExecute(null));
        }

        [TestCase]
        public void AddCommandCanNotExecuteIfQuantityIsNotDecimal()
        {
            var sut = new AddStockViewModel(_addStockHelperMock.Object);
            sut.Price = "10,0";
            sut.Quantity = "quantity";
            Assert.IsFalse(sut.AddCommand.CanExecute(null));
        }

        [TestCase]
        public void AddCommandCannotExecuteIfPriceIsNotDecimal()
        {
            var sut = new AddStockViewModel(_addStockHelperMock.Object);
            sut.Price = "price";
            sut.Quantity = "10";
            Assert.IsFalse(sut.AddCommand.CanExecute(null));
        }

        [TestCase]
        public void AddCommandResetProperties()
        {
            var sut = new AddStockViewModel(_addStockHelperMock.Object);
            sut.Price = "123";
            sut.AddCommand.Execute(null);
            Assert.IsTrue(String.IsNullOrEmpty(sut.Price));
        }
    }
}
