using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLogic : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private float distanceShoot;
    [SerializeField]
    private float deltaTimeToShoot;
    [SerializeField]
    private int damage;

    private float timer;

    private void Start()
    {
        timer = deltaTimeToShoot;
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
}
