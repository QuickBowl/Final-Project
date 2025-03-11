using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/TimeBuff")]
public class TimeBuff : PowerupEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<GameTimer>().timer += amount;
    }


}
