using System;
using System.Collections.Generic;

namespace GoogleFormSubmitter
{
    public class AnswerRandomizer
    {
        private readonly Random random = new Random();

        public string RandomSingleAnswer(string[] seeds)
        {
            return seeds[random.Next(0, seeds.Length)];
        }

        public string[] RandomMultipleAnswers(string[] seeds, int minNumber = 1)
        {
            if (minNumber > seeds.Length)
                throw new IndexOutOfRangeException(nameof(minNumber));

            int numAnswer = random.Next(minNumber, seeds.Length);
            string[] answers = new string[numAnswer];

            for (int i = 0; i < numAnswer; i++)
                answers[i] = seeds[i];

            return answers;
        }
    }
}
