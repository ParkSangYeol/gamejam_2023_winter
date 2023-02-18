using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleButtonFactory : ExplosiveFactory
{
    public SingleButtonFactory(Vector3 deploymentPlace) : base(deploymentPlace) {}

    public override void DeployExplosive()
    {
        return;
    }
}
