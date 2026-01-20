using UnityEngine;
using System.Collections;

public class FireCauldronSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject stoneEnemyPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform player;

    [Header("Settings")]
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private int stonesPerWave = 3;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            StartCoroutine(SpawnWaveCoroutine());
        }
    }

    private IEnumerator SpawnWaveCoroutine()
    {
        for (int i = 0; i < stonesPerWave; i++)
        {
            GameObject stone = Instantiate(
                stoneEnemyPrefab,
                shootPoint.position,
                Quaternion.identity
            );

            JumpingFollower follower = stone.GetComponent<JumpingFollower>();

            if (follower != null)
            {
                follower.player = player;
            }
            else
            {
                Debug.LogError("El prefab no tiene el componente JumpingFollower");
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}

