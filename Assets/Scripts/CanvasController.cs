using UnityEngine;
using UnityEngine.UI;

public class Assets
{
    public static string Play = "Press 'Play' to start the game";
    public static string Wave = "Survive the wave";
    public static string Boss = "Defeat the Boss";
    public static string Win = "Now You! Got the Juice! Want more?";
    public static string Loss = "Oh no. Try again?";
}

public class CanvasController : MonoBehaviour
{
    public int score;
    public Text InformativeText;
    public GameObject InformativeObject;
    public Button PlayButton;
    public GameObject PlayObject;
    public Text ScoreText;
    public GameObject ScoreObject;
    public Text WaveLevelText;

    public void Start() {
        score = 0;

        gameObject.name = "Canvas";
        gameObject.tag = "Canvas";

        PlayButton.onClick.AddListener(StartWave);
    }

    public void Update() {

        WaveLevelText.text = "Wave #: " + Wave.WaveLevel + " / " + Wave.FinalWaveLevel;
        ScoreText.text = "Juice: " + score;
    }

    public void Play(){

        ScoreObject.SetActive(true);
        PlayObject.SetActive(true);
    }

    public void StartWave(){

        score = 0;
        GameObject.FindWithTag("GameController").GetComponent<GameController>().Play();
    }

    public void End() {
        PlayObject.SetActive(false);
    }

    public void WonText(){
        InformativeText.text = Assets.Win;
    }

    public void LossText() {
        InformativeText.text = Assets.Loss;
    }

    public void PlayText() {
        InformativeText.text = Assets.Play;
    }

    public void BossText() {
        InformativeText.text = Assets.Boss;
    }

    public void WaveText() {
        InformativeText.text = Assets.Wave;
    }
}