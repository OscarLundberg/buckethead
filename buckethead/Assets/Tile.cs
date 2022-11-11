
using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Tile : MonoBehaviour
{
  public bool isWater;
  [Range(0, 10)]
  public float threshold = 1.1;

  public SpriteRenderer sr;
  // Start is called before the first frame update
  void Start()
  {
    this.sr = GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  async void Tick()
  {
    await UniTask.Delay(TimeSpan.FromSeconds(0.2), ignoreTimeScale: false);
    if (isWater)
    {
      this.sr.color = Color.blue;
      PropagateWater().Forget();
    }
    Tick().Forget();
  }

  async UniTaskVoid PropagateWater()
  {

    var waters = FindNeighbourWater();
    foreach (var water in waters)
    {
      water.threshold = threshold;
      water.isWater = true;
      water.sr.color = Color.blue;
    }
  }



  List<Tile> FindNeighbourWater()
  {
    var waters = GameObject.FindGameObjectsWithTag("WATER").Select(e => e.GetComponent<WaterTile>());
    if (waters != null)
      return waters.Where(e => Vector3.Distance(e.transform.position, transform.position) < threshold)?.ToList();
    return new List<Tile>();
  }
}