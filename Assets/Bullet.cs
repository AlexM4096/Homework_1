using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private bool _isLaunched;
    private float _lifeTime;
    private Action _onLifeTimeEnd;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_isLaunched)
        {
            _lifeTime -= Time.deltaTime;
            
            if (_lifeTime <= 0)
                _onLifeTimeEnd?.Invoke();
        }
    }

    public void Launch(Transform parentTransform, float lifeTime, Action onLifeTimeEnd)
    {
        _isLaunched = true;
        _lifeTime = lifeTime;
        _onLifeTimeEnd = onLifeTimeEnd;
        
        transform.position = parentTransform.position;
        _rigidbody.velocity = parentTransform.forward;
    }
}