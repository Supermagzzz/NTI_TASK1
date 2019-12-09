using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solution : MonoBehaviour {

    private SceneController controller;

    void Start() {
        controller = gameObject.GetComponent<SceneController>();
    }
}
