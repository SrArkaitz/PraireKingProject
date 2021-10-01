using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    private Vector3 offset;
    [SerializeField] private float smoothSpeed;

    public Vector3 minValue, maxValue;
    public Transform minY, maxY, minX, maxX;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Follow();

    }


    private void FixedUpdate()
    {

        Vector3 targetPos = new Vector3(target.position.x, target.position.y, 0f);
        Vector3 cameraPos = new Vector3(transform.position.x, transform.position.y, 0f);

        if (Vector3.Distance(targetPos,cameraPos) > 1)//Deadzone de la cámara un pelin chapuzilla pero funcional
        {
            TestFollow();
        }
        
    }

    private void Follow()
    {
        Vector3 targetPos = target.position + offset;
        Vector3 boundPos = new Vector3(Mathf.Clamp(targetPos.x, minValue.x, maxValue.x), Mathf.Clamp(targetPos.y, minValue.y, maxValue.y), Mathf.Clamp(targetPos.z, minValue.z, maxValue.z));

        Vector3 smoothPos = Vector3.Lerp(transform.position, boundPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothPos;
    }

    private void TestFollow()
    {
        Vector3 targetPos = target.position + offset;
        Vector3 boundPos = new Vector3(Mathf.Clamp(targetPos.x, minX.position.x, maxX.position.x), Mathf.Clamp(targetPos.y, minY.position.y, maxY.position.y), Mathf.Clamp(targetPos.z, minValue.z, maxValue.z));

        Vector3 smoothPos = Vector3.Lerp(transform.position, boundPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothPos;
    }



}
