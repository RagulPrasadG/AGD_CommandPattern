using Command.Main;
using System.Collections.Generic;

namespace Command.Commands
{
    public class CommandInvoker
    {
        private Stack<ICommand> commandRegistry = new Stack<ICommand>();

        public void ProcessCommand(ICommand commandToProcess)
        {
            ExecuteCommand(commandToProcess);
            RegisterCommand(commandToProcess);
        }

        public void ExecuteCommand(ICommand commandToExecute) => commandToExecute.Execute();

        private bool RegistryEmpty() => commandRegistry.Count == 0;

        private bool IsCommandBelongsToActivePlayer()
        {
            return (commandRegistry.Peek() as UnitCommand).commandData.ActorPlayerID == GameService.Instance.PlayerService.ActivePlayerID;
        }

        public void Undo()
        {
            if (!RegistryEmpty() && IsCommandBelongsToActivePlayer())
                commandRegistry.Pop().Undo();
        }

        public void RegisterCommand(ICommand commandToRegister) => commandRegistry.Push(commandToRegister);
    }
}