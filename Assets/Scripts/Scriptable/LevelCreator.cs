using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Levels")]
public class LevelCreator : ScriptableObject
{


    public List<LevelOrder> customers;

    [System.Serializable]
    public class LevelOrder
    {
        public List<GameObject> orders;
    }
}
