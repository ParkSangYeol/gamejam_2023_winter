using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerFactory : ExplosiveFactory
{
    public TimerFactory(Vector3 deploymentPlace) : base(deploymentPlace) {}

    public override void DeployExplosive()
    {
        return;
    }
}
