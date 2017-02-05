using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CUGUIBaseUI : CBetterUI {
    public GameObject GetCtrl(string name) {
        GameObject obj = (GameObject)Get(name);
        if (!obj) {

            Debug.LogWarning("GetCtrl Failed!! Name:" + name + ",transform.name:" + transform.name + ",m_lstData" + m_lstData.Count);
        }
        return obj;
    }
    public void AddCtrl(GameObject obj) {
        Add(obj);
    }
    public Text GetText(string name) {
        GameObject obj = GetCtrl(name);
        if (!obj) return null;

        Text com = obj.GetComponent<Text>() as Text;
        if (!com) Debug.LogWarning("GetLabel Failed!! Name:" + name);
        return com;
    }

    public BJLanguageTextPair GetTextPair(string name) {
        Text res = GetText(name);
        if (res == null) {
            return null;
        }
        return new BJLanguageTextPair(res);
    }

    public RawImage GetTexture(string name) {
        GameObject obj = GetCtrl(name);
        if (!obj) return null;

        RawImage com = obj.GetComponent<RawImage>() as RawImage;
        if (!com) Debug.LogWarning("GetTexture Failed!! Name:" + name);
        return com;
    }

    public InputField GetInputField(string name) {
        GameObject obj = GetCtrl(name);
        if (!obj) return null;

        InputField com = obj.GetComponent<InputField>() as InputField;
        if (!com) Debug.LogWarning("UIInput Failed!! Name:" + name);
        return com;
    }

    public Image GetSprite(string name) {
        GameObject obj = GetCtrl(name);
        if (!obj) return null;

        Image com = obj.GetComponent<Image>() as Image;
        if (!com) Debug.LogWarning("GetSprite Failed!! Name:" + name);
        return com;
    }    

    public void Show(GameObject obj, bool state) {
        obj.SetActive(state);
    }
    public void ShowCtrl(string objname, bool state) {
        GameObject obj = GetCtrl(objname);
        if (!obj) return;
        obj.SetActive(state);
    }

    public void EnableBtn(string objname, bool bEnable) {
        var obj = GetButton(objname);
        if (!obj) return;
        obj.enabled = bEnable;
    }

    public Button GetButton(string name) {
        GameObject obj = GetCtrl(name);
        if (!obj) return null;

        Button com = obj.GetComponent<Button>() as Button;
        if (!com) Debug.LogWarning("GetLabel Failed!! Name:" + name);
        return com;
    }

    public Slider GetSlider(string name) {
        GameObject obj = GetCtrl(name);
        if (!obj) return null;

        Slider com = obj.GetComponent<Slider>() as Slider;
        if (!com) Debug.LogWarning("GetSlider Failed!! Name:" + name);
        return com;
    }

    public Toggle GetToggle(string name) {
        GameObject obj = GetCtrl(name);
        if (!obj) return null;

        var com = obj.GetComponent<Toggle>() as Toggle;
        if (!com) Debug.LogWarning("GetCheck Failed!! Name:" + name);
        return com;
    }

    public Image GetPanel(string name) {
        GameObject obj = GetCtrl(name);
        if (!obj) return null;

        Image com = obj.GetComponent<Image>() as Image;
        if (!com) Debug.LogWarning("GetPanel Failed!! Name:" + name);
        return com;
    }

    public Vector3 WorldToScreenPoint(GameObject obj) {
        if (!obj) return Vector3.zero;
        return UICamera.currentCamera.WorldToScreenPoint(obj.transform.position);
    }

    public Camera GetCurUICamera() {
        return UICamera.currentCamera;
    }

    public void Destroy(Component obj) {
        UnityEngine.Object.Destroy(obj);
    }

    public void DestroyGameObject(GameObject obj) {
        UnityEngine.Object.Destroy(obj);
    }

    public void DestroyGameObjectByTime(GameObject obj, float t) {
        UnityEngine.Object.Destroy(obj, t);
    }

    public void DestroyImmediate(GameObject obj) {
        UnityEngine.Object.DestroyImmediate(obj);
    }

    static public Transform FindChild(GameObject ObjParent, string strChildName) {
        Transform objtrs = ObjParent.transform.FindChild(strChildName);
        if (objtrs != null)
            return objtrs;

        Transform[] transforms = ObjParent.GetComponentsInChildren<Transform>(true);
        foreach (Transform trs in transforms) {
            if (trs.gameObject.name == strChildName)
                return trs;
        }

        return null;
    }

    public Text FindChildText(GameObject ObjParent, string strChildName) {
        Transform trs = FindChild(ObjParent, strChildName);
        if (trs == null) {
            Debug.LogError("SetLabel Failed!! Name:" + strChildName);
            return null;
        }
        Text com = trs.GetComponent<Text>() as Text;
        if (!com) Debug.LogWarning("GetLabel Failed!! Name:" + strChildName);
        return com;
    }

    public Slider FindChildSlider(GameObject ObjParent, string strChildName) {
        Transform trs = FindChild(ObjParent, strChildName);
        if (trs == null) {
            Debug.LogError("Slider Failed!! Name:" + strChildName);
            return null;
        }
        Slider com = trs.gameObject.GetComponent<Slider>() as Slider;
        if (!com) Debug.LogWarning("Slider Failed!! Name:" + strChildName);
        return com;
    }

    public Image FindChildImage(GameObject ObjParent, string strChildName) {
        Transform trs = FindChild(ObjParent, strChildName);
        if (trs == null) {
            Debug.LogError("SetLabel Failed!! Name:" + strChildName);
            return null;
        }
        Image com = trs.gameObject.GetComponent<Image>() as Image;
        if (!com) Debug.LogWarning("Image Failed!! Name:" + strChildName);
        return com;
    }

    public GameObject Find(string name) {
        return GameObject.Find(name);
    }

}
