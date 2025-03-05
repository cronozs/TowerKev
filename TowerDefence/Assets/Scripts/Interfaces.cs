using UnityEngine;

namespace Tower
{
    public interface IObjectPool
    {
        public GameObject GetObject();
        public void ReturnObject(GameObject obj);
    }
}
