﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DwarfCorp
{
    [Newtonsoft.Json.JsonObject(IsReference = true)]
    public class SetTargetEntityAct : CreatureAct
    {
        public LocatableComponent Entity { get; set; }

        public SetTargetEntityAct(LocatableComponent entity, CreatureAIComponent creature) :
            base(creature)
        {
            Name = "Set Target Entity";
            Entity = entity;
        }

        public override IEnumerable<Status> Run()
        {
            if(Entity == null || Entity.IsDead)
            {
                yield return Act.Status.Fail;
            }
            else
            {
                Agent.TargetComponent = Entity;
                yield return Act.Status.Success;
            }
        }
    }

}