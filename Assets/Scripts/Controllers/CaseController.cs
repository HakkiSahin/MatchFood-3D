using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using MoreMountains.Feedbacks;

public class CaseController : MonoBehaviour
{

    public GameObject moneyEffect;
    [SerializeField] CafeController;
    [SerializeField] TextMeshProUGUI money;

    //MMFeedbacks feedbacks;

    private void Start()
    {
        //  feedbacks = GameObject.Find("Feels").transform.GetChild(1).GetComponent<MMFeedbacks>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CustomersController>() != null)
        {
           
            transform.transform.GetChild(0).GetComponent<TextMeshPro>().text = other.GetComponent<CustomersController>().money.ToString();
            transform.GetChild(0).GetComponent<Animator>().SetTrigger("isMoney");

            if (other.GetComponent<CustomersController>().money > 0)
            {
                Instantiate(moneyEffect, transform.position, Quaternion.identity);
                money.text = (int.Parse(money.text) + other.GetComponent<CustomersController>().money).ToString();
                PlayerPrefs.SetInt("Money", int.Parse(money.text));
                
                
            }
            else
            {
                cafeController.ExitCustomer();

               
                //feedbacks.PlayFeedbacks();
            }

        }
    }
}
