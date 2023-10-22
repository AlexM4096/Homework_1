using UnityEngine;

public abstract class GunWithClip : AbstractGun
{ 
    [SerializeField, Range(1, 100)] protected int maxClipSize;
    protected int CurrentClipSize;

    public override bool CanShoot => CurrentClipSize > 0;

    protected override void Awake()
    {
        base.Awake();

        CurrentClipSize = maxClipSize;
    }

    public override void Reload()
    {
        CurrentClipSize = maxClipSize;
    }
}