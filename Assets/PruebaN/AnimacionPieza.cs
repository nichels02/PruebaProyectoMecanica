using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum StatePieza { Stand,Animation, End}
public class AnimacionPieza : MonoBehaviour
{
    public StatePieza state = StatePieza.Stand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AnimationPieza()
    {

        //-------

        state = StatePieza.End;
    }
}
