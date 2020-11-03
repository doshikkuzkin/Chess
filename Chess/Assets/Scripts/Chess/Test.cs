using System;
using UnityEngine;

namespace Chess
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private Board board;

        private void Start()
        {
            foreach (var coords in board.GetCells())
            {
                Debug.Log(coords);
            }
        }
    }
}
