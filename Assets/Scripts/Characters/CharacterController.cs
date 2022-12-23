using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.Rendering.DebugUI;
using DG.Tweening;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Transform deposits;

    public GameObject depositCount;
    public Animator anim;

    GameObject table;

    #region Customers
    [Header("Customers")]

    public List<GameObject> customerOrderList;
    public List<CustomersController> customerList;
    public CafeController cafeControllers;
    #endregion

    [SerializeField] GameObject plate;
    [SerializeField] Transform plateSpawn;
    [SerializeField] Transform cwp;


   
    void Start()
    {
        table = GameObject.FindWithTag("Table");
    }

    float time = 0f;
    private void Update()
    {
        if (time <= 0.2f)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0f;
            NextPartBusy();           
        }

        ScreenShot();

    }

    public void LevelStart()
    {
        FillTheOrderList();
    }


    void ScreenShot()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ScreenCapture.CaptureScreenshot("game" + PlayerPrefs.GetInt("s") + ".png");
            PlayerPrefs.SetInt("s", PlayerPrefs.GetInt("s") + 1);
            Time.timeScale = 0.001f;
            Debug.Log("Selection");
        }
        if (Input.GetKeyDown(KeyCode.A)) Time.timeScale = 1;
    }


    public void FillTheOrderList()
    {
        customerOrderList.Clear();
        customerOrderList = customerList[0].orders;
        activePlate = null;

        if (!isBusy)
        {
            MakeHamburger();
        }

    }



    public void FillTheCustomerList(CustomersController customers)
    {

        customerList.Add(customers);


        if (customerList.Count <= 1)
            FillTheOrderList();
    }


    string orderName;
    IEnumerator MoveToBox(Transform goPos)
    {
        isWork = true;
        orderName = "";
        anim.SetTrigger("isLeft");
        float i = 0.0f;



        while (i < 1.0f)
        {

            i += Time.deltaTime * 0.15f;
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(goPos.position.x, transform.position.y, transform.position.z), i);
            if (Vector3.Distance(transform.position,
                new Vector3(goPos.position.x, transform.position.y, transform.position.z)) <= 0.1f)
            {
                break;
            }
            yield return null;
        }

        anim.SetTrigger("isIdle");
        yield return new WaitForSeconds(1f);
        goPos.GetComponent<Animator>().SetTrigger("OpenBox");

        anim.SetTrigger("isRight");





        i = 0.0f;
        while (i < 1.0f)
        {

            i += Time.deltaTime * 0.15f;
            transform.position = Vector3.Lerp(transform.position,
               new Vector3(goPos.tag == "Cutting" ? -2.5f : -5f, transform.position.y, transform.position.z), i);

            if (Vector3.Distance(transform.position,
               new Vector3(goPos.tag == "Cutting" ? -2.5f : -5f, transform.position.y, transform.position.z)) <= 0.3f)
            {
                anim.SetTrigger("isIdle");
                break;
            }
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        orderName = goPos.name;

        PlayAnim(Enum.Parse<AnimSet>(goPos.tag));


    }

    bool isWork = false;
    void PlayAnim(AnimSet animEnum)
    {
        anim.SetTrigger("isIdle");

        switch (animEnum)
        {
            case AnimSet.Cutting:
                anim.SetTrigger("isCut");

                break;
            case AnimSet.Cooking:
                anim.SetTrigger("isCook");

                break;
            default:
                break;
        }

        isWork = false;


    }


    public void GoNext()
    {
        NextPart();

    }

    public void NextPart()
    {
        anim.SetTrigger("isIdle");
        StopAllCoroutines();
        StartCoroutine(Prepare());
    }

    public void NextPartBusy()
    {
        if (!isWork)
            NextPart();
    }

    GameObject activePlate = null;
    void MakeHamburger()
    {
        StopAllCoroutines();
        activePlate = Instantiate(plate, plateSpawn.position, plate.transform.rotation);
        StartCoroutine(Prepare());
    }

    public void FailPrepare()
    {
        customerOrderList.Clear();
        StopAllCoroutines();
        Destroy(activePlate);
        StartCoroutine(MoveStartPos());
    }

    IEnumerator MoveStartPos()
    {
        float i = 0f;
        while (i < 1.0f)
        {

            i += Time.deltaTime * 0.3f;
            transform.position = Vector3.Lerp(transform.position,
               new Vector3(cwp.position.x, transform.position.y, transform.position.z), i);
            yield return null;
        }
        ControlCustomerCount();
    }

    bool isBreak;
    bool isBusy = false;
    IEnumerator Prepare()
    {
        isBusy = true;
        time = 0f;
        yield return new WaitForEndOfFrame();

        for (int i = 0; i < customerOrderList.Count; i++)
        {
            for (int j = 0; j < depositCount.transform.childCount; j++)
            {
                if (customerOrderList[i].transform.name.Contains(depositCount.transform.GetChild(j).transform.name))
                {
                    if (int.Parse(depositCount.transform.GetChild(j).GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text) > 0)
                    {
                        StartCoroutine(MoveToBox(deposits.GetChild(j).transform));
                        depositCount.transform.GetChild(j).GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text = (int.Parse(depositCount.transform.GetChild(j).GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text) - 1).ToString();
                        CustomerOrderRemove(customerOrderList[i].transform.name);
                        EnabledPlateOrder(customerOrderList[i].transform.name);
                        customerOrderList.RemoveAt(i);
                        isBreak = true;
                        break;
                    }
                }
            }
            if (isBreak)
                break;
        }
        isBreak = false;



        if (customerOrderList.Count <= 0)
        {

            isBusy = false;
            if (customerList.Count > 0)
            {
                customerList.RemoveAt(0);
                cafeControllers.RemoveCustomer(activePlate);
                if (customerList.Count > 0)
                {
                    FillTheOrderList();
                }
            }
        }
    }

    private void CustomerOrderRemove(string name)
    {
        for (int i = 0; i < customerList[0].transform.GetChild(0).childCount; i++)
        {
            if (name == customerList[0].transform.GetChild(0).GetChild(i).name)
            {
                customerList[0].transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    void ControlCustomerCount()
    {

        isBusy = false;
        if (customerList.Count > 0)
        {
            customerList.RemoveAt(0);
            if (customerList.Count > 0)
            {
                FillTheOrderList();
            }
        }

    }

    void EnabledPlateOrder(string orderName)
    {

        for (int i = 0; i < activePlate.transform.childCount; i++)
        {
            if (activePlate.transform.GetChild(i).name == orderName)
            {
                activePlate.transform.GetChild(i).gameObject.SetActive(true);
                break;
            }
        }
    }
}

public enum AnimSet
{
    Cutting,
    Cooking,

}


