using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillCompetition104 {
    public class Problem4 {
        public static void Run_1(string InputPath, string OutputPath) {
            StreamReader reader = new StreamReader(InputPath);
            StreamWriter writer = new StreamWriter(OutputPath);

            #region 主流程區段
            int InputLineCount = int.Parse(reader.ReadLine());//取得輸入資料數量            
            for (int i = 0; i < InputLineCount; i++) {
                int[] Data = (from t in reader.ReadLine().Split(' ') select int.Parse(t)).ToArray();
                List<List<int>> X = MPermutations(new List<int>(new int[] { -1, 1 }), Data.Length);
                bool OK = false;
                for(int j = 0; j < X.Count; j++) {
                    int Sum = 0;
                    for (int k = 0; k < X[j].Count; k++) Sum += Data[k] * X[j][k];
                    if (Sum == 0) OK = true;
                }
                writer.WriteLine(OK);
            }
            #endregion

            reader.Close();
            writer.Close();
        }

        private static List<List<int>> MPermutations(List<int> Data, int Count, List<List<int>> Temp = null) {
            if (Count == 0) return Temp;
            List<List<int>> NextLevelTemp = new List<List<int>>();
            if (Temp == null) {
                for (int i = 0; i < Data.Count; i++) {
                    List<int> NextLevelTempItem = new List<int>();
                    NextLevelTempItem.Add(Data[i]);
                    NextLevelTemp.Add(NextLevelTempItem);
                }
            } else {
                for (int i = 0; i < Temp.Count; i++) {
                    for (int j = 0; j < Data.Count; j++) {
                        List<int> NextLevelTempItem = new List<int>(Temp[i].ToArray());
                        NextLevelTempItem.Add(Data[j]);
                        NextLevelTemp.Add(NextLevelTempItem);
                    }
                }
            }
            return MPermutations(Data, Count - 1, NextLevelTemp);
        }

        public static void Run_2(string InputPath, string OutputPath) {
            StreamReader reader = new StreamReader(InputPath);
            StreamWriter writer = new StreamWriter(OutputPath);

            #region 主流程區段
            int InputLineCount = int.Parse(reader.ReadLine());//取得輸入資料數量            
            for (int i = 0; i < InputLineCount; i++) {
                var Sum = (from t in reader.ReadLine().Split(',') select int.Parse(new string(t.Reverse().ToArray()))).Sum();
                writer.WriteLine(int.Parse(new string(Sum.ToString().Reverse().ToArray())));
            }
            #endregion

            reader.Close();
            writer.Close();
        }
    }
}
