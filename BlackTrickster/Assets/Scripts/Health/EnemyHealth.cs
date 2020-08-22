using UnityEngine;

public class EnemyHealth : Health
{
    public bool canBeExecuted = false;
    public Transform behindEnemyPoint;

    #region Blinking Effect Variables
    [Range(0.1f, 0.5f)]
    public float blinkEffectTime = 0.5f; //The lower this value, the faster the blink
    Material matBlink;
    Material matDefault;
    #endregion

    public override void Awake()
    {
        base.Awake();
        onHurt.BindToEvent(OnHurt);
        onDeath.BindToEvent(OnDeath);
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = Color.green;
        matDefault = rend.material;
        matBlink = Resources.Load("Materials/Blink", typeof(Material)) as Material;
    }

    public void OnHurt(float param)
    {
        rend.material = matBlink;
        Invoke("ResetMaterial", blinkEffectTime);
    }

    public void OnDeath(float param)
    {
        canBeExecuted = true;
        rend.material.color = Color.red;
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

    void ResetMaterial()
    {
        rend.material = matDefault;
    }
}