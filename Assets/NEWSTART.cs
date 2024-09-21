using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NEWSTART : MonoBehaviour
{
    nLaptop nl;

    padManager pad;

    Resolution[] resolutions;
    public Dropdown resDropdown;
    TutorialManager tut;


    // Start is called before the first frame update
    void Start()
    {
        nl = FindObjectOfType<nLaptop>();
        pad = FindObjectOfType<padManager>();
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        tut = FindObjectOfType<TutorialManager>();

        List<string> options = new List<string>();

        int currentResIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }
        resDropdown.AddOptions(options);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Quiting()
    {
        Application.Quit();
    }
    public void Return()
    {
        nl.pause.SetActive(false);
        if(pad.isOpen == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        nl.isPause = false;
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void SetResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SkipTut()
    {
        for (int i = 0; i < 26; i++)
        {
            tut.index = i;
            tut.block2.SetActive(false);
            tut.block1.SetActive(false);
            tut.block3.SetActive(false);
            tut.Invoke("HideTutorial", 10f);



        }
    }
}
