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
    Label start;

    float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        UIDocument ui = GetComponent<UIDocument>();
        light1 = ui.rootVisualElement.Q<VisualElement>("Light1");
        light2 = ui.rootVisualElement.Q<VisualElement>("Light2");
        light3 = ui.rootVisualElement.Q<VisualElement>("Light3");
        start = ui.rootVisualElement.Q<Label>("StartMessage");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0f)
            timer = timer - Time.deltaTime;
        else if (timer < 0f)
        {
            start.visible = false;
            timer = 0f;
        }
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
