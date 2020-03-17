using UnityEngine;

public class CompositeSpawnZone : SpawnZone
{
    [SerializeField]
    SpawnZone[] spawnZones;

    public override Vector3 SpawnPoint
    {
        get
        {
            int index = Random.Range(0, spawnZones.Length);
            return spawnZones[index].SpawnPoint;
        }
    }
}