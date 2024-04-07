using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    GlobalLight light;
    ControlPortal portal;

    public float maxCollect = 5f;
    private float collectLeft;
    private float progress;
    public float health { get { return collectLeft; }}

    // Start is called before the first frame update
    void Start()
    {
        collectLeft = maxCollect;
        light = GameObject.FindGameObjectWithTag("Global").GetComponent<GlobalLight>();
        portal = gameObject.GetComponentInChildren<ControlPortal>();
    }

    public void CatchCollect()
    {
        collectLeft -= 1f;
        progress = collectLeft / maxCollect;
        light.ReduceIntensity(progress);
        if (collectLeft <= 0)
            portal.CreatePortal();           
    }
}
