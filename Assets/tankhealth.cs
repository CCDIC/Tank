//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class tankhealth : MonoBehaviour
//{
//    public int hp = 100;
//    public GameObject tankExpositon;
//    public AudioClip tankExpositonClip;
//    public Slider hpslider;
//    private int hptotal;
//    // Start is called before the first frame update
//    void Start()
//    {
//        hptotal = hp;
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//    void TankDamage()
//    {
//        if (hp <= 0)return;
//        hp -= Random.Range(10, 20);
//        hpslider.value = (float)hp /hptotal;    
//        if (hp <= 0)
//        {
//            AudioSource.PlayClipAtPoint(tankExpositonClip, transform.position);
//            GameObject.Instantiate(tankExpositon,transform.position+Vector3.up,transform.rotation);
//            GameObject.Destroy(this.gameObject);
//        }
//    }
//}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class tankhealth : MonoBehaviour
//{
//    public int hp = 100;
//    public GameObject tankExpositon;
//    public AudioClip tankExpositonClip;
//    public Slider hpslider;
//    private int hptotal;

//    void Start()
//    {
//        hptotal = hp;
//    }

//    void TankDamage()
//    {
//        if (hp <= 0) return;

//        hp -= Random.Range(10, 20);
//        hpslider.value = (float)hp / hptotal;

//        if (hp <= 0)
//        {
//            AudioSource.PlayClipAtPoint(tankExpositonClip, transform.position);
//            Instantiate(tankExpositon, transform.position + Vector3.up, transform.rotation);
//            Destroy(this.gameObject);
//        }
//    }

//    // 新增：坦克之间碰撞时扣血
//    void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("tank"))
//        {
//            if (hp <= 0) return;

//            hp -= Random.Range(5, 10);
//            hpslider.value = (float)hp / hptotal;

//            if (hp <= 0)
//            {
//                AudioSource.PlayClipAtPoint(tankExpositonClip, transform.position);
//                Instantiate(tankExpositon, transform.position + Vector3.up, transform.rotation);
//                Destroy(this.gameObject);
//            }
//        }
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tankhealth : MonoBehaviour
{
    public int hp = 100;
    public GameObject tankExpositon;
    public AudioClip tankExpositonClip;
    public Slider hpslider;
    private int hptotal;
    public GameObject collisionEffectPrefab;



    void Start()
    {
        hptotal = hp;
    }

    void TankDamage()
    {
        if (hp <= 0) return;

        hp -= Random.Range(10, 20);
        hpslider.value = (float)hp / hptotal;

        if (hp <= 0)
        {
            AudioSource.PlayClipAtPoint(tankExpositonClip, transform.position);
            Instantiate(tankExpositon, transform.position + Vector3.up, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    // 新增：坦克之间碰撞时扣血
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("tank"))
        {
            if (hp <= 0) return;

            // 播放火花粒子（使用 Squares Explode）
            ContactPoint contact = collision.contacts[0];
            Vector3 hitPoint = contact.point;
            Instantiate(collisionEffectPrefab, hitPoint, Quaternion.identity);

            // 扣血逻辑
            hp -= Random.Range(5, 10);
            hpslider.value = (float)hp / hptotal;

            if (hp <= 0)
            {
                AudioSource.PlayClipAtPoint(tankExpositonClip, transform.position);
                Instantiate(tankExpositon, transform.position + Vector3.up, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }

}
