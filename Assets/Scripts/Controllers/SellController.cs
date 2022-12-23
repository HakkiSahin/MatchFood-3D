using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class SellController : MonoBehaviour
{
    [SerializeField] Transform tables;
    [SerializeField] Transform sellPlace;
    [SerializeField] TextMeshProUGUI yourMoneyText;
    int yourMoney;
    void Start()
    {
        yourMoney = PlayerPrefs.GetInt("Money") > 0 ? PlayerPrefs.GetInt("Money") : 0;
        yourMoneyText.text = yourMoney.ToString();
        ControlBuyObject();
    }

    private void ControlBuyObject()
    {
        for (int i = 0; i < sellPlace.childCount; i++)
        {
           
            if (PlayerPrefs.GetInt("Place" + i) >= 1)
            {
                sellPlace.GetChild(i).gameObject.SetActive(false);
                tables.GetChild(i).gameObject.SetActive(true);

            }
        }

        for (int i = 0; i < tables.childCount; i++)
        {
            if (tables.GetChild(i).gameObject.activeSelf)
            {
                if (PlayerPrefs.GetInt("Chair" + i) >= 1)
                {
                    tables.GetChild(i).GetChild(1).gameObject.SetActive(true);
                }
            }

        }
    }

    private void BuyPlace(Transform place)
    {
        PlayerPrefs.SetInt("Place" + place.name, 1);
    }

    private void BuyChair(Transform chair)
    {
        PlayerPrefs.SetInt("Chair" + chair.name, 1);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.transform.tag == "Sell")
                {

                    if (int.Parse(hit.transform.GetChild(0).GetComponent<TextMeshPro>().text) <= yourMoney)
                    {

                        MoneyChange(int.Parse(hit.transform.GetChild(0).GetComponent<TextMeshPro>().text));
                        hit.transform.gameObject.SetActive(false);
                        BuyPlace(hit.transform);
                        tables.GetChild(int.Parse(hit.transform.name)).gameObject.SetActive(true);
                    }

                }
                else if (hit.transform.tag == "Chair")
                {
                    if (1000 <= yourMoney)
                    {
                        for (int i = 0; i < hit.transform.childCount; i++)
                        {
                            if (!hit.transform.GetChild(i).gameObject.activeSelf)
                            {
                                MoneyChange(1000);
                                hit.transform.GetChild(i).gameObject.SetActive(true);
                                BuyChair(hit.transform);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    void MoneyChange(int buyMoney)
    {
        yourMoney = yourMoney - buyMoney;
        yourMoneyText.text = yourMoney.ToString();
        PlayerPrefs.SetInt("Money", yourMoney);
    }
}
