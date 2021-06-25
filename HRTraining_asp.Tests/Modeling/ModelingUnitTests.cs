using HRTraining.Domain.Entities;
using HRTraining.Domain.Entities.Activities;
using HRTraining.Domain.Entities.Targets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HRTraining.Tests
{
    [TestClass]
    public class ModelingUnitTests
    {
        [TestMethod]
        public void CanCorrectlyModel_Run_30MinuteHillWorkout()
        {
            var hillWorkout = new Workout()
            {
                ID = Guid.NewGuid(),
                Name = "30-Minute Hill Workout",
                Description = "Test to see if this workout can be created",
                Activities = new List<Activity>()
                {
                    new Warmup()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Warm-up",
                        Instructions = "10-minute easy jog or walk. Toward the end of warm-up increase speed for 10 seconds two or three times," +
                        "so you get your legs used to turning over faster. Break the quick strides up by walking or standing still",
                        Targets = new List<Target>() { },
                        Duration = new TimeSpan(0, 10, 0), // Warm-up for 10 minutes
                    },
                    // Main Set - repeat 7 times
                    new Set()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Main Set",
                        Instructions = "Repeat work and recovery intervals 6 more times for a total of 7 work/rest intervals.",
                        WorkInterval = new Run()
                        {
                            ID = Guid.NewGuid(),
                            InclinePercentage = 3,
                            Duration = new TimeSpan(0, 1, 0),
                            Name = "Work interval",
                            Instructions = "(Treadmill): increase incline to 3 or 4% and run for 1 minute. " +
                            "(Outside): Look for a moderate hill that will take 1 minute to run up." +
                            "Run at a hard effort – similar to how you would feel if you were racing a 5k.You breathing should be a bit labored and your " +
                            "legs should start to feel tired after a couple of repeats."
                        },
                        RecoveryInterval = new Run()
                        {
                            ID = Guid.NewGuid(),
                            InclinePercentage = 1,
                            Duration = new TimeSpan(0, 1, 0),
                            Name = "Recovery interval",
                            Instructions = ": (Treadmill): Lower incline to 1% and speed, run for 1 minute at an easy pace. " +
                            "(Outside): Recover downhill. Go at an easy pace(walk if you have to) to get your breathing back down to normal."
                        },
                        NumberOfRepeats = 7
                    }, 
                    new Cooldown()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Cool down",
                        Duration = new TimeSpan(0, 6, 0),
                        Instructions = "After last recovery interval, finish with another 6 minutes of easy jogging. Don’t skip the cool down part " +
                        "of your run – it allows your body to gradually recover and return to your normal heart rate."
                    }
                },
                Goal = null
            };

        }

        [TestMethod]
        public void CanCorrectlyModel_Run_30MinuteLadderWorkout()
        {
            var ladderWorkout = new Workout()
            { 
                ID = Guid.NewGuid(),
                Name = "30-Minute Ladder Workout",
                Description = "The Ladder Run is a form of interval workout which climbs up, down, or both up and down in distance with a short rest period in between each interval. " +
                "It is a variety of high-intensity running paces and distances, all in a single workout.",
                Activities = new List<Activity>()
                {
                    new Warmup()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Warm-up",
                        Instructions = "5-minute easy jog",
                        Duration = new TimeSpan(0, 5, 0)
                    },
                    new Run()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Work Interval",
                        Duration = new TimeSpan(0, 5, 0),
                        Instructions = "5 mins at marathon pace (or 5 out of 10 on a perceived exertion scale of 1 to 10)"
                    },
                    new Run()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Recovery Interval",
                        Duration = new TimeSpan(0, 1, 0),
                        Instructions = "1 minute at easy pace"
                    },
                    new Run()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Work Interval",
                        Duration = new TimeSpan(0, 4, 0),
                        Instructions = "4 minutes at half marathon pace (or 6 out of 10 PE)"
                    },
                    new Run()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Recovery Interval",
                        Duration = new TimeSpan(0, 1, 0),
                        Instructions = "1 minute at easy pace"
                    },
                    new Run()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Work Interval",
                        Duration = new TimeSpan(0, 3, 0),
                        Instructions = "3 minutes at 10K pace (7 out of 10 PE)"
                    },
                    new Run()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Recovery Interval",
                        Duration = new TimeSpan(0, 1, 0),
                        Instructions = "1 minute at easy pace"
                    },
                    new Run()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Work Interval",
                        Duration = new TimeSpan(0, 2, 0),
                        Instructions = "2 minutes at 5K pace (8 out of 10 PE)"
                    },
                    new Run()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Recovery Interval",
                        Duration = new TimeSpan(0, 1, 0),
                        Instructions = "1 minute at easy pace"
                    },
                    new Run()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Work Interval",
                        Duration = new TimeSpan(0, 1, 0),
                        Instructions = "1 minute at hard (sprint) pace (9 out of 10 PE)"
                    },
                    new Run()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Recovery Interval",
                        Duration = new TimeSpan(0, 1, 0),
                        Instructions = "1 minute at easy pace"
                    },
                    new Cooldown()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Cool down",
                        Duration = new TimeSpan(0, 5, 0),
                        Instructions = "5 minutes easy jogging"
                    }
                }
            };
        }

        [TestMethod]
        public void CanCorrectlyModel_Run_30MinuteRunAndStrengthComboWorkout()
        {
            var comboWorkout = new Workout()
            {
                ID = Guid.NewGuid(),
                Name = "30-Minute Run and Strength Combo Workout",
                Description = "You’ll combine run intervals with some muscle-strengthening exercises for a total body workout.",
                Activities = new List<Activity>()
                {
                    new Warmup()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Warm-up",
                        Instructions = "5-minute easy jog",
                        Duration = new TimeSpan(0, 5, 0),
                    },
                    new Run()
                    {
                        ID = Guid.NewGuid(),
                        Duration = new TimeSpan(0, 1, 0),
                        Name = "Run",
                        Instructions = "Run: 1 minute at 5K pace"
                    },
                    new StrengthTraining()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Squats",
                        Duration = new TimeSpan(0, 1, 0)
                    },
                    new Run()
                    {
                        ID = Guid.NewGuid(),
                        Duration = new TimeSpan(0, 2, 0),
                        Name = "Run",
                        Instructions = "Run: 2 minutes at 5K pace"
                    },
                    new StrengthTraining()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Walking Lunges",
                        Duration = new TimeSpan(0, 1, 0)
                    },
                    new Run()
                    {
                        ID = Guid.NewGuid(),
                        Duration = new TimeSpan(0, 3, 0),
                        Name = "Run",
                        Instructions = "Run: 3 minutes at 5K pace"
                    },
                    new StrengthTraining()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Donkey Kicks",
                        Duration = new TimeSpan(0, 1, 0)
                    },
                    new Run()
                    {
                        ID = Guid.NewGuid(),
                        Duration = new TimeSpan(0, 4, 0),
                        Name = "Run",
                        Instructions = "Run: 4 minutes at 5K pace"
                    },
                    new StrengthTraining()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Tricep dips",
                        Duration = new TimeSpan(0, 1, 0)
                    },
                    new Run()
                    {
                        ID = Guid.NewGuid(),
                        Duration = new TimeSpan(0, 5, 0),
                        Name = "Run",
                        Instructions = "Run: 5 minutes at 5K pace"
                    },
                    new StrengthTraining()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Push-ups",
                        Duration = new TimeSpan(0, 1, 0)
                    },
                    new Cooldown()
                    {
                        ID = Guid.NewGuid(),
                        Duration = new TimeSpan(0, 5, 0),
                        Name = "Easy Jog"
                    }
                }
            };
        }

        [TestMethod]
        public void CanCorrectlyModel_Run_30MinuteSprintIntervalWorkout()
        {
            var sprintWorkout = new Workout()
            {
                ID = Guid.NewGuid(),
                Name = "30-Minute Sprint Interval Workout",
                Description = "Short bursts of speed help build strength, increase aerobic capacity, and get your legs used to the faster turnover. " +
                "This is a fun workout to do outside, whether on a track or road, but can also be done on a treadmill. Set an easy pace for your recovery intervals." +
                "This can mean a slow jog, but walking is fine if you need a slower pace.",
                Activities = new List<Activity>()
                { 
                    new Warmup()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Easy Jog",
                        Duration = new TimeSpan(0, 5, 0),
                        Instructions = "5-minute easy jog"
                    },
                    new Set()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Main Set",
                        Duration = new TimeSpan(0, 20, 0),
                        WorkInterval = new Run()
                        {
                            ID = Guid.NewGuid(),
                            Name = "Work Interval",
                            Duration = new TimeSpan(0, 0, 30),
                            Instructions = "30-second speed interval (start with a fast, but not sprinting, pace for the first two or three times, then sprint full-out for the remaining intervals)"
                        },
                        RecoveryInterval = new Run()
                        {
                            ID = Guid.NewGuid(),
                            Name = "Recovery Interval",
                            Duration = new TimeSpan(0, 1, 0),
                            Instructions = "1 minute at easy pace"
                        },
                    },
                    new Cooldown()
                    {
                        ID = Guid.NewGuid(),
                        Duration = new TimeSpan(0, 5, 0),
                        Name = "Easy Jog"
                    }
                }
            };
        }

        [TestMethod]
        public void CanCorrectlyModel_Run_BeginnerEasyRun()
        {
            var easyRun = new Workout()
            {
                ID = Guid.NewGuid(),
                Name = "Easy Run - Beginner",
                Description = "The easy run is your aerobic workout, staying within heart-rate zones 1 and 2. You should be ab to keep a conversation going, speaking in paragraphs with full sentences.",
                Activities = new List<Activity>()
                { 
                    new Run()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Easy Run",
                        Duration = new TimeSpan(0, 45, 0),
                        Instructions = "45 minutes at an easy pace. With this variation, distance doesn’t matter. You’re running for time instead of distance, so there’s no pressure to hit certain mileage."
                    }
                }
            };
        }

        [TestMethod]
        public void CanCorrectlyModel_Run_AdvancedEasyRun()
        {
            var easyRun = new Workout()
            {
                ID = Guid.NewGuid(),
                Name = "Easy Run - Advanced",
                Description = "The easy run is your aerobic workout, staying within heart-rate zones 1 and 2. You should be ab to keep a conversation going, speaking in paragraphs with full sentences.",
                Activities = new List<Activity>()
                {
                    new Run()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Easy Run",
                        Instructions = "6-10 miles at an easy, conversational pace. There should be no set structure or fluctuations in speed, but the hardest part will be resisting the temptation to speed up.",
                        Targets = new List<Target>()
                        {
                            new Distance()
                            {
                                ID = Guid.NewGuid(),
                                DistanceMileage = 6
                            }
                        }
                    }
                }
            };
        }

        [TestMethod]
        public void CanCorrectlyModel_Run_TempoRun_Beginner()
        {
            var tempoRun = new Workout()
            {
                ID = Guid.NewGuid(),
                Name = "Tempo Run - Beginner",
                Description = "Run at 85-90% of maximum heart rate",
                Activities = new List<Activity>()
                {
                    new Warmup()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Warm-up",
                        Instructions = "Start main set once warm"
                    },
                    new Set()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Tempo paced run",
                        Duration = new TimeSpan(0, 40, 0),
                        WorkInterval = new Run()
                        {
                            ID = Guid.NewGuid(),
                            Name = "Tempo Interval",
                            Duration = new TimeSpan(0, 5, 0),
                            Instructions = "Run at a tempo pace"
                        },
                        RecoveryInterval = new Run()
                        {
                            ID = Guid.NewGuid(),
                            Name = "Rest Interval",
                            Duration = new TimeSpan(0, 3, 0)
                        },
                        NumberOfRepeats = 3
                    },
                    new Cooldown()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Cool down"
                    }
                }
            };
        }

        [TestMethod]
        public void CanCorrectlyModel_Run_Fartlek()
        {
            var fartlekWorkout = new Workout()
            {
                ID = Guid.NewGuid(),
                Name = "The Fartlek Run",
                Description = "Combines running fast intervals with low-to-moderate efforts. Each interval varies in distance, duration, and speed. Fartlek is an excellent introduction to the world of speedwork training.",
                Activities = new List<Activity>()
                { 
                    new Warmup()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Warm-up",
                    },
                    new Set()
                    {
                        ID = Guid.NewGuid(),
                        Duration = new TimeSpan(0, 30, 0),
                        WorkInterval = new Run()
                        {
                            ID = Guid.NewGuid(),
                            Instructions = "Pick an object in the distance (street corner, stationary car, tree, or a signpost). Run to it as hard as you can."
                        },
                        RecoveryInterval = new Run()
                        {
                            ID = Guid.NewGuid(),
                            Instructions = "Slow down and recover by jogging/walking to another landmark."
                        },
                    },
                    new Cooldown()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Cool down"
                    }
                }
            };
        }

        [TestMethod]
        public void CanCorrectlyModel_AerobicWorkout_30MinuteIndoorCardio()
        {
            var fartlekWorkout = new Workout()
            {
                ID = Guid.NewGuid(),
                Name = "30-Minute Indoor Cardio",
                Activities = new List<Activity>()
                {
                    new Warmup()
                    {
                        Activities = new List<Activity>()
                        {
                            new StrengthTraining()
                            {
                                ID = Guid.NewGuid(),
                                Name = "Squats",
                                Repetitions = 20
                            },
                            new StrengthTraining()
                            {
                                ID = Guid.NewGuid(),
                                Name = "Punches",
                                Repetitions = 30
                            },
                            new StrengthTraining()
                            {
                                ID = Guid.NewGuid(),
                                Name = "Single Leg Deadlift",
                                Repetitions = 20
                            }
                        },                        
                    },                    
                    new StrengthTraining()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Jumping Jacks",
                        Repetitions = 50
                    },
                    new StrengthTraining()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Mountain Climbers",
                        Repetitions = 40
                    },
                    new StrengthTraining()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Plank Jacks",
                        Repetitions = 20
                    },
                    new StrengthTraining()
                    {
                        ID = Guid.NewGuid(),
                        Name = "High Knees",
                        Repetitions = 30
                    },
                    new StrengthTraining()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Skaters",
                        Repetitions = 30
                    },
                    new StrengthTraining()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Bicycles",
                        Repetitions = 40
                    },
                    new StrengthTraining()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Commandos",
                        Repetitions = 20
                    },
                    new StrengthTraining()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Jump Lunges",
                        Repetitions = 30
                    },
                    new Cooldown()
                    {
                        Activities = new List<Activity>()
                        {
                            new StrengthTraining()
                            {
                                ID = Guid.NewGuid(),
                                Name = "Squats Cool down",
                                Repetitions = 20
                            },
                            new StrengthTraining()
                            {
                                ID = Guid.NewGuid(),
                                Name = "Punches Cool down",
                                Repetitions = 30
                            },
                            new StrengthTraining()
                            {
                                ID = Guid.NewGuid(),
                                Name = "Toe Touches Cool down",
                                Repetitions = 20
                            }
                        },
                    },
                }
            };
        }

        [TestMethod]
        public void CanCorrectlyModel_Elliptical_WorkoutRoutine()
        {
            var ellipticalWorkout = new Workout()
            {
                ID = Guid.NewGuid(),
                Name = "Elliptical Workout Routine",
                Activities = new List<Activity>()
                {
                    new Warmup()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Warm-up",
                        Activities = new List<Activity>()
                        {
                            new Elliptical()
                            {
                                ID = Guid.NewGuid(),
                                Duration = new TimeSpan(0, 3, 0),
                                InclinePercentage = 9,
                                Resistance = 6,
                                BackwardDirection = false
                            }
                        }
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        InclinePercentage = 9,
                        Resistance = 12,
                        BackwardDirection = false,
                        Duration = new TimeSpan(0, 3, 0)
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        InclinePercentage = 9,
                        Resistance = 12,
                        BackwardDirection = true,
                        Duration = new TimeSpan(0, 3, 0)
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        InclinePercentage = 9,
                        Resistance = 13,
                        BackwardDirection = false,
                        Duration = new TimeSpan(0, 3, 0)
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        InclinePercentage = 9,
                        Resistance = 13,
                        BackwardDirection = true,
                        Duration = new TimeSpan(0, 3, 0)
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        InclinePercentage = 9,
                        Resistance = 12,
                        BackwardDirection = false,
                        Duration = new TimeSpan(0, 3, 0)
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        InclinePercentage = 9,
                        Resistance = 14,
                        BackwardDirection = false,
                        Duration = new TimeSpan(0, 3, 0)
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        InclinePercentage = 9,
                        Resistance = 14,
                        BackwardDirection = true,
                        Duration = new TimeSpan(0, 3, 0)
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        InclinePercentage = 9,
                        Resistance = 15,
                        BackwardDirection = false,
                        Duration = new TimeSpan(0, 3, 0)
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        InclinePercentage = 9,
                        Resistance = 15,
                        BackwardDirection = true,
                        Duration = new TimeSpan(0, 3, 0)
                    },
                    new Cooldown()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Cool down",
                        Activities = new List<Activity>()
                        {
                            new Elliptical()
                            {
                                ID = Guid.NewGuid(),
                                InclinePercentage = 9,
                                Resistance = 6,
                                BackwardDirection = false,
                                Duration = new TimeSpan(0, 3, 0)
                            }
                        }
                    }
                }
            };
        }

        [TestMethod]
        public void CanCorrectlyModel_Elliptical_BuildAndBurn()
        {
            var ellipticalWorkout = new Workout()
            {
                ID = Guid.NewGuid(),
                Name = "Elliptical Workout Routine - Build + Burn",
                Activities = new List<Activity>()
                {
                    new Warmup()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Warm-up",
                        Activities = new List<Activity>()
                        {
                            new Elliptical()
                            {
                                ID = Guid.NewGuid(),
                                Duration = new TimeSpan(0, 1, 0),
                                InclinePercentage = 5,
                                Resistance = 10,
                                StrokesPerMinute = 120
                            }
                        }
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        InclinePercentage = 5,
                        Resistance = 5,
                        StrokesPerMinute = 120,
                        Duration = new TimeSpan(0, 1, 0)
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        InclinePercentage = 5,
                        Resistance = 12,
                        StrokesPerMinute = 115,
                        Duration = new TimeSpan(0, 1, 0)
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        InclinePercentage = 5,
                        Resistance = 14,
                        StrokesPerMinute = 110,
                        Duration = new TimeSpan(0, 1, 0)
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Recovery",
                        InclinePercentage = 5,
                        Resistance = 0,
                        StrokesPerMinute = 110,
                        Duration = new TimeSpan(0, 1, 0)
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        InclinePercentage = 5,
                        Resistance = 10,
                        StrokesPerMinute = 125,
                        Duration = new TimeSpan(0, 1, 0)
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        InclinePercentage = 5,
                        Resistance = 12,
                        StrokesPerMinute = 120,
                        Duration = new TimeSpan(0, 1, 0)
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        InclinePercentage = 5,
                        Resistance = 14,
                        StrokesPerMinute = 115,
                        Duration = new TimeSpan(0, 1, 0)
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Recovery",
                        InclinePercentage = 5,
                        Resistance = 0,
                        StrokesPerMinute = 110,
                        Duration = new TimeSpan(0, 2, 0)
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        InclinePercentage = 5,
                        Resistance = 10,
                        StrokesPerMinute = 125,
                        Duration = new TimeSpan(0, 1, 0)
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        InclinePercentage = 5,
                        Resistance = 12,
                        StrokesPerMinute = 125,
                        Duration = new TimeSpan(0, 1, 0)
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        InclinePercentage = 5,
                        Resistance = 14,
                        StrokesPerMinute = 120,
                        Duration = new TimeSpan(0, 1, 0)
                    },
                    new Elliptical()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Recovery",
                        InclinePercentage = 5,
                        Resistance = 0,
                        StrokesPerMinute = 110,
                        Duration = new TimeSpan(0, 2, 0)
                    },
                }
            };
        }

        [TestMethod]
        public void CanCorrectlyModel_Run_CustomWorkout()
        {
            var customRunWorkout = new Workout()
            {
                ID = Guid.NewGuid(),
                Name = "Running Workout 1",
                Activities = new List<Activity>()
                {
                    new Walk()
                    {
                        ID = Guid.NewGuid(),
                        Duration = new TimeSpan(0, 5, 0)
                    },
                    new Set()
                    {
                        ID = Guid.NewGuid(),
                        NumberOfRepeats = 12,
                        WorkInterval = new Run()
                        {
                            ID = Guid.NewGuid(),
                            Duration = new TimeSpan(0, 1, 0),
                        },
                        RecoveryInterval = new Walk()
                        {
                            ID = Guid.NewGuid(),
                            Duration = new TimeSpan(0, 1, 0)
                        }
                    }
                }
            };
        }

        [TestMethod]
        public void CanCorrectlyModel_Workout_CustomWorkout()
        {
            var workout = new Workout()
            {
                ID = Guid.NewGuid(),
                Name = "Example Workout 1",
                Activities = new List<Activity>()
                { 
                    new Stretch()
                    {
                        ID = Guid.NewGuid(),
                        Instructions = "Do a series of stretches",
                        Duration = new TimeSpan(0, 5, 0)
                    },
                    new Warmup()
                    {
                        Activities = new List<Activity>()
                        {
                            new Walk()
                            {
                                ID = Guid.NewGuid(),
                                Duration = new TimeSpan(0, 5, 0)
                            }
                        }
                    },
                    new Set()
                    {
                        ID = Guid.NewGuid(),
                        WorkInterval = new Run()
                        {
                            ID = Guid.NewGuid(),
                            Instructions = "Run until HR is at above maximum HR set in configuration"
                        },
                        RecoveryInterval = new Walk()
                        {
                            ID = Guid.NewGuid(),
                            Instructions = "Walk until HR is below minimum HR set in configuration"
                        },
                        Duration = new TimeSpan(0, 30, 0)
                    },
                    new Cooldown()
                    {
                        ID = Guid.NewGuid(),
                        Targets = new List<Target>()
                        {
                            new Distance()
                            {
                                ID = Guid.NewGuid(),
                                DistanceMileage = 0.5
                            }
                        }
                    },
                    new Stretch()
                    {
                        ID = Guid.NewGuid(),
                        Instructions = "Do a series of stretches",
                        Duration = new TimeSpan(0, 5, 0)
                    }
                }
            };
        }
    }
}
