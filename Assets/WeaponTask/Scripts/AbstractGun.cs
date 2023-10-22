using UnityEngine;
using UnityEngine.Pool;

public abstract class AbstractGun : MonoBehaviour, IGun
{
    [SerializeField] protected Bullet bulletPrefab;
    [SerializeField] protected Transform bulletSpawnPoint;
    
    protected ObjectPool<Bullet> Pool;

    protected virtual void Awake()
    {
        Pool = new ObjectPool<Bullet>(
            CreateBullet,
            OnGetBullet,
            OnReleaseBullet,
            OnDestroyBullet,
            true,
            10,
            100
        );
    }

    public abstract void Shoot();

    public abstract void Reload();

    public abstract bool CanShoot { get; }
    public bool TryShoot()
    {
        if (CanShoot)
        {
            Shoot();
            return true;
        }
        return false;
    }

    protected Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(
            bulletPrefab,
            bulletSpawnPoint.position,
            bulletSpawnPoint.rotation
        );

        bullet.SetPool(Pool);
        
        return bullet;
    }

    protected void OnGetBullet(Bullet bullet)
    {
        Transform bulletTransform = bullet.transform;
        
        bulletTransform.position = bulletSpawnPoint.position;
        bulletTransform.rotation = bulletSpawnPoint.rotation;
        
        bullet.gameObject.SetActive(true);
    }

    protected void OnReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    protected void OnDestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
}