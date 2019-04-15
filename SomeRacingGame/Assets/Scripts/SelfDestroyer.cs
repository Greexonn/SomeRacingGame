using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour
{
    public float destroyTime;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
