using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bag : MonoBehaviour
{
    private int amountKey;
    public UnityEvent ChangeAmountKey;
    public void Add(int amount)
    {
        amountKey += amount;
        ChangeAmountKey.Invoke();
    }

    public bool DrawKey(int amount)
    {
        if (amountKey - amount < 0) return false;

        amountKey -= amount;
        ChangeAmountKey.Invoke();
        return true;
    }

    public int GetAmountKey()
    {
        return amountKey;
    }
}
