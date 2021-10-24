using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private string nameTarget;
    [SerializeField]
    private int damage;
    private void OnCollisionEnter(Collision collision)
    {
        Attack(collision);
    }

    private void Attack(Collision collision)
    {
        HealthManager playerHealth;
        if(collision.gameObject.TryGetComponent<HealthManager>(out playerHealth))
        {
            if(playerHealth.NameEntity == nameTarget)
            {
                playerHealth.GetDamage(damage);
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        Attack(collision);
    }
}
