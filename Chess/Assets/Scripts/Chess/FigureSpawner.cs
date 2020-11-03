using System;
using UnityEngine;

namespace Chess
{
    public class FigureSpawner : MonoBehaviour
    {
        [SerializeField] private FiguresConfig figuresConfig;
        [SerializeField] private Board board;

        private readonly int figuresInRow = 5;
        private void Start()
        {
            SpawnFiguresInRow(0, FigureColor.White);
            SpawnFiguresInRow(board.GetRowCount() - 1, FigureColor.Black);
        }

        private void SpawnFiguresInRow(int rowIndex, FigureColor figureColor)
        {
            var firstRow = board.GetRow(rowIndex).GetCellsCoords();
            for (int i = 0; i < figuresInRow; i++)
            {
                Figure figure = figuresConfig.GetFigureByPos(firstRow[i].x, figureColor);
                BoardFigure boardFigure = Instantiate(figure.Prefab, firstRow[i], Quaternion.identity)
                    .GetComponent<BoardFigure>();
                boardFigure.Setup(figure);
                if (!figure.SingleInRow)
                {
                    Instantiate(boardFigure, firstRow[firstRow.Length - i - 1], Quaternion.identity);
                }
            }

            var nextIndex = figureColor == FigureColor.White ? rowIndex + 1 : rowIndex - 1;
            var secondRow = board.GetRow(nextIndex).GetCellsCoords();
            var pawn = figuresConfig.GetFigureByType(FigureType.Pawn, figureColor);
            var pawnFigure = Instantiate(pawn.Prefab, secondRow[0], Quaternion.identity)
                .GetComponent<BoardFigure>();
            pawnFigure.Setup(pawn);
            for (int i = 1; i < secondRow.Length; i++)
            {
                Instantiate(pawnFigure, secondRow[i], Quaternion.identity);
            }
        }
    }
}