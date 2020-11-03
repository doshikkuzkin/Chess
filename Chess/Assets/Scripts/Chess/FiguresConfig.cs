using System.Linq;
using UnityEngine;

namespace Chess
{
    [CreateAssetMenu(fileName = "FiguresConfig", menuName = "Chess/FiguresConfig", order = 0)]
    public class FiguresConfig : ScriptableObject
    {
        [SerializeField] private Figure[] whiteFigures;
        [SerializeField] private Figure[] blackFigures;

        public Figure GetFigureByType(FigureType type, FigureColor color)
        {
            switch (color)
            {
                case FigureColor.Black:
                    return FindFigureByType(blackFigures, type);
                case FigureColor.White:
                    return FindFigureByType(whiteFigures, type);
            }

            return null;
        }

        public Figure GetFigureByPos(float posInRow, FigureColor type)
        {
            switch (type)
            {
                case FigureColor.Black:
                    return FindFigureByPos(blackFigures, posInRow);
                case FigureColor.White:
                    return FindFigureByPos(whiteFigures, posInRow);
            }

            return null;
        }

        private Figure FindFigureByPos(Figure[] array, float posInRow)
        {
            foreach (var figure in array)
            {
                if (figure.RowPosition == posInRow)
                {
                    return figure;
                }
            }

            return null;
        }

        private Figure FindFigureByType(Figure[] array, FigureType type)
        {
            var fgr = array.FirstOrDefault(figure => figure.Type == type);
            return fgr != null ? fgr : null;
        }
    }
}