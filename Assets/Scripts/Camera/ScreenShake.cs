using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public bool shakeOn = true;

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        if (shakeOn == true)
        {
            while (elapsed < duration)
            {
                float x = Random.Range(-0.5f, 0.5f) * magnitude;
                float y = Random.Range(-0.5f, 0.5f) * magnitude;

                transform.localPosition = new Vector3(x, y, originalPos.z);

                elapsed += Time.deltaTime;

                yield return null;
            }
        }


        transform.localPosition = originalPos;

    }
}
