using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ShowMaxAmmo : MonoBehaviour
{
    public GameObject[] gameObjectsToManage; // List of GameObjects to be managed
    public PlayerShooting playerShootingScript; // Reference to the PlayerShooting script
    [SerializeField]
    private int maxAmmo;


    public void Start()
    {
        UpdateMaxAmmoVisual();
    }

    public void UpdateMaxAmmoVisual()
    {
        // Check if the PlayerShooting script is not null
        if (playerShootingScript != null)
        {
            // Get the MaxAmmo value from the PlayerShooting script
            maxAmmo = playerShootingScript.MaxAmmo;

            // Loop through the gameObjectsToManage array
            for (int i = 0; i < gameObjectsToManage.Length; i++)
            {
                // Check if the current index is less than or equal to the MaxAmmo
                if (i < maxAmmo)
                {
                    // Set the GameObject at the current index active
                    gameObjectsToManage[i].SetActive(true);
                }
                else
                {
                    // Set the GameObject at the current index inactive
                    gameObjectsToManage[i].SetActive(false);
                }
            }
            
        }
        else
        {
            // Log a warning if the PlayerShooting script reference is null
            Debug.LogWarning("PlayerShooting script reference is missing!");
        }
    }
}