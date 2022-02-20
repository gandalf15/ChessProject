using System;
using src.Classes;

namespace SolarWinds.MSP.Chess
{
    public class Pawn : ChessPiece
    {
        private ChessCoordinates _coordinates;
        private PieceColor _pieceColor;

        public Pawn(PieceColor pieceColor) : base(pieceColor)
        {
        }

        public ChessCoordinates Coordinate { get; set; }

        public override bool Move(MovementType movementType, int newX, int newY)
        {
            throw new NotImplementedException("Need to implement Pawn.Move()");
        }

    }
}
