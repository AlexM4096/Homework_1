using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunHolder : MonoBehaviour
{
    private List<AbstractGun> _guns;
    private AbstractGun _currentGun;
    private int _currentIndex;

    private void Start()
    {
        _guns = GetComponentsInChildren<AbstractGun>().ToList();
        _currentGun = _guns[_currentIndex];

        foreach (var gun in _guns)
            gun.gameObject.SetActive(false);
        
        SwapWeapon();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bool shoot = _currentGun.TryShoot();

            Debug.Log(shoot ? "" : "I need more bullets! I need more bullets!");
        }
        
        if (Input.GetKeyDown(KeyCode.R))
            _currentGun.Reload();

        SwapWeapon();
    }

    private void SwapWeapon()
    {
        _currentGun.gameObject.SetActive(false);
        
        int delta = (int)Input.mouseScrollDelta.y;
        
        _currentIndex += delta;
        _currentIndex %= _guns.Count;

        if (_currentIndex < 0) _currentIndex += _guns.Count;

        _currentGun = _guns[_currentIndex];
        _currentGun.gameObject.SetActive(true);
    }
}