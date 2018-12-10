using UnityEngine;

public enum LevelState 
{ 
    Stasis, Spawn, Wave, Boss, Restart
}

public class Level : MonoBehaviour 
{
    public LevelState LevelState { get; set; }

    private EnemyManager EnemyManager;

    private GameObject Player, Ground, Boss, BossClone, Spike, Drop, Fire;

    private float DropTime, CurrentDropTime, SpikeTime, CurrentSpikeTime, FireTime, CurrentFireTime;

    public void Start() {

        gameObject.name = "Level";
        gameObject.tag = "Level";

        EnemyManager = GetComponent<EnemyManager>();
        if (EnemyManager == null) {
            EnemyManager = this.gameObject.AddComponent<EnemyManager>();
        }

        Player = Resources.Load("Prefabs/Player") as GameObject;
        Ground = Resources.Load("Prefabs/Ground") as GameObject;
        Boss = Resources.Load("Prefabs/Boss") as GameObject;
        Spike = Resources.Load("Prefabs/Spike") as GameObject;
        Drop = Resources.Load("Prefabs/JuiceDrop") as GameObject;
        Fire = Resources.Load("Prefabs/Fire") as GameObject;
    }

    public void Update()  {

        switch (LevelState) {
            case LevelState.Stasis:
                break;
            case LevelState.Spawn:
                CreateGame();
                break;
            case LevelState.Wave:
                WaveSpawner();
                break;
            case LevelState.Boss:
                BossReady();
                break;
            case LevelState.Restart:
                ResetLevel();
                break;
            default:
                break;
        }
    }

    public void CreateGame() {

        // Assign Time values for the enemy spawners
        DropTime = RandomHelper.NextRandom(2, 3);
        SpikeTime = RandomHelper.NextRandom(3, 5);
        FireTime = RandomHelper.NextRandom(4, 5);

        // Create Initial Values for the Wave
        EnemyManager.SetInitialValuesForWave();

        // Create the player and ground
        Player = Instantiate(Player);
        Ground = Instantiate(Ground);

        // Put the Game in Statis
        LevelState = LevelState.Stasis;
    }

    public void WaveSpawner(){

        // Spawn a drop
        CurrentDropTime += Time.deltaTime;
        if(CurrentDropTime > DropTime && Wave.DropsSpawnAmount != Wave.DropsAmount) {
            EnemyManager.AddObserver(Drop.GetComponent<JuiceDrop>());
            CurrentDropTime = 0f;
            DropTime = RandomHelper.NextRandom(3, 5);
        }

        // Spawn a spike
        CurrentSpikeTime += Time.deltaTime;
        if (CurrentSpikeTime > SpikeTime && Wave.SpikesSpawnAmount != Wave.SpikesAmount) {
            EnemyManager.AddObserver(Spike.GetComponent<Spike>());
            CurrentSpikeTime = 0;
            SpikeTime = RandomHelper.NextRandom(3, 5);
        }

        // Spawn a fire
        CurrentFireTime += Time.deltaTime;
        if(CurrentFireTime > FireTime && Wave.FiresSpawnAmount != Wave.FireAmount){
            EnemyManager.AddObserver(Fire.GetComponent<Fire>());
            CurrentFireTime = 0f;
            FireTime = RandomHelper.NextRandom(3, 5);
        }

        // Spawn the boss
        if (Wave.DropsSpawnAmount == Wave.DropsAmount && Wave.SpikesSpawnAmount == Wave.SpikesAmount && Wave.FiresSpawnAmount == Wave.FireAmount && Wave.WaveLevel == Wave.FinalWaveLevel) {
            LevelState = LevelState.Boss;
            // Or Spawn another wave
        } else if (Wave.DropsSpawnAmount == Wave.DropsAmount && Wave.SpikesSpawnAmount == Wave.SpikesAmount && Wave.FiresSpawnAmount == Wave.FireAmount){
            GameObject.FindWithTag("GameController").GetComponent<GameController>().Restart();
        }

        // Notify all enemies
        //EnemyManager.Notify(Player);
    }

    // Create Boss
    private void BossReady() {
        EnemyManager.ClearWave();
        GameObject.FindWithTag("GameController").GetComponent<GameController>().Boss();
        BossClone = Instantiate(Boss);
        LevelState = LevelState.Stasis;
    }

    // Position player in the starting Location
    public void ResetLevel(){
        // Assign Time values for the enemy spawners
        DropTime = RandomHelper.NextRandom(2, 3);
        SpikeTime = RandomHelper.NextRandom(1, 5);
        FireTime = RandomHelper.NextRandom(4, 5);

        // Create Initial Values for the Wave
        EnemyManager.SetInitialValuesForWave();

        //Player.GetComponent<Rigidbody2D>().position = Player.GetComponent<Player>().StartLocation();
        EnemyManager.ClearWave();
        Destroy(BossClone);
        LevelState = LevelState.Stasis;
    }
}