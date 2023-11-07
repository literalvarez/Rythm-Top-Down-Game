using TMPro;
using UnityEngine;

public class StatsAmount : MonoBehaviour
{
    public TextMeshProUGUI bulletsPerShotText;
    public TextMeshProUGUI bulletSpreadAngleText;
    public TextMeshProUGUI maxBulletBonusesText;
    public TextMeshProUGUI maxBulletRangeText;
    public TextMeshProUGUI maxDashDistanceText;

    public PlayerShooting playerShooting;
    public PlayerDash playerDashScript;

    private void Start()
    {
        if (playerShooting == null)
        {
            Debug.LogError("PlayerShooting script reference is not set!");
            return;
        }

        UpdateStatsText();
    }

    private void Update()
    {
        // Update the stats text every frame (you might want to optimize this if needed)
        UpdateStatsText();
    }

    private void UpdateStatsText()
    {
        // Update TMP text components with current values from PlayerShooting script without variable names
        bulletsPerShotText.text = playerShooting.BulletsPerShot.ToString();
        bulletSpreadAngleText.text = playerShooting.BulletSpreadAngle.ToString(/*"F2"*/) + "°";
        maxBulletBonusesText.text = playerShooting.maxBulletBounces.ToString();
        maxBulletRangeText.text = playerShooting.maxBulletRange.ToString(/*"F2"*/) + "m";
        maxDashDistanceText.text = playerDashScript.dashDistance.ToString("F2") + "m";
    }
}
