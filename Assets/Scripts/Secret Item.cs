using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SecretItem : MonoBehaviour, IPointerDownHandler
{
    public int itemIndex;
    public AudioSource Audioplayer;
    public SpriteRenderer sprite;
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Audioplayer.Play();
        SaveManager.Instance.items[itemIndex] = true;
        sprite.enabled = false;
        wait();
    }

    void Start()
    {
        Audioplayer = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
    }
}