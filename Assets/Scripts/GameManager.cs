using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public AudioMixer audioMixer;
    //public TMPro.TMP_Dropdown resolutionDropdown;
    //public Button mainMenu;
    //Resolution[] resolutions;
    private void Awake()
    {
        Instance = this;
    }
    public void Start(){
        //resolutions = Screen.resolutions;
        //resolutionDropdown.ClearOptions();
        //List<string> options = new List<string>();
        //int currentResolutionIndex = 0;
        //for(int i = 0; i < resolutions.Length; i++){
        //    string option = resolutions[i].width + " x " + resolutions[i].height;
        //    options.Add(option);
        //    if(resolutions[i].width == Screen.currentResolution.width && 
        //        resolutions[i].height == Screen.currentResolution.height){
        //        currentResolutionIndex = i;
        //    }
        //}   
        //resolutionDropdown.AddOptions(options);
        //resolutionDropdown.value = currentResolutionIndex;
        //resolutionDropdown.RefreshShownValue();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void GameOptions()
    {
        SceneManager.LoadScene(1);
    }
    public void GameQuit()
    {
        Application.Quit();
    }
    //public void SetVolume(float volume)
    //{
    //    audioMixer.SetFloat("Volume", volume);
}
    //public void SetQuality(int qualityIndex){
    //    QualitySettings.SetQualityLevel(qualityIndex);
    //}
    //public void SetFullscreen(bool isFullscreen){
    //    Screen.fullScreen = isFullscreen;
    //}
    //public void SetResolution(int resolutionIndex){
    //    Resolution resolution = resolutions[resolutionIndex];
    //    Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    //}


//}
