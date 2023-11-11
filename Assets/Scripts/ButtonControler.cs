using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private Button buttonToRemove;

    public List<Button> allButtons;
    public int buttonsToEnable = 3;
    public int clicksToRemove = 3;

    void OnEnable()
    {
        EnableRandomButtons();
    }

    void EnableRandomButtons()
    {
        int buttonCount = allButtons.Count;
        for (int i = 0; i < buttonCount - 1; i++)
        {
            int randomIndex = Random.Range(i, buttonCount);
            Button temp = allButtons[i];
            allButtons[i] = allButtons[randomIndex];
            allButtons[randomIndex] = temp;
        }

        for (int i = 0; i < buttonCount; i++)
        {
            if (i < buttonsToEnable)
            {
                allButtons[i].interactable = true;
            }
            else
            {
                allButtons[i].interactable = false;
            }
        }
    }

    public void RemoveAndDisableButton()
    {
        clicksToRemove--;
        if (buttonToRemove != null && clicksToRemove == 0)
        {
            allButtons.Remove(buttonToRemove);
            buttonToRemove.interactable = false;
        }
    }
}
