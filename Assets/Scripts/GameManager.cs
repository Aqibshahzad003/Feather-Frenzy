using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI birdsText;
    private int bird=5;

    public TextMeshProUGUI levelNameText;
    public int totalEnemyCount;
    private int enemyDestroyed;


    private void Start()
    {
        // Find all game objects with the "Enemy" tag in the scene.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        totalEnemyCount = enemies.Length;

        int currentlevel = SceneManager.GetActiveScene().buildIndex;
        levelNameText.text = "Level: " + currentlevel;

        birdsText.text = "BIRDS LEFT: " + bird.ToString();
    }
    public void DecreaseBirdText()
    {       
       bird--;
       birdsText.text ="BIRDS LEFT: "+ bird.ToString();
    }
    public void EnemyDestroyed()
    {
        enemyDestroyed++;

        // Check if all enemies are destroyed.
        if (enemyDestroyed >= totalEnemyCount)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 10)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            int nextSceneIndex = currentSceneIndex + 1;

            SceneManager.LoadScene(nextSceneIndex);
        }
    }
    public void RestartButton()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
