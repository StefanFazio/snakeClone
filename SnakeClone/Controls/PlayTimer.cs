using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SnakeClone
{
    public class PlayTimer : Observable
    {
        private DispatcherTimer timer;
        private const int defaultSpeed = 120;
        private const int boostSpeed = 50;
        private IUpdateFrame client;
        private TimeSpan playtime;
        private DateTime formerTimestamp;
        private bool isBoosted;
        private const int boostDuration = 5000;
        private TimeSpan currentBoostDuration;

        private ISpawnPink spawnPink;
        private bool pinkAppleIsOnField = false;
        private TimeSpan nextPAppleSpawnTime;




        public PlayTimer(IUpdateFrame client, ISpawnPink spawnPink)
        {
            this.client = client;
            this.spawnPink = spawnPink;

            nextPAppleSpawnTime = SetNextPAppleSpawnTime();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(defaultSpeed);
            timer.Tick += Tick;
        }

        private void Tick(object sender, EventArgs e)
        {
            var timeDelta = DateTime.Now.Subtract(formerTimestamp);
            formerTimestamp = DateTime.Now;
            playtime += timeDelta;

            SetBoostValues(timeDelta);

            if(!pinkAppleIsOnField)
                SetPinkAppleValues(timeDelta);

            client.UpdateFrame();
            NotifyObservers();
        }

        private void SetBoostValues(TimeSpan timeDelta)
        {
            if (!isBoosted) return;

            if (isBoosted)
                currentBoostDuration -= timeDelta;

            if (currentBoostDuration < TimeSpan.FromMilliseconds(0))
            {
                DeactivateBoost();
                nextPAppleSpawnTime = SetNextPAppleSpawnTime();
            }
        }

        private TimeSpan SetNextPAppleSpawnTime()
        {
            var random = new Random();
            return TimeSpan.FromMilliseconds(random.Next(5000, 15000));
        }

        private void SetPinkAppleValues(TimeSpan timeDelta)
        {
            if (isBoosted) return;

            nextPAppleSpawnTime -= timeDelta;

            if (nextPAppleSpawnTime < TimeSpan.FromMilliseconds(0))
            {
                pinkAppleIsOnField = true;
                spawnPink.SpawnPinkApple();
            }
        }

        public void Start()
        {
            formerTimestamp = DateTime.Now;
            timer.Start();
        }

        public void Pause()
        {
            timer.Stop();
        }

        public string GetCurrentPlaytime()
        {
            return playtime.ToString(@"%h\:mm\:ss");
        }

        public void Reset()
        {
            playtime = TimeSpan.FromMilliseconds(0);
            DeactivateBoost();
        }

        public void ActivateBoost()
        {
            pinkAppleIsOnField = false;
            currentBoostDuration = TimeSpan.FromMilliseconds(boostDuration);
            isBoosted = true;
            timer.Interval = TimeSpan.FromMilliseconds(boostSpeed);
        }

        private void DeactivateBoost()
        {
            isBoosted = false;
            timer.Interval = TimeSpan.FromMilliseconds(defaultSpeed);
        }
    }
}
