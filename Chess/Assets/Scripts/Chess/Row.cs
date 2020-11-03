using System.Linq;
using UnityEngine;

namespace Chess
{
    [CreateAssetMenu(fileName = "Row", menuName = "Chess/Row", order = 0)]
    public class Row : ScriptableObject
    {
        [SerializeField] private Cell[] cells;

        public Vector3[] GetCellsCoords()
        {
            return cells.Select(cell => cell.Coords).ToArray();
        }
    }
}