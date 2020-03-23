using System.Collections.Generic;

namespace Lab7
{
    public class DateController
    {
        private List<IDateListener> _dateListeners = new List<IDateListener>();

        public void AddDateListener(IDateListener dateListener)
        {
            _dateListeners.Add(dateListener);
        }

        public void EndDay()
        {
            foreach (var listener in _dateListeners)
            {
                listener.OnDayEnd();
            }
        }

        public void EndMonth()
        {
            foreach (var listener in _dateListeners)
            {
                listener.OnMonthEnd();
            }
        }
    }
}