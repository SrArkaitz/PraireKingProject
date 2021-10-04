using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTest : MonoBehaviour
{

    public ScreenShake screenShake;

    public void Shaking()
    {
        StartCoroutine(screenShake.Shake(0.2f, 0.2f));
    }
}
