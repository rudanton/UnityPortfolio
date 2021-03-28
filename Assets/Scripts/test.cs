using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text text3;
    TitleAnimations title;
    // Start is called before the first frame update
    void Awake()
    {
        title = FindObjectOfType<TitleAnimations>();
    }
    
    // Update is called once per frame
    void Update()
    {
        string cur = title.current.ToString();
        text1.text = cur;
        string ind = title.index.ToString();
        text2.text = ind;
        text3.text = title.clipName;
    }
}
