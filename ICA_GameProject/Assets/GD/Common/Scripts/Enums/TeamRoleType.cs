using System.Collections.Generic;
using System.ComponentModel;

namespace GD
{
    [System.Serializable]
    public class TeamMember
    {
        public string Name;
        public List<DepartmentRole> role = new();
    }

    [System.Serializable]
    public class DepartmentRole
    {
        public DepartmentType Department;
        public RoleType Role;
    }

    [System.Serializable]
    public enum DepartmentType
    {
        [Description("Creates visual elements of the game, including characters, environments, and user interfaces.")]
        Art,

        [Description("Responsible for conceptualizing and designing game mechanics, features, and overall gameplay.")]
        Design,

        [Description("Manages the overall development process, including scheduling, budgeting, and coordination.")]
        Production,

        [Description("Handles the implementation of game logic, features, and systems.")]
        Programming,

        [Description("Promotes the game, creates marketing materials, and coordinates promotional activities.")]
        Marketing,

        [Description("Creates and implements audio elements, including music, sound effects, and voiceovers.")]
        Sound,

        [Description("Ensures the quality and functionality of the game through testing and debugging.")]
        QualityAssurance
    }

    [System.Serializable]
    public enum RoleType
    {
        [Description("Creates visual concepts for characters, environments, and game elements.")]
        ART_ConceptArtist,

        [Description("Builds 3D models of characters, objects, and environments for use in the game.")]
        ART_3DModeler,

        [Description("Animates characters and objects to bring them to life within the game world.")]
        ART_Animator,

        [Description("Develops textures and materials to enhance the visual appearance of 3D models.")]
        ART_TextureArtist,

        [Description("Oversees the entire game development process, from concept to release.")]
        GD_LeadDesigner,

        [Description("Designs individual levels or areas within a game, focusing on gameplay and user experience.")]
        GD_LevelDesigner,

        [Description("Designs and implements game systems, including mechanics, rules, and features.")]
        GD_SystemDesigner,

        [Description("Creates the narrative and dialogue for the game, shaping the story and characters.")]
        GD_Writer,

        [Description("Focuses on the user experience, designing and implementing interfaces and interactions.")]
        PROG_UXProgrammer,

        [Description("Implements gameplay features and mechanics using programming languages.")]
        PROG_GameplayProgrammer,

        [Description("Handles networking aspects of the game, enabling multiplayer and online features.")]
        PROG_NetworkProgrammer,

        [Description("Writes and optimizes shaders to achieve specific visual effects in the game.")]
        PROG_ShaderProgrammer,

        [Description("Works on the core engine of the game, optimizing performance and functionality.")]
        PROG_EngineProgrammer,

        [Description("Creates original music compositions for the game.")]
        SND_Composer,

        [Description("Designs and implements sound effects to enhance the audio experience.")]
        SND_SoundEffectsDesigner,

        [Description("Manages the technical aspects of audio production, ensuring high-quality sound.")]
        SND_AudioEngineer,

        [Description("Directs voice-over sessions and ensures quality performances for in-game characters.")]
        SND_VoiceOverDirector,

        [Description("Tests game functionality, identifying and reporting bugs for resolution.")]
        QA_TestEngineer,

        [Description("Analyzes and documents testing processes, creating test cases and strategies.")]
        QA_TestAnalyst,

        [Description("Leads the testing team, coordinating efforts and ensuring comprehensive testing.")]
        QA_TestLead,

        [Description("Automates testing processes to streamline and improve efficiency.")]
        QA_AutomationEngineer,

        [Description("Oversees the entire game development process, from concept to release.")]
        PROD_Producer,

        [Description("Assists the producer in managing and coordinating the development process.")]
        PROD_AssociateProducer,

        [Description("Provides administrative support to the production team.")]
        PROD_ProductionAssistant,

        [Description("Facilitates the Agile development process as a Scrum Master.")]
        PROD_ScrumMaster,

        [Description("Develops marketing strategies to promote the game and increase its visibility.")]
        MKT_MarketingStrategist,

        [Description("Manages communication with the gaming community, addressing concerns and feedback.")]
        MKT_CommunityManager,

        [Description("Handles public relations for the game, interacting with media and promoting positive coverage.")]
        MKT_PublicRelationsManager,

        [Description("Manages the overall brand image of the game, ensuring a consistent and appealing identity.")]
        MKT_BrandManager
    }

    /*
    [Flags]
    public enum RoleType
    {
        AIProgrammer = 1 << 0, // 1
        Animator = 1 << 1, // 2
        ArtDirector = 1 << 2, // 4
        AudioEngineer = 1 << 3, // 8
        CharacterArtist = 1 << 4, // 16
        CinematicArtist = 1 << 5, // 32
        ConceptArtist = 1 << 6, // 64
        ContentDesigner = 1 << 7, // 128
        EnvironmentArtist = 1 << 8, // 256
        GameDesigner = 1 << 9, // 512
        GameDirector = 1 << 10, // 1024
        GameProducer = 1 << 11, // 2048
        GameplayProgrammer = 1 << 12, // 4096
        GraphicsProgrammer = 1 << 13, // 8192
        InterfaceDesigner = 1 << 14, // 16384
        LevelDesigner = 1 << 15, // 32768
        LocalizationManager = 1 << 16, // 65536
        NarrativeDesigner = 1 << 17, // 131072
        NetworkProgrammer = 1 << 18, // 262144
        ParticleEffectsArtist = 1 << 19, // 524288
        QATester = 1 << 20, // 1048576
        RiggingArtist = 1 << 21, // 2097152
        ScriptWriter = 1 << 22, // 4194304
        SoundDesigner = 1 << 23, // 8388608
        SystemsDesigner = 1 << 24, // 16777216
        TechnicalArtist = 1 << 25, // 33554432
        TechnicalDirector = 1 << 26, // 67108864
        UIUXDesigner = 1 << 27, // 134217728
        VFXArtist = 1 << 28, // 268435456
        VoiceActor = 1 << 29, // 536870912
        Writer = 1 << 30  // 1073741824

        //SINCE enums are INTs we can only have 32 roles MAX!
    }
    */
}