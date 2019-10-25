using NUnit.Framework;
using System;

namespace ProgramTest
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void InputChoice_Input_ShouldReturnGivenProgramBP()
        {
            //arrange
            string a = "BP";

            //act
            MedicalReadings.Initialize.Input(a);

            //assert
        }

        [Test]
        public void InputChoice_Input_ShouldReturnGivenProgramKD()
        {
            //arrange
            string a = "KD";

            //act
            MedicalReadings.Initialize.Input(a);

            //assert
        }

        [Test]
        public void InputChoice_Input_ShouldReturnGivenProgramOther()
        {
            //arrange
            string a = "";
            if (a != "BP" && a != "KD")
            {
                //act
                MedicalReadings.Initialize.Input(a);
            };

            //assert
        }
    }
}