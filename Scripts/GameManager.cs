using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject CorVrs;
    public Button BombBlastBar; 
    float spawnRate;
    public Image BombBar;
    private int sp;
    private float secondsCount;
    private int minuteCount;
    public Text Timer;
    public float secBlast = 0f;
    
    public static bool SpawnAllowed;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 2.4f;
        SpawnAllowed = true;
        InvokeRepeating("SpawnerV", 1f, spawnRate);
    }

    void SpawnerV()
    {
        if (SpawnAllowed)
        {
            sp = Random.Range(0, spawnPoints.Length);
            Instantiate(CorVrs, spawnPoints[sp].position, Quaternion.identity);
            spawnRate -= 0.1f;
            Debug.Log(spawnRate);
        }
    }

    void Update()
    {
        UpdateTimerUI();
    }

    public void UpdateTimerUI()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        Timer.text = minuteCount + "m:" + (int) secondsCount + "s";
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }

        secBlast += Time.deltaTime;
        BombBar.fillAmount = secBlast / 10;
        if (BombBar.fillAmount == 1f)
        {
            BombBlastBar.interactable = true;
        }
    }
}