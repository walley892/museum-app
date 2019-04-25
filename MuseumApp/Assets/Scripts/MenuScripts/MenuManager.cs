using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    //private static MenuState MenuState;

    // Start is called before the first frame update
    void Start(){
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleLanguage(){
        MenuState.toggleLanguage();

        if (MenuState.english()){
            GameObject.Find("WelcomeText").GetComponent<Text>().text = "Kallinikeio";
            GameObject.Find("MuseumText").GetComponent<Text>().text = "Municipal Museum of Athienou";

            GameObject.Find("TourButton").GetComponentInChildren<Text>().text = "Tour";
            GameObject.Find("LibraryButton").GetComponentInChildren<Text>().text = "Library";
            GameObject.Find("SettingsButton").GetComponentInChildren<Text>().text = "Settings";
            GameObject.Find("LanguageButton").GetComponentInChildren<Text>().text = "Ελληνικά";
            GameObject.Find("ExitButton").GetComponentInChildren<Text>().text = "Exit";
            GameObject.Find("CreditsButton").GetComponentInChildren<Text>().text = "Credits";
        }
        else {
            GameObject.Find("WelcomeText").GetComponent<Text>().text = "Καλλινίκειο";
            GameObject.Find("MuseumText").GetComponent<Text>().text = "Δημοτικό Μουσείο Αθηένου";

            GameObject.Find("TourButton").GetComponentInChildren<Text>().text = "Περιοδεία";
            GameObject.Find("LibraryButton").GetComponentInChildren<Text>().text = "Βιβλιοθήκη";
            GameObject.Find("SettingsButton").GetComponentInChildren<Text>().text = "Ρυθμίσεις";
            GameObject.Find("LanguageButton").GetComponentInChildren<Text>().text = "Εnglish";
            GameObject.Find("ExitButton").GetComponentInChildren<Text>().text = "Εξοδος";
            GameObject.Find("CreditsButton").GetComponentInChildren<Text>().text = "Πιστώσεις";
        }


    }


    public void updateText(){

        if (MenuState.english()){
            if (GameObject.Find("WelcomeText") != null) GameObject.Find("WelcomeText").GetComponent<Text>().text = "Kallinikeio";
            if (GameObject.Find("MuseumText") != null) GameObject.Find("MuseumText").GetComponent<Text>().text = "Municipal Museum of Athienou";

            if (GameObject.Find("TourText") != null) GameObject.Find("TourText").GetComponent<Text>().text = "Tour";
            if (GameObject.Find("LibraryText") != null) GameObject.Find("LibraryText").GetComponent<Text>().text = "Library";
            if (GameObject.Find("SettingsText") != null) GameObject.Find("SettingsText").GetComponent<Text>().text = "Settings";
            if (GameObject.Find("LanguageText") != null) GameObject.Find("LanguageText").GetComponent<Text>().text = "Ελληνικά";
            if (GameObject.Find("ExitText") != null) GameObject.Find("ExitText").GetComponent<Text>().text = "Exit";
            if (GameObject.Find("CreditsText") != null) GameObject.Find("CreditsText").GetComponent<Text>().text = "Credits";

            if (GameObject.Find("BackButton") != null) GameObject.Find("BackButton").GetComponentInChildren<Text>().text = "Back";
        
        }
        else {
            if (GameObject.Find("WelcomeText") != null) GameObject.Find("WelcomeText").GetComponent<Text>().text = "Καλλινίκειο";
            if (GameObject.Find("MuseumText") != null) GameObject.Find("MuseumText").GetComponent<Text>().text = "Δημοτικό Μουσείο Αθηένου";

            if (GameObject.Find("TourText") != null) GameObject.Find("TourText").GetComponent<Text>().text = "Περιοδεία";
            if (GameObject.Find("LibraryText") != null) GameObject.Find("LibraryText").GetComponent<Text>().text = "Βιβλιοθήκη";
            if (GameObject.Find("SettingsText") != null) GameObject.Find("SettingsText").GetComponent<Text>().text = "Ρυθμίσεις";
            if (GameObject.Find("LanguageText") != null) GameObject.Find("LanguageText").GetComponent<Text>().text = "English";
            if (GameObject.Find("ExitText") != null) GameObject.Find("ExitText").GetComponent<Text>().text = "Εξοδος";
            if (GameObject.Find("CreditsText") != null) GameObject.Find("CreditsText").GetComponent<Text>().text = "Πιστώσεις";

            if (GameObject.Find("BackButton") != null) GameObject.Find("BackButton").GetComponentInChildren<Text>().text = "Πίσω";

        }



    }

}
