using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeFactory : ExplosiveFactory
{
    public MazeFactory(Vector3 deploymentPlace) : base(deploymentPlace) {}

    public override void DeployExplosive()
    {
        return;
    }
}
