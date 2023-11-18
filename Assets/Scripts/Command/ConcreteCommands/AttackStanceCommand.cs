using Command.Actions;
using Command.Commands;
using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttackStanceCommand : UnitCommand
{
    private bool willHitTarget;

    public AttackStanceCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();
    }

    public override bool WillHitTarget() => true;

    public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.AttackStance).PerformAction(actorUnit, targetUnit, willHitTarget);
}
