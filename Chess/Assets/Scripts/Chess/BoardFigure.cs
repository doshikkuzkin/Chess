using UnityEngine;

namespace Chess
{
    public class BoardFigure : MonoBehaviour
    {
        [SerializeField] private Figure figure;

        public void Setup(Figure reference)
        {
            figure = reference;
        }
    }
}