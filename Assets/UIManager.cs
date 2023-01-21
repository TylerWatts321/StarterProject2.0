using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject objectiveText;
    public Text gameStateText;
    public Text gameRestartText;
    public TimerCountdown timer;
    public PlayerController player;
    public void Start()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.opening, false);
        Invoke("DisableObjective", 2f);
    }

    private void DisableObjective()
    {
        objectiveText.SetActive(false);
        AudioManager.instance.PlaySound(AudioManager.instance.music, true);
        timer.enabled = true;
        player.enabled = true;
    }

    public void Update()
    {
        if(gameStateText.isActiveAndEnabled)
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(0);
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
        else
        {
            if (TargetSpawner.instance.targets.Count <= 0)
            {
                gameStateText.gameObject.SetActive(true);
                DisplayGameOver("You killed all the zombies in time!", Color.green);
                AudioManager.instance.PlaySound(AudioManager.instance.win, false);
                timer.enabled = false;

            }
            else if ((timer.isActiveAndEnabled == true && timer.timeRemaining <= 0) 
                    || TargetController.touchedPlayer == true)
            {
                gameStateText.gameObject.SetActive(true);
                DisplayGameOver("You didn't kill the zombies in time!", Color.red);
                AudioManager.instance.PlaySound(AudioManager.instance.lose, false);
            }
        }
    }

    public void DisplayGameOver(string textToDisplay, Color color)
    {
        gameStateText.text = textToDisplay;
        gameStateText.color = color;
        gameStateText.gameObject.SetActive(true);
        player.enabled = false;

        gameRestartText.gameObject.SetActive(true);
    }
}
