 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeManeger : MonoBehaviour
{
    [SerializeField] private List<GameObject> knifeList = new List<GameObject>();

    [SerializeField] private List<GameObject> knifeIconList = new List<GameObject>();


    [SerializeField] private GameObject kinfePrefab;

    [SerializeField] private GameObject knifeIconPrefab;


    [SerializeField] private Vector2 knifeIconPosition;

    [SerializeField] private Color activeColor;

    [SerializeField] private Color disableColor;

    [SerializeField] private int kinfeCount;

    private int knifeIndex=0;
    private void Start()
    {
        CreatKnifes();
        CreatKnifeICons();
    }

    private void CreatKnifes()
    {

        for (int i = 0; i < kinfeCount; i++)
        {
            GameObject newKnife = Instantiate(kinfePrefab, transform.position,Quaternion.identity);
            newKnife.SetActive(false);
            knifeList.Add(newKnife);
        }
        knifeList[0].SetActive(true);
    }

    private void CreatKnifeICons()
    {
        for (int i = 0; i < kinfeCount; i++)
        {
            GameObject newKnifeICon = Instantiate(knifeIconPrefab, knifeIconPosition, knifeIconPrefab.transform.rotation);
            newKnifeICon.GetComponent<SpriteRenderer>().color = activeColor;
            knifeIconPosition.y += 0.5f;
            knifeIconList.Add(newKnifeICon);
        }
    }

    public void SetDisableKnifeIConColor()
    {
        knifeIconList[(knifeIconList.Count - 1) - knifeIndex].GetComponent<SpriteRenderer>().color = disableColor;
    }

    public void SetActiveKnife()
    {
        if (knifeIndex< kinfeCount-1)
        {
            knifeIndex++;
            knifeList[knifeIndex].SetActive(true);
        }
    }
}
