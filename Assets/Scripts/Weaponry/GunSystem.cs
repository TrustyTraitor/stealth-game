using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    // Weapon Stats
    public int damage;
    public float fireRate;
    public float spread;
    public float range;
    public float reloadTime;
    public float burstSpeed;
    
    public int magSize, shotsPerBurst;
    public bool isFullAuto;

    public int maxHeldAmmo; // How much of this ammo can be held at once
    public int currentHeldAmmo; // How much ammo the player currently has on them

    // 
    public int loadedAmmo; // Kepps track of how much ammo is in the current magazine
    private int ammoFired;

    // Status
    private bool isShooting = false;
    private bool isReadyToFire = true;
    private bool isReloading = false;

    public GameObject muzzleFlash;

    public Camera playerCam;
    public Transform barrelPoint;
    [Tooltip("The Scale of the muzzle flash")]
    public float flashScale = 1f;
    public RaycastHit rayHit;
    public LayerMask enemyLayer;

    public delegate void OnAmmoChange();
    public event OnAmmoChange onAmmoChange;

    private AudioSource audioSource;

    public GameManager gameManager;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        loadedAmmo = magSize;
        isReadyToFire = true;
    }

    private void Update()
    {
        InputHandler();
    }

    private void InputHandler()
    {
        if (gameManager.IsInteractingWithUI == false)
        {
            if (isFullAuto) isShooting = Input.GetButton("Fire1");
            else isShooting = Input.GetButtonDown("Fire1");

            // Reload
            if (Input.GetButtonDown("Reload") && !isReloading && loadedAmmo < magSize) Reload();

            // Shoot
            if (isReadyToFire && isShooting && !isReloading)
            {
                if (loadedAmmo > 0)
                {
                    ammoFired = 0;
                    Shoot();
                }
                else Debug.Log("Cannot Fire");
            
            }
        }
    }

    private void ReloadFinished() 
    {
        isReloading = false;

        if (onAmmoChange != null)
        {
            onAmmoChange();
        }
        Debug.Log("Reload Finished");
    }
    private void Reload()
    {
        Debug.Log("Starting Reload");
        isReloading = true;
        int needAmount = magSize - loadedAmmo;

        if (needAmount <= currentHeldAmmo) 
        {
            currentHeldAmmo -= needAmount;
            loadedAmmo += needAmount;
        }
        else 
        {
            loadedAmmo += currentHeldAmmo;
            currentHeldAmmo = 0;
        }

        Invoke("ReloadFinished", reloadTime);
    }

    private void StopShooting() 
    {
        isReadyToFire = true;

        if (onAmmoChange != null)
        { 
            onAmmoChange(); 
        }
    }
    
    private void Shoot() 
    {
        isReadyToFire = false;
        loadedAmmo--;
        ammoFired++;

        // Spread
        float xSpread = Random.Range(-spread, spread);
        float ySpread = Random.Range(-spread, spread);

        //Bullet Direction with Spread
        Vector3 direction = playerCam.transform.forward + new Vector3(xSpread, ySpread, 0);

        //Debug.DrawRay(playerCam.transform.position, direction, Color.blue, 2f);
        if (Physics.Raycast(playerCam.transform.position, direction, out rayHit, range, enemyLayer)) 
        {
            if (rayHit.collider.CompareTag("Enemy"))
            {
                rayHit.collider.GetComponent<EnemyTarget>().TakeDamage(damage);
            }
        }

        // creates muzzle flash and destroys it after it is finished running
        GameObject muzzleFlashPart = Instantiate(muzzleFlash, barrelPoint.transform, false) as GameObject;
        muzzleFlashPart.transform.localScale = new Vector3(2,2,2);
        muzzleFlashPart.transform.rotation = barrelPoint.transform.rotation;
        ParticleSystem particleSystem = muzzleFlashPart.GetComponent<ParticleSystem>();
        particleSystem.transform.localScale *= flashScale;

        float totalDuration = particleSystem.main.duration + particleSystem.main.startLifetime.constant;
        Destroy(muzzleFlashPart, totalDuration);

        Invoke("StopShooting", fireRate);

        audioSource.Play();

        if (ammoFired < shotsPerBurst && loadedAmmo > 0) 
        {
            Invoke("Shoot", fireRate);
        }
    }

}
