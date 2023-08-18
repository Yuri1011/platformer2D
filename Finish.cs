using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

    private bool isActivated = false;

    public void Activate() {
        isActivated = true;
    }
    public void FinishLevel() {
    // переменная isActivated контролирует объект Finish на сцене, его отображение.
        if (isActivated) {
            gameObject.SetActive(false);
        }
    }
}
