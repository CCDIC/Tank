//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TankAttack : MonoBehaviour
//{
//    private Transform FirePosition;
//    public GameObject shellPrefab;
//    public KeyCode fireKey = KeyCode.Space;
//    public float shellSpeed = 10;
//    public AudioClip fireSound;
//    // Start is called before the first frame update
//    void Start()
//    {
//        FirePosition = transform.Find("FirePosition");
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(fireKey)) {
//            AudioSource.PlayClipAtPoint(fireSound,transform.position);
//            GameObject go = GameObject.Instantiate(shellPrefab,FirePosition.position,FirePosition.rotation) as GameObject;
//            go.GetComponent<Rigidbody>().velocity=go.transform.forward*shellSpeed;

//        }
//    }
//}

//蓄力
//using UnityEngine;

//public class TankAttack : MonoBehaviour
//{
//    public GameObject shell;
//    public Transform firePosition;
//    public KeyCode fireKey = KeyCode.Space;

//    public float minPower = 10f;
//    public float maxPower = 50f;
//    public float chargeRate = 20f;

//    private float currentPower;
//    private bool isCharging;

//    void Update()
//    {
//        if (Input.GetKeyDown(fireKey))
//        {
//            isCharging = true;
//            currentPower = minPower;
//        }

//        if (Input.GetKey(fireKey) && isCharging)
//        {
//            currentPower += chargeRate * Time.deltaTime;
//            currentPower = Mathf.Min(currentPower, maxPower);
//        }

//        if (Input.GetKeyUp(fireKey) && isCharging)
//        {
//            FireShell(currentPower);
//            isCharging = false;
//        }
//    }

//    void FireShell(float speed)
//    {
//        GameObject go = Instantiate(shell, firePosition.position, firePosition.rotation);
//        go.GetComponent<Rigidbody>().velocity = go.transform.forward * speed;
//    }
//}


//蓄力条
//using UnityEngine;
//using UnityEngine.UI; // 引入 UI 命名空间

//public class TankAttack : MonoBehaviour
//{
//    public GameObject shell;
//    public Transform firePosition;
//    public KeyCode fireKey = KeyCode.Space;

//    public float minPower = 0f;
//    public float maxPower = 35f;
//    public float chargeRate = 2f;

//    private float currentPower;
//    private bool isCharging;

//    public Slider chargeBar;  // 引用 UI 进度条
//    void Start()
//    {
//        // 初始隐藏蓄力条
//        if (chargeBar != null)
//            chargeBar.gameObject.SetActive(false);
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(fireKey))
//        {
//            isCharging = true;
//            currentPower = minPower;
//            if (chargeBar != null)
//                chargeBar.gameObject.SetActive(true);
//        }

//        if (Input.GetKey(fireKey) && isCharging)
//        {
//            currentPower += chargeRate * Time.deltaTime;
//            currentPower = Mathf.Min(currentPower, maxPower);

//            if (chargeBar != null)
//                chargeBar.value = currentPower;
//        }

//        if (Input.GetKeyUp(fireKey) && isCharging)
//        {
//            FireShell(currentPower);
//            isCharging = false;

//            if (chargeBar != null)
//            {
//                chargeBar.value = 0;
//                chargeBar.gameObject.SetActive(false);
//            }
//        }
//    }

//    void FireShell(float speed)
//    {
//        GameObject go = Instantiate(shell, firePosition.position, firePosition.rotation);
//        go.GetComponent<Rigidbody>().velocity = go.transform.forward * speed;

//    }
//}

//箭头
using UnityEngine;
using UnityEngine.UI; // 引入 UI 命名空间

public class TankAttack : MonoBehaviour
{
    public GameObject shell;
    public Transform firePosition;
    public KeyCode fireKey = KeyCode.Space;

    public float minPower = 0f;
    public float maxPower = 35f;
    public float chargeRate = 2f;

    private float currentPower;
    private bool isCharging;
    public Transform powerArrow;  // 拖入场景中的箭头对象
    public float arrowMaxScale = 3f;  // 最长拉伸比例


    public Slider chargeBar;  // 引用 UI 进度条
    void Start()
    {
        // 初始隐藏蓄力条
        if (chargeBar != null)
            chargeBar.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            isCharging = true;
            currentPower = minPower;

            if (chargeBar != null) chargeBar.gameObject.SetActive(true);
            if (powerArrow != null) powerArrow.localScale = Vector3.one;
        }

        if (Input.GetKey(fireKey) && isCharging)
        {
            currentPower += chargeRate * Time.deltaTime;
            currentPower = Mathf.Min(currentPower, maxPower);

            if (chargeBar != null) chargeBar.value = currentPower;

            if (powerArrow != null)
            {
                float scaleY = Mathf.Lerp(1f, arrowMaxScale, currentPower / maxPower);
                powerArrow.localScale = new Vector3(1f, scaleY, 1f);  // 拉长箭头
            }
        }

        if (Input.GetKeyUp(fireKey) && isCharging)
        {
            FireShell(currentPower);
            isCharging = false;

            if (chargeBar != null)
            {
                chargeBar.value = 0;
                chargeBar.gameObject.SetActive(false);
            }

            if (powerArrow != null)
                powerArrow.localScale = Vector3.one;
        }

    }

    void FireShell(float speed)
    {
        GameObject go = Instantiate(shell, firePosition.position, firePosition.rotation);
        go.GetComponent<Rigidbody>().velocity = go.transform.forward * speed;

    }
}