using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animcontroller : MonoBehaviour
{
    public void GetAnimEnding()
    {
        transform.parent.GetComponent<CharacterController>().GoNext();
    }
}
