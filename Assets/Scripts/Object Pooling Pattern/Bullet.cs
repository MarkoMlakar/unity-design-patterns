using System.Collections;
using UnityEngine;

namespace Object_Pooling_Pattern
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float destructionTime;

        public void Shoot(Vector3 direction, float shootForce)
        {
            rb.AddForce(direction.normalized * shootForce,ForceMode.Impulse);
            StartCoroutine(DelayedDestroy());
        }

        private IEnumerator DelayedDestroy()
        {
            yield return new WaitForSeconds(destructionTime);
            Destroy(gameObject);
        }
    }
}
