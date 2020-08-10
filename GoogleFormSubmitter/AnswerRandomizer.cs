using System;
using System.Collections.Generic;

namespace GoogleFormSubmitter
{
    public class AnswerRandomizer
    {
        private readonly Random random = new Random();

        public string Q1(int i)
        {
            if (i < 352)
                return "Huflit";

            if (i < 352 + 53)
                return "Tài chính MKT";

            if (i < 352 + 53 + 65)
                return "Đại học kinh tế";

            if (i < 352 + 53 + 65 + 30)
                return "Đại học Ngân Hàng";

            return Seeds.Universities[new Random().Next(0, Seeds.Universities.Length)];
        }

        public string Q2(int i) => GetFixedSingleAnswer(i, Seeds.Genders, new int[] { 216, 304 });

        public string Q3(int i) => GetFixedSingleAnswer(i, Seeds.StudentYears, new int[] { 78, 103, 141, 187, 11 });

        public string Q4(int i) => GetFixedSingleAnswer(i, Seeds.TrueFalse, new int[] { 493, 27 });

        public string[] Q5(int i)
        {
            List<string> answers = new List<string>();

            if (i < 489)
                answers.Add(Seeds.Q5[0]);

            if (i < 449)
                answers.Add(Seeds.Q5[1]);

            if (i >= 520 - 283)
                answers.Add(Seeds.Q5[2]);

            if (i >= 520 - 371)
                answers.Add(Seeds.Q5[3]);

            if (i >= 520 - 46)
                answers.Add(Seeds.Q5[4]);

            return answers.ToArray();
        }

        public string Q6(int i) => GetFixedSingleAnswer(i, Seeds.Q6, new int[] { 105, 286, 97, 25, 7 });

        public string[] Q7(int i)
        {
            List<string> answers = new List<string>();

            if (i < 499)
                answers.Add(Seeds.Q7[0]);

            if (i < 424)
                answers.Add(Seeds.Q7[1]);

            if (i < 191)
                answers.Add(Seeds.Q7[2]);

            if (i >= 520 - 455)
                answers.Add(Seeds.Q7[3]);

            if (i >= 520 - 33) // TODO: fix later
                answers.Add(Seeds.Q7[4]);

            return answers.ToArray();
        }

        public string Q8(int i) => GetFixedSingleAnswer(i, Seeds.Q8, new int[] { 417, 103 });

        public string Q9(int i) => GetFixedSingleAnswer(i, Seeds.Q9, new int[] { 313, 76, 48, 25, 31, 11, 9, 7 });

        public string Q10(int i) => GetFixedSingleAnswer(i, Seeds.Q10, new int[] { 95, 87, 257, 53, 28 });

        public string Q11_1(int i) => GetFixedSingleAnswer(i, Seeds.ArgeeDisagree, new int[] { 78, 298, 121, 15, 8 });

        public string Q11_2(int i) => GetFixedSingleAnswer(i, Seeds.ArgeeDisagree, new int[] { 92, 171, 216, 34, 7 });

        public string Q11_3(int i) => GetFixedSingleAnswer(i, Seeds.ArgeeDisagree, new int[] { 65, 159, 203, 53, 40 });

        public string Q11_4(int i) => GetFixedSingleAnswer(i, Seeds.ArgeeDisagree, new int[] { 88, 235, 151, 32, 14 });

        public string[] Q12(int i)
        {
            List<string> answers = new List<string>();

            if (i < 362)
                answers.Add(Seeds.Q12[0]);

            if (i < 379)
                answers.Add(Seeds.Q12[1]);

            if (i < 221)
                answers.Add(Seeds.Q12[2]);

            if (i >= 520 - 204)
                answers.Add(Seeds.Q12[3]);

            if (i >= 520 - 214)
                answers.Add(Seeds.Q12[4]);

            if (i >= 520 - 22)
                answers.Add(Seeds.Q12[5]);

            return answers.ToArray();
        }

        public string[] Q13(int i)
        {
            List<string> answers = new List<string>();

            if (i < 413)
                answers.Add(Seeds.Q13[0]);

            if (i < 269)
                answers.Add(Seeds.Q13[1]);

            if (i < 188)
                answers.Add(Seeds.Q13[2]);

            if (i >= 520 - 395)
                answers.Add(Seeds.Q13[3]);

            if (i >= 520 - 45) // TODO: Fix later
                answers.Add(Seeds.Q13[4]);

            return answers.ToArray();
        }

        public string Q14_1(int i) => GetFixedSingleAnswer(i, Seeds.Q14, new int[] { 104, 164, 108, 95, 48 });

        public string Q14_2(int i) => GetFixedSingleAnswer(i, Seeds.Q14, new int[] { 89, 157, 114, 90, 69 });

        public string Q14_3(int i) => GetFixedSingleAnswer(i, Seeds.Q14, new int[] { 110, 148, 116, 94, 52 });

        public string Q14_4(int i) => GetFixedSingleAnswer(i, Seeds.Q14, new int[] { 92, 131, 116, 114, 67 });

        public string Q14_5(int i) => GetFixedSingleAnswer(i, Seeds.Q14, new int[] { 106, 140, 124, 89, 62 });

        public string Q14_6(int i) => GetFixedSingleAnswer(i, Seeds.Q14, new int[] { 115, 157, 104, 85, 58 });

        public string Q14_7(int i) => GetFixedSingleAnswer(i, Seeds.Q14, new int[] { 100, 154, 115, 95, 55 });

        public string Q15_1(int i) => GetFixedSingleAnswer(i, Seeds.ArgeeDisagree, new int[] { 75, 207, 174, 52, 12 });

        public string Q15_2(int i) => GetFixedSingleAnswer(i, Seeds.ArgeeDisagree, new int[] { 110, 215, 151, 70, 25 });

        public string Q15_3(int i) => GetFixedSingleAnswer(i, Seeds.ArgeeDisagree, new int[] { 94, 161, 145, 101, 18 });

        public string Q15_4(int i) => GetFixedSingleAnswer(i, Seeds.ArgeeDisagree, new int[] { 89, 148, 141, 114, 28 });


        public string GetFixedSingleAnswer(int i, string[] seeds, int[] limits)
        {
            int j = 0;
            for(int k = 0; k < limits.Length; k++)
            {
                j += limits[k];
                if (i < j)
                    return seeds[k];
            }
            return "error";
        }

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
