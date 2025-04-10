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

                while (MoveUtility.IsInsideBoard(current))
                {
                    if (!MoveUtility.TryAddMove(current, ref possibleMoves, this))
                        break;

                    current += direction;
                }
            }

            return possibleMoves;
        }
    }
}