using System;
using System.Collections.Generic;
using UnityEngine;

namespace Q.ExtensionUtil
{
    public class EventBatchStatic
    {
        public object _target;
        public Delegate _delegate;

        public EventBatchStatic(Delegate del, object target)
        {
            _target = target;
            _delegate = del;
        }
    }

    public static class EventServiceStatic
    {
        public static void DispatchEnum(object obj, Enum eventName, params object[] args)
        {
            Dispatch(obj, eventName.GetEventString(), args);
        }

        public static void AddListenerEnum(object obj, Enum eventName, Delegate action)
        {
            AddListener(obj, eventName.GetEventString(), action);
        }

        public static void DispatchAllEnum(Enum eventName, params object[] args)
        {
            DispatchAll(eventName.GetEventString(), args);
        }

        public static void RemoveListenerEnum(object obj, Enum eventName, Delegate action)
        {
            RemoveListener(obj, eventName.GetEventString(), action);
        }

        public static string GetEventString(this Enum enu)
        {
            return "Enum_" + enu;
        }

        private static Dictionary<string, List<EventBatchStatic>> _eventBatchStaticDict = new Dictionary<string, List<EventBatchStatic>>();

        public static void AddListener(object obj, string eventName, Delegate action)
        {
            if (obj == null) return;
            var batch = new EventBatchStatic(action, obj);
            if (!_eventBatchStaticDict.TryGetValue(eventName, out var batches))
            {
                batches = new List<EventBatchStatic>();
                _eventBatchStaticDict.Add(eventName, batches);
                batches.Add(batch);
            }
            else
            {
                if (batches.Contains(batch))
                {
                    Debug.LogError($"Duplicate Add found event name {eventName}");
                    return;
                }

                batches.Add(batch);
            }
        }

        private static object cTarget;
        private static Delegate cDelegate;

        public static void RemoveListener(object obj, string eventName, Delegate action)
        {
            if (obj == null) return;

            cTarget = obj;
            cDelegate = action;
            if (!_eventBatchStaticDict.TryGetValue(eventName, out var batches))
            {
                return;
            }

            var bathToDel = batches.Find(IsMatchToRemove);
            batches.Remove(bathToDel);
        }

        public static void DispatchAll(string eventName, params object[] args)
        {
            List<EventBatchStatic> batchesOut;

            if (_eventBatchStaticDict.TryGetValue(eventName, out batchesOut))
            {
                for (int i = batchesOut.Count - 1; i >= 0; i--)
                {
                    if (batchesOut[i]._delegate != null)
                    {
                        batchesOut[i]._delegate.Method.Invoke(batchesOut[i]._delegate.Target, args);
                    }
                }
            }
        }

        public static void Dispatch(object obj, string eventName, params object[] args)
        {
            if (obj == null) return;
            if (!_eventBatchStaticDict.TryGetValue(eventName, out var batchesOut)) return;
            for (int i = batchesOut.Count - 1; i >= 0; i--)
            {
                var count = batchesOut.Count;
                if (i >= count || batchesOut[i]._delegate == null) continue;
                if (batchesOut[i]._target == null || batchesOut[i]._target == obj)
                {
                    batchesOut[i]._delegate.Method.Invoke(batchesOut[i]._delegate.Target, args);
                }
            }
        }

        private static bool IsMatchToRemove(EventBatchStatic b)
        {
            return cTarget == b._target && cDelegate == b._delegate;
        }

        public static void RemoveAll(string[] listKeys)
        {
            foreach (var eventName in listKeys)
            {
                if (!_eventBatchStaticDict.TryGetValue(eventName, out var batches))
                {
                    continue;
                }

                batches.Clear();
            }
        }
    }
}