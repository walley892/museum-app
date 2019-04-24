using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static LocalModelManager;

    //  This class is used to keep track of menu states such as language/graphic settings & cached models
public static class MenuState
{

    private static LocalModelManager _manager;
    private static bool _english;

    static MenuState(){
        _manager = new LocalModelManager("Models");
        _english = false;
    }

    public static bool english(){
        return _english;
    }

    public static void setLanguage(bool english){
        _english = english;
    }

    public static GameObject getModel(int modelID){
        return _manager.createModel(modelID);
    }



}


