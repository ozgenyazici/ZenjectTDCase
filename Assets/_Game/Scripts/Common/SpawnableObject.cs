using UnityEngine;

namespace Zenject.TD
{
    public class SpawnableObject : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<Vector3, Transform, GameObject>
        {
        }
    }
}