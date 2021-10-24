using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyHealthView;
    [SerializeField]
    private float timeEnemyView;

    [SerializeField]
    private Image fillHealth;
    [SerializeField]
    private string nameEntity;

    private float timer = 0;

    private const string ENEMY_NAME = "Enemy";
    private void OnEnable()
    {
        HealthManager.OnGetDamage += ChangeView;
    }

    private void Update()
    {
        if (nameEntity != ENEMY_NAME)
        {
            return;
        }

        if(timer <= 0)
        {
            timer = 0;
            enemyHealthView.SetActive(false);
        }
        timer -= Time.deltaTime;
    }

    private void OnDisable()
    {
        HealthManager.OnGetDamage -= ChangeView;
    }

    private void ChangeView(string name, float fillAmount)
    {
        if(name == ENEMY_NAME)
        {
            timer = timeEnemyView;
            enemyHealthView.SetActive(true);
        }
        if(name == nameEntity)
        {
            fillHealth.fillAmount = fillAmount;
        }
    }
}
