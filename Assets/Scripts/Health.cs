using UnityEngine;

public class Health : MonoBehaviour 
{
    public int Amount;

    public void Start() {
        Amount = 1;
    }

    public int Alive() {
        return Amount;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Evil"){
            Wave.WaveLevel = 0;
            Wave.FinalWaveLevel = RandomHelper.NextRandom(3, 5);

            GameObject.FindWithTag("Canvas").GetComponent<CanvasController>().LossText();
            GameObject.FindWithTag("GameController").GetComponent<GameController>().Restart();
        }
        if(collision.tag == "Boss"){

            Wave.WaveLevel = 0;
            Wave.FinalWaveLevel = RandomHelper.NextRandom(3, 5);
            GameObject.FindWithTag("Canvas").GetComponent<CanvasController>().WonText();
            GameObject.FindWithTag("Canvas").GetComponent<CanvasController>().score++;
            GameObject.FindWithTag("GameController").GetComponent<GameController>().Restart();
        }
    }
}