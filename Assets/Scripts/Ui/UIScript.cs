using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIScript : MonoBehaviour
{
    private Health health;
    VisualElement light1;
    VisualElement light2;
    VisualElement light3;

    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        UIDocument ui = GetComponent<UIDocument>();
        light1 = ui.rootVisualElement.Q<VisualElement>("Light1");
        light2 = ui.rootVisualElement.Q<VisualElement>("Light2");
        light3 = ui.rootVisualElement.Q<VisualElement>("Light3");
    }

    // Update is called once per frame
    void Update()
    {
        if (health != null)
        {
            if (health.health < 3)
                light3.visible = false;
            if (health.health < 2)
                light2.visible = false;
        }
        else
            light1.visible = false;
    }
}
