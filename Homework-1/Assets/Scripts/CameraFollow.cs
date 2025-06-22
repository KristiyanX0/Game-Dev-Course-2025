using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float interpolationFactor = Mathf.Clamp(Time.deltaTime * 3f, 0f, 1f);
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, interpolationFactor);
    }
}
