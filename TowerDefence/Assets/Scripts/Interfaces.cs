using UnityEngine;

namespace Tower
{
    public interface IObjectPool
    {
        public GameObject GetObject(string Type);
    }

    public interface IReturnPool
    {
        public void ReturnObject(GameObject obj, string type);
    }

    public interface IDamagable
    {
        public void Damage(float damage);
    }
}
