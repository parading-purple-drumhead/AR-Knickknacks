using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class TimeScript : MonoBehaviour
{
public GameObject timeText;
    string timeApiUrl = "http://worldtimeapi.org/api/timezone/America/Chicago";
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTime",2f,1f);
    }

    // UpdateTime is called once per second
    void UpdateTime()
    {
       
       StartCoroutine(GetRequest(timeApiUrl));
    }
     IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();


            if (webRequest.isNetworkError)
            {
                Debug.Log(": Error: " + webRequest.error);         
            }
            else
            {
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                int dateTime = webRequest.downloadHandler.text.IndexOf("datetime",0);
                int startTime = webRequest.downloadHandler.text.IndexOf("T",dateTime);
                int endTime = startTime + 8;
                string time = webRequest.downloadHandler.text.Substring(startTime+1,8);
                Debug.Log("Time: "+time);
                timeText.GetComponent<TextMeshPro>().text = "Current Time\n\n" + time;
            }
        }
    }
}
