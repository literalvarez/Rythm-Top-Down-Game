using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private Button buttonToRemove;

    public List<Button> allButtons;
    public List<Transform> initialButtonTransforms; // List to store initial button transforms
    public int buttonsToEnable = 3;
    public int clicksToRemove = 3;

    void OnEnable()
    {
        EnableRandomButtons();
        UpdateTransformsPositions(); // Update positions after shuffling
    }

    void EnableRandomButtons()
    {
        int buttonCount = allButtons.Count;
        for (int i = 0; i < buttonCount - 1; i++)
        {
            int randomIndex = Random.Range(i, buttonCount);
            Button tempButton = allButtons[i];
            allButtons[i] = allButtons[randomIndex];
            allButtons[randomIndex] = tempButton;
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
            buttonToRemove.transform.position = initialButtonTransforms[5].position;
            initialButtonTransforms.RemoveAt(initialButtonTransforms.Count - 1);

            allButtons.Remove(buttonToRemove);
            buttonToRemove.interactable = false;
            UpdateTransformsPositions(); // Update positions after removing a button
        }
    }

    void UpdateTransformsPositions()
    {
        int buttonCount = Mathf.Min(allButtons.Count, initialButtonTransforms.Count);
        for (int i = 0; i < buttonCount; i++)
        {
            allButtons[i].transform.position = initialButtonTransforms[i].position;
        }
    }
}
