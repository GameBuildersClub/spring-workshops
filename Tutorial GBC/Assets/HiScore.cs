using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HiScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("HiScore").ToString("F2");
    }
}
