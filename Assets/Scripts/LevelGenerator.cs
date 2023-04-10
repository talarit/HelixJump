using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public float DistancePlatforms;
    public Transform FinishPlatforms;
    public Transform CylinderRoot;
    public float CylinderScale = 1f;
    public GameObject FirstPlatformPrefab;
    public Game Game;
    private void Awake()
    {
        int IndexLevel = Game.LevelIndex;
        Random random = new Random(IndexLevel);
        //количество платформ зависит от уровня 
        int MinPlatforms = 2*(IndexLevel+1);
        int MaxPlatforms = 5*(IndexLevel+1);
        int PlatformsCount = RandomRange(random, MinPlatforms, MaxPlatforms + 1);

        for (int i=0; i<PlatformsCount;i++)
        {
           int PrefabsIndex = RandomRange(random, 0, PlatformPrefabs.Length);
            GameObject platformPrefab = i==0 ? FirstPlatformPrefab : PlatformPrefabs[PrefabsIndex];
            GameObject platforms = Instantiate(platformPrefab, transform);
            platforms.transform.localPosition = CalculatePlatforms(i);
            if (i>0)
                platforms.transform.localRotation = Quaternion.Euler(0, RandomRange(random, 0, 360f), 0);
        }
        FinishPlatforms.localPosition = CalculatePlatforms(PlatformsCount);
        CylinderRoot.localScale = new Vector3(1, PlatformsCount * DistancePlatforms+CylinderScale, 1);
    }

    private int RandomRange(Random random, int min, int max)
    {
        int number = random.Next();
        int len = max - min;
        number %= len;
        return min + number;
    }

    private float RandomRange(Random random, float min, float max)
    {
        float number = (float)random.NextDouble();
        return Mathf.Lerp(min, max, number);
    }
    private Vector3 CalculatePlatforms(int i)
    {
        return new Vector3(0, -DistancePlatforms * i, 0); ;
    }
}
