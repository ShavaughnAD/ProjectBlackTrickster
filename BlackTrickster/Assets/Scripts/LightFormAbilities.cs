using UnityEngine;

public class LightFormAbilities : MonoBehaviour
{
    public GameObject magicAttack;
    public Transform magicAttackSpawnPoint;
    public float force;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject magAtk = Instantiate(magicAttack, magicAttackSpawnPoint.position, Quaternion.identity);
            magAtk.GetComponent<Rigidbody>().AddForce(magicAttackSpawnPoint.forward * force * Time.deltaTime, ForceMode.Impulse);
        }
    }
}