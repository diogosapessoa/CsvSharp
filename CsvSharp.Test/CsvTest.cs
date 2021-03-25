using CsvSharp.Test.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CsvSharp.Test
{
    [TestClass]
    public class CsvTest
    {
        private static readonly IEnumerable<Genius> genius = new List<Genius>
        {
            new Genius("Galileu", "Galilei", new DateTime(1564, 2, 15)),
            new Genius("Isaac", "Newton", new DateTime(1643, 4, 1)),
            new Genius("Albert", "Einstein", new DateTime(1879, 3, 13))
        };

        private static readonly IEnumerable<GeniusIgnore> geniusIgnore = new List<GeniusIgnore>
        {
            new GeniusIgnore("Galileu", "Galilei", new DateTime(1564, 2, 15)),
            new GeniusIgnore("Isaac", "Newton", new DateTime(1643, 4, 1)),
            new GeniusIgnore("Albert", "Einstein", new DateTime(1879, 3, 13))
        };

        [TestMethod("Deserialize CSV test")]
        public void Deserialize()
        {
            IEnumerable<Genius> genius = CsvConvert.Deserialize<Genius>(Properties.Resources.sample, CultureInfo.InvariantCulture);
            Assert.AreEqual(3, genius.Count());
        }

        [TestMethod("Serialize CSV test")]
        public void Serialize()
        {
            var csv = CsvConvert.Serialize(genius, CultureInfo.InvariantCulture);
            Assert.AreEqual(Properties.Resources.sample, csv);
        }

        [TestMethod("Deserialize ignore CSV test")]
        public void DeserializeIgnore()
        {
            IEnumerable<GeniusIgnore> genius = CsvConvert.Deserialize<GeniusIgnore>(Properties.Resources.sample, CultureInfo.InvariantCulture);
            Assert.AreEqual(3, geniusIgnore.Count());
        }

        [TestMethod("Serialize ignore CSV test")]
        public void SerializeIgnore()
        {
            var csv = CsvConvert.Serialize(genius, CultureInfo.InvariantCulture);
            Assert.AreEqual(Properties.Resources.sample, csv);
        }
    }
}
