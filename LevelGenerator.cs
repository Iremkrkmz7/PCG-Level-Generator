using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance { get; private set; }
 
    public GameObject planePrefab;
    public GameObject enemyPrefab;
    public GameObject coinPrefab;
    public GameObject gameOverText;
    public GameObject winText;
 
    public LevelData[] levels = new LevelData[]
    {
        new LevelData { planeSize = 20f, coinCount = 3, enemyCount = 3, planeColor = Color.green },
        new LevelData { planeSize = 15f,  coinCount = 4, enemyCount = 3, planeColor = Color.blue },
        new LevelData { planeSize = 10f,  coinCount = 5, enemyCount = 2, planeColor = new Color(1f, 0.5f, 0f) }, // turuncu
        new LevelData { planeSize = 5f,  coinCount = 4, enemyCount = 1, planeColor = Color.red },
    };
    private int _currentLevel = 0;
    private int _coinsCollected = 0;
    private readonly List<GameObject> _spawned = new List<GameObject>();

    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
    }
    void Start() => GenerateLevel();
 
    public void GenerateLevel()
    {
        if (_currentLevel >= levels.Length)
        {
            Win();
            return;
        }
 
        ClearLevel();
        _coinsCollected = 0;
 
        LevelData data = levels[_currentLevel];
 
        SpawnPlane(data);
        SpawnEnemies(data);
        SpawnCoins(data);
 
        Debug.Log($"[PCG] Level {_currentLevel + 1} başladı | " +
                  $"Boyut: {data.planeSize} | Coin: {data.coinCount} | Düşman: {data.enemyCount}");
    }
    
    void SpawnPlane(LevelData data)
    {
        var go = Instantiate(planePrefab, Vector3.zero ,Quaternion.identity, transform);
        go.transform.localScale = new Vector3(data.planeSize * 0.1f ,1f , data.planeSize * 0.1f);
        go.GetComponent<Renderer>().material.color = data.planeColor;

        _spawned.Add(go);
    }
   
    void SpawnEnemies(LevelData data)
    {
        float half = data.planeSize * 0.4f;
        for (int i = 0; i < data.enemyCount; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-half, half),
                1f,
                Random.Range(-half, half)
            );
            var go = Instantiate(enemyPrefab, pos, Quaternion.identity, transform);
            var npc = go.GetComponent<NPC>();
            if (npc != null) npc.gameOverText = gameOverText;
            _spawned.Add(go);
        }
    }
 
    void SpawnCoins(LevelData data)
    {
        float half = data.planeSize * 0.4f;
        for (int i = 0; i < data.coinCount; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-half, half),
                0.5f,
                Random.Range(-half, half)
            );
            var go = Instantiate(coinPrefab, pos, Quaternion.identity, transform);
            _spawned.Add(go);
        }
    }
 
    public void CoinCollected()
    {
        _coinsCollected++;
        Debug.Log($"[Coin] {_coinsCollected}/{levels[_currentLevel].coinCount}");

        if(_coinsCollected >= levels[_currentLevel].coinCount)
        {
            _currentLevel++;
            GenerateLevel();
        }
    }
    void Win()
    {
        if(winText != null) winText.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("[WIN] Tüm levellar tamamlandı!");

    }
    public void ClearLevel()
    {
        foreach (var obj in _spawned)
        if(obj != null) Destroy (obj);
        _spawned.Clear();
    }
}



       

    
    

 

