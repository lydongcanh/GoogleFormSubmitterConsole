using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Collections.Specialized;
using System.Text;

namespace GoogleFormSubmitter
{
    public class MainClass
    {
        public static async Task Main(string[] args)
        {
            
            Console.Write("Enter number of answers: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine((i + 1) + ". Sending data...");

                var url = "https://docs.google.com/forms/d/e/1FAIpQLSfJPxwtkz6SJO13WXG6shkq51CqCrjGvijnFWyq1iV_7vs1jA/formResponse";
                var service = new GoogleFormsSubmissionService(url);
                var randomizer = new AnswerRandomizer();

                var keyValue = new Dictionary<string, string>
                {
                    { "pageHistory", "0,1,2,3" }, // values must not have spaces

                    { "entry.942122049", randomizer.Q1(i) }, // 1
                    { "entry.1591232226", randomizer.Q2(i) }, // 2
                    { "entry.592342948", randomizer.Q3(i) }, // 3
                    { "entry.1586518932", randomizer.Q4(i) }, // 4
                    { "entry.290410784", randomizer.Q6(i) }, // 6
                    { "entry.707901832", randomizer.Q8(i) }, // 8
                    { "entry.1465880545", randomizer.Q9(i) }, // 9
                    { "entry.435710000", randomizer.Q10(i) }, // 10

                    // 11
                    { "entry.1407575000", randomizer.Q11_1(i) },
                    { "entry.450457108", randomizer.Q11_2(i) },
                    { "entry.328563900", randomizer.Q11_3(i) },
                    { "entry.1767421383", randomizer.Q11_4(i) },


                    // 14
                    { "entry.1024633657", randomizer.Q14_1(i) },
                    { "entry.1594492916", randomizer.Q14_2(i) },
                    { "entry.1968152235", randomizer.Q14_3(i) },
                    { "entry.335777492", randomizer.Q14_4(i) },
                    { "entry.1756164232", randomizer.Q14_5(i) },
                    { "entry.1875171372", randomizer.Q14_6(i) },
                    { "entry.1863010780", randomizer.Q14_7(i) },

                    // 15
                    { "entry.1017603238", randomizer.Q15_1(i) },
                    { "entry.1775366673", randomizer.Q15_2(i) },
                    { "entry.1479727737", randomizer.Q15_3(i) },
                    { "entry.1660021787", randomizer.Q15_4(i) },
                };

                service.SetFieldValues(keyValue);
                service.SetCheckboxValues("entry.1931486168", randomizer.Q5(i)); // 5
                service.SetCheckboxValues("entry.377350911", randomizer.Q7(i)); // 7

                service.SetCheckboxValues("entry.597665629", randomizer.Q12(i)); // 12
                service.SetCheckboxValues("entry.1405303139", randomizer.Q13(i)); // 13

                await service.SubmitAsync();
            }
        }
    }
}
