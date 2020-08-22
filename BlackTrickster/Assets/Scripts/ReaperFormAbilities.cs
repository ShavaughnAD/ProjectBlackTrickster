using UnityEngine;

public class ReaperFormAbilities : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] PlayerMovement playerMovement;
    public LayerMask enemyMask;
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Space))
        {

            //EnemyHealth[] enemiesToExecute = FindObjectsOfType<EnemyHealth>();
            //foreach (EnemyHealth executableEnemies in enemiesToExecute)
            //{
            //    executableEnemies.ExecuteMeDaddy();
            //

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, enemyMask))
            {
                playerMovement.enabled = false;
                transform.rotation = Quaternion.identity;
                transform.position = hit.transform.GetComponent<EnemyHealth>().behindEnemyPoint.position;
            }
        }
    }
}
