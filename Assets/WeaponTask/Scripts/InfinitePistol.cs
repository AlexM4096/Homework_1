public class InfinitePistol : AbstractGun
{
    public override bool CanShoot => true;

    public override void Shoot()
    {
        Pool.Get();
    }

    public override void Reload() {}
}