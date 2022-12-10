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
        public static Action<string> OnFirstShoot;
        [Header("Bullet")] 
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform bulletPivot;
        [SerializeField] private float shootingSpread;
        [SerializeField] private float shootForce;
        [SerializeField] private GameObject poolObject;
        [SerializeField] private TextAsset instructions;
        [Header("Input controls")]
        [SerializeField] private PlayerInput playerInput;
        private Vector3 shootDirection;
        private InputAction shootAction;
        private RaycastHit hit;
        private Ray ray;
        private Camera cam;
        private Vector3 targetPoint;
        private bool isFirstShoot = true;
        
        // Pooling
        private IObjectPool<Bullet> bulletPool;

        private void Awake()
        {
           bulletPool = new ObjectPool<Bullet>(CreateBullet, OnGet, OnRelease,OnDestroyPoolObject,maxSize:20, defaultCapacity:5);
        }


        private void Start()
        {
            shootAction = playerInput.actions["Shoot"];
            cam = Camera.main;
        }

        private void Update()
        {
            if (!shootAction.WasPerformedThisFrame()) return;
            
            if(isFirstShoot)
                OnFirstShoot?.Invoke(instructions.text);
            
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

            bulletPool.Get().Shoot(shootDirection,shootForce);
            isFirstShoot = false;
        }

        private Bullet CreateBullet()
        {
            Bullet bullet = Instantiate(bulletPrefab, bulletPivot.position, 
                quaternion.identity,poolObject.transform).GetComponent<Bullet>();
            bullet.SetPool(bulletPool);
            return bullet;
        }
        
        private void OnRelease(Bullet obj)
        {
            obj.rb.isKinematic = true;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = quaternion.identity;
            obj.gameObject.SetActive(false);
        }

        private void OnGet(Bullet obj)
        {
            obj.rb.isKinematic = false;
            obj.gameObject.SetActive(true);
        }

        private void OnDestroyPoolObject(Bullet obj)
        {
            Destroy(obj.gameObject);
        }
    }
}
