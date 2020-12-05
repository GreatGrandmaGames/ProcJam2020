using System;

namespace Grandma.PF
{
    /// <summary>
    /// Allows values to easily align and listen for changes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SubscriptionValue<T>
    {
        private T m_Value;
        private Action<T> m_OnValueChanged;
        private Action m_OnValueChangedParameterless;

        public T Value
        {
            get => m_Value;
            set
            {
                if (Equals(m_Value, value) == false)
                {
                    m_Value = value;
                    m_OnValueChanged?.Invoke(m_Value);
                    m_OnValueChangedParameterless?.Invoke();
                }
            }
        }

        public void Subscribe(Action<T> action)
        {
            action?.Invoke(m_Value);
            m_OnValueChanged += action;
        }

        public void Unsubscribe(Action<T> action)
        {
            m_OnValueChanged -= action;
        }

        public void SubscribeParameterless(Action action)
        {
            action?.Invoke();
            m_OnValueChangedParameterless += action;
        }

        public void UnsubscribeParameterless(Action action)
        {
            m_OnValueChangedParameterless -= action;
        }
    }
}