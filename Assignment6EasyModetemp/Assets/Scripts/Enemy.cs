using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    // Note: Protected means that classes that inherit from Enemy will be able to use the variables + methods from here.
    // Note: Making Awake() virtual means that Enemy will set up the variables in here, but allow classes that inherit from Enemy to set their own values for variables
    protected float speed;
    protected int health;

    [SerializeField] protected Weapon weapon;

    protected virtual void Awake()
    {
        weapon = gameObject.AddComponent<Weapon>();

        speed = 5f;
        health = 100;

        weapon.damageBonus = 10;
    }

    protected abstract void Attack(int amount);

    public abstract void TakeDamage(int amount);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
