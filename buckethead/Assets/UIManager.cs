using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

public class UIManager : MonoBehaviour
{
  public static UIManager instance;
  public int score;
  public int maxScore = 300;
  public GameObject game_ui;
  public GameObject menu_ui;
  public TMP_Text timerText;
  public TMP_Text scoreText;
  public TMP_Text scoreTextMenu;

  void Start()
  {
    if (instance != null)
    {
      Destroy(this.gameObject);
    }
    else
    {
      instance = this;
      DontDestroyOnLoad(this.gameObject);
    }
  }

  public void SetScore(int i)
  {
    this.score = i;
    scoreText.text = $"{this.score}/{maxScore}";
  }

  public void LoadGame()
  {
    SceneManager.LoadScene(1);
    menu_ui.SetActive(false);
    game_ui.SetActive(false);
  }
  // Update is called once per frame
  public void StartGame()
  {
    this.timer = 0;
    this.timerActive = true;
    game_ui.SetActive(true);
  }

  public void EndGame()
  {
    SceneManager.LoadScene("Menu");
    game_ui.SetActive(false);
    menu_ui.SetActive(true);
    scoreTextMenu.text = $"Du fick {score} poäng";
  }

 
  public bool timerActive;
  float timer;
  float dTime;
  float maxTime = 120;
  void Update()
  {
    if (timerActive)
    {
      dTime += Time.deltaTime;
      if (dTime >= 1f)
      {
        timer += 1f;
        dTime = 0;
        timerText.text = $"{Mathf.FloorToInt(maxTime - timer)}";
      }
      if (timer >= maxTime)
      {
        EndGame();
      }
    }
  }

}
