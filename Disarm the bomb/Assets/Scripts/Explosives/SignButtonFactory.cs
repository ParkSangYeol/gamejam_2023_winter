using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignButtonFactory : ExplosiveFactory
{
    public SignButtonFactory(Vector3 deploymentPlace) : base(deploymentPlace) {}

    public override void DeployExplosive()
    {
        return;
    }
}
