using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using src.Classes;

namespace SolarWinds.MSP.Chess
{
    public class ChessPieceFactory
    {
        public ChessPiece CreateChessPiece(PieceType pieceType, PieceColor pieceColor)
        {
            switch (pieceType)
            {
                case PieceType.Pawn:
                    return new Pawn(pieceColor);
                default:
                    var pieceName = Enum.GetName(pieceType);
                    throw new NotImplementedException($"{pieceName} is not implemented.");
            }
        }
    }
}
