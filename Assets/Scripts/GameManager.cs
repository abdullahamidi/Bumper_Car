using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int carCount;

    Text gameOverText;
    GameObject panel;
    GameObject speedUpButton;
    GameObject steeringWheel;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        carCount = PrefabController.instance.playerCount;
        gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
        steeringWheel = GameObject.Find("SteeringWheel");
        panel = GameObject.Find("Panel");
        speedUpButton = GameObject.Find("SpeedUp");
        panel.SetActive(false);
        speedUpButton.SetActive(false);
    }

    void Update()
    {
        if (carCount == 1)
        {
            Win();
        }
    }

    public void Win()
    {
        Time.timeScale = 0;
        gameOverText.text = "You Win!";
        steeringWheel.SetActive(false);
        speedUpButton.SetActive(false);
        panel.SetActive(true);
    }

    public void Lose()
    {
        Time.timeScale = 0;
        gameOverText.text = "You Lose!";
        steeringWheel.SetActive(false);
        speedUpButton.SetActive(false);
        panel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
