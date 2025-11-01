using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankmoverment : MonoBehaviour
{
    public float speed = 5;
    public float angularspeed = 30;
    private Rigidbody rb;
    public float number = 1;
    public AudioClip idleAudio;
    public AudioClip activeAudio;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float v = Input.GetAxis("VerticalPlayer"+number);
        rb.velocity = transform.forward * v * speed;

        float h = Input.GetAxis("HorizontalPlayer" + number);
        rb.angularVelocity = transform.up * h * angularspeed;

        if (Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1)
        {
            audio.clip = activeAudio;
            if(audio.isPlaying==false)
            audio.Play();
        }
        else
        {
            audio.clip = idleAudio;
            if (audio.isPlaying == false)
                audio.Play();
        }
    }
}
