using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;
using UnityEngine.Pool;

namespace Object_Pooling_Pattern
{
    public class BulletSpawner : MonoBehaviour
    {
        [Header("Bullet")] 
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform bulletPivot;
        [SerializeField] private float shootingSpread;
        [SerializeField] private float shootForce;
        [SerializeField] private GameObject poolObject;
        [Header("Input controls")]
        [SerializeField] private PlayerInput playerInput;
        private Vector3 shootDirection;
        private InputAction shootAction;
        private RaycastHit hit;
        private Ray ray;
        private Camera cam;
        private Vector3 targetPoint;
        
        // Pooling
        private IObjectPool<Bullet> bulletPool;

        private void Awake()
        {
           // bulletPool = new ObjectPool<Bullet>(CreateBullet);
        }

        private void Start()
        {
            shootAction = playerInput.actions["Shoot"];
            cam = Camera.main;
        }

        private void Update()
        {
            if (shootAction.WasPerformedThisFrame())
            {
                ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                if (Physics.Raycast(ray, out hit))
                {
                    targetPoint = hit.point;
                }
                else
                {
                    targetPoint = ray.GetPoint(50);
                }

                shootDirection = targetPoint - bulletPivot.position;
                float x = Random.Range(-shootingSpread, shootingSpread);
                float y = Random.Range(-shootingSpread, shootingSpread);
                shootDirection += new Vector3(x, y, 0);

                GameObject bullet = Instantiate(bulletPrefab, bulletPivot.position, 
                    quaternion.identity,poolObject.transform);
                bullet.GetComponent<Bullet>().Shoot(shootDirection,shootForce);
            }
        }


    }
}
