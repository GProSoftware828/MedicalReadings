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
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Please enter BP to input blood pressure data or KD to enter Kidney Disease data:");
            string readChoice;
            readChoice = Console.ReadLine();
            do
            {
                try
                {
                    if (readChoice == "BP")
                    {
                        Console.WriteLine("Please enter blood pressure readings in the format [{SysBP: 120, DiaBP: 90, atDate: '2018/10/31'},{SysBP: 115, DiaBP: 100, atDate: '2018/10/20'}]");
                        Console.WriteLine("Enter 'exit' to exit the system.");
                        string BPObj;
                        BPObj = Console.ReadLine();
                        if (BPObj == "exit")
                        {
                            break;
                        }
                        JArray inputArray = JArray.Parse(BPObj);
                        //write to a .txt file here
                        Console.WriteLine(inputArray);
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
                            Console.WriteLine("No classification of blood pressure: " + bloodPressureCollectionInput);
                        }
                    }
                    if (readChoice == "KD")
                    {
                        Console.WriteLine("Please enter eGFR Data in the format [{eFGR: 65, atDate: '2018/10/31'},{eFGR: 70, atDate: '2018/10/20'}]");
                        Console.WriteLine("Enter 'exit' to exit the system.");
                        string KDObj;
                        KDObj = Console.ReadLine();
                        if (KDObj == "exit")
                        {
                            break;
                        }
                        JArray inputArray = JArray.Parse(KDObj);
                        Console.WriteLine(inputArray);
                        List<KidneyReadings> kidneyCollectionInput = JsonConvert.DeserializeObject<List<KidneyReadings>>(KDObj);
                        var Reading1 = kidneyCollectionInput[kidneyCollectionInput.Count - 1].eFGR;
                        Console.WriteLine(Reading1);
                        if (Reading1 > 89)
                        {
                            Console.WriteLine("Normal");
                        }
                        if (59 < Reading1 && Reading1 < 90)
                        {
                            Console.WriteLine("Mildly Decreased");
                        }
                        if (44 < Reading1 && Reading1 < 60)
                        {
                            Console.WriteLine("Mild to Moderate");
                        }
                        if (29 < Reading1 && Reading1 < 45)
                        {
                            Console.WriteLine("Moderate to Severe");
                        }
                        if (14 < Reading1 && Reading1 < 30)
                        {
                            Console.WriteLine("Severely Decreased");
                        }
                        if(!(Reading1 > 89) 
                            && !(59 < Reading1 && Reading1 < 90)
                            && !(44 < Reading1 && Reading1 < 60)
                            && !(29 < Reading1 && Reading1 < 45)
                            && !(14 < Reading1 && Reading1 < 30))
                        {
                            Console.WriteLine("Kidney Failure");
                        }
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Please only enter one of the two options.");
                }
            } while (1 < 2);
        }
    }
}
