using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarWinds.MSP.Chess
{
    public enum AddResult
    {
        Success,
        CoordinatesOccupied,
        MaxNumberReached,
        NotValidPositionForThisPiece
    }
}
