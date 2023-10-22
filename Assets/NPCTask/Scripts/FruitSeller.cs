using UnityEngine;

public class FruitSeller : NPC
{
    protected override void Sell()
    {
        Debug.Log("Good purchase my friend! U bought some fruits!");
    }
}