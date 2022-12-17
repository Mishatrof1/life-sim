using System;

namespace Animations
{
    public enum AnimationType
    {
        IdleNeutral = 0,
        IdleSad = 1,
        IdleAngry = 2,
        Amazing = 3,
        Angry = 4,
        Boring = 5,
        Crying = 6,
        Displeasure = 7,
        Fear = 8,
        Indifference = 9,
        Laugh = 10,
        Sad = 11,
        Smile = 12,
        Weeping = 13
    }

    public static class AnimationUtils
    {
        public static string GetAnimationName(AnimationType animation)
        {
            switch (animation)
            {
                case AnimationType.IdleNeutral:
                    return "idle_neitral";
                case AnimationType.IdleSad:
                    return "idle_sad";
                case AnimationType.IdleAngry:
                    return "idle_angry";
                case AnimationType.Amazing:
                    return "amazing";
                case AnimationType.Angry:
                    return "angry";
                case AnimationType.Boring:
                    return "boring";
                case AnimationType.Crying:
                    return "crying";
                case AnimationType.Displeasure:
                    return "displeasure";
                case AnimationType.Fear:
                    return "fear";
                case AnimationType.Indifference:
                    return "indifference";
                case AnimationType.Laugh:
                    return "laugh";
                case AnimationType.Sad:
                    return "sad";
                case AnimationType.Smile:
                    return "smile";
                case AnimationType.Weeping:
                    return "weeping";
                default:
                    throw new ArgumentOutOfRangeException(nameof(animation), animation, null);
            }
        }
    }
}