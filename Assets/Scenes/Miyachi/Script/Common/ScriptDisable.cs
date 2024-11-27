using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDisable : MonoBehaviour
{
    public MonoBehaviour Script;
    public void StopScript()
    {
        Script.enabled = false;
    }
}

public class MyScript
{
}