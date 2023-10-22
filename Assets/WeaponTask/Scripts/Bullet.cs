using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]

public class Bullet : MonoBehaviour
{
    [SerializeField, Range(10, 100)] private float speed;
    [SerializeField, Range(0.01f, 1)] private float lifeTime;

    private ObjectPool<Bullet> _pool;
    private Rigidbody _rigidbody;

    private void OnEnable()
    {
        StartCoroutine(Countdown());
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.TryGetComponent<Bullet>(out var bullet)) return;
    //     
    //     StopCoroutine(Countdown());
    //     _pool.Release(this);
    // }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = speed * transform.forward;
    }

    public void SetPool(ObjectPool<Bullet> pool) => _pool = pool;

    public IEnumerator Countdown()
    {
        yield return new WaitForSeconds(lifeTime);
        _pool.Release(this);
        yield return null;
    }
}