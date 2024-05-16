using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDifficulty : MonoBehaviour
{
    public void Medium()
    {
        PlayerPrefs.SetString("difficulty", "Medium");
    }
}
