using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice.Simple
{
    public class SimpleCalculator
    {
        public int Add(int _a, int _b) => _a + _b;
        public int Sub(int _a, int _b) => _a - _b;
        public int Mul(int _a, int _b) => _a * _b;
        public int Div(int _a, int _b)  
        {
            if (_b == 0) throw new ArgumentException();
            if (_b == int.MinValue || _a == int.MinValue) throw new ArgumentException();
            return _a / _b;
        }
        public char Cota(int note)
        {
            if (note >= 90 && note <= 100) return 'A';
            if (note >= 70 && note < 90) return 'B';
            if (note >= 60 && note < 70) return 'C';
            if (note >= 50 && note < 60) return 'D';
            if (note >= 0 && note < 50) return 'F';

            throw new ArgumentException();
        }
    }
}
