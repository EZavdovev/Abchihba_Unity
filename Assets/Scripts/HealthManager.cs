using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HealthManager : MonoBehaviour
{
    public static event Action<string, float> OnGetDamage = delegate { };
    [SerializeField]
    private int maxHp;
    [SerializeField]
    private string nameEntity;
    [SerializeField]
    private GameObject loseText;

    private int hp;

    private void Start()
    {
        hp = maxHp;
    }

    public void GetDamage(int damage)
    {
        hp -= damage;
        OnGetDamage(nameEntity,(float)hp/(float)maxHp);
        if(hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(nameEntity == "Enemy")
        {
            Destroy(gameObject);
            return;
        }
        loseText.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
}
