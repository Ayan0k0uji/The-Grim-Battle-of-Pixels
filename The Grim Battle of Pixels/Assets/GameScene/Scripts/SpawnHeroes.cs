using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public abstract class SpawnHeroes : MonoBehaviourPunCallbacks
{
    private string namePl1, namePl2;
  

    public abstract string GetNamePl1();

    public abstract string GetNamePl2();

}
