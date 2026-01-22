using System.Collections.Generic;
using UnityEngine;

public class ResetManager : MonoBehaviour
{
    public static ResetManager Instance;

    private List<Health> enemies = new List<Health>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void RegisterEnemy(Health enemy)
    {
        if (!enemies.Contains(enemy))
            enemies.Add(enemy);
    }

    public void ResetLevel()
    {
        foreach (Health enemy in enemies)
        {
            if (enemy != null)
            {
                enemy.ResetEnemy();
            }
        }
    }
}
