using System;
using System.Collections.Generic;
using System.Text;

namespace Powah
{
    public class PowahUser
    {
        public string UserName { get; set; }
        public int Age { get; set; }
        public int Weigth { get; set; }
        public int DeadliftMax { get; set; }
        public int FlatBenchMax { get; set; }
        public int SquatMax { get; set; }

        public PowahUser(string UserName, int Age, int Weigth, int DeadliftMax, int FlatBenchMax, int SquatMax)
        {
            this.UserName = UserName;
            this.Age = Age;
            this.Weigth = Weigth;
            this.DeadliftMax = DeadliftMax;
            this.FlatBenchMax = FlatBenchMax;
            this.SquatMax = SquatMax;
        }
    }
}
