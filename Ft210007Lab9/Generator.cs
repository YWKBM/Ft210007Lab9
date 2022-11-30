using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ft210007Lab9
{
    internal class Generator
    {

        public int range { get; set; }
        public List<int> response { get; private set; } //список сгенерированных чисел 
        private Random rnd = new Random();

        public Generator(int range)
        {
            this.range = range;
            this.response = new List<int>();
        }

        public int Generate()
        {
            int resp = rnd.Next(1, range); //генерация числа
            if (!response.Contains(resp))
            {
                response.Add(resp);
                return resp;
            }
            else
            {
                return Generate();
            }
        }

    }
}

