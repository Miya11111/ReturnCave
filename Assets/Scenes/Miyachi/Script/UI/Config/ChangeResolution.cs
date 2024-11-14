using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeResolution : MonoBehaviour
{
    public void Onclick_800x600(){
        Screen.SetResolution(800, 600, FullScreenMode.Windowed);
    }

    public void Onclick_1600x1200(){
        Screen.SetResolution(1600,1200, FullScreenMode.Windowed);
    }

    public void Onclick_FullScreen(){
        Screen.SetResolution(1600,1200, true);
    }
}
