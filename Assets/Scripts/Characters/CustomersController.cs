using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Feedbacks;
using Random = UnityEngine.Random;

public class CustomersController : MonoBehaviour
{

    public List<GameObject> orders;
    private List<GameObject> ordersList;
    Transform exitDot;
    Transform waitPos;
    public float money = 0;
    public float waitTime = 25f;
    public bool isWait = false;
    public CharacterController character;

    bool levelCreate;

    public Color startColor;
    public Color endColor;


    GameObject go;
    public Material mat;


    public List<SkinnedMeshRenderer> headParts;

    Camera camera;
    void Start()
    {
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        go = this.gameObject;
        mat = go.transform.GetChild(2).GetChild(0).GetComponent<SkinnedMeshRenderer>().material;

        mat.color = Color.yellow;
        isWait = false;
        character = GameObject.Find("Chef").GetComponent<CharacterController>();

        transform.Rotate(0, 180f, 0);
        exitDot = GameObject.Find("ExitDot").transform;

        
    }

    public void LevelCreate(List<GameObject>? orderList)
    {
        levelCreate = (orderList != null ? true : false);

        if (levelCreate)
        {
            CreateMenu(orderList);
        }
        else
        {
            ordersList = new List<GameObject>();
            GameObject obj = GameObject.Find("ObjectCount");


            for (int i = 0; i < obj.transform.childCount; i++)
            {
                ordersList.Add(obj.transform.GetChild(i).gameObject);
            }
            CreateMenu(null);
        }
    }

    private void Update()
    {
        transform.GetChild(0).LookAt(camera.transform, Vector3.left);
        if (isWait)
        {
            waitTime -= Time.deltaTime;
            mat.color = Color.Lerp(startColor, endColor, (25 - waitTime) / 25);
            if (waitTime <= 0)
            {
                money = 0f;
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                StartCoroutine(GoExit(null));
                headParts[0].SetBlendShapeWeight(0, 100);
            }
        }
    }
    public void GoToPosition(Transform wait)
    {

        waitPos = wait;
        StartCoroutine(MoveOrder());
    }
    int count = 0;
    private void CreateMenu(List<GameObject>? orderList)
    {
        if (orderList != null)
        {
            for (int i = 0; i < orderList.Count; i++)
            {
                orders.Add(orderList[i]);
                for (int j = 0; j < transform.GetChild(0).childCount; j++)
                {
                    if (transform.GetChild(0).GetChild(j).name.Contains(orderList[i].name))
                    {
                        transform.GetChild(0).GetChild(j).gameObject.SetActive(true);
                        SizeAndPositionObject(transform.GetChild(0).childCount, transform.GetChild(0).GetChild(j).gameObject, orderList.Count);
                        money += 5;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < ordersList.Count; i++)
            {
                if (UnityEngine.Random.Range(0, 100) < 75)
                {
                    orders.Add(ordersList[i]);
                    for (int j = 0; j < transform.GetChild(0).childCount; j++)
                    {
                        if (transform.GetChild(0).GetChild(j).name.Contains(ordersList[i].name))
                        {
                            
                            transform.GetChild(0).GetChild(j).gameObject.SetActive(true);
                            SizeAndPositionObject(transform.GetChild(0).childCount, transform.GetChild(0).GetChild(j).gameObject, orders.Count);
                            money += 5;
                        }
                    }
                }
            }
        }






        AddChefOrder();
    }

    private void SizeAndPositionObject(int childCount, GameObject gameObject, int orderCount)
    {
        float size = 1f;
        if (orderCount < 5)
        {
            size = 1.2f;

            gameObject.transform.localScale = gameObject.transform.localScale * size;

            for (int i = 7; i < transform.GetChild(0).childCount; i++)
            {
                if (transform.GetChild(0).GetChild(i).name.Contains(orderCount.ToString()))
                {
                    gameObject.transform.position = transform.GetChild(0).GetChild(i).GetChild(count).transform.position;
                    count++;
                    break;
                }
            }
        }
    }

    private void AddChefOrder()
    {
        CharacterController controller = GameObject.Find("Chef").GetComponent<CharacterController>();
        controller.FillTheCustomerList(transform.GetComponent<CustomersController>());

    }



    IEnumerator MoveOrder()
    {
        float i = 0.0f;
        //transform.GetChild(2).GetComponent<Animator>().SetTrigger("isWalk");
        while (i < 1.0f)
        {

            i += Time.deltaTime * 0.2f;
            transform.position = Vector3.Lerp(transform.position,
                waitPos.position, i);
            if (Vector3.Distance(transform.position,
                waitPos.position) < 0.2f)
            {
                int a = Random.Range(1, 4);
                transform.GetChild(2).GetComponent<Animator>().SetTrigger(a.ToString());
                break;
            }

            yield return null;
        }


    }

    public IEnumerator MoveExit(GameObject? obj)
    {
        StartCoroutine(GoExit(obj));


        //if (obj != null)
        //{
        //    float i = 0.0f;

        //    while (i < 1.0f)
        //    {

        //        i += Time.deltaTime * 0.4f;
        //        obj.transform.position = Vector3.Lerp(obj.transform.position,
        //            transform.position, i);
        yield return null;
        //    }


        //    obj.transform.SetParent(transform);
        //}

        //anim.SetTrigger("isWalk");





    }

    public IEnumerator GoExit(GameObject? obj)
    {
        if (obj == null)
        {
            character.FailPrepare();
        }
        else
        {
            headParts[0].SetBlendShapeWeight(1, 0);
            //mat.color = Color.green;
        }

        transform.GetChild(0).gameObject.SetActive(false);



        isWait = false;
        StopCoroutine("MoveExit");

        float i = 0.0f;

        while (i < 1.0f)
        {
            i += Time.deltaTime * 2;
            transform.rotation = Quaternion.Lerp(transform.rotation,
                exitDot.rotation, i);

            yield return null;
        }


        transform.GetChild(2).GetComponent<Animator>().SetTrigger("isWalk");
        i = 0.0f;


        while (i < 1.0f)
        {

            i += Time.deltaTime * 0.01f;
            transform.position = Vector3.Lerp(transform.position,
                exitDot.position, i);
            yield return null;
        }

    }
}
