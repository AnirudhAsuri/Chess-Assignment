using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core.Pieces
{
    public class Bishop : ChessPiece
    {
        public override List<Vector2Int> GetPossibleMoves()
        {
            var possibleMoves = new List<Vector2Int>();

            foreach (var direction in diagonalDirections)
            {
                var current = boardPosition + direction;

                while (IsInsideBoard(current))
                {
                    if (!TryAddMove(current, ref possibleMoves))
                        break;

                    current += direction;
                }
            }

            return possibleMoves;
        }
    }
}