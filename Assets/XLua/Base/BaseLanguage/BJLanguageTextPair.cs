using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class BJLanguageTextPair : LanguageTextPair {
    public string key;
    public bool isUseEnum;

    public BJLanguageTextPair() {
    }

    public BJLanguageTextPair(Text txt) {
        label = txt;
        key = txt.gameObject.name;
    }

    protected override bool CheckNull() {
        return key == null || key == "" || key == "null";
    }

    public override string GetKeyStr() {
        return key;
    }
}
