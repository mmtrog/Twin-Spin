using System.Collections;
using UnityEngine;

public class FlickerEffect : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public float timeFlicker;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(Flicker());
    }

    IEnumerator Flicker ()
    {
        spriteRenderer.enabled = false;

        yield return new WaitForSeconds(timeFlicker);

        spriteRenderer.enabled = true;

        yield return new WaitForSeconds(timeFlicker);

        StartCoroutine(Flicker());
    }
}
