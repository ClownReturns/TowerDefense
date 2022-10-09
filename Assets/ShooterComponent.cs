using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterComponent : MonoBehaviour
{
    [SerializeField] private GameObject pfBullet;
    [SerializeField] private float force;
    [SerializeField] private int magazineCap;
    [SerializeField] private int maxMagazines;
    [SerializeField] private int currentAmmo;
    [SerializeField] private int currentMagazines;
    [SerializeField] UIComponent m_UI;

    GameObject Cylinder;

    void Start()
    {
        Cylinder = GameObject.Find("Cylinder");
        currentAmmo = magazineCap;
        m_UI.UpdateAmmo(currentAmmo, currentMagazines, magazineCap);
        InputHandlerComponent.Instance.OnShootEvent += ShooterComponent_OnShootEvent;
        InputHandlerComponent.Instance.OnReloadEvent += ShooterComponent_OnReloadEvent;
    }


    public void ShooterComponent_OnShootEvent(object sender, EventArgs args)
    {
        if (canShoot())
        {
            GameObject bulletTransform = Instantiate(pfBullet, Cylinder.transform.position, transform.rotation);
            bulletTransform.GetComponent<Projectile>().Setup(force, transform.forward);
            currentAmmo--;
            m_UI.UpdateAmmo(currentAmmo, currentMagazines, magazineCap);
        }
    }
    public void ShooterComponent_OnReloadEvent(object sender, EventArgs args)
    {
        if (currentAmmo < magazineCap)
        {
            reload();
        }
    }


    private Boolean canShoot()
    {
        return currentAmmo > 0;
    }

    private void reload()
    {
        if (currentMagazines > 0)
        {
            currentAmmo = magazineCap;
            currentMagazines--;
            m_UI.UpdateAmmo(currentAmmo, currentMagazines, magazineCap);

        }
    }
    public void ResetAmmo()
    {
        Debug.Log("Reset ammo");
        currentMagazines = maxMagazines;
        currentAmmo = magazineCap;
        m_UI.UpdateAmmo(currentAmmo, currentMagazines, magazineCap);
    }

    public void PressedButton()
    {
        Debug.Log("Reset ammo");

    }
}
