using Command.Player;

namespace Command.Commands
{
    public abstract class UnitCommand : ICommand
    {
        public CommandData commandData;

        protected UnitController actorUnit;
        protected UnitController targetUnit;

        public abstract void Execute();

        public abstract bool WillHitTarget();

        public void SetActorUnit(UnitController actorUnitController) =>actorUnit = actorUnitController;
        public void SetTargetUnit(UnitController targetUnitController) => targetUnit = targetUnitController;

    }

    public struct CommandData
    {
        public int ActorUnitID;
        public int TargetUnitID;
        public int ActorPlayerID;
        public int TargetPlayerID;

        public CommandData(int actorUnitID,int targetUnitID,int actorPlayerID,int targetPlayerID)
        {
            this.ActorPlayerID = actorPlayerID;
            this.ActorUnitID = actorUnitID;
            this.TargetUnitID = targetUnitID;
            this.TargetPlayerID = targetPlayerID;
        }

    }

}