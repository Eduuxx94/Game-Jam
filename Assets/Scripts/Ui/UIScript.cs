using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIScript : MonoBehaviour
{
    GameObject player;

    private Health health;
    private Shooting collect;

    VisualElement light1;
    VisualElement light2;
    VisualElement light3;
    Label start;
    Label counter;

    float timer = 2f;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
        health = player.GetComponent<Health>();
        collect = player.GetComponent<Shooting>();
        UIDocument ui = GetComponent<UIDocument>();
        light1 = ui.rootVisualElement.Q<VisualElement>("Light1");
        light2 = ui.rootVisualElement.Q<VisualElement>("Light2");
        light3 = ui.rootVisualElement.Q<VisualElement>("Light3");
        start = ui.rootVisualElement.Q<Label>("StartMessage");
        counter = ui.rootVisualElement.Q<Label>("Counter");
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
        counter.text = collect.count.ToString();
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
