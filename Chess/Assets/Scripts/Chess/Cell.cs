using UnityEngine;

namespace Chess
{
    [System.Serializable]
    public class Cell
    {
        [SerializeField] private Vector3 coords;

        public Vector3 Coords => coords;
    }
}