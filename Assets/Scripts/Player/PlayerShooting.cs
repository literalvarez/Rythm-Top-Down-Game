
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public bool canShoot = false; // Private variable to control shooting
    public bool shooted = false;

    void Update()
    {
        // Rotate player to face the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector3 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        // Shooting logic
        if (canShoot && Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            shooted = true;
            canShoot = false;
        }
    }

    public void EnableShooting()
    {
        canShoot = true;
        shooted = false;
        Invoke("DisableShooting", 0.25f); // Turn off shooting after 150ms (0.1 seconds)
    }

    private void DisableShooting()
    {
        if(shooted == false) 
        {
            canShoot = false; 
        }       
    }

}
