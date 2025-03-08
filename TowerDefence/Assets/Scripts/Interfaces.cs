using UnityEngine;

namespace Tower
{
    public interface IObjectPool
    {
        public GameObject GetObject();
    }

    public interface IReturnPool
    {
        public void ReturnObject(GameObject obj);
    }

    public interface IDamagable
    {
        public void Damage(float damage, GameObject target);
    }
}
