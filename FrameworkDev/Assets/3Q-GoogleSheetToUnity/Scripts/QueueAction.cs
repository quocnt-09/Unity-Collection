using System;
using System.Collections.Generic;

namespace Q.Extension
{
    public struct QAction
    {
        public Delegate m_Action;
        public object[] m_Params;
    }

    public class QueueAction
    {
        private Queue<QAction> _queue;
        public bool IsExecute { get; private set; }

        public int Counter { get; private set; }

        public QueueAction()
        {
            _queue = new Queue<QAction>();
            Counter = 0;
            IsExecute = false;
        }

        public void AddQueue(Delegate method, object[] Params = null)
        {
            _queue.Enqueue(new QAction {m_Action = method, m_Params = Params,});
            Counter = _queue.Count;
        }

        public void Execute()
        {
            var action = _queue.Dequeue();
            action.m_Action.DynamicInvoke(action.m_Params);
            Counter = _queue.Count;
            IsExecute = true;
        }

        public void Done(bool nextAction)
        {
            IsExecute = false;
            if (nextAction)
            {
                NextAction(nextAction);
            }
        }

        public bool NextAction(bool execute = false)
        {
            if (Counter <= 0 || IsExecute) return false;

            if (execute)
            {
                Execute();
            }

            return true;
        }

        public int CountMethod(string methodName)
        {
            var count = 0;
            foreach (var action in _queue)
            {
                if (action.m_Action.Method.Name.Equals(methodName)) count++;
            }

            return count;
        }
    }
}