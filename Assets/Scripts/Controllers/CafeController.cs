using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CafeController : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject customer;
    [SerializeField] Transform customerParents;
    [SerializeField] Transform platePos;

    [SerializeField] Transform waitPoint;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform cameraPos;
    [SerializeField] Transform camera;

    [SerializeField] Transform caseTop;
    public List<GameObject> activeCustomers;

    public List<LevelCreator> levelCreator;

    int customerCount = 2;


    public GameObject nextLevelButton;

    GameObject activeCustomer;

    #endregion
    public GameObject sellPoint;
    void Start()
    {
        //Level Startt

        if (PlayerPrefs.GetInt("CustomerCount") >= customerCount)
            customerCount = PlayerPrefs.GetInt("CustomerCount");
        else
            PlayerPrefs.SetInt("CustomerCount", customerCount);

        customerCount = PlayerPrefs.GetInt("Level") / 5 + 2 + PlayerPrefs.GetInt("CustomerCount");
        CreateCustomers();
    }


    private void CreateCustomers()
    {
        if (levelCreator.Count > PlayerPrefs.GetInt("Level"))
        {

            for (int j = 0; j < levelCreator[PlayerPrefs.GetInt("Level")].customers.Count; j++)
            {
                GameObject obj = Instantiate(customer, spawnPoint.position, Quaternion.identity, customerParents);
                activeCustomers.Add(obj);
                obj.GetComponent<CustomersController>().LevelCreate(levelCreator[PlayerPrefs.GetInt("Level")].customers[j].orders);
            }

        }
        else
        {
            for (int i = 0; i < customerCount; i++)
            {
                GameObject obj = Instantiate(customer, spawnPoint.position, Quaternion.identity, customerParents);
                activeCustomers.Add(obj);
                obj.GetComponent<CustomersController>().LevelCreate(null);

            }
        }


        StartCoroutine(GetNewPosWait());
    }

    public void RemoveCustomer(GameObject obj)
    {
        StartCoroutine(activeCustomers[0].GetComponent<CustomersController>().MoveExit(null));
        activeCustomers.RemoveAt(0);
        StartCoroutine(GetNewPosWait());
        StartCoroutine(PlatePos(obj));

    }

    IEnumerator PlatePos(GameObject obj)
    {
        float i = 0;
        while (i <= 1)
        {
            i += Time.deltaTime * 0.8f;
            obj.transform.position = Vector3.Lerp(obj.transform.position, platePos.position, i);
            yield return null;
        }
        Destroy(obj);
        obj.transform.SetParent(caseTop);
    }

    public void ExitCustomer()
    {
        activeCustomers.RemoveAt(0);
        StartCoroutine(GetNewPosWait());

    }

    IEnumerator GetNewPosWait()
    {
        yield return new WaitForSeconds(2f);
        GetNewPosition();
    }

    private void GetNewPosition()
    {


        if (activeCustomers.Count > 0)
        {
            activeCustomer = activeCustomers[0];
            activeCustomers[0].GetComponent<CustomersController>().isWait = true;
            activeCustomers[0].transform.GetChild(0).gameObject.SetActive(true);
            for (int i = 0; i < 3; i++)
            {
                activeCustomers[i].GetComponent<CustomersController>().GoToPosition(waitPoint.GetChild(i));
                if (i + 1 > customerCount)
                {
                    break;
                }
            }
        }
        else
        {
            StartCoroutine(CameraMove());
        }


    }

    public IEnumerator CameraMove()
    {

        yield return new WaitForSeconds(1f);
        StartCoroutine(activeCustomer.GetComponent<CustomersController>().MoveExit(null));
        sellPoint.SetActive(true);

        float i = 0f;
        while (i <= 1)
        {
            i += Time.deltaTime * 0.5f;
            camera.position = Vector3.Lerp(camera.position, cameraPos.position, i);
            yield return null;
        }


        nextLevelButton.SetActive(true);

    }

    public void NextLevel()
    {
        //Level End 
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        SceneManager.LoadScene("GameScene");
    }

}
