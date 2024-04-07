using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    GlobalLight light;

    public float maxCollect = 5;
    private float collectLeft;
    private float progress;

    // Start is called before the first frame update
    void Start()
    {
        collectLeft = maxCollect;
        light = GameObject.FindGameObjectWithTag("Global").GetComponent<GlobalLight>();
    }

    public void CatchCollect()
    {
        collectLeft -= 1;
        progress = collectLeft / maxCollect;
        light.ReduceIntensity(progress);
        //if (collectLeft = 0)
    }
}
