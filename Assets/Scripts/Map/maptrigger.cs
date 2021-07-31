using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maptrigger : MonoBehaviour
{
    // Start is called before the first frame update
    bool isopen;
    public GameObject mapCanvas;
    public GameObject EventSystem;
    public GameObject InvenManager;
    public GameObject InvenCam;
    public GameObject MainCam;
    public GameObject InvenBackground;

    void Start()
    {
        isopen = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(!isopen)
            {
                mapCanvas.SetActive(true);
                EventSystem.SetActive(true);
                InvenManager.SetActive(true);
                InvenCam.SetActive(true);
                InvenBackground.SetActive(true);
                MainCam.SetActive(false);
                isopen = true;
            }
            else
            {
                mapCanvas.SetActive(false);
                EventSystem.SetActive(false);
                InvenManager.SetActive(false);
                InvenCam.SetActive(false);
                InvenBackground.SetActive(false);
                MainCam.SetActive(true);
                isopen = false;
            }
        }
    }
}
