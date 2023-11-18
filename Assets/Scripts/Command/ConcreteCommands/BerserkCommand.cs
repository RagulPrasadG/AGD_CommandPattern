using Command.Actions;
using Command.Commands;
using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkCommand : UnitCommand
{
    private bool willHitTarget;

    public BerserkCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();
    }

    public override bool WillHitTarget() => true;

    public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.BerserkAttack).PerformAction(actorUnit, targetUnit, willHitTarget);
}
