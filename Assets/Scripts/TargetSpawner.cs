using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TargetSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField]
    private int outerRadius;
    [SerializeField]
    private int subdivisions;
    [SerializeField]
    private float enemiesToSpawn;
    [SerializeField]
    private GameObject enemyPrefab;

    public List<GameObject> targets = new List<GameObject>();

    private float stepValue;

    public static TargetSpawner instance { private set; get; }

    [SerializeField]
    private List<float> rings = new List<float>();
    private void Awake()
    {
        instance = this;
        DetermineSpawnRings();
        SpawnTargets();
    }
    private void DetermineSpawnRings()
    {
        rings.Add(outerRadius);
        for (int i = 1; i <= subdivisions; i++)
        {
            float ringCount = i;
            rings.Add(outerRadius * Mathf.Sqrt(ringCount / (subdivisions + 1)));
        }
    }
    private void SpawnTargets()
    {
        System.Random random = new System.Random();
        for(int i = 0; i <= enemiesToSpawn; i++)
        {
            GameObject spawnedTarget = Instantiate(enemyPrefab.gameObject, transform);
            spawnedTarget.transform.position = (Vector2) Random.insideUnitCircle.normalized * rings[(random.Next(0, rings.Count))];
            targets.Add(spawnedTarget);
        }
        TargetController.UpdateSpeed();
    }

    private void OnDrawGizmos()
    {
        foreach(float radius in rings)
        {
            Gizmos.DrawWireSphere(Vector2.zero, radius);
        }
    }

    public void RemoveTarget(GameObject gameObj)
    {
        targets.Remove(gameObj);
    }

    public void PlayRandomZombieSound()
    {
        System.Random random = new System.Random();
        targets[(random.Next(0, targets.Count))].GetComponent<TargetController>().PlaySound();
    }
}
