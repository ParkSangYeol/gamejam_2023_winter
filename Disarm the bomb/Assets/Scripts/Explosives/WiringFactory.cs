using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiringFactory : ExplosiveFactory
{
    public WiringFactory(Vector3 deploymentPlace) : base(deploymentPlace) {}

    public override void DeployExplosive()
    {
        return;
    }
}
