using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject aboutPanel;
    [SerializeField] GameObject homePanel;
    [SerializeField] GameObject settingsPanel;

    [SerializeField] Button[] buttons;
    [SerializeField] Color clickedColor;
    Color originalColor;

    
    bool settingsIsOpen, aboutIsOpen;
    private void Start()
    {
        aboutPanel.SetActive(false);
        homePanel.SetActive(true);
        settingsPanel.SetActive(false);

        settingsIsOpen = false;
        aboutIsOpen = false;

        originalColor = buttons[0].GetComponentInChildren<TextMeshProUGUI>().color;

        foreach(var button in buttons)
        {
            button.onClick.AddListener(() => ButtonClicked(button));
        }

    }
    public void LoadMainGame()
    {
        //SceneManager.LoadScene("MainGame");
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        //Consider open panel of confirmation
        Application.Quit();
    }
    public void OpenAboutPanel()
    {
        aboutPanel.SetActive(true);
        homePanel.SetActive(false);
        settingsPanel.SetActive(false);

        aboutIsOpen = true;
    }
    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
        aboutPanel.SetActive(false);
        homePanel.SetActive(false);

        settingsIsOpen = true;
    }
    public void GoBack()
    {
        if(aboutIsOpen)
        {
            aboutPanel.SetActive(!aboutIsOpen);
            homePanel.SetActive(true);
        }
        if(settingsIsOpen)
        {
            settingsPanel.SetActive(!settingsIsOpen);
            homePanel.SetActive(true);
        }
    }
    void ButtonClicked(Button clickedButton)
    {
        foreach(var button in buttons)
        {
            button.GetComponentInChildren<TextMeshProUGUI>().color = originalColor;
        }

        clickedButton.GetComponentInChildren<TextMeshProUGUI>().color = clickedColor;
    }
}
