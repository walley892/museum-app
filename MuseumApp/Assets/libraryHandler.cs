using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class libraryHandler : MonoBehaviour
{

    public Button button;
    public GameObject Menu;
    public GameObject UI;
    //private MenuState MenuState;


    private void Awake() {

        //MenuState = new MenuState;

        for (int model_index = 0; model_index < 3; model_index++){ // REPLACE 3 WITH THE NUMBER OF MODELS IN DATABASE
            Button lib_button = Instantiate(button);
            int temp = model_index;
            lib_button.onClick.AddListener(() => View_Model(temp));
            lib_button.GetComponentInChildren<Text>().text += (model_index + 1).ToString(); // REPLACE LATER WITH ARTIFACT NAME

            lib_button.transform.SetParent(GameObject.Find("Button Panel").transform);
            lib_button.enabled = true;
        }

        Button back_button = Instantiate(button);
        back_button.onClick.AddListener(() => LoadByIndex(0));
        back_button.GetComponentInChildren<Text>().text = "Back";
        back_button.transform.SetParent(GameObject.Find("Button Panel").transform);
        back_button.enabled = true;


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void View_Model(int model_index){
    GameObject artifact;

    artifact = MenuState.getModel(model_index);
    artifact.transform.position = new Vector3(0.0f, 3.0f, 0.0f);
    artifact.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
    artifact.name = "Library Artifact";

    Menu.SetActive(false);
    UI.SetActive(true);

    }

    public void Destroy_Artifact(){
        Destroy(GameObject.Find("Library Artifact"));
    }



    public void LoadByIndex(int sceneIndex){
        SceneManager.LoadScene(sceneIndex);
    }

}
