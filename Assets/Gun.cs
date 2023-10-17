using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField, Range(1, 100)] protected int maxClipCapacity;
    protected int CurrentClipCapacity;

    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform bulletLauncher;
    
    protected GameObjectPool<Bullet> BulletPool;

    private void Awake()
    {
        Bullet bullet = bulletPrefab.GetComponent<Bullet>();
        BulletPool = new GameObjectPool<Bullet>(bullet, maxClipCapacity);
    }

    protected virtual bool CanShoot => CurrentClipCapacity > 0;

    public virtual bool TryShoot()
    {
        if (CanShoot)
        {
            Shoot();
            return true;
        }
        
        Debug.Log("I need more bullets! I need more bullets!");
        return false;
    }

    public virtual void Reload()
    {
        CurrentClipCapacity = maxClipCapacity;
    }

    public virtual void Shoot()
    {
        CurrentClipCapacity--;

        Bullet bullet = BulletPool.Get();
        bullet.Launch(bulletLauncher, 5, () => Debug.Log("Test"));
    }
}