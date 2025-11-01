//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class shell : MonoBehaviour
//{
//    public GameObject shellExplosionPrefeb;
//    public AudioClip audio;
//    // Start is called before the first frame update
//    void Start()
//    {
//        //audio = this.GetComponent<AudioSource>();
//        //audio = this.GetComponent("AudioSource")as AudioSource;
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//    public void OnTriggerEnter(Collider collider)
//    {
//        AudioSource.PlayClipAtPoint(audio,transform.position);
//        GameObject.Instantiate(shellExplosionPrefeb,transform.position,transform.rotation);
//        GameObject.Destroy(this.gameObject);
//        if (collider.tag == "tank")
//        {
//            collider.SendMessage("TankDamage");
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour
{
    public GameObject shellExplosionPrefeb;
    public AudioClip audio;

    //void OnTriggerEnter(Collider collider)
    //{
    //    // 播放爆炸音效
    //    AudioSource.PlayClipAtPoint(audio, transform.position);

    //    // 创建爆炸粒子
    //    Instantiate(shellExplosionPrefeb, transform.position, transform.rotation);

    //    // 销毁子弹
    //    Destroy(this.gameObject);

    //    // 如果击中坦克，造成伤害并击退
    //    if (collider.tag == "tank")
    //    {
    //        // 扣血
    //        collider.SendMessage("TankDamage");

    //        // 击退效果
    //        Rigidbody rb = collider.GetComponent<Rigidbody>();
    //        if (rb != null)
    //        {
    //            Vector3 forceDir = collider.transform.position - transform.position;
    //            forceDir.y = 0; // 水平方向推力
    //            rb.AddForce(forceDir.normalized * 20f, ForceMode.Impulse);
    //        }
    //    }
    //}
    public void OnTriggerEnter(Collider collider)
{
    AudioSource.PlayClipAtPoint(audio, transform.position);

    Instantiate(shellExplosionPrefeb, transform.position, transform.rotation);

    Destroy(this.gameObject);

    if (collider.tag == "tank")
    {
        collider.SendMessage("TankDamage");

        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 forceDir = collider.transform.position - transform.position;
            forceDir.y = 0; // 水平击退，不弹飞
            rb.AddForce(forceDir.normalized *150f, ForceMode.Force); // 使用平缓推力
        }
    }
}

}
