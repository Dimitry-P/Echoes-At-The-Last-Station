using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destructible : MonoBehaviour
{
    [SerializeField] private int maxHitPoints;

    [SerializeField] private int hitPoints;

    public UnityEvent Die;
    public UnityEvent ChangeHitPoints;

    private void Start()
    {
       
        hitPoints = maxHitPoints;
        ChangeHitPoints.Invoke();
    }


    public void ChargeStrength(int curePower)
    {
        if(hitPoints < maxHitPoints)
        {
            hitPoints += curePower;
            ChangeHitPoints.Invoke();
        }
    }

    public void ApplyDamage(int damage)
    {
        hitPoints -= damage;
        ChangeHitPoints.Invoke();
        if (hitPoints <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        hitPoints = 0;
        ChangeHitPoints.Invoke();
        Die.Invoke();
    }

    public int GetHitPoints()
    {
        return hitPoints;
    }

    public int GetMaxHitPoints()
    {
        return maxHitPoints;
    }
}
