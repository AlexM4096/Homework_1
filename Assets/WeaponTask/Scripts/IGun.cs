public interface IGun
{
    void Shoot();
    void Reload();
    bool CanShoot { get; }
    bool TryShoot();
}