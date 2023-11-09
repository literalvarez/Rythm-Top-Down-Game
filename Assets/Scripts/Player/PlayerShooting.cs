
using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public bool canShoot = false; // Private variable to control shooting
    public bool canReload = false;
    public int CurrentAmmo = 4;
    public int MaxAmmo = 4;
    public ParticleSystem shootfx;
    public AudioSource shootSFX;
    public GameObject[] bulletVisuals; // Array of GameObjects representing bullets

    public int BulletsPerShot = 5; // You can change this number according to your preference
    public float BulletSpreadAngle = 30f; // The range of angles in degrees

    public int maxBulletBounces = 1;
    public float maxBulletRange = 20f;


    void Start()
    {
        // Ensure bullet visuals are synced with initial ammo count
        UpdateBulletVisuals();
    }


    void Update()
    {
        // Rotate player to face the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector3 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        // Shooting logic
        if (Input.GetMouseButtonDown(0) && canShoot && CurrentAmmo >= 1)
        {
            float startingAngle = -BulletSpreadAngle / 2f;

            if (BulletsPerShot == 1)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Bullet bulletScript = bullet.GetComponent<Bullet>();
                if (bulletScript != null)
                {
                    Debug.Log("Setting Values");
                    bulletScript.maxTravelDistance = maxBulletRange;
                    bulletScript.maxBonuces = maxBulletBounces;
                }
            }
            else if (BulletsPerShot > 1)
            {
                for (int i = 0; i < BulletsPerShot; i++)
                {
                    float bulletAngle = startingAngle + i * (BulletSpreadAngle / (BulletsPerShot - 1));
                    Vector3 bulletEulerAngles = new Vector3(0f, 0f, bulletAngle + angle); // Add player's rotation angle to the bullet's angle

                    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(bulletEulerAngles));
                    Bullet bulletScript = bullet.GetComponent<Bullet>();

                    if (bulletScript != null)
                    {
                        Debug.Log("Setting Values");
                        bulletScript.maxTravelDistance = maxBulletRange;
                        bulletScript.maxBonuces = maxBulletBounces;
                    }

                }
            }
            shootfx.Play();
            shootSFX.Play();
            
            StopCoroutine(DisableShootingCoroutine());
            CurrentAmmo = CurrentAmmo - 1;
            UpdateBulletVisuals();
            canShoot = false;
            
        }


        if (Input.GetMouseButtonDown(1) && canReload) // RELOAD RELOAD RELOAD // RELOAD RELOAD RELOAD // RELOAD RELOAD RELOAD
        {
            CurrentAmmo = MaxAmmo;
            
            StopCoroutine(DisableReloadingCoroutine());
            UpdateBulletVisuals();
            canReload = false;
        }
    }
    private void UpdateBulletVisuals()
    {
        for (int i = 0; i < bulletVisuals.Length; i++)
        {
            bulletVisuals[i].SetActive(i < CurrentAmmo); // Enable visuals for remaining bullets
        }
    }


    public void EnableShooting()
    {
        canShoot = true;
        StartCoroutine(DisableShootingCoroutine());
    }
    public void EnableReload () // RELOAD RELOAD RELOAD // RELOAD RELOAD RELOAD // RELOAD RELOAD RELOAD
    {
        canReload = true;
        StartCoroutine(DisableReloadingCoroutine());
    }

    private IEnumerator DisableShootingCoroutine()
    {
        yield return new WaitForSeconds(0.25f); // Wait for 0.25 seconds
            
        canShoot = false;
    }
    private IEnumerator DisableReloadingCoroutine() // RELOAD RELOAD RELOAD // RELOAD RELOAD RELOAD // RELOAD RELOAD RELOAD
    {
        yield return new WaitForSeconds(0.25f); // Wait for 0.25 seconds

        canReload = false;
    }
    // Method to set the number of bullets per shot

    public void SetMaxAmmo()
    {
        MaxAmmo = MaxAmmo + 2;
    }
    public void SetBulletsPerShot()
    {
        BulletsPerShot = BulletsPerShot+2;
    }

    // Method to set the bullet spread angle
    public void SetBulletSpreadAngle()
    {
        BulletSpreadAngle = BulletSpreadAngle+10;
    }

    public void SetBulletsBounces()
    {
        maxBulletBounces = maxBulletBounces + 1;
    }
    public void SetMaxBulletRange()
    {
        maxBulletRange = maxBulletRange + 20;
    }

    public void ReloadAmmo() 
    {
        CurrentAmmo = MaxAmmo;
        UpdateBulletVisuals();
    }
}
