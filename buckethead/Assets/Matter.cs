using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// The types of matter that can be displayed.
/// Negatives are background
/// Positives: Even are liquid, odd are rigid
///</summary>
public enum Matter
{
  Sky = -5,
  Underground = -4,
  Water = 2,
  Ground = 3,
  Lava = 4,
}


public struct MatterData
{
  public Color color;
}

public class MatterConfig
{
  public static float TickDuration = 0.2f;
  public static int MaxSegments = 5;
  public static Dictionary<Matter, MatterData> Data = new Dictionary<Matter, MatterData>() {
    { Matter.Underground,  new MatterData() { color = new Color(25, 16, 0) }},
    { Matter.Water,  new MatterData() { color = new Color(37, 150, 190) }},
    { Matter.Ground,  new MatterData() { color = new Color(74.5f, 30.2f, 14.5f) }},
    { Matter.Lava,  new MatterData() { color = new Color(255, 124, 0) }},
  };

  public static bool isLiquid(Matter e)
  {
    return (int)e % 2 == 0 && (int)e > 0;
  }

  public static bool isBackground(Matter e){
    return e < 0;
  }
}