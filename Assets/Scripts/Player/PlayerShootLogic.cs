
using System.Collections;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public bool canShoot = false; // Private variable to control shooting
    public ParticleSystem shootfx;


    void Update()
    {
        // Rotate player to face the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector3 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        // Shooting logic
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            shootfx.Play();


            StopCoroutine(DisableShootingCoroutine());
            canShoot = false;
        }
    }

    public void EnableShooting()
    {
        canShoot = true;
        StartCoroutine(DisableShootingCoroutine());
    }

    private IEnumerator DisableShootingCoroutine()
    {
        yield return new WaitForSeconds(0.22f); // Wait for 0.2 seconds
            
        canShoot = false;
    }
}
