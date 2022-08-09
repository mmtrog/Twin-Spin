using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InventoryUI : MonoBehaviour
{

    private Vector2 originalTrans;


    private void Awake ()
    {
        originalTrans = new Vector2(transform.position.x, transform.position.y);
    }


    public void Show ()
    {
        
        StartCoroutine(MoveIn());

    }

    public void Close ()
    {

        StartCoroutine(MoveOut());
    
    }

    IEnumerator MoveIn ()
    {

        Tweener t1 = transform.DOMove(Vector2.zero, 0.8f);

        yield return t1.WaitForCompletion();
    }

    IEnumerator MoveOut ()
    {
        Tweener t1 = transform.DOMove(originalTrans, 1.2f);

        yield return t1.WaitForCompletion();
    }
}
