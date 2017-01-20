using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class Test : MonoBehaviour
{
    void Start()
    {
        AirConsole.instance.onMessage += OnMessage;
    }

    void Update()
    {

    }

    void OnMessage(int from, JToken data)
    {
        AirConsole.instance.Message(from, "Full of pixels!");
    }
}
