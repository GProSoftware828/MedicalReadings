using NUnit.Framework;
using System;

namespace ProgramTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void BloodPressure_ShouldExist_TypesExist()
        {
            MedicalReadings.BloodPressureReading _subject;
            _subject = new MedicalReadings.BloodPressureReading();
            Assert.IsNotNull(_subject);
        }
        [Test]
        public void KidneyDisease_ShouldExist_TypesExist()
        {
            MedicalReadings.KidneyTestReading _subject;
            _subject = new MedicalReadings.KidneyTestReading();
            Assert.IsNotNull(_subject);
        }
        [Test]
        public void Initialize_ShouldExist_TypesExist()
        {
            MedicalReadings.Initialize _subject;
            _subject = new MedicalReadings.Initialize();
            Assert.IsNotNull(_subject);
        }
    }
}