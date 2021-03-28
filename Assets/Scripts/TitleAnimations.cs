using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimations : MonoBehaviour
{
    public Animation anim;
    public List<string> clips;
    public string clipName;
    public int index = 1;
    public float current=0;
    private void Awake()
    {
        anim = GetComponent<Animation>();
        anim.wrapMode = WrapMode.Loop;
    }
    // Start is called before the first frame update
    void Start()
    {
        clips = new List<string>();
        foreach(AnimationState state in anim)
        {
            clips.Add(state.name);
        }
        anim.Play(clips[0]);
    }

    // Update is called once per frame
    //void Update()
    //{
        //for(int i =0; i<clips.Count;i++)
        //current += Time.deltaTime;
        //if(current>1f)
        //{
        //    current = 0;
        //    index++;
        //    if (index >= clips.Count) index = 1;
        //    clipName = clips[index];
        //    anim.Play(clipName);
        //}
        
    //}
}
