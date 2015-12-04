using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillCompetition104 {
    class Program {
        static void Main(string[] args) {
            Problem1.Run_1("InputFiles/in1-1-1.txt","OutputFiles/out1-1-1.txt");
            Problem1.Run_1("InputFiles/in1-1-2.txt", "OutputFiles/out1-1-2.txt");
            Problem1.Run_2("InputFiles/in1-2-1.txt", "OutputFiles/out1-2-1.txt");
            Problem1.Run_2("InputFiles/in1-2-2.txt", "OutputFiles/out1-2-2.txt");

            Problem2.Run_1("InputFiles/in2-1-1.txt", "OutputFiles/out2-1-1.txt");
            Problem2.Run_1("InputFiles/in2-1-2.txt", "OutputFiles/out2-1-2.txt");
            Problem2.Run_2("InputFiles/in2-2-1.txt", "OutputFiles/out2-2-1.txt");
            Problem2.Run_2("InputFiles/in2-2-2.txt", "OutputFiles/out2-2-2.txt");

            Problem3.Run_1("InputFiles/in3-1-1.txt", "OutputFiles/out3-1-1.txt");
            Problem3.Run_1("InputFiles/in3-1-2.txt", "OutputFiles/out3-1-2.txt");
            Problem3.Run_2("InputFiles/in3-2-1.txt", "OutputFiles/out3-2-1.txt");
            Problem3.Run_2("InputFiles/in3-2-2.txt", "OutputFiles/out3-2-2.txt");

            Problem4.Run_1("InputFiles/in4-1-1.txt", "OutputFiles/out4-1-1.txt");
            Problem4.Run_1("InputFiles/in4-1-2.txt", "OutputFiles/out4-1-2.txt");
            Problem4.Run_2("InputFiles/in4-2-1.txt", "OutputFiles/out4-2-1.txt");
            Problem4.Run_2("InputFiles/in4-2-2.txt", "OutputFiles/out4-2-2.txt");
        }
    }
}
