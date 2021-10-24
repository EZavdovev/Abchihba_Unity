using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItem : PickedItem
{
    protected override void GetItem(Collider other)
    {
        WeaponLogic weapon;
        if (other.gameObject.TryGetComponent<WeaponLogic>(out weapon))
        {
            if ( (weapon.Ammo/ weapon.MaxAmmo) != 1f)
            {
                weapon.GetAmmo(countResources);
                Destroy(gameObject);
            }
        }
    }
}
