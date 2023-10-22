using UnityEngine;

public class ShotGun : GunWithClip
{
    [SerializeField, Range(0, 90)] private float angleSpread;

    public override bool CanShoot => CurrentClipSize >= 3;

    public override void Shoot()
    {
        CurrentClipSize -= 3;
        
        float angel = angleSpread / 2;

        Pool.Get();
        
        Bullet bullet1 = Pool.Get();
        bullet1.transform.Rotate(new Vector3(0, -angel, 0));
        
        Bullet bullet2 = Pool.Get();
        bullet2.transform.Rotate(new Vector3(0, angel, 0));
    }
}