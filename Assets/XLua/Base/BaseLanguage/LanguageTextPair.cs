
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

[System.Serializable]
public abstract class LanguageTextPair {
    public Text label;

    protected abstract bool CheckNull();
    public abstract string GetKeyStr();

    public void Refresh() {
        if (!CheckNull()) {
            label.text = LanguageManager.GetInstance().GetText(GetKeyStr());
        }
    }

    public void Refresh(string arg) {
        if (!CheckNull()) {
            label.text = String.Format(LanguageManager.GetInstance().GetText(GetKeyStr()), arg);
        }
    }

    public void AddStr(string arg) {
        if (!CheckNull()) {
            label.text = LanguageManager.GetInstance().GetText(GetKeyStr()) + arg;
        }
    }

    public void Refresh(string[] args) {
        if (!CheckNull()) {
            label.text = String.Format(LanguageManager.GetInstance().GetText(GetKeyStr()), args);
        }
    }

    public void Refresh(string arg1, string arg2) {
        if (!CheckNull()) {
            label.text = String.Format(LanguageManager.GetInstance().GetText(GetKeyStr()), arg1, arg2);
        }
    }

    public void Replace(string key) {
        label.text = LanguageManager.GetInstance().GetText(key);
    }

    public void Active(bool isActive) {
        label.gameObject.SetActive(isActive);
    }

    public void SetNull() {
        label.text = "";
    }
}

