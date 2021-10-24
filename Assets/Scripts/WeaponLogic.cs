using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WeaponLogic : MonoBehaviour
{
    public static event Action OnAmmoChanged = delegate { };
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private float distanceShoot;
    [SerializeField]
    private float deltaTimeToShoot;
    [SerializeField]
    private int damage;
    [SerializeField]
    private int maxAmmo;
    public int MaxAmmo
    {
        get
        {
            return maxAmmo;
        }
    }
    private int ammo;
    public int Ammo
    {
        get
        {
            return ammo;
        }
    }
    private float timer;

    private void OnEnable()
    {
        timer = deltaTimeToShoot;
        ammo = maxAmmo;
        OnAmmoChanged();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            timer += Time.deltaTime;
            if (timer > deltaTimeToShoot)
            {
                timer = 0;
                Shoot();
            }
        }
        else
        {
            timer = deltaTimeToShoot;
        }
    }

    private void Shoot()
    {
        if(ammo <= 0)
        {
            return;
        }
        ammo--;
        OnAmmoChanged();
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distanceShoot))
        {
            if(hit.collider.tag == "Player") 
            {
                return;
            }
            HealthManager health;
            if(hit.collider.TryGetComponent<HealthManager>(out health))
            {
                health.GetDamage(damage);
            }
        }
    }

    public void GetAmmo(int countAmmo)
    {

        ammo += countAmmo;

        if(ammo > maxAmmo)
        {
            ammo = maxAmmo;
        }
        OnAmmoChanged();
    }
}
