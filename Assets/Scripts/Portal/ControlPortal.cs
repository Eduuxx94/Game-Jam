using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPortal : MonoBehaviour
{
    public Transform position;
    public GameObject portal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePortal()
    {
        Instantiate(portal, position.position, Quaternion.identity);
    }
}
