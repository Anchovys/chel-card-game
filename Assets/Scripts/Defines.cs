﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class Defines
{
    public static string CardsDataPath;
    public static string WorkPath;
    public static string SpritesPath;

    static Defines()
    {
        WorkPath = Path.Combine("Assets", "Data");
        CardsDataPath = Path.Combine(WorkPath, "cards.json");
        SpritesPath = Path.Combine(Defines.WorkPath, "Sprites");
    }
}