using System;
using BoardManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardTests
{
    [TestClass]
    public class ColumnTest
    {
        [TestMethod]
        public void AddCardToAColumn()
        {
            Column column = new Column();
            Card card = new Card();
            column.AddCard(card);

            Assert.IsTrue(column.getCards().Contains(card));
            Assert.IsTrue(column.Equals(card.getActualColumn()));
        }
    }
}
