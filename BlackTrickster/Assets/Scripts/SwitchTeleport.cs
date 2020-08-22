using UnityEngine;

public class SwitchTeleport : MonoBehaviour
{
    public GameObject grenade;
    public Transform grenadeSpawnPoint;
    public Camera cam;
    public LayerMask enemyMask;
    public float damage = 10;
    public DamageType damageType;

    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, enemyMask))
            {
                Vector3 goToTrans = hit.transform.position;
                Vector3 currentTrans = gameObject.transform.position;
                Instantiate(grenade, grenadeSpawnPoint.position, Quaternion.identity);


                hit.transform.position = currentTrans;
                gameObject.transform.position = goToTrans;
            }
        }

        //if (Input.GetKeyDown(KeyCode.Mouse1))
        //{
        //    if (Physics.Raycast(ray, out hit, Mathf.Infinity, enemyMask))
        //    {
        //        if (hit.transform.GetComponent<Health>())
        //        {
        //            hit.transform.GetComponent<Health>().TakeDamage(damage, damageType);
        //        }
        //    }
        //}
    }
}