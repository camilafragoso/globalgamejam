using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoCamera : MonoBehaviour
{
    [Range(1f, 10f)]public float step;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        step = 1f * Time.deltaTime;

        var cameraPosition = Camera.main.gameObject.transform.position;
        cameraPosition.y -= step;
        Camera.main.gameObject.transform.position = cameraPosition;
    }
}
