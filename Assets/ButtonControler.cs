using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button[] allButtons; // Reference to all the buttons in your UI
    public int buttonsToEnable = 3; // Number of buttons to enable

    void OnEnable()
    {
        EnableRandomButtons();
    }

    void EnableRandomButtons()
    {
        // Shuffle the array of buttons
        for (int i = 0; i < allButtons.Length - 1; i++)
        {
            int randomIndex = Random.Range(i, allButtons.Length);
            Button temp = allButtons[i];
            allButtons[i] = allButtons[randomIndex];
            allButtons[randomIndex] = temp;
        }

        // Enable the first 'buttonsToEnable' buttons and disable the rest
        for (int i = 0; i < allButtons.Length; i++)
        {
            if (i < buttonsToEnable)
            {
                allButtons[i].interactable = true; // Enable selected buttons
            }
            else
            {
                allButtons[i].interactable = false; // Disable other buttons
            }
        }
    }
}
