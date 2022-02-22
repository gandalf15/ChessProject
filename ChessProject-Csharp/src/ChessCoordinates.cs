using System;

namespace SolarWinds.MSP.Chess
{
    /// <summary>
    /// 2D chess coordinates from 0 up to 7 (8 positions) in both dimensions.
    /// </summary>
    public class ChessCoordinates
    {
        private int _x;
        private int _y;
        
        /// <summary>
        /// Creates ChessCoordinates
        /// </summary>
        /// <param name="x">X dimension or row.</param>
        /// <param name="y">Y dimension or column.</param>
        public ChessCoordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets X coordinate.
        /// </summary>
        public int X
        {

            get => _x;

            set
            {
                if (value is >= 0 and <= 7)
                {
                    _x = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "X coordinate must be in the range from 0 to 7.");
                }
            }
        }

        /// <summary>
        /// Gets Y coordinate.
        /// </summary>
        public int Y
        {
            get => _y;

            set
            {
                if (value is >= 0 and <= 7)
                {
                    _y = value;
                } 
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Y coordinate must be in the range from 0 to 7.");
                }
            }
        }

        /// <summary>
        /// Textual representation of a ChessCoordinates.
        /// </summary>
        /// <returns>String description of ChessCoordinates.</returns>
        public override string ToString() => $"(X: {X}, Y: {Y})";
    }
}
