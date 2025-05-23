using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core.Pieces
{
    public class Rook : ChessPiece
    {
        public override List<Vector2Int> GetPossibleMoves()
        {
            Debug.Log("GetPossibleMoves");
            var possibleMoves = new List<Vector2Int>();

            foreach (var direction in orthogonalDirections)
            {
                var current = boardPosition + direction;
                Debug.Log("Hey");
                while (MoveUtility.IsInsideBoard(current))
                {
                    Debug.Log("Hey");
                    if (!MoveUtility.TryAddMove(current, ref possibleMoves, this))
                        break;

                    current += direction;
                }
            }

            return possibleMoves;
        }
    }
}