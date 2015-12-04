using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillCompetition104 {
    public class Problem2 {
        public static void Run_1(string InputPath, string OutputPath) {
            StreamReader reader = new StreamReader(InputPath);
            StreamWriter writer = new StreamWriter(OutputPath);

            #region 主流程區段
            int InputLineCount = int.Parse(reader.ReadLine());//取得輸入資料數量            
            for(int i = 0; i < InputLineCount; i++) {
                writer.WriteLine(Taxi(double.Parse(reader.ReadLine())));
            }
            #endregion

            reader.Close();
            writer.Close();
        }

        private static int Taxi(double Length) {
            if ((Length-=1.5) <= 0) return 85;
            return 85 + (int)Math.Ceiling(Length / 0.25) * 5;
        }
        
        public static void Run_2(string InputPath, string OutputPath) {
            StreamReader reader = new StreamReader(InputPath);
            StreamWriter writer = new StreamWriter(OutputPath);

            #region 主流程區段
            int InputLineCount = int.Parse(reader.ReadLine());//取得輸入資料數量            
            for (int i = 0; i < InputLineCount; i++) {
                writer.WriteLine(IsPalindrome(reader.ReadLine()));
            }
            #endregion

            reader.Close();
            writer.Close();
        }

        private static bool IsPalindrome(string Value) {
            return new string(Value.Reverse().ToArray()) == Value;
        }
    }
}
