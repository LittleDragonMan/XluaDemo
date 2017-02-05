using UnityEngine;
using System.Collections;

public class UICamera : MonoBehaviour {

    private static UICamera instance_;
    public static UICamera Instance {
        get {
            return instance_;
        }
    }

    public static Camera currentCamera {
        get {
            return instance_.camera;
        }
    }

    public Camera camera;

    void Awake() {
        instance_ = this;
    }
}
