﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UniRx;

namespace Submarine.Battle
{
    public class BattleInputService : MonoBehaviour
    {
        [SerializeField]
        Button decoyButton;
        [SerializeField]
        Button pingerButton;
        [SerializeField]
        Button lookoutButton;

        const float SqrDragAmountThresholdForClick = 10f * 10f;
        readonly TimeSpan touchTimeThresholdForClick = TimeSpan.FromSeconds(1.5d);
        readonly float halfScreenWidth = Screen.width / 2f;

        IReadOnlyReactiveProperty<bool> isTouched;
        Vector3 touchStartPosition;
        DateTime touchStartTime;

        bool IsTouchingUI
        {
            get { return EventSystem.current != null && EventSystem.current.currentSelectedGameObject != null; }
        }

        Vector3 DragAmount
        {
            get { return isTouched.Value ? Input.mousePosition - touchStartPosition : Vector3.zero; }
        }

        public IReadOnlyReactiveProperty<bool> IsAccelerating
        {
            get { return isTouched; }
        }

        public float TurningRate
        {
            get { return Mathf.Clamp(DragAmount.x / halfScreenWidth, -1f, 1f); }
        }

        public IObservable<Unit> OnTorpadeShootAsObservable()
        {
            return onClickAsObservable();
        }

        public IObservable<Unit> OnDecoyShootAsObservable()
        {
            return decoyButton.OnClickAsObservable();
        }

        public IObservable<Unit> OnPingerUseAsObservable()
        {
            return pingerButton.OnClickAsObservable();
        }

        public IObservable<Unit> OnLookoutShootAsObservable()
        {
            return lookoutButton.OnClickAsObservable();
        }

        void Awake()
        {
            isTouched = Observable.EveryUpdate()
                .Select(_ => Input.GetMouseButton(0))
                .Where(_ => !IsTouchingUI)
                .ToReactiveProperty()
                .AddTo(this);

            isTouched.Where(b => b)
                .Subscribe(_ => touchStartPosition = Input.mousePosition)
                .AddTo(this);

            isTouched.Where(b => b)
                .Subscribe(_ => touchStartTime = DateTime.Now)
                .AddTo(this);
        }

        IObservable<Unit> onClickAsObservable()
        {
            return isTouched
                .Where(value =>
                {
                    if (value) return false;
                    var touchTime = DateTime.Now - touchStartTime;
                    var dragAmount = Input.mousePosition - touchStartPosition;
                    return touchTime < touchTimeThresholdForClick &&
                        dragAmount.sqrMagnitude < SqrDragAmountThresholdForClick;
                })
                .AsUnitObservable();
        }
    }
}
