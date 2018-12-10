using UnityEngine;

public class GameController : MonoBehaviour
{
    private Level LevelObject;
    private GameObject Canvas;
    private CanvasController CanvasController;

    public void Start() {

        gameObject.name = "GameController";
        gameObject.tag = "GameController";

        LevelObject = GameObject.FindWithTag("Level").GetComponent<Level>();
        Canvas = GameObject.FindWithTag("Canvas");
        CanvasController = Canvas.GetComponent<CanvasController>();

        Begin();
    }

    public void Begin(){
         
        LevelObject.LevelState = LevelState.Spawn;
        CanvasController.Play();
        CanvasController.PlayText();
    }

    public void Play() {

        LevelObject.LevelState = LevelState.Wave;
        CanvasController.End();
        CanvasController.WaveText();
    }

    public void Boss(){

        CanvasController.BossText();
    }

    public void Restart() {
        ++Wave.WaveLevel;
        LevelObject.LevelState = LevelState.Restart;
        CanvasController.Play();
    }

    public void End() {

        CanvasController.Play();
        CanvasController.InformativeText.text = Assets.Play;
    }
}