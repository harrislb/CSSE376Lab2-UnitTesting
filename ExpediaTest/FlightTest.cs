using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{

        private readonly int numberMiles = 5000;
        private readonly DateTime dtStart = new DateTime(2008, 3, 9);
        private readonly DateTime dtEnd = new DateTime(2008, 3, 9);
        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(dtStart, dtEnd, numberMiles);
            Assert.IsNotNull(target);
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForSameDayFlight()
        {
            var target = new Flight(dtStart, dtEnd, numberMiles);
            Assert.AreEqual(200, target.getBasePrice());
        }

        private readonly DateTime dtEnd2 = new DateTime(2008, 3, 15);
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForSixDayStay()
        {
            var target = new Flight(dtStart, dtEnd2, numberMiles);
            Assert.AreEqual(320, target.getBasePrice());
        }
        private readonly DateTime dtEnd3 = new DateTime(2008, 3, 19);
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDaysStay()
        {
            var target = new Flight(dtStart, dtEnd3, numberMiles);
            Assert.AreEqual(400, target.getBasePrice());
        }
        private readonly DateTime dtEnd4 = new DateTime(2008, 2, 14);
        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadLength()
        {
            new Flight(dtStart, dtEnd4, numberMiles);
        }
        private readonly int negativeMiles = -200;
        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadMiles()
        {
            new Flight(dtStart, dtEnd3, negativeMiles);
        }
		
	}
}
