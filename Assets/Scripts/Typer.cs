using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Typer : MonoBehaviour
{
    public string phrase;
    public float typingTime;
    public float closeTime;
    public Text uiText;
    public GameObject textPanel;
    public Animator panelAnimator;
    [SerializeField]
    private bool wasTriggered = false;
    [SerializeField]
    private bool wasCompleted = false;
    public AudioSource audio;
    public VideoPlayer video;

    public enum Zona {
        Zona1, Zona2, Zona3, Zona4
    }
    public Zona zona;
    private void Start()
    {
        textPanel.SetActive(false);
        video.Stop();
    }

    private void Update()
    {
        if (wasTriggered == true && wasCompleted == false)
        {
            textPanel.SetActive(true);
            panelAnimator.SetTrigger("start");
            //start animation
            if (zona == Zona.Zona2)
            {
                video.Play();
            }
            else if (zona == Zona.Zona3) {
                video.Stop();
            }
            
        }

        if (uiText.text == phrase) {
            //do something
            StartCoroutine(Close());
        }    

    }


    IEnumerator Type() {
        foreach (char letter in phrase.ToCharArray())
        {
            uiText.text += letter;
            yield return new WaitForSeconds(typingTime);
        }
    }

    IEnumerator Close() {
        yield return new WaitForSeconds(closeTime);
        wasCompleted = true;
        textPanel.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        uiText.text = "";
        if (other.gameObject.CompareTag("Player")) {
            wasTriggered = true;
            StartCoroutine(Type());
        }
    }

}
