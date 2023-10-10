using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject LevelsPanel;
    public GameObject Title;

    private AudioSource audioSource;
    public AudioClip clickClip;
    public static string selectedLevel;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OpenLevel(int leveldID)
    {
        SceneManager.LoadScene(leveldID);
    }
    public void PlayButton()
    {
        audioSource.PlayOneShot(clickClip);
        Title.gameObject.SetActive(false);
        LevelsPanel.SetActive(true);
    }
    public void GoBackButton()
    {
        audioSource.PlayOneShot(clickClip);
        Title.gameObject.SetActive(true);
        LevelsPanel.SetActive(false);
    }
    public void ExitButton()
    {
#if UNITY_EDITOR
        audioSource.PlayOneShot(clickClip);
        Application.Quit();
#endif
    }
}
