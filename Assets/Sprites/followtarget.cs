using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followtarget : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    private Vector3 offset;
    private Camera cam; 
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position-(player1.position+player2.position)/2;
        cam = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 == null || player2 == null) return;
        transform.position = offset+ (player1.position + player2.position) / 2;   
        float distance = Vector3.Distance(player1.position, player2.position);
        float size = distance * 1.00f;
        cam.orthographicSize = size;
    }
}
