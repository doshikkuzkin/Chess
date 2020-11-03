using UnityEngine;
using UnityEngine.Serialization;

namespace Chess
{
    [CreateAssetMenu(fileName = "MoveModel", menuName = "Chess/MoveModel", order = 0)]
    public class MoveModel : ScriptableObject
    {
        [SerializeField] private float deltaX;
        [SerializeField] private float deltaZ;
        [SerializeField] private bool canSwapDelta;
        [SerializeField] private bool forwardOnly;
        [SerializeField] private bool moveDiagonally;
        [SerializeField] private bool moveVertOrHor;

        public bool CanMove(Vector3 startPosition, Vector3 endPosition)
        {
            float moveX = Mathf.Abs(endPosition.x - startPosition.x);
            float moveZ = endPosition.z - startPosition.z;

            if (forwardOnly)
            {
                if (moveZ <= 0)
                {
                    return false;
                }
                if (moveX != 0)
                {
                    return false;
                }

                if (moveZ == deltaZ) return true;

                return false;
            }

            moveZ = Mathf.Abs(moveZ);

            if (moveDiagonally)
            {
                if (moveX == moveZ)
                    return true;
            }
            
            if (canSwapDelta)
            {
                if ((moveX == deltaX && moveZ == deltaZ) || moveX == deltaZ && moveZ == deltaX)
                {
                    return true;
                }
            }
            
            if (moveVertOrHor)
            {
                if ((moveX == 0 && moveZ >= deltaZ) || (moveZ == 0 && moveX >= deltaX))
                {
                    return true;
                }
            }

            return false;
        }
    }
}