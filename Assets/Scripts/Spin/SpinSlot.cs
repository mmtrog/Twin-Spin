using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpinSlot : MonoBehaviour
{
    public ItemData[] foodList;

    public GameObject slotParent;

    public float timeSpin;

    private float timeCounter;

    public List<SpriteRenderer> listSprite;

    public List<ItemController> listItem;

    public List<EventTrigger> eventButtonList;

    public new ParticleSystem particleSystem;

    private bool readyStop, readyStart;

    public void StartSpin()
    {
        timeCounter = timeSpin;

        readyStop = false;

        readyStart = true;

        foreach (ItemController itemCtl in listItem)
        {
            itemCtl.Move();
        }

    }

    private void Start ()
    {
        timeCounter = timeSpin;

        readyStart = false;

        foreach (SpriteRenderer itemSprite in listSprite)
        {
            itemSprite.sprite = foodList[new System.Random().Next(0, foodList.Length)].icon;
        }

    }

    private void Update ()
    {
        if (readyStart == true)
        {
            timeCounter -= Time.deltaTime;
        }

        if (timeCounter < 0 && readyStop == false)
        {
            readyStop = true;

            StartCoroutine (StopMove());
        }

    }

    //private ItemData lastItem;

    public ItemData RandomItem ()
    {
        ItemData lastItem = foodList[0];

        int i = Random.Range(0, 10);

        switch (i)
        {
            case 0:
            case 1:
                    lastItem = foodList[7];
            break;
            case 2:
            case 3:
            case 4:
            case 5:
                do
                {
                    lastItem = foodList[new System.Random().Next(0, foodList.Length)];
                }
                while (lastItem.value != 1);
            break;
            case 6:
            case 7:
            case 8:
            case 9:
                do
                {
                    lastItem = foodList[new System.Random().Next(0, foodList.Length)];
                }
                while (lastItem.value != 2);
            break;
            case 10:
                do
                {
                    lastItem = foodList[new System.Random().Next(0, foodList.Length)];
                }
                while (lastItem.value != 3);
            break;
        }

        return lastItem;
    }      

    IEnumerator StopMove ()
    {
        foreach (ItemController itemCtl in listItem)
        {
            itemCtl.SetReadyStop(true);
        }

        yield return new WaitForSeconds(2.5f);

        particleSystem.Play();

        foreach (EventTrigger trigger in eventButtonList)
        {
            trigger.enabled = true;
        }

        readyStart = false;
    }
}
