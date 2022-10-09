using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIComponent : MonoBehaviour
{
    [SerializeField] GameObject gmAmmo;
    [SerializeField] GameObject gmTotalAmmo;
    [SerializeField] GameObject listPanel;
    [SerializeField] Image progressBar;

    TMPro.TextMeshProUGUI ammo;
    TMPro.TextMeshProUGUI totalAmmo;


    [SerializeField] private GameObject pfBulletToken;



    // Start is called before the first frame update
    private void Awake()
    {
        ammo = gmAmmo.GetComponent<TMPro.TextMeshProUGUI>();
        totalAmmo = gmTotalAmmo.GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void UpdateAmmo(int currentAmmo, int magazines, int magazineCap)
    {
        UpdateAmmoText(currentAmmo, magazines * magazineCap);
        UpdateAmmoList(currentAmmo);
        UpdateAmmoBar(currentAmmo, magazineCap);
    }


    private void UpdateAmmoText(int currentAmmo, int maxAmmo)
    {
        ammo.text = currentAmmo.ToString();
        totalAmmo.text = "/" + maxAmmo.ToString();
    }

    private void UpdateAmmoList(int currentAmmo)
    {
        for (int i = 0; i < currentAmmo; i++)
        {
            Debug.Log("+1 item");
            GameObject bulletCopy = Instantiate(pfBulletToken);
            bulletCopy.transform.parent = listPanel.transform;
        }
    }

    private void UpdateAmmoBar(int currentAmmo, int maxAmmo)
    {
        float fillAmmount = (float)currentAmmo / (float)maxAmmo;
        progressBar.fillAmount = fillAmmount;
    }
}
