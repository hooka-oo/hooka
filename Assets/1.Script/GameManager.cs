using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    float time;
    public bool isDay; 

    void Start()
    {
        isDay = true;
        Debug.Log("낮");
        StartCoroutine(DayNightRoutine());
        
    }

    void Update()
    {
        
    }

    IEnumerator DayNightRoutine()
    {
        while (true) // 무한 반복
        {
            if (isDay)
            {
                yield return new WaitForSeconds(5f);
                Debug.Log("밤");
                isDay = false;
            }
            else
            {
                yield return new WaitForSeconds(5f);
                Debug.Log("낮");
                isDay = true;
            }
        }
    }
}
