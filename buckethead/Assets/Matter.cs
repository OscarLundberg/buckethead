using System.Collections;
using System.Collections.Generic;


///<summary>
/// The types of matter that can be displayed.
/// Even are liquid, odd are rigid
///</summary>
public enum Matter {
  Water = 0,
  Ground = 1,
  Lava = 2,
}


public interface MatterData {

}

public class MatterConfig {
  public static Dictionary<Matter, MatterData> Data = new Dictionary<Matter, MatterData>() {

  };
}