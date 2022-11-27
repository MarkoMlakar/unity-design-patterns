using System.Collections;
using Managers;
using UnityEngine;
using UnityEngine.Pool;

namespace Object_Pooling_Pattern
{
    public class Bullet : MonoBehaviour
    {
        public Rigidbody rb;
        [SerializeField] private float destructionTime;
        [SerializeField] private AudioClip bulletSound;

        private IObjectPool<Bullet> bulletPool;

        public void SetPool(IObjectPool<Bullet> pool)
        {
            bulletPool = pool;
        }

        public void Shoot(Vector3 direction, float shootForce)
        {
            rb.AddForce(direction.normalized * shootForce,ForceMode.Impulse);
            AudioManager.Instance.PlayClip(bulletSound);
            StartCoroutine(DelayedDestroy());
        }

        private IEnumerator DelayedDestroy()
        {
            yield return new WaitForSeconds(destructionTime);
            bulletPool.Release(this);
        }
    }
}
