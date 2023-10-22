using UnityEngine;

public class Pistol : GunWithClip
{
    public override void Shoot()
    {
        CurrentClipSize--;
        Pool.Get();
    }
}