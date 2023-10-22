using UnityEngine;

public class Customer : MonoBehaviour, ICustomer
{
    [SerializeField, Range(-100, 100)] private int reputation;

    public int Reputation => reputation;
}