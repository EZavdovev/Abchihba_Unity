using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HealthManager : MonoBehaviour
{
    public static event Action<string, float> OnChangeHealth = delegate { };
    [SerializeField]
    private int maxHp;
    [SerializeField]
    private string nameEntity;
    public string NameEntity
    {
        get
        {
            return nameEntity;
        }
    }
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
        OnChangeHealth(nameEntity, GetCoefficient());
        if (hp <= 0)
        {
            Die();
        }
    }

    public void GetHealth(int health)
    {
        hp += health;
        if(hp > maxHp)
        {
            hp = maxHp;
        }
        OnChangeHealth(nameEntity, GetCoefficient());
    }

    public float GetCoefficient()
    {
        return ((float)hp / (float)maxHp);
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
