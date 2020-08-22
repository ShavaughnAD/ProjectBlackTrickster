using UnityEngine;

public class DualityForm : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    public GameObject lightForm;
    public GameObject reaperForm;

    [SerializeField] LightFormAbilities lightFormAbilities;
    [SerializeField] ReaperFormAbilities reaperFormAbilities;
    public bool isReaperForm = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //playerHealth.isImmune = true;
            FormChange();
        }
    }

    void FormChange()
    {
        //Add Animation Later
        isReaperForm = !isReaperForm;
        if(isReaperForm == true)
        {
            playerHealth.isImmune = true;
            lightForm.SetActive(false);
            reaperForm.SetActive(true);

            reaperFormAbilities.enabled = true;
            lightFormAbilities.enabled = false;
        }
        else
        {
            playerHealth.isImmune = false;
            lightForm.SetActive(true);
            reaperForm.SetActive(false);

            reaperFormAbilities.enabled = false;
            lightFormAbilities.enabled = true;
        }
    }
}