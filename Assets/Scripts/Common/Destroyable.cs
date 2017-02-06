using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public float MaxHealth;

    public float Health { get; private set; }
    public float HealthRate { get { return Health / MaxHealth;  } }

    public GameObject Explosion;
    public bool DestroyOnDeath;
    public float DestroyOnDeathDelay;

    public bool IsDead { get; private set; }

    protected virtual void Awake()
    {
        Health = MaxHealth;
        IsDead = false;
    }

    public virtual void DecreaseHealth(float amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Health = 0;
            die();
        }
    }

    public virtual void IncreaseHealth(float amount)
    {
        Health += amount;
    }

    private void die()
    {
        IsDead = true;
        if (DestroyOnDeath)
        {
            Destroy(this.gameObject, DestroyOnDeathDelay);
        }
        if (Explosion != null)
        {
            Instantiate(Explosion, transform.position, transform.rotation);
        }
    }
}
