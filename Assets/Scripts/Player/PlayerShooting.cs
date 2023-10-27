
using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public bool canShoot = false; // Private variable to control shooting
    public bool canReload = false;
    public int CurrentAmmo = 4;
    public int MaxAmmo = 4;
    public ParticleSystem shootfx;
    public GameObject[] bulletVisuals; // Array of GameObjects representing bullets


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
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            shootfx.Play();


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
}
