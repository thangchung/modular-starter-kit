using System;
using System.Collections.Generic;
using System.Text;

namespace MSK.Core.Module.ESAPI.Intrusion
{
    /// <summary> 
    /// The IIntrusionDetector interface is intended to track security relevant events and identify attack behavior.
    /// </summary>
    public interface IIntrusionDetector
    {
        /// <summary> 
        /// The intrusion detection quota for a particular event.
        /// </summary>
        /// <param name="threshold">
        /// The quote for a particular event name.
        /// </param>
        void AddThreshold(Threshold threshold);

        /// <summary>
        /// Remove event threshold
        /// </summary>
        /// <param name="eventName"></param>
        bool RemoveThreshold(string eventName);

        /// <summary> Adds the exception to the IntrusionDetector.
        /// </summary>
        /// <param name="exception">The exception to add.
        /// </param>        
        void AddException(Exception exception);

        /// <summary> Adds the event to the IntrusionDetector.        
        /// </summary>
        /// <param name="eventName">The event to add.
        /// </param>        
        void AddEvent(string eventName);
    }

    /// <summary>
    /// The Threshold class is used to represent the amount of events that can be allowed, 
    /// and in what timeframe they are allowed.
    /// </summary>
    /// TODO: refactor later
    public class Threshold
    {
        /// <summary>
        /// The name of the event.
        /// </summary>
        public readonly string Event;

        /// <summary>
        /// The number of occurences.
        /// </summary>
        public readonly int MaxOccurences;

        /// <summary>
        /// The interval allowed between events.
        /// </summary>
        public readonly TimeSpan MaxTimeSpan;

        /// <summary>
        /// The list of actions associated with the threshold/
        /// </summary>
        public readonly IList<string> Actions;

        /// <summary>
        /// Constructor for Threshold
        /// </summary>
        /// <param name="name">
        /// Event name.
        /// </param>
        /// <param name="maxOccurences">
        /// Count of events allowed.
        /// </param>
        /// <param name="maxTimeSpan">
        /// Interval between events allowed.
        /// </param>
        /// <param name="actions">
        /// Actions associated with threshold.
        /// </param>
        public Threshold(string name, int maxOccurences, long maxTimeSpan, IEnumerable<string> actions)
        {
            Event = name;
            MaxOccurences = maxOccurences;
            MaxTimeSpan = TimeSpan.FromSeconds(maxTimeSpan);

            Actions = new List<string>();

            // Add actions
            if (actions != null)
            {
                foreach (string action in actions)
                {
                    string actionName = (action != null ? action.Trim() : action);
                    if (string.IsNullOrEmpty(actionName))
                    {
                        continue;
                    }

                    Actions.Add(actionName);
                }
            }
        }

        /// <summary>
        /// Returns string representation of threshold.
        /// </summary>
        /// <returns>String representation of threshold.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Threshold: {0} - {1} in {2} seconds results in ", Event, MaxOccurences, MaxTimeSpan);

            for (int i = 0; i < Actions.Count; ++i)
            {
                if (i != 0)
                {
                    sb.Append(", ");
                }
                sb.AppendFormat(Actions[i]);
            }

            return sb.ToString();
        }
    }
}