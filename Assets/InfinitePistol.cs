public class InfinitePistol : AbstractGun
{
    public override void Shoot()
    {
        Bullet bullet = Pool.Get();
    }
}