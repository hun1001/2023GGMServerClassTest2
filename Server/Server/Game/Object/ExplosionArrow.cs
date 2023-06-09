using Google.Protobuf.Protocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Game.Object
{
    public class ExplosionArrow : Arrow
    {
        public ExplosionArrow()
        {
            ObjectType = GameObjectType.ExplosionProjectile;
        }
    }
}
