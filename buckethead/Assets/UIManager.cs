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
  public GameObject highscore_ui;
  public TMP_Text timerText;
  public TMP_Text scoreText;
    public string endpoint;
  public TMP_InputField nameField;

  // Start is called before the first frame update
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
    menu_ui.SetActive(false);
    SceneManager.LoadScene(1);
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
    game_ui.SetActive(false);
    menu_ui.SetActive(false);
    SceneManager.LoadScene(0);
    highscore_ui.SetActive(true);
  }

  public void SubmitHighscore()
  {
    menu_ui.SetActive(true);
  }

  

  bool timerActive;
  float timer;
  float dTime;
  float maxTime = 120;
  void Update()
  {
    if (timerActive)
    {
      dTime += Time.deltaTime;
      if (dTime >= 0.1f)
      {
        timer += 0.1f;
        timerText.text = $"{timer}";
      }
      if (timer >= maxTime)
      {
        EndGame();
      }
    }
  }

    async UniTask<List<HighscoreEntry>> GetHighScoreAsync()
    {
        var req = new UnityWebRequest("");
        var op = await req.SendWebRequest();
        return JsonUtility.FromJson<List<HighscoreEntry>>(op.downloadHandler.text);
    }

    async UniTaskVoid PostHighScoreAsync()
    {
        string nm = "unknown";
        if(nameField?.text != null && nameField.text.Length > 3) {
            nm = nameField.text;
        }
        var req = new UnityWebRequest($"{endpoint}?name={nm}&score={score}", "POST");
        var op = await req.SendWebRequest();
        return;
    }
}


public struct HighscoreEntry {
    string name;
    int score;
}