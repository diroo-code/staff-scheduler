using System;
using Google.Cloud.Firestore;
using Google.Type;

namespace staffschedulerlibrary.Models
{
    [FirestoreData]
    public class RealTimeStatusUpdate
    {
        [FirestoreProperty]
        public int UpdateId { get; set; }

        [FirestoreProperty]
        public string Message { get; set; }

        [FirestoreProperty]
        public System.DateTime Timestamp { get; set; }
        

        public RealTimeStatusUpdate(string message)
        {
            Message = message;
            Timestamp = System.DateTime.Now;
        }

        public override string ToString()
        {
            return $"[{Timestamp}] {Message}";
        }
    }
}
