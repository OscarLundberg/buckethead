
using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Tile : MonoBehaviour
{
  private bool isWater;
  private float threshold = 1.1f;
  private List<Matter> segments;
  public Matter fill;
  public List<SpriteRenderer> sprites;

  void Start()
  {
    this.segments = new List<Matter>();
    for (int i = 0; i < MatterConfig.MaxSegments; i++)
    {
      segments.Add(this.fill);
    }
    Tick().Forget();
  }

  bool hasGaps()
  {
    return this.segments.Any(MatterConfig.isBackground) && this.segments.Any(MatterConfig.isLiquid);
  }

  bool hasLiquid()
  {
    return this.segments.Any(MatterConfig.isLiquid);
  }

  ///<summary>
  /// if a neighbour can offload liquid to this tile 
  /// </summary>
  bool acceptsLiquid(int? incomingSegment = null)
  {
    if (incomingSegment == null) { incomingSegment = MatterConfig.MaxSegments - 1; }

    for (int i = (int)incomingSegment; i >= 0; i--)
    {
      if (MatterConfig.isLiquid(segments[i]))
      {
        return true;
      }
    }
    return false;
  }

  async UniTaskVoid Tick()
  {
    await UniTask.Delay(TimeSpan.FromSeconds(MatterConfig.TickDuration), ignoreTimeScale: false);
    if (this.hasLiquid())
    {
      PropagateLiquid();
    }
    Tick().Forget();
  }

  async UniTaskVoid PropagateLiquid()
  {
    // Settle own liquid (if there are gaps)
    if (hasGaps())
    {
      // move ALL liquid segments down if they will not overlap a rigid segment (Rigid segment above liquid: UNSUPPORTE)
      // var liqSeg = getLiquidSegments()
      // for(var segObj of liqSeg){
      //    // seg: { ind: number, val: matter }
      //    // if(MatterConfig.isBackground(this.segments[ind + 1])){
      //          propaagate to target
      //          segments[ind+1] = val
      //       }
      // }
    }
    /// check gravity 
    /// (liquid should always drop to gorund level before propagating horizontally)
    var under = FindGravityNeighbour();
    if (!under.acceptsLiquid())
    {

    }

    // handle horizontal offloading
    // if anyNeighboursCanHandleIt
    // target = randomize direction from given
    // push liquid segment to target
  }


  private List<Tile> _neighbours;
  List<Tile> neighbours
  {
    get => this._neighbours ?? FindNeighbours();
  }

  Tile FindGravityNeighbour()
  {
    return neighbours.First(e => e.transform.position.y < transform.position.y);
  }

  List<Tile> FindNeighbours()
  {
    var tiles = GameObject.FindObjectsOfType<Tile>();
    if (tiles != null)
    {
      var neighbours = tiles.Where(e => Vector3.Distance(e.transform.position, transform.position) < threshold)?.ToList();
      this._neighbours = neighbours;
      return neighbours;
    }
    return new List<Tile>();
  }
}