using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPantalla : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Cambiar(){
        SceneManager.LoadScene("Nivel0");
    }
    public void atras(){
        SceneManager.LoadScene("SampleScene");
    }
}
