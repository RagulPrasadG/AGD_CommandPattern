using Command.Actions;
using Command.Commands;
using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdEyeCommand : UnitCommand
{ 
    private bool willHitTarget;

    public ThirdEyeCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();
    }

    public override bool WillHitTarget() => true;

    public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.ThirdEye).PerformAction(actorUnit, targetUnit, willHitTarget);
}
