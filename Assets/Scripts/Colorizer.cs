using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Colorizer
{
    public static Color GetColor()
    {
        return Random.ColorHSV(0, 1, 0.8f, 1f, 0.5f, 0.5f, 1, 1);
    }
}
