using UnityEngine;

namespace Chess
{
    [CreateAssetMenu(fileName = "Figure", menuName = "Chess/Figure", order = 0)]
    public class Figure : ScriptableObject
    {
        [SerializeField] private FigureType type;
        [SerializeField] private FigureColor figureColor;
        [SerializeField] private GameObject prefab;
        [SerializeField] private float rowPosition;
        [SerializeField] private bool singleInRow;
        [SerializeField] private MoveModel moveModel;

        public float RowPosition => rowPosition;

        public GameObject Prefab => prefab;

        public FigureType Type => type;

        public bool SingleInRow => singleInRow;

        public FigureColor FigureColor => figureColor;

        public MoveModel MoveModel => moveModel;
    }
}