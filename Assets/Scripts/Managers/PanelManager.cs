using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> panels;
    
    void Start()
    {
        Time.timeScale = 0;
        closePanels();
        changePanel(0);
    }

    public void changePanel(int i)
    {
        if ((i > -1) && (i < panels.Capacity))
        {
            closePanels();
            panels[i].SetActive(true);
        }
    }

    public void closePanels()
    {
        foreach (GameObject p in panels)
        {            
            p.SetActive(false);
        }
    }
}
