using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Ball : MonoBehaviour
{
    [SerializeField] private BallType type;
    private bool isPoped;

    public BallType Type => type;
    public bool IsPoped => isPoped;
    
    public event Action Pop;

    private void OnMouseDown()
    {
        isPoped = true;
        OnPop();
        gameObject.SetActive(false);
    }

    private void OnPop()
    {
        Pop?.Invoke();
    }
}