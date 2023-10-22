using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class NPC : MonoBehaviour
{
    [SerializeField] private int minimalReputation;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out ICustomer customer)) return;
        
        if (Check(customer))
            Sell();
        else
            Debug.Log("Go away! U little twat!");
    }

    protected virtual bool Check(ICustomer customer) => customer.Reputation >= minimalReputation;

    protected abstract void Sell();
}
