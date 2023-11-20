using Command.Main;
using UnityEngine;

namespace Command.Commands
{
    public class BerserkAttackCommand : UnitCommand
    {
        private bool willHitTarget;
        private const float hitChance = 0.66f;

        public BerserkAttackCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.BerserkAttack).PerformAction(actorUnit, targetUnit, willHitTarget);

         //if (isSuccessful)
         //       targetUnit.TakeDamage(actorUnit.CurrentPower* 2);
         //   else
         //   {
         //       actorUnit.TakeDamage(actorUnit.CurrentPower* 2);
         //       actorUnit.OnActionExecuted();
         //       Debug.Log("actor unit must be hit now.");
         //   }

        public override void Undo()
        {
            if(willHitTarget)
            {
                targetUnit.RestoreHealth(actorUnit.CurrentPower * 2);
                return;
            }
            actorUnit.RestoreHealth(actorUnit.CurrentPower * 2);
        }

        public override bool WillHitTarget() => Random.Range(0f, 1f) < hitChance;
    }
}
