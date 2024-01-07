using System.ComponentModel;

namespace GD
{
    public enum LifecycleStageType
    {
        [Description("Experimental stage for trying out ideas.")]
        Sandbox,

        [Description("Initial implementation to validate a concept.")]
        ProofOfConcept,

        [Description("Early development stage with basic features.")]
        PreAlpha,

        [Description("Feature-complete version for internal testing.")]
        Alpha,

        [Description("Publicly available version for user testing.")]
        Beta,

        [Description("Final testing before the official release.")]
        ReleaseCandidate,

        [Description("Stable version for general use.")]
        StableRelease,

        [Description("No longer actively supported or maintained.")]
        EndOfLife
    }
}