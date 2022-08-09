using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Food : MonoBehaviour
{
    private void OnMouseUp ()
    {
        transform.DOMove(Vector2.zero, 1);
    }

}
