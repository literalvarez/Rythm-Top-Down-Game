using TMPro;
using UnityEngine;

public class StatsAmount : MonoBehaviour
{
    public TextMeshProUGUI bulletsPerShotText;
    public TextMeshProUGUI bulletSpreadAngleText;
    public TextMeshProUGUI maxBulletBonusesText;
    public TextMeshProUGUI maxBulletRangeText;
    public TextMeshProUGUI maxDashDistanceText;
    public TextMeshProUGUI maxAmmoText;

    public PlayerShooting playerShooting;
    public PlayerDash playerDashScript;

    private void Start()
    {
        UpdateStatsText();
    }


    public void UpdateStatsText()
    {
        // Update TMP text components with current values from PlayerShooting script without variable names
        bulletsPerShotText.text = playerShooting.BulletsPerShot.ToString();
        bulletSpreadAngleText.text = playerShooting.BulletSpreadAngle.ToString(/*"F2"*/) + "°";
        maxBulletBonusesText.text = playerShooting.maxBulletBounces.ToString();
        maxBulletRangeText.text = playerShooting.maxBulletRange.ToString(/*"F2"*/) + "m";
        maxDashDistanceText.text = playerDashScript.dashDistance.ToString("F2") + "m";
        maxAmmoText.text = playerShooting.MaxAmmo.ToString();
    }
}
