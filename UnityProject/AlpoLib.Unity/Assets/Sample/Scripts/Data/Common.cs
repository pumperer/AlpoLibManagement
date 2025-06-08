using alpoLib.Data.Serialization;

namespace alpoLib.Sample.Data
{
    public enum AssetType
    {
        None = 0,
        Gold,
        Gem,
    }

    public enum GoalType
    {
        None = 0,
        GetGold,
        MaxStage,
    }

    public enum GoalSubType
    {
        None = 0,
    }

    public enum GoalCountMethod
    {
        None = 0,
        Add,
        Assign,
        Max,
    }
    
    public record Goal
    {
        [DataCompoundElement("goal_type")]
        public GoalType Type { get; set; }
        
        [DataCompoundElement("goal_sub_type")]
        public GoalSubType SubType { get; set; }
        
        [DataCompoundElement("goal_grade")]
        public int GoalGrade { get; set; }
        
        [DataCompoundElement("goal_id")]
        public int GoalId { get; set; }
        
        [DataCompoundElement("goal_value")]
        public int GoalValue { get; set; }
        
        [DataCompoundElement("goal_count")]
        public int GoalCount { get; set; }
        
        [DataCompoundElement("goal_count_method")]
        public GoalCountMethod GoalCountMethod { get; set; }
    }

    public record Reward
    {
        [DataCompoundElement("type")]
        public AssetType Type { get; set; }
        
        [DataCompoundElement("id")]
        public int Id { get; set; }
        
        [DataCompoundElement("amount")]
        public int Amount { get; set; }
    }
    
    public record SpecCost
    {
        [DataCompoundElement("cost_type")]
        public AssetType Type { get; set; }
        
        [DataCompoundElement("cost_amount")]
        public int Value { get; set; }
    }
}