using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class UIHandle : MonoBehaviour
{

    
    public Text testo;

   
    public SceneControl Scm;


    // Start is called before the first frame update
    void Start()
    {
        testo = GetComponent<Text>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        testo.text = ("Packages Taken: " + Scm.Packages)
 ;    }
}
