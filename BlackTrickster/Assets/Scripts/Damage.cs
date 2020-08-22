using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage = 10;
    public DamageType damageType;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<Health>().TakeDamage(damage, damageType);
        }
    }
}