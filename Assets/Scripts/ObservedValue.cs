using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kpable.Mechanics
{
    public class ObservedValue<T>
    {
        private T currentValue;

        public delegate void ValueChangeEvent();
        public event ValueChangeEvent OnValueChanged;

        virtual public T Value
        {
            get { return currentValue; }
            set
            {
                currentValue = value;
                if (OnValueChanged != null) OnValueChanged();
            }
        }

        public ObservedValue()
        {

        }

        public ObservedValue(T value)
        {
            currentValue = value;
        }
    }
}