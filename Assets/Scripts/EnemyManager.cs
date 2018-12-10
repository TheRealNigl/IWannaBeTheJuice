using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private List<Spike> Spikes;
    private List<JuiceDrop> Drops;
    private List<Fire> Fires;

    private List<GameObject> Objects;

    public void Start() {

        Spikes = new List<Spike>();
        Drops = new List<JuiceDrop>();
        Fires = new List<Fire>();

        Objects = new List<GameObject>();

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

        Spikes.Add(observer);
        GameObject g = Instantiate(observer.gameObject);
        Spikes[Wave.SpikesSpawnAmount] = g.GetComponent<Spike>();
        Wave.SpikesSpawnAmount++;
        Objects.Add(g);
    }

    public void AddObserver(JuiceDrop observer) {

        Drops.Add(observer);
        GameObject g = Instantiate(observer.gameObject);
        Drops[Wave.DropsSpawnAmount] = g.GetComponent<JuiceDrop>();
        Wave.DropsSpawnAmount++;
        Objects.Add(g);
    }

    public void AddObserver(Fire observer) {

        Fires.Add(observer);
        GameObject g = Instantiate(observer.gameObject);
        Fires[Wave.FiresSpawnAmount] = g.GetComponent<Fire>();
        Wave.FiresSpawnAmount++;
        Objects.Add(g);
    }

    public void RemoveObserver(Spike observer) {
        Spikes.Remove(observer);
    }

    public void RemoveObserver(JuiceDrop observer) {
        Drops.Remove(observer);
    }

    public void RemoveObserver(Fire observer) {
        Fires.Remove(observer);
    }

    public void ClearWave() {

        foreach (Spike g in Spikes) {
            RemoveObserver(g);
            Destroy(g.gameObject);
        }
        foreach (JuiceDrop g in Drops) {
            RemoveObserver(g);
            Destroy(g.gameObject);
        }
        foreach (Fire g in Fires) {
            RemoveObserver(g);
            Destroy(g.gameObject);
        }
    }
}