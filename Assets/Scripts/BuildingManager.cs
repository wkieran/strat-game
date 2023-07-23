using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{

   public GameObject Farm;

    public void placeFarm(Vector3 pos)
    {
        var spawnedFarm = Instantiate(Farm, pos, Quaternion.identity);
    }
}
