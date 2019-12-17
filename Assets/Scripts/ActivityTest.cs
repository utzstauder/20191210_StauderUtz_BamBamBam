using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityTest : MonoBehaviour
{
    public GameObject testSubject;

    private void Awake()
    {
        gameObject.SetActive(true);
        Debug.Log("Awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        if (testSubject != null)
        {
            Debug.Log("activeSelf: " + testSubject.activeSelf);
            Debug.Log("activeInHierarchy: " + testSubject.activeInHierarchy);
        }
    }
}
