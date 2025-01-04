namespace ProcedureTestTasks
{
    public static class TaskExecutor
    {
        public static string[] FindWords(string[] words)
        {
            if (words.Length == 0 || words == null)
            {
                throw new NotSupportedException("null or empty array");
            }
            string firstRow = "qwertyuiop";
            string secondRow = "asdfghjkl";
            int countFirst = 0;
            int countSecond = 0;
            int countThird = 0;
            string result = "";
            for (int i = 0; i < words.Length; i++)
            {
                countFirst = 0;
                countSecond = 0;
                countThird = 0;
                foreach (char letter in words[i])
                {
                    if (firstRow.Contains(letter))
                    {
                        countFirst++;
                    }
                    else if (secondRow.Contains(letter))
                    {
                        countSecond++;
                    }
                    else
                    {
                        countThird++;
                    }
                }
                if (TwoAreZeros(ref countFirst, ref countSecond, ref countThird))
                {
                    result = i != 0? $"{result}|{words[i]}" : words[i];
                }
            }
            return result.Split("|");
        }

        public static bool TwoAreZeros(ref int num1, ref int num2, ref int num3)
        {
            return (num1 == 0 & num2 == 0) || (num1 == 0 & num3 == 0) || (num2 == 0 & num3 == 0);
        }
        public static int GetCountUniqueEmails(string[] emails)
        {
            int count = 0;
            int indexOfPlus = 0;
            int indexOfAt = 0;
            for (int i = 0; i < emails.Length; i++)
            {
                emails[i] = emails[i].Trim('.');
                if (emails[i].Contains("+"))
                {
                    indexOfPlus = emails[i].IndexOf("+");
                    indexOfAt = emails[i].IndexOf("@");
                    emails[i] = emails[i].Substring(0, indexOfPlus) + emails[i].Substring(indexOfAt);
                }

            }
            for (int i = 0; i < emails.Length; i++)
            {
                for (int j = 0; j < emails.Length; j++)
                {
                    if (emails[i] == emails[j] && j != i)
                    {
                        count++;
                    }
                }
            }
            return emails.Length - count;
        }
        public static int[] Intersection(int[] nums1, int[] nums2)
        {
            int count7 = 0;
            string result = "";
            for(int i = 0; i < nums1.Length; i++)
            {
                if (nums1[i] % 7 == 0)
                {
                    count7++;
                }
                for(int j = 0;j < nums2.Length; j++)
                {
                    if (nums1[i] == nums2[j])
                    {
                        result = result == "" ? nums2[i].ToString() : $"{result} {nums1[i]}";
                    }
                }
            }
            if (count7 == 0)
            {
                throw new Exception("В первом массиве отсутствуют элементы кратные 7");
            }
            var resultStringArray = result.Split();
            int[] resultIntArray = new int[resultStringArray.Length];
            for(int i = 0; i < resultIntArray.Length; i++)
            {
                resultIntArray[i] = int.Parse(resultStringArray[i]);
            }
            return resultIntArray;
        }   
    }
}
