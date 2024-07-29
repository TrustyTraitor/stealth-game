using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using UnityEngine;
using TMPro;

public class AmmoCounter : MonoBehaviour
{
    public GunSystem gun;
    public TMP_Text ammoLabel;
    public TMP_Text heldAmmoLabel;

    private string strAmmo;
    private string strHeldAmmo;

    private void Awake()
    {
        if (gun != null) 
        {
            gun.onAmmoChange += OnAmmoChange;

            strAmmo = gun.loadedAmmo.ToString() + "/" + gun.magSize.ToString();
            strHeldAmmo = gun.currentHeldAmmo.ToString();
        }
        ammoLabel.text = strAmmo;
        heldAmmoLabel.text = strHeldAmmo;
    }

    public void OnAmmoChange()
    {
        if (gun != null)
        {
            strAmmo = gun.loadedAmmo.ToString() + "/" + gun.magSize.ToString();
            strHeldAmmo = gun.currentHeldAmmo.ToString();
        }
        ammoLabel.text = strAmmo;
        heldAmmoLabel.text = strHeldAmmo;
    }
}
