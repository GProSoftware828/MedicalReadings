using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MedicalReadings
{
    public class BloodPressureReading
    {
        public static void BloodPressure()
        {
            Console.WriteLine("Please enter blood pressure readings in the format [{SysBP: 120, DiaBP: 90, atDate: '2018/10/31'},{SysBP: 115, DiaBP: 100, atDate: '2018/10/20'}]");
            Console.WriteLine("Enter 'exit' to exit the system.");
            string BPObj;
            BPObj = Console.ReadLine();
            if (BPObj == "exit")
            {
                return;
            }
            //write to a .txt file here
            List<BloodPressure> bloodPressureCollectionInput = JsonConvert.DeserializeObject<List<BloodPressure>>(BPObj);
            var Pressure1 = bloodPressureCollectionInput[bloodPressureCollectionInput.Count - 1].SysBP;
            var Pressure2 = bloodPressureCollectionInput[bloodPressureCollectionInput.Count - 1].DiaBP;
            Console.WriteLine("According to the last reading entered: ");
            if ((Pressure1 > 180 || Pressure1 == 180) && (Pressure2 > 120 || Pressure2 == 120))
            {
                Console.WriteLine("Classification: 'Stage 3'");
            }
            if ((159 < Pressure1 && Pressure1 < 180) || (99 < Pressure2 && Pressure2 < 110))
            {
                Console.WriteLine("Classification: 'Stage 2'");
            }
            if ((139 < Pressure1 && Pressure1 < 160) || (89 < Pressure2 && Pressure2 < 100))
            {
                Console.WriteLine("Classification: 'Stage 1'");
            }
            if (!((Pressure1 > 180 || Pressure1 == 180) && (Pressure2 > 120 || Pressure2 == 120))
                && !((159 < Pressure1 && Pressure1 < 180) || (99 < Pressure2 && Pressure2 < 110))
                && !((139 < Pressure1 && Pressure1 < 160) || (89 < Pressure2 && Pressure2 < 100)))
            {
                Console.WriteLine("No hypertension: ");
            }
            var PressureDate = bloodPressureCollectionInput[bloodPressureCollectionInput.Count - 1].atDate;
            Console.WriteLine("Referencing reading: SysBP of: "
                + $"{Pressure1}"
                + ", DiaBP of: "
                + $"{Pressure2}"
                + ", at input date: "
                + $"{PressureDate}");

            return;
        }
    }

    public static class KidneyTestReading
    {
        public static void KidneyTest()
        {
            Console.WriteLine("Please enter eGFR Data in the format [{eFGR: 65, atDate: '2018/10/31'},{eFGR: 70, atDate: '2018/10/20'}]");
            Console.WriteLine("Enter 'exit' to exit the system.");
            string KDObj;
            KDObj = Console.ReadLine();
            if (KDObj == "exit")
            {
                return;
            }
            List<KidneyReadings> kidneyCollectionInput = JsonConvert.DeserializeObject<List<KidneyReadings>>(KDObj);
            var Reading1 = kidneyCollectionInput[kidneyCollectionInput.Count - 1].eFGR;
            if (Reading1 > 89)
            {
                Console.WriteLine("Latest reading is: Normal");
            }
            if (59 < Reading1 && Reading1 < 90)
            {
                Console.WriteLine("Latest reading is: Mildly Decreased");
            }
            if (44 < Reading1 && Reading1 < 60)
            {
                Console.WriteLine("Latest reading is: Mild to Moderate");
            }
            if (29 < Reading1 && Reading1 < 45)
            {
                Console.WriteLine("Latest reading is: Moderate to Severe");
            }
            if (14 < Reading1 && Reading1 < 30)
            {
                Console.WriteLine("Latest reading is: Severely Decreased");
            }
            if (!(Reading1 > 89)
                && !(59 < Reading1 && Reading1 < 90)
                && !(44 < Reading1 && Reading1 < 60)
                && !(29 < Reading1 && Reading1 < 45)
                && !(14 < Reading1 && Reading1 < 30))
            {
                Console.WriteLine("Kidney Failure");
            }
            var Reading1Date = kidneyCollectionInput[kidneyCollectionInput.Count - 1].atDate;
            Console.WriteLine("Referencing: e.FGR of: " + $"{Reading1}" + " on date: " + $"{Reading1Date}");
            for (int i = 0; i < kidneyCollectionInput.Count; i++)
            {
                var readingFirst = kidneyCollectionInput[i];
                int j = i + 1;
                var readingSecond = !(readingFirst == kidneyCollectionInput[kidneyCollectionInput.Count - 1]) ?
                    kidneyCollectionInput[j] : kidneyCollectionInput[i];
                if (readingSecond.eFGR < (readingFirst.eFGR * .81))
                {
                    Console.WriteLine("DROP OVER 20% FOUND: e.FGR reading " + $"{readingFirst.eFGR}"
                        + " on date" +
                        $"{readingFirst.atDate}" +
                        " and e.FGR reading " +
                        $"{readingSecond.eFGR}" + " on date " +
                        $"{readingSecond.atDate}"
                        + " show a drop of "
                    + Math.Round(((1 - (double)readingSecond.eFGR / (double)readingFirst.eFGR)) * 100) + "%");
                }
                else
                {
                    Console.WriteLine("Showing no signs of large drops in these consecutive readings.");
                }
            }
        }
    }

    public class Initialize
    {
        public static void Input(string a)
        {
            if (a == "BP")
            {
                BloodPressureReading.BloodPressure();
            }
            if (a == "KD")
            {
                KidneyTestReading.KidneyTest();
            }
            else
            {
                return;
            }
        }
    }

    public class Program
    {
        static public void Main(string[] args)
        {
            Console.WriteLine("Please enter BP to input blood pressure data or KD to enter Kidney Disease data:");
            Console.WriteLine("Enter 'exit' to exit the system.");
            string readChoice = Console.ReadLine();

            Initialize.Input(readChoice);
        }
    }
}
