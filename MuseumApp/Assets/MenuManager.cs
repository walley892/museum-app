using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    //private static MenuState MenuState;

    // Start is called before the first frame update
    void Start(){
        //MenuState = new MenuState;
        initialize_menu_artifacts();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initialize_menu_artifacts(){
        GameObject c;

        c = MenuState.getModel(Random.Range(0, 3));
        c.transform.position = new Vector3(0.0f, 26.0f, 0.0f);
        c.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        c.name = "CenterMenuArtifact";

        c = MenuState.getModel(Random.Range(0, 3));
        c.transform.position = new Vector3(0.0f, 25.0f, 3.0f);
        c.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        c.name = "MenuArtifact1";

        c = MenuState.getModel(Random.Range(0, 3));
        c.transform.position = new Vector3(2.853f, 25.5f, 0.927f);
        c.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        c.name = "MenuArtifact2";

        c = MenuState.getModel(Random.Range(0, 3));
        c.transform.position = new Vector3(1.763f, 26.5f, -2.427f);
        c.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        c.name = "MenuArtifact3";

        c = MenuState.getModel(Random.Range(0, 3));
        c.transform.position = new Vector3(-1.763f, 25.0f, -2.427f);
        c.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        c.name = "MenuArtifact4";

        c = MenuState.getModel(Random.Range(0, 3));
        c.transform.position = new Vector3(-2.853f, 26.0f, 0.927f);
        c.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        c.name = "MenuArtifact5";
    }
}
