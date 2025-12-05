using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUI : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerController pc;
    void Start()
    {
        pc=PlayerController.Instance;
        InvokeRepeating("ModifyInflationScale", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ModifyInflationScale()
    {
        pc.inflationScale = 0.7f;
    }
}
