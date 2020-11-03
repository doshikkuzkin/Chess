using System;
using System.Collections.Generic;
using UnityEngine;

namespace Chess
{
    [CreateAssetMenu(fileName = "Board", menuName = "Chess/Board", order = 0)]
    public class Board : ScriptableObject
    {
        [SerializeField] private List<Row> rows = new List<Row>();

        private readonly int cellsCount = 64;

        public Vector3[] GetCells()
        {
            List<Vector3> coords = new List<Vector3>();

            foreach (var row in rows)
            {
                coords.AddRange(row.GetCellsCoords());
            }

            return coords.ToArray();
        }

        public Row GetRow(int index)
        {
            return rows[index];
        }

        public int GetRowCount()
        {
            return rows.Count;
        }
    }
}