using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace src.Classes
{
    public class ChessCoordinates
    {
        private int _x;
        private int _y;
        public ChessCoordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X
        {

            get => _x;

            set
            {
                if (value is >= 0 and <= 7)
                {
                    _x = value;
                }
            }
        }

        public int Y
        {
            get => _y;

            set
            {
                if (value is >= 0 and <= 7)
                {
                    _y = value;
                }
            }
        }

        public override string ToString() => $"(X: {X}, Y: {Y})";
    }
}
