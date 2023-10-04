namespace Game.Events
{
    public class LevelEvents
    {
        public class OnMenuEnterd { }
        public class OnLevelStarted { }

        public class OnCuttingStarted { }
        public class OnCuttingOver { }

        public class OnCuttingRequest { }
        
        public class OnProgressUpdate
        {
            public float Percentage { get; private set; }

            public OnProgressUpdate (float percentage) { Percentage = percentage; }
        }

        public class OnComplete { }
    }
}