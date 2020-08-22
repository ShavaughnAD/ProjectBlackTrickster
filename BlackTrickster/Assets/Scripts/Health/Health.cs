using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 20;
    public float currentHealth = 20;
    public bool isImmune = false;

    public HealthDelegate onHurt = new HealthDelegate();
    public HealthDelegate onDeath = new HealthDelegate();
    public HealthDelegate onHeal = new HealthDelegate();

    [SerializeField] DamageResistance damageResistance;
    public Renderer rend;

    public virtual void Awake()
    {
        ResetHealth();
    }

    public virtual void TakeDamage(float damageAmount, DamageType damageType)
    {
        if (isImmune == true)
        {
            Debug.Log( gameObject.name + "  is Immune, Such Wow");
            return;
        }
        currentHealth -= damageResistance.CalculateDamageResistance(damageAmount, damageType);
        Debug.Log(gameObject.name + " Ouch, he hit me");
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0)
        {
            onDeath.CallEvent(0);
        }
        else
        {
            //Maybe Create A Stagger Function Here
            onHurt.CallEvent(currentHealth / maxHealth);
        }
    }

    public virtual void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}