using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Cursor.lockState = CursorLockMode.Confined;
    }
}
