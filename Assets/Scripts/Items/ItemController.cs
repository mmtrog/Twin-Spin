using System.Collections;
using UnityEngine;
using DG.Tweening;

public class ItemController : MonoBehaviour
{
    public SpinSlot parentSpinSlot;

    private Vector2 original;

    private bool readyStop;

    private ItemData lastItem;

    //public AnimationCurve curve;

    public InventoryManager inventory;

    private void OnEnable ()
    {
        original = transform.localPosition;

        readyStop = false;
    }

    public void Move ()
    {
        StartCoroutine(StartMove());
    }

    IEnumerator StartMove ()
    {

        Tweener t1 = transform.DOMove(new Vector2(0, -7f), 0.8f).SetRelative().SetEase(Ease.Linear);

        yield return t1.WaitForCompletion();

    }

    private void Update ()
    {
        if (transform.localPosition.y <= -2.8)
        {
            StopAllCoroutines();

            transform.DOKill();

            StartCoroutine(ResetTrans());
        }

        if (readyStop == true && Mathf.Abs(transform.localPosition.y - original.y) <= 0.1f)
        {
            StopAllCoroutines();

            transform.DOKill();

            gameObject.GetComponent<SpriteRenderer>().enabled = true;

            if (gameObject.name == "Item 3")
            {
                inventory.Add(lastItem);  
            }

            readyStop = false;
        }
    }

    IEnumerator ResetTrans ()
    {
        lastItem = parentSpinSlot.RandomItem();

        gameObject.GetComponent<SpriteRenderer>().sprite = lastItem.icon;


        transform.DOKill();

        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        Tweener t1 = transform.DOLocalMove(new Vector2(0, 2.7f), 0.01f);

        yield return t1.WaitForCompletion();

        gameObject.GetComponent<SpriteRenderer>().enabled = true;

        StartCoroutine(StartMove());

    }

    public void SetReadyStop (bool status)
    {
    
        readyStop = status;

    }
}
