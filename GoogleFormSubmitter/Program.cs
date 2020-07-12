using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Collections.Specialized;
using System.Text;

namespace GoogleFormSubmitter
{
    class MainClass
    {
        public static async Task Main(string[] args)
        {
            
            Console.Write("Enter number of answers: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine((i + 1) + ". Sending data...");

                var url = "https://docs.google.com/forms/d/e/1FAIpQLSfg0vX1NZh-lliq1dSaoJsdbCUTlF9oD7KsnjjStzmHcmcY0g/formResponse";
                var service = new GoogleFormsSubmissionService(url);
                var randomizer = new AnswerRandomizer();

                var keyValue = new Dictionary<string, string>
                {
                    { "pageHistory", "0,1,2" }, // values must not have spaces
                    { "entry.942122049", randomizer.RandomSingleAnswer(Seeds.Universities) }, // 1
                    { "entry.1591232226", randomizer.RandomSingleAnswer(Seeds.Genders) }, // 2
                    { "entry.592342948", randomizer.RandomSingleAnswer(Seeds.StudentYears) }, // 3
                    { "entry.1586518932", "Đúng" }, // 4

                    // 7
                    { "entry.290410784", randomizer.RandomSingleAnswer(Seeds.Q7) },
                    { "entry.1758965307", randomizer.RandomSingleAnswer(Seeds.Q7) },
                    { "entry.25957341", randomizer.RandomSingleAnswer(Seeds.Q7) },
                    { "entry.1143952455", randomizer.RandomSingleAnswer(Seeds.Q7) },
                    { "entry.614017038", randomizer.RandomSingleAnswer(Seeds.Q7) },
                    { "entry.793063967", randomizer.RandomSingleAnswer(Seeds.Q7) },
                    { "entry.43530589", randomizer.RandomSingleAnswer(Seeds.Q7) },
                    { "entry.386930221", randomizer.RandomSingleAnswer(Seeds.Q7) },
                    { "entry.1323186032", randomizer.RandomSingleAnswer(Seeds.Q7) },
                    { "entry.530330889", randomizer.RandomSingleAnswer(Seeds.Q7) },
                    { "entry.1820489267", randomizer.RandomSingleAnswer(Seeds.Q7) },

                    { "entry.435710000", randomizer.RandomSingleAnswer(Seeds.Q10) }, // 10

                    // 13
                    { "entry.1024633657", randomizer.RandomSingleAnswer(Seeds.Q13) },
                    { "entry.1594492916", randomizer.RandomSingleAnswer(Seeds.Q13) },
                    { "entry.1968152235", randomizer.RandomSingleAnswer(Seeds.Q13) },
                    { "entry.335777492", randomizer.RandomSingleAnswer(Seeds.Q13) },
                    { "entry.1756164232", randomizer.RandomSingleAnswer(Seeds.Q13) },
                    { "entry.1875171372", randomizer.RandomSingleAnswer(Seeds.Q13) },
                    { "entry.1863010780", randomizer.RandomSingleAnswer(Seeds.Q13) },
                    { "entry.1692810268", randomizer.RandomSingleAnswer(Seeds.Q13) }
                };

                service.SetFieldValues(keyValue);
                service.SetCheckboxValues("entry.1931486168", randomizer.RandomMultipleAnswers(Seeds.Q5, 2));
                service.SetCheckboxValues("entry.377350911", randomizer.RandomMultipleAnswers(Seeds.Q6, 2));
                service.SetCheckboxValues("entry.707901832", randomizer.RandomMultipleAnswers(Seeds.Q8, 2));
                service.SetCheckboxValues("entry.1465880545", randomizer.RandomMultipleAnswers(Seeds.Q9, 2));
                service.SetCheckboxValues("entry.597665629", randomizer.RandomMultipleAnswers(Seeds.Q11, 2));
                service.SetCheckboxValues("entry.1405303139", randomizer.RandomMultipleAnswers(Seeds.Q12, 2));

                await service.SubmitAsync();
            }
        }
    }
}
