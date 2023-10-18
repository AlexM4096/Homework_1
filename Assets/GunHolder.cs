using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunHolder : MonoBehaviour
{
    private List<AbstractGun> _guns;
    private int _currentIndex;

    private void Awake()
    {
        _guns = GetComponentsInChildren<AbstractGun>().ToList();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _guns[_currentIndex].Shoot();
        
    }
}