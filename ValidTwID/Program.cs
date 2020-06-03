using System;
using System.Text.RegularExpressions;

namespace ValidTwID
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入要驗證的身分證字號(英文字母大寫):");
            var IdNumber = Console.ReadLine();
            var result = IsValidId(IdNumber);
            Console.WriteLine($"驗證結果為:{result}");
            Console.ReadKey();
        }

        public static bool IsValidId(string Id)
        {
            var flag = false;
            //正規檢查字串格式
            if (Regex.IsMatch(Id, @"^[A-Z]{1}[1-2]{1}[0-9]{8}$"))
            {
                //身分證字號開頭應文字母代表的值先列出來放在Array中
                var idnum = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 34, 18, 19, 20, 21, 22, 35, 23, 24, 25, 26, 27, 28, 29, 32, 30, 31, 33 };
                //身份證字號原為Length=10的字串，經過英文字母轉換成數字後變成Length=11的陣列
                var resultNum = new int[11];
                //英文字串做運算，會變成ASCII的數值，從65開始為數字
                resultNum[1] = idnum[(Id[0]) - 65] % 10;
                var numSum = resultNum[0] = idnum[(Id[0]) - 65] / 10;

                for (var i = 1; i <= 9; i++)
                {
                    //數字字串做運算，會變成ASCII的數值，從48開始為數字
                    resultNum[i + 1] = Id[i] - 48;
                    numSum += resultNum[i] * (10 - i);
                }
                //最後一碼檢查碼驗證
                flag = ((numSum % 10) + resultNum[10]) % 10 == 0;
            }
            return flag;
        }
    }
}
