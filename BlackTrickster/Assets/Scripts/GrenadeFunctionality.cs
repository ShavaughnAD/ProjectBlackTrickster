using UnityEngine;

public class GrenadeFunctionality : MonoBehaviour
{
    public float damage = 20;
    public float radius = 5;

    public float startTime = 3;
    float currentTime = 3;

    public DamageType damageType;

   void Start()
    {
        currentTime = startTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider item in colliders)
            {
                if (item.tag == "Enemy")
                {
                    Debug.Log(item.name + " Got bomb hit");
                    item.GetComponent<Health>().TakeDamage(damage, damageType);
                }
            }
            Destroy(gameObject);
        }
    }
}