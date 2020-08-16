using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 20;
    public float currentHealth = 20;
    public bool canBeExecuted = false;
    Renderer rend;

    void Awake()
    {
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
    }

    void Start()
    {
        rend.material.color = Color.green;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log(gameObject.name + " Ouch, he hit me");
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0)
        {
            //Maybe Create A Stagger Function Here
            rend.material.color = Color.red;
            canBeExecuted = true;
        }
    }

    public void ExecuteMeDaddy()
    {
        if (canBeExecuted)
        {
            Debug.LogError("No! My wife and kids!");
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("Hahaha You cannot kill me so easily!!");
        }
    }
}