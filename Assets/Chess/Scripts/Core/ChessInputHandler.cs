using UnityEngine;
using Chess.Scripts.Core;

namespace Chess.Scripts.Core
{
    public class ChessInputHandler : MonoBehaviour
    {
        [SerializeField] private Vector2 boardOrigin = new Vector2(-4f,-4f);
        private float tileSize;

        private void Start()
        {
            tileSize = ChessBoardPlacementHandler.Instance.GetTileSize();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleClick();
            }
        }

        private void HandleClick()
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 relativePos = mouseWorldPos - boardOrigin;

            int col = Mathf.FloorToInt(relativePos.x / tileSize);
            int row = Mathf.FloorToInt(relativePos.y / tileSize);

            if (!IsWithinBoard(row, col)) return;

            Vector2Int clickedPosition = new Vector2Int(row, col);
            Debug.Log($"Clicked tile at ({row}, {col})");

            ChessPiece[] allPieces = FindObjectsOfType<ChessPiece>();
            ChessPiece selectedPiece = null;

            foreach (var piece in allPieces)
            {
                if (piece.boardPosition == clickedPosition)
                {
                    selectedPiece = piece;
                    break;
                }
            }

            if (selectedPiece != null)
            {
                if (!selectedPiece.isEnemy)
                {
                    SelectPiece(selectedPiece);
                }
            }
            else
            {
                ChessBoardPlacementHandler.Instance.ClearHighlights();
            }
        }

        private bool IsWithinBoard(int row, int col)
        {
            return row >= 0 && row < 8 && col >= 0 && col < 8;
        }

        private void SelectPiece(ChessPiece piece)
        {
            Debug.Log(piece);
            ChessPieceHighlighter.HighlightPossibleMoves(piece);
        }
    }
}