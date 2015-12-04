using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillCompetition104 {
    public class Node {
        public string Key { get; set; }
        public int Value { get; set; }
        public List<Node> Neighbor { get; set; } = new List<Node>();

        public void AddNeighbor(Node node) {
            this.Neighbor.Add(node);
            node.Neighbor.Add(this);
        }

        public void RemoveNeighbor(Node node) {
            this.Neighbor.Remove(node);
            node.Neighbor.Remove(this);
        }

        public bool IsNeighbor(Node node) => Neighbor.IndexOf(node) > -1;

        public Node Min { get; set; }
        public Node Max { get; set; }

        public void PullValue(int Value) {
            if (Value > this.Value) {
                if (Max == null) {
                    Max = new Node() { Value = Value };
                } else {
                    Max.PullValue(Value);
                }
            } else {
                if (Min == null) {
                    Min = new Node() { Value = Value };
                } else {
                    Min.PullValue(Value);
                }
            }
        }

        public int GetMaxLength() {
            if (Min == null && Max == null) return 1;
            int A = 1 + Max.GetMaxLength();
            int B = 1 + Max.GetMaxLength();

            return Math.Max(A, B);
        }

        public override bool Equals(object obj) {
            if (obj is string && obj == this.Key) return true;
            return obj is Node && ((Node)obj).Key == this.Key;
        }
    }

    public class Problem3 {
        public static void Run_1(string InputPath, string OutputPath) {
            StreamReader reader = new StreamReader(InputPath);
            StreamWriter writer = new StreamWriter(OutputPath);

            #region 主流程區段
            int InputLineCount = int.Parse(reader.ReadLine());//取得輸入資料數量            
            for(int i = 0; i < InputLineCount; i++) {
                writer.WriteLine(IsTree(reader.ReadLine().Split(' ').Select(item => item.Split(',')).ToArray()));
            }
            #endregion

            reader.Close();
            writer.Close();
        }

        private static bool IsTree(string[][] Data) {
            List<Node> map = new List<Node>();
            for(int i = 0; i < Data.Length; i++) {//初始化節點地圖
                Node A = map.Where(item => item.Key == Data[i][0]).FirstOrDefault();
                Node B = map.Where(item => item.Key == Data[i][1]).FirstOrDefault();

                if (A == null) {
                    A = new Node() { Key = Data[i][0] };
                    map.Add(A);
                }
                if (B == null) {
                    B = new Node() { Key = Data[i][1] };
                    map.Add(B);
                }
                A.AddNeighbor(B);
            }

            for(int i = 0; i < map.Count; i++) {
                if (HasLoop(map[i])) return true;
            }

            return false;
        }

        private static bool HasLoop(Node Start, Node Now = null, List<Node> History = null) {//檢查是否可以繞回原點
            if (History == null) History = new List<Node>();
            if (Now == null) Now = Start;
            History.Add(Now);
            foreach(var item in Now.Neighbor) {
                if (History.Count > 2 && item == Start) return true;
                if (History.IndexOf(item) > -1) continue;
                if (HasLoop(Start, item, new List<Node>(History.ToArray()))) return true;
            }
            return false;
        }
        
        public static void Run_2(string InputPath, string OutputPath) {
            StreamReader reader = new StreamReader(InputPath);
            StreamWriter writer = new StreamWriter(OutputPath);

            #region 主流程區段
            int InputLineCount = int.Parse(reader.ReadLine());//取得輸入資料數量
            Node root = new Node() { Value = int.Parse(reader.ReadLine()) };
            for (int i = 1 ; i < InputLineCount ; i++) {
                root.PullValue(int.Parse(reader.ReadLine()));
            }
            writer.WriteLine(root.GetMaxLength());
            #endregion

            reader.Close();
            writer.Close();
        }
    }
}
