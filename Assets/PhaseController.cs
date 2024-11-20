using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseController : MonoBehaviour
{
    public enum Phases
    {
        Quiet,
        Loud
    }

    public Phases currentPhase = Phases.Quiet;

    public GameObject enemy;

    public int enemyPerSpawn = 3;

    [Tooltip("Time in seconds for spawn wave.")]
    public int spawnRate = 45;

    public Transform[] spawnPoints;

    public PlayerDetectedAlert alert;

    private IEnumerator spawnHandler;

    private void Awake()
    {
        spawnHandler = spawnEnemies();

        alert.onPlayerAlert += SetToLoud;
    }

    private void OnDisable()
    {
        alert.onPlayerAlert -= SetToLoud;
    }

    public IEnumerator spawnEnemies()
    {
        while (true)
        {
            int rand = UnityEngine.Random.Range(0, spawnPoints.Length);

            for (int i = 0; i < enemyPerSpawn; ++i)
                Instantiate(enemy, spawnPoints[rand].position, Quaternion.identity);
            
            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void SetToLoud()
    {
        currentPhase = Phases.Loud;
        Debug.Log("Going Loud");
        StartCoroutine(spawnHandler);
    }

    public void SetToQuiet()
    {
        currentPhase = Phases.Quiet;
        StopCoroutine(spawnHandler);
    }
}
