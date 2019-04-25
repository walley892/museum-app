using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    //private static MenuState MenuState;

    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleLanguage(){
        MenuState.toggleLanguage();

        if (MenuState.english()){
            GameObject.Find("LanguageButton").GetComponentInChildren<Text>().text = "Ελληνικά";
        }
        else {
            GameObject.Find("LanguageButton").GetComponentInChildren<Text>().text = "Εnglish";
        }


    }


}
