using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillCompetition104 {
    public class Problem1 {
        public static void Run_1(string InputPath, string OutputPath) {
            StreamReader reader = new StreamReader(InputPath);
            StreamWriter writer = new StreamWriter(OutputPath);

            #region 主流程區段
            int InputLineCount = int.Parse(reader.ReadLine());//取得輸入資料數量            
            for(int i = 0; i < InputLineCount; i++) {
                Dictionary<int, int> ItemResult = Factorization(int.Parse(reader.ReadLine()));
                writer.WriteLine(string.Join(" ",ItemResult.Select(item => $"{item.Key}^{item.Value}")));
            }
            #endregion

            reader.Close();
            writer.Close();
        }

        private static Dictionary<int,int> Factorization(int Value) {
            Dictionary<int, int> result = new Dictionary<int, int>() { [Value] = 1};
            int i = 2;
            while(Value > 1) {
                if (Value % i > 0) {
                    i++;continue;
                }
                if (!result.ContainsKey(i))result[i] = 0;
                result[i]++;
                Value /= i;
            }
            if (result.Count > 1) result.Remove(result.Keys.Max());//輸入非質數
            return result;
        }

        public static void Run_2(string InputPath, string OutputPath) {
            StreamReader reader = new StreamReader(InputPath);
            StreamWriter writer = new StreamWriter(OutputPath);

            #region 主流程區段
            int InputLineCount = int.Parse(reader.ReadLine());//取得輸入資料數量            
            for (int i = 0; i < InputLineCount; i++) {
                writer.WriteLine(ZeroCount(int.Parse(reader.ReadLine())));
            }
            #endregion

            reader.Close();
            writer.Close();
        }

        private static int ZeroCount(int Level,int TempValue=1) {//Level 目標階層,上一層遺留數字
            if (Level <= 1)return 0;
            int Value = Level * TempValue,result = 0;
            while(Value % 10 == 0) {
                result++;
                Value /= 10;
            }
            return result + ZeroCount(Level - 1, (int)(Value % Math.Pow(10,Math.Floor(Math.Log10(Level)+ 1))));
        }
    }
}
