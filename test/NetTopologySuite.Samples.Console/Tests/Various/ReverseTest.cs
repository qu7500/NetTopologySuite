using System.Diagnostics;
using NetTopologySuite.Geometries;
using NetTopologySuite.Samples.SimpleTests;
using NUnit.Framework;

namespace NetTopologySuite.Samples.Tests.Various
{
    /// <summary>
    ///
    /// </summary>
    [TestFixture]
    public class ReverseTest : BaseSamples
    {
        /// <summary>
        ///
        /// </summary>
        public ReverseTest() : base() { }

        /// <summary>
        ///
        /// </summary>
        [Test]
        public void LineStringReverseTest()
        {
            var lineString = Factory.CreateLineString(new Coordinate[]
            {
                new Coordinate(10, 10),
                new Coordinate(20, 20),
                new Coordinate(20, 30),
            });
            var reverse = (LineString)lineString.Reverse();

            Debug.WriteLine(lineString.ToString());
            Debug.WriteLine(reverse.ToString());

            Assert.IsTrue(lineString.EqualsTopologically(reverse));
            Assert.IsFalse(lineString.EqualsExact(reverse));
        }

        /// <summary>
        ///
        /// </summary>
        [Test]
        public void MultiLineStringReverseTest()
        {
            var lineString1 = Factory.CreateLineString(new Coordinate[]
            {
                new Coordinate(10, 10),
                new Coordinate(20, 20),
                new Coordinate(20, 30),
            });
            var lineString2 = Factory.CreateLineString(new Coordinate[]
            {
                new Coordinate(12, 12),
                new Coordinate(24, 24),
                new Coordinate(24, 36),
            });
            var multiLineString = Factory.CreateMultiLineString(new[] { lineString1, lineString2, });
            var reverse = (MultiLineString)multiLineString.Reverse();

            Debug.WriteLine(multiLineString.ToString());
            Debug.WriteLine(reverse.ToString());

            Assert.IsTrue(multiLineString.EqualsTopologically(reverse));
            Assert.IsFalse(multiLineString.EqualsExact(reverse));

            var result2 = reverse[0];
            Assert.IsTrue(lineString1.EqualsTopologically(result2));
            Assert.IsFalse(lineString1.EqualsExact(result2));

            var result1 = reverse[1];
            Assert.IsTrue(lineString2.EqualsTopologically(result1));
            Assert.IsFalse(lineString2.EqualsExact(result1));
        }
    }
}
