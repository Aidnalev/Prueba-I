using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationUI : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        if (ControlDeAnimaciones.currentAnimation != null)
        {
            Animator animator = GetComponent<Animator>();
            animator.SetTrigger(ControlDeAnimaciones.currentAnimation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
