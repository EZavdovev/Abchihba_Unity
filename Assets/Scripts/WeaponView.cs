using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponView : MonoBehaviour
{
    [SerializeField]
    private Text information;
    [SerializeField]
    private WeaponLogic weaponInfo;
    private void OnEnable()
    {
        WeaponLogic.OnAmmoChanged += ChangeView;
        ChangeView();
    }

    private void ChangeView()
    {
        information.text = weaponInfo.Ammo.ToString() + "/" + weaponInfo.MaxAmmo.ToString();
    }
    private void OnDisable()
    {
        WeaponLogic.OnAmmoChanged -= ChangeView;
    }
}
