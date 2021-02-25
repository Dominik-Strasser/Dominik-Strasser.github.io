﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUrlOnClick : MonoBehaviour
{
    public string url;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 clickPos;
        bool clicked;
 
#if UNITY_ANDROID || UNITY_IOS
        clicked = Input.touchCount > 0;
        if(clicked)
            clickPos = Input.GetTouch(0).position;
#else
        clicked = Input.GetMouseButtonDown(0);
        clickPos = Input.mousePosition;
#endif
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(clickPos);
        if (Physics.Raycast(ray, out hit) && clicked && hit.collider.name == transform.name)
        {
            Application.OpenURL(url);
        }
    }
}