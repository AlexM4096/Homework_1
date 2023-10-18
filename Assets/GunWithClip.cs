using UnityEngine;

public abstract class GunWithClip : AbstractGun
{ 
    [SerializeField, Range(1, 100)] protected int maxClipSize;
    protected int CurrentClipSize;

    public virtual bool CanShoot => CurrentClipSize > 0;

    public virtual void Reload()
    {
        CurrentClipSize = maxClipSize;
    }
}