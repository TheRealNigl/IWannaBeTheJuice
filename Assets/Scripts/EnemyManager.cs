using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private List<Spike> Spikes;
    private List<JuiceDrop> Drops;
    private List<Fire> Fires;

    public void Start() {

        Spikes = new List<Spike>();
        Drops = new List<JuiceDrop>();
        Fires = new List<Fire>();

        Wave.WaveLevel = 0;
        Wave.FinalWaveLevel = RandomHelper.NextRandom(3, 5);
    }

    public void SetInitialValuesForWave(){

        Wave.DropsSpawnAmount = 0;
        Wave.SpikesSpawnAmount = 0;
        Wave.FiresSpawnAmount = 0;

        Wave.DropsAmount = RandomHelper.NextRandom(16, 20);
        Wave.SpikesAmount = RandomHelper.NextRandom(5, 10);
        Wave.FireAmount = RandomHelper.NextRandom(3, 5);
    }

    public void Notify() {

        for (int i = 0; i < Spikes.Count; i++) {
            Spikes[i].OnNotify();
        }
        for (int i = 0; i < Drops.Count; i++) {
            Drops[i].OnNotify();
        }
        for (int i = 0; i < Fires.Count; i++) {
            Fires[i].OnNotify();
        }
    }

    public void AddObserver(Spike observer) {
        GameObject g = Instantiate(observer.gameObject);
        Spikes.Add(g.GetComponent<Spike>());
        Wave.SpikesSpawnAmount++;
    }

    public void AddObserver(JuiceDrop observer) {
        GameObject g = Instantiate(observer.gameObject);
        Drops.Add(g.GetComponent<JuiceDrop>());
        Wave.DropsSpawnAmount++;
    }

    public void AddObserver(Fire observer) {
        GameObject g = Instantiate(observer.gameObject);
        Fires.Add(g.GetComponent<Fire>());
        Wave.FiresSpawnAmount++;
    }

    public void ClearWave() {

        if (Spikes.Count > 0)
        {
            foreach (Spike g in Spikes)
            {
                if (g != null)
                {
                    Destroy(g.gameObject);
                }
            }
            Spikes = new List<Spike>();
        }
        if (Drops.Count > 0)
        {
            foreach (JuiceDrop g in Drops)
            {
                if (g != null)
                {
                    Destroy(g.gameObject);
                }
            }
            Drops = new List<JuiceDrop>();
        }

        if (Fires.Count > 0)
        {
            foreach (Fire g in Fires)
            {
                if (g != null)
                {
                    Destroy(g.gameObject);
                }
            }
            Fires = new List<Fire>();
        }
        
    }
}