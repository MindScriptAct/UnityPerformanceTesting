using UnityEngine;

namespace Assets.Scripts.Utils
{
    static class GameObjectExtensions
    {
        public static GameObject InstantiateChild(this GameObject parent, GameObject original)
        {
            GameObject clone = Object.Instantiate(original);
            clone.transform.parent = parent.transform;
            return clone;
        }

        public static GameObject InstantiateChild(this GameObject parent, GameObject original, Vector3 position, Quaternion rotation)
        {
            GameObject clone = Object.Instantiate(original, position, rotation);
            clone.transform.parent = parent.transform;
            return clone;
        }
    }
}
