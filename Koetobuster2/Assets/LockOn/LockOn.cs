using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{
    public static int lockon_flag;

    //idx0 = four triangles
    //idx1 = a circle
    public Animator[] LockOnAnim = new Animator[2];
    public Animator[] LockOnAnim2 = new Animator[2];
    public Animator[] LockOnAnim3 = new Animator[2];
    public Animator[] LockOnAnim4 = new Animator[2];

    void Start()
    {
        lockon_flag = 0;
    }

    void Update()
    {
        if(lockon_flag == 1){
            LockOnAnim[0].SetInteger("lockon_flag", 1); 
            LockOnAnim[1].SetInteger("lockon_flag", 1); 
            LockOnAnim2[0].SetInteger("lockon_flag", 1); 
            LockOnAnim2[1].SetInteger("lockon_flag", 1); 
            LockOnAnim3[0].SetInteger("lockon_flag", 1); 
            LockOnAnim3[1].SetInteger("lockon_flag", 1); 
            LockOnAnim4[0].SetInteger("lockon_flag", 1); 
            LockOnAnim4[1].SetInteger("lockon_flag", 1); 
            lockon_flag = 0;
        }else if(lockon_flag == 0){
            LockOnAnim[0].SetInteger("lockon_flag", 0); 
            LockOnAnim[1].SetInteger("lockon_flag", 0); 
            LockOnAnim2[0].SetInteger("lockon_flag", 0); 
            LockOnAnim2[1].SetInteger("lockon_flag", 0); 
            LockOnAnim3[0].SetInteger("lockon_flag", 0); 
            LockOnAnim3[1].SetInteger("lockon_flag", 0); 
            LockOnAnim4[0].SetInteger("lockon_flag", 0); 
            LockOnAnim4[1].SetInteger("lockon_flag", 0); 
            lockon_flag = 0;
        }
    }
}
