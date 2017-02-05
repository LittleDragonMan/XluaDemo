using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LanguageManager : MonoBehaviour {

    private Dictionary<string, string> languageDic_ = new Dictionary<string, string>();
    public const string LANGUAGE_PREFIX_CONFIG_NAME = "GameConfigLanguage";
    private static LanguageManager instance_;

    public static LanguageManager GetInstance() {
        if (instance_ == null) {
            instance_ = new LanguageManager();
        }

        return instance_;
    }

    public void Clear() {
        languageDic_.Clear();
    }
    
    public void Init() {
        Clear();

        string str = LANGUAGE_PREFIX_CONFIG_NAME;
        //JsonValue json = BJUtility.LoadJsonConfig(str);
        JsonValue json = new JsonValue();
        JsonValue miscJson = json.Get("root");

        int index = 0;
        for (index = 0; index < miscJson.GetLength(); ++index) {
            JsonValue pairItem = miscJson.Get(index);
            string key = pairItem.Get("key").GetString();
            if (languageDic_.ContainsKey(pairItem.Get("key").GetString())) {
                //Debug.Log("An element with the same key already exists in the dictionary,key=" + pairItem["Key"]);
                continue;
            }
            if (key == null || key == "") {
                continue;
            }
            string typeStr = key.Substring(0, 1);

            languageDic_.Add(key, JsonUtility.UnEscapeJavascriptString(pairItem.Get("name").GetString()));
        }

    }

    public string GetText(string key) {
        if (key == null)
            return "";
        if (languageDic_.ContainsKey(key)) {
            return languageDic_[key];
        }

        return key;
    }

    public string GetText(string key, string defaultText) {
        if (languageDic_.ContainsKey(key)) {
            return languageDic_[key];
        }

        return defaultText;
    }
}
