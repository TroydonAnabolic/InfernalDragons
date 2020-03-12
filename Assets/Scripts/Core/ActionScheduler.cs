using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction currentAction;

        public void StartAction(IAction action)
        {
            // if there is no action we return and await next action
            if (currentAction == action) return;
            // when the action is not null we are cancelling an action. An action is only triggered when we interact with combat, that is the only time an action is cancelled.
            if (currentAction != null)
            {
                // if the mover action exists and depending where we click cancel the existing action when beginning a new one
                currentAction.Cancel();
                print("Cancelled" + currentAction);
            }
            currentAction = action;
        }
    }
}