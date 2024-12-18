using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using Valve.VR;

public class Password : MonoBehaviour
{
    public Text result;
    private string sumString;
    private int sum = 0;
    private int count = 0;
    private int answer = 2538;
    public GameObject Player;

    public Transform endingTransform;

    public AudioSource bgmAudioSource;
    public AudioClip endingClip; 

    // Start is called before the first frame update
    void Start()
    {
        result.text = "";
    }


    // Update is called once per frame
    public void OnButtonDown(string numTag)
    {
        GetButtonNumber(numTag);
        
    }

    public void GetButtonNumber(string numTag)
    {
        if (int.Parse(numTag) == -1)
        {
            result.text = "";
            sum = 0;
            count = 0;
            sumString = "";
        }
        else
        {

            result.text = result.text + numTag + " ";
            sumString += numTag;

            count += 1;
            if (count >= 4)
            {
                count = 0;
                sum = int.Parse(sumString);

                if (answer == sum)
                {
                    Player.transform.position = endingTransform.position;
                    Player.transform.rotation = endingTransform.rotation;

                    bgmAudioSource.clip = endingClip;
                    bgmAudioSource.Play();
                }
            }
        }
    }
}
