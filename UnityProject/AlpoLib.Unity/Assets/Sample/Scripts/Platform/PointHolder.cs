using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace alpoLib.Sample.Platform
{
    public class PointHolder : MonoBehaviour
    {
        public static PointHolder Instance;

        private Dictionary<Type, List<PointBase>> _pointDic;

        private void Awake()
        {
            Instance = this;
            GatherPoint();
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        private void GatherPoint()
        {
            var points = GetComponentsInChildren<PointBase>(true);
            _pointDic = points.GroupBy(p => p.GetType()).ToDictionary(g => g.Key, g => g.ToList());
        }

        public bool TryGetRandomPoint(Type type, out Vector3 point)
        {
            point = Vector3.zero;
            if (!_pointDic.TryGetValue(type, out var list))
                return false;
            if (list.Count == 0)
                return false;
            point = list[UnityEngine.Random.Range(0, list.Count - 1)].TargetPoint.position;
            return true;
        }

        public bool TryGetPoint(Type type, out PointBase point)
        {
            point = null;
            if (!_pointDic.TryGetValue(type, out var list))
                return false;
            if (list.Count == 0)
                return false;
            var first = list.Where(p => !p.Occupied);
            point = first.ElementAtOrDefault(UnityEngine.Random.Range(0, list.Count - 1));
            return true;
        }
    }
}