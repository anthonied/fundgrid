using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunGrid.Domain;
using NUnit.Framework;

namespace FundGrid.Tests
{
    [TestFixture]
    class UnitTests
    {
        private List<GridItem> _ExistingGridItems;

        [SetUp]
        public void Given()
        {
            _ExistingGridItems = new List<GridItem>();
            _ExistingGridItems.Add(new GridItem() {Amount = 50, Id = 10, Number = 4, Owner = "Someone1" });
            _ExistingGridItems.Add(new GridItem() { Amount = 50, Id = 11, Number = 6, Owner = "Someone2" });
            _ExistingGridItems.Add(new GridItem() { Amount = 50, Id = 12, Number = 8, Owner = "Someone3" });
            _ExistingGridItems.Add(new GridItem() { Amount = 50, Id = 13, Number = 9, Owner = "Someone4" });
            _ExistingGridItems.Add(new GridItem() { Amount = 50, Id = 14, Number = 12, Owner = "Someone5" });
            _ExistingGridItems.Add(new GridItem() { Amount = 50, Id = 15, Number = 24, Owner = "Someone6" });
        }
        [Test]
        public void NullGridItemIsAvailible()
        {
            GridItem item = new GridItem() { Id = 0 };
            Assert.That(item.IsAvailible, Is.True);
        }
        [Test]
        public void GridFilledNoData()
        {
            Grid grid = new Grid() { DimensionColumns = 4, DimensionRows = 6, Id = 12, IncrementValue = 10, InitialValue = 10, ExistingGridItems = new List<GridItem>()};
            List<GridItem> ExistingGridItems = new List<GridItem>();
            Assert.That(grid.ItemCount, Is.EqualTo(24));
        }
        [Test]
        public void GridFilledCorrectlyWithData()
        {
            Grid grid = new Grid() { DimensionColumns = 4, DimensionRows = 6, Id = 12, IncrementValue = 10, InitialValue = 10, ExistingGridItems = _ExistingGridItems };
            Assert.That(grid.FullGridItems[0][3].Number, Is.EqualTo(4));
            Assert.That(grid.FullGridItems[0][5].Number, Is.EqualTo(6));
            Assert.That(grid.FullGridItems[1][1].Number, Is.EqualTo(8));
            Assert.That(grid.FullGridItems[1][2].Number, Is.EqualTo(9));
            Assert.That(grid.FullGridItems[3][5].Number, Is.EqualTo(24));
        }

    }
}
