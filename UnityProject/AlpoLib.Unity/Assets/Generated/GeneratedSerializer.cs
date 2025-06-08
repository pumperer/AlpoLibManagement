using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using alpoLib.Core.Serialization;
using UnityEngine;

namespace alpoLib.Data.Serialization.Generated {
public sealed record __r_AchievementDetailBase_1353023679_Wrapped : alpoLib.Sample.Data.AchievementDetailBase {
public static SchemeDefinition[] __schema__ = {
new() { NameHash = 428415991, TypeHash = 1798982289 }, /* Int32 AchievementId */
new() { NameHash = 902736219, TypeHash = 1798982289 }, /* Int32 GoalCount */
new() { NameHash = 42386432, TypeHash = 1798982289 }, /* Int32 RewardGroupId */
new() { NameHash = 2543258826, TypeHash = 1798982289 }, /* Int32 Sequence */
new() { NameHash = 1714641353, TypeHash = 3333469098 }, /* CustomBoolean Status */
new() { NameHash = 4214230326, TypeHash = 1798982289 }, /* Int32 Id */
/* Definition Count: 6 */
};
public System.Int32 __r_AchievementId_Ovr { set { AchievementId = value; } }
public System.Int32 __r_GoalCount_Ovr { set { GoalCount = value; } }
public System.Int32 __r_RewardGroupId_Ovr { set { RewardGroupId = value; } }
public System.Int32 __r_Sequence_Ovr { set { Sequence = value; } }
public alpoLib.Core.Foundation.CustomBoolean __r_Status_Ovr { set { Status = value; } }
public System.Int32 __r_Id_Ovr { set { Id = value; } }
}
public sealed class __r_AchievementDetailBase_1353023679_Serializer : SerializerBase<alpoLib.Sample.Data.AchievementDetailBase> {
public override SchemeDefinition[] GetSchemeDefinitions() { return __r_AchievementDetailBase_1353023679_Wrapped.__schema__; }
public override alpoLib.Sample.Data.AchievementDetailBase Deserialize(BufferStream stream) {
var da = new __r_AchievementDetailBase_1353023679_Wrapped();
da.__r_AchievementId_Ovr = stream.ReadS32();
da.__r_GoalCount_Ovr = stream.ReadS32();
da.__r_RewardGroupId_Ovr = stream.ReadS32();
da.__r_Sequence_Ovr = stream.ReadS32();
da.__r_Status_Ovr = stream.ReadCustomBoolean();
da.__r_Id_Ovr = stream.ReadS32();
return da; }
public override void Serialize(BufferStream stream, alpoLib.Sample.Data.AchievementDetailBase da) {
stream.WriteS32(da.AchievementId);
stream.WriteS32(da.GoalCount);
stream.WriteS32(da.RewardGroupId);
stream.WriteS32(da.Sequence);
stream.WriteCustomBoolean(da.Status);
stream.WriteS32(da.Id);
}
public override alpoLib.Sample.Data.AchievementDetailBase JsonToObject(JToken token) {
var da = new alpoLib.Sample.Data.AchievementDetailBase();
da.AchievementId = token["achievement_id"] != null ? token["achievement_id"].ToObject<System.Int32>() : default;
da.GoalCount = token["goal_count"] != null ? token["goal_count"].ToObject<System.Int32>() : default;
da.Id = token["id"] != null ? token["id"].ToObject<System.Int32>() : default;
da.RewardGroupId = token["reward_group_id"] != null ? token["reward_group_id"].ToObject<System.Int32>() : default;
da.Sequence = token["sequence"] != null ? token["sequence"].ToObject<System.Int32>() : default;
da.Status = token["status"] != null ? token["status"].ToObject<alpoLib.Core.Foundation.CustomBoolean>() : default;
return da; }
public override void ObjectToJson(JToken token, alpoLib.Sample.Data.AchievementDetailBase da) {
}
}
public sealed record __r_AchievementSummaryBase_2225946754_Wrapped : alpoLib.Sample.Data.AchievementSummaryBase {
public static SchemeDefinition[] __schema__ = {
new() { NameHash = 4002822995, TypeHash = 333453118 }, /* (Compound) GoalType Goal.Type */
new() { NameHash = 653371828, TypeHash = 1330835919 }, /* (Compound) GoalSubType Goal.SubType */
new() { NameHash = 3903521800, TypeHash = 1798982289 }, /* (Compound) Int32 Goal.GoalGrade */
new() { NameHash = 1783185724, TypeHash = 1798982289 }, /* (Compound) Int32 Goal.GoalId */
new() { NameHash = 3575548640, TypeHash = 1798982289 }, /* (Compound) Int32 Goal.GoalValue */
new() { NameHash = 902736219, TypeHash = 1798982289 }, /* (Compound) Int32 Goal.GoalCount */
new() { NameHash = 2525674724, TypeHash = 3463765971 }, /* (Compound) GoalCountMethod Goal.GoalCountMethod */
new() { NameHash = 243566418, TypeHash = 566847661 }, /* Goal Goal */
new() { NameHash = 2543258826, TypeHash = 1798982289 }, /* Int32 Sequence */
new() { NameHash = 1714641353, TypeHash = 3333469098 }, /* CustomBoolean Status */
new() { NameHash = 4214230326, TypeHash = 1798982289 }, /* Int32 Id */
/* Definition Count: 11 */
};
public alpoLib.Sample.Data.Goal __r_Goal_Ovr { set { Goal = value; } }
public System.Int32 __r_Sequence_Ovr { set { Sequence = value; } }
public alpoLib.Core.Foundation.CustomBoolean __r_Status_Ovr { set { Status = value; } }
public System.Int32 __r_Id_Ovr { set { Id = value; } }
}
public sealed class __r_AchievementSummaryBase_2225946754_Serializer : SerializerBase<alpoLib.Sample.Data.AchievementSummaryBase> {
public override SchemeDefinition[] GetSchemeDefinitions() { return __r_AchievementSummaryBase_2225946754_Wrapped.__schema__; }
public override alpoLib.Sample.Data.AchievementSummaryBase Deserialize(BufferStream stream) {
var da = new __r_AchievementSummaryBase_2225946754_Wrapped();
da.__r_Goal_Ovr = DeserializeComp<alpoLib.Sample.Data.Goal, __r_Goal_775933579_Serializer>(stream);
da.__r_Sequence_Ovr = stream.ReadS32();
da.__r_Status_Ovr = stream.ReadCustomBoolean();
da.__r_Id_Ovr = stream.ReadS32();
return da; }
public override void Serialize(BufferStream stream, alpoLib.Sample.Data.AchievementSummaryBase da) {
SerializeComp<alpoLib.Sample.Data.Goal, __r_Goal_775933579_Serializer>(stream, da.Goal);
stream.WriteS32(da.Sequence);
stream.WriteCustomBoolean(da.Status);
stream.WriteS32(da.Id);
}
public override alpoLib.Sample.Data.AchievementSummaryBase JsonToObject(JToken token) {
var da = new alpoLib.Sample.Data.AchievementSummaryBase();
da.Goal = new alpoLib.Sample.Data.Goal {
Type = token["goal_type"] != null ? token["goal_type"].ToObject<alpoLib.Sample.Data.GoalType>() : default,
SubType = token["goal_sub_type"] != null ? token["goal_sub_type"].ToObject<alpoLib.Sample.Data.GoalSubType>() : default,
GoalGrade = token["goal_grade"] != null ? token["goal_grade"].ToObject<System.Int32>() : default,
GoalId = token["goal_id"] != null ? token["goal_id"].ToObject<System.Int32>() : default,
GoalValue = token["goal_value"] != null ? token["goal_value"].ToObject<System.Int32>() : default,
GoalCount = token["goal_count"] != null ? token["goal_count"].ToObject<System.Int32>() : default,
GoalCountMethod = token["goal_count_method"] != null ? token["goal_count_method"].ToObject<alpoLib.Sample.Data.GoalCountMethod>() : default,
};
da.Id = token["id"] != null ? token["id"].ToObject<System.Int32>() : default;
da.Sequence = token["sequence"] != null ? token["sequence"].ToObject<System.Int32>() : default;
da.Status = token["status"] != null ? token["status"].ToObject<alpoLib.Core.Foundation.CustomBoolean>() : default;
return da; }
public override void ObjectToJson(JToken token, alpoLib.Sample.Data.AchievementSummaryBase da) {
}
}
public sealed record __r_Goal_775933579_Wrapped : alpoLib.Sample.Data.Goal {
public static SchemeDefinition[] __schema__ = {
new() { NameHash = 4002822995, TypeHash = 333453118 }, /* GoalType Type */
new() { NameHash = 653371828, TypeHash = 1330835919 }, /* GoalSubType SubType */
new() { NameHash = 3903521800, TypeHash = 1798982289 }, /* Int32 GoalGrade */
new() { NameHash = 1783185724, TypeHash = 1798982289 }, /* Int32 GoalId */
new() { NameHash = 3575548640, TypeHash = 1798982289 }, /* Int32 GoalValue */
new() { NameHash = 902736219, TypeHash = 1798982289 }, /* Int32 GoalCount */
new() { NameHash = 2525674724, TypeHash = 3463765971 }, /* GoalCountMethod GoalCountMethod */
/* Definition Count: 7 */
};
public alpoLib.Sample.Data.GoalType __r_Type_Ovr { set { Type = value; } }
public alpoLib.Sample.Data.GoalSubType __r_SubType_Ovr { set { SubType = value; } }
public System.Int32 __r_GoalGrade_Ovr { set { GoalGrade = value; } }
public System.Int32 __r_GoalId_Ovr { set { GoalId = value; } }
public System.Int32 __r_GoalValue_Ovr { set { GoalValue = value; } }
public System.Int32 __r_GoalCount_Ovr { set { GoalCount = value; } }
public alpoLib.Sample.Data.GoalCountMethod __r_GoalCountMethod_Ovr { set { GoalCountMethod = value; } }
}
public sealed class __r_Goal_775933579_Serializer : SerializerBase<alpoLib.Sample.Data.Goal> {
public override SchemeDefinition[] GetSchemeDefinitions() { return __r_Goal_775933579_Wrapped.__schema__; }
public override alpoLib.Sample.Data.Goal Deserialize(BufferStream stream) {
var da = new __r_Goal_775933579_Wrapped();
da.__r_Type_Ovr = (alpoLib.Sample.Data.GoalType)stream.ReadS32(); // ENUM
da.__r_SubType_Ovr = (alpoLib.Sample.Data.GoalSubType)stream.ReadS32(); // ENUM
da.__r_GoalGrade_Ovr = stream.ReadS32();
da.__r_GoalId_Ovr = stream.ReadS32();
da.__r_GoalValue_Ovr = stream.ReadS32();
da.__r_GoalCount_Ovr = stream.ReadS32();
da.__r_GoalCountMethod_Ovr = (alpoLib.Sample.Data.GoalCountMethod)stream.ReadS32(); // ENUM
return da; }
public override void Serialize(BufferStream stream, alpoLib.Sample.Data.Goal da) {
stream.WriteS32((System.Int32)da.Type); // ENUM
stream.WriteS32((System.Int32)da.SubType); // ENUM
stream.WriteS32(da.GoalGrade);
stream.WriteS32(da.GoalId);
stream.WriteS32(da.GoalValue);
stream.WriteS32(da.GoalCount);
stream.WriteS32((System.Int32)da.GoalCountMethod); // ENUM
}
public override alpoLib.Sample.Data.Goal JsonToObject(JToken token) {
var da = new alpoLib.Sample.Data.Goal();
return da; }
public override void ObjectToJson(JToken token, alpoLib.Sample.Data.Goal da) {
}
}
public sealed record __r_CharacterAwakeningCostBase_1396567940_Wrapped : alpoLib.Sample.Data.CharacterAwakeningCostBase {
public static SchemeDefinition[] __schema__ = {
new() { NameHash = 3492698941, TypeHash = 1798982289 }, /* Int32 Grade */
new() { NameHash = 1701603989, TypeHash = 1798982289 }, /* Int32 Gold */
new() { NameHash = 1714641353, TypeHash = 3333469098 }, /* CustomBoolean Status */
new() { NameHash = 4214230326, TypeHash = 1798982289 }, /* Int32 Id */
/* Definition Count: 4 */
};
public System.Int32 __r_Grade_Ovr { set { Grade = value; } }
public System.Int32 __r_Gold_Ovr { set { Gold = value; } }
public alpoLib.Core.Foundation.CustomBoolean __r_Status_Ovr { set { Status = value; } }
public System.Int32 __r_Id_Ovr { set { Id = value; } }
}
public sealed class __r_CharacterAwakeningCostBase_1396567940_Serializer : SerializerBase<alpoLib.Sample.Data.CharacterAwakeningCostBase> {
public override SchemeDefinition[] GetSchemeDefinitions() { return __r_CharacterAwakeningCostBase_1396567940_Wrapped.__schema__; }
public override alpoLib.Sample.Data.CharacterAwakeningCostBase Deserialize(BufferStream stream) {
var da = new __r_CharacterAwakeningCostBase_1396567940_Wrapped();
da.__r_Grade_Ovr = stream.ReadS32();
da.__r_Gold_Ovr = stream.ReadS32();
da.__r_Status_Ovr = stream.ReadCustomBoolean();
da.__r_Id_Ovr = stream.ReadS32();
return da; }
public override void Serialize(BufferStream stream, alpoLib.Sample.Data.CharacterAwakeningCostBase da) {
stream.WriteS32(da.Grade);
stream.WriteS32(da.Gold);
stream.WriteCustomBoolean(da.Status);
stream.WriteS32(da.Id);
}
public override alpoLib.Sample.Data.CharacterAwakeningCostBase JsonToObject(JToken token) {
var da = new alpoLib.Sample.Data.CharacterAwakeningCostBase();
da.Gold = token["gold"] != null ? token["gold"].ToObject<System.Int32>() : default;
da.Grade = token["grade"] != null ? token["grade"].ToObject<System.Int32>() : default;
da.Id = token["id"] != null ? token["id"].ToObject<System.Int32>() : default;
da.Status = token["status"] != null ? token["status"].ToObject<alpoLib.Core.Foundation.CustomBoolean>() : default;
return da; }
public override void ObjectToJson(JToken token, alpoLib.Sample.Data.CharacterAwakeningCostBase da) {
}
}
public sealed record __r_CharacterExpBase_1245192702_Wrapped : alpoLib.Sample.Data.CharacterExpBase {
public static SchemeDefinition[] __schema__ = {
new() { NameHash = 3492698941, TypeHash = 1798982289 }, /* Int32 Grade */
new() { NameHash = 1499963410, TypeHash = 1798982289 }, /* Int32 Level */
new() { NameHash = 1731065367, TypeHash = 1798982289 }, /* Int32 Exp */
new() { NameHash = 1714641353, TypeHash = 3333469098 }, /* CustomBoolean Status */
new() { NameHash = 4214230326, TypeHash = 1798982289 }, /* Int32 Id */
/* Definition Count: 5 */
};
public System.Int32 __r_Grade_Ovr { set { Grade = value; } }
public System.Int32 __r_Level_Ovr { set { Level = value; } }
public System.Int32 __r_Exp_Ovr { set { Exp = value; } }
public alpoLib.Core.Foundation.CustomBoolean __r_Status_Ovr { set { Status = value; } }
public System.Int32 __r_Id_Ovr { set { Id = value; } }
}
public sealed class __r_CharacterExpBase_1245192702_Serializer : SerializerBase<alpoLib.Sample.Data.CharacterExpBase> {
public override SchemeDefinition[] GetSchemeDefinitions() { return __r_CharacterExpBase_1245192702_Wrapped.__schema__; }
public override alpoLib.Sample.Data.CharacterExpBase Deserialize(BufferStream stream) {
var da = new __r_CharacterExpBase_1245192702_Wrapped();
da.__r_Grade_Ovr = stream.ReadS32();
da.__r_Level_Ovr = stream.ReadS32();
da.__r_Exp_Ovr = stream.ReadS32();
da.__r_Status_Ovr = stream.ReadCustomBoolean();
da.__r_Id_Ovr = stream.ReadS32();
return da; }
public override void Serialize(BufferStream stream, alpoLib.Sample.Data.CharacterExpBase da) {
stream.WriteS32(da.Grade);
stream.WriteS32(da.Level);
stream.WriteS32(da.Exp);
stream.WriteCustomBoolean(da.Status);
stream.WriteS32(da.Id);
}
public override alpoLib.Sample.Data.CharacterExpBase JsonToObject(JToken token) {
var da = new alpoLib.Sample.Data.CharacterExpBase();
da.Exp = token["exp"] != null ? token["exp"].ToObject<System.Int32>() : default;
da.Grade = token["grade"] != null ? token["grade"].ToObject<System.Int32>() : default;
da.Id = token["id"] != null ? token["id"].ToObject<System.Int32>() : default;
da.Level = token["level"] != null ? token["level"].ToObject<System.Int32>() : default;
da.Status = token["status"] != null ? token["status"].ToObject<alpoLib.Core.Foundation.CustomBoolean>() : default;
return da; }
public override void ObjectToJson(JToken token, alpoLib.Sample.Data.CharacterExpBase da) {
}
}
public sealed record __r_CharacterLevelBase_1737323998_Wrapped : alpoLib.Sample.Data.CharacterLevelBase {
public static SchemeDefinition[] __schema__ = {
new() { NameHash = 3492698941, TypeHash = 1798982289 }, /* Int32 Grade */
new() { NameHash = 1499963410, TypeHash = 1798982289 }, /* Int32 Level */
new() { NameHash = 1714641353, TypeHash = 3333469098 }, /* CustomBoolean Status */
new() { NameHash = 4214230326, TypeHash = 1798982289 }, /* Int32 Id */
/* Definition Count: 4 */
};
public System.Int32 __r_Grade_Ovr { set { Grade = value; } }
public System.Int32 __r_Level_Ovr { set { Level = value; } }
public alpoLib.Core.Foundation.CustomBoolean __r_Status_Ovr { set { Status = value; } }
public System.Int32 __r_Id_Ovr { set { Id = value; } }
}
public sealed class __r_CharacterLevelBase_1737323998_Serializer : SerializerBase<alpoLib.Sample.Data.CharacterLevelBase> {
public override SchemeDefinition[] GetSchemeDefinitions() { return __r_CharacterLevelBase_1737323998_Wrapped.__schema__; }
public override alpoLib.Sample.Data.CharacterLevelBase Deserialize(BufferStream stream) {
var da = new __r_CharacterLevelBase_1737323998_Wrapped();
da.__r_Grade_Ovr = stream.ReadS32();
da.__r_Level_Ovr = stream.ReadS32();
da.__r_Status_Ovr = stream.ReadCustomBoolean();
da.__r_Id_Ovr = stream.ReadS32();
return da; }
public override void Serialize(BufferStream stream, alpoLib.Sample.Data.CharacterLevelBase da) {
stream.WriteS32(da.Grade);
stream.WriteS32(da.Level);
stream.WriteCustomBoolean(da.Status);
stream.WriteS32(da.Id);
}
public override alpoLib.Sample.Data.CharacterLevelBase JsonToObject(JToken token) {
var da = new alpoLib.Sample.Data.CharacterLevelBase();
da.Grade = token["grade"] != null ? token["grade"].ToObject<System.Int32>() : default;
da.Id = token["id"] != null ? token["id"].ToObject<System.Int32>() : default;
da.Level = token["level"] != null ? token["level"].ToObject<System.Int32>() : default;
da.Status = token["status"] != null ? token["status"].ToObject<alpoLib.Core.Foundation.CustomBoolean>() : default;
return da; }
public override void ObjectToJson(JToken token, alpoLib.Sample.Data.CharacterLevelBase da) {
}
}
public sealed record __r_RewardBase_4157815432_Wrapped : alpoLib.Sample.Data.RewardBase {
public static SchemeDefinition[] __schema__ = {
new() { NameHash = 42386432, TypeHash = 1798982289 }, /* Int32 RewardGroupId */
new() { NameHash = 4002822995, TypeHash = 115391202 }, /* (Compound) AssetType Reward.Type */
new() { NameHash = 4214230326, TypeHash = 1798982289 }, /* (Compound) Int32 Reward.Id */
new() { NameHash = 422475319, TypeHash = 1798982289 }, /* (Compound) Int32 Reward.Amount */
new() { NameHash = 1946898862, TypeHash = 1830732134 }, /* Reward Reward */
new() { NameHash = 1714641353, TypeHash = 3333469098 }, /* CustomBoolean Status */
new() { NameHash = 4214230326, TypeHash = 1798982289 }, /* Int32 Id */
/* Definition Count: 7 */
};
public System.Int32 __r_RewardGroupId_Ovr { set { RewardGroupId = value; } }
public alpoLib.Sample.Data.Reward __r_Reward_Ovr { set { Reward = value; } }
public alpoLib.Core.Foundation.CustomBoolean __r_Status_Ovr { set { Status = value; } }
public System.Int32 __r_Id_Ovr { set { Id = value; } }
}
public sealed class __r_RewardBase_4157815432_Serializer : SerializerBase<alpoLib.Sample.Data.RewardBase> {
public override SchemeDefinition[] GetSchemeDefinitions() { return __r_RewardBase_4157815432_Wrapped.__schema__; }
public override alpoLib.Sample.Data.RewardBase Deserialize(BufferStream stream) {
var da = new __r_RewardBase_4157815432_Wrapped();
da.__r_RewardGroupId_Ovr = stream.ReadS32();
da.__r_Reward_Ovr = DeserializeComp<alpoLib.Sample.Data.Reward, __r_Reward_1658775395_Serializer>(stream);
da.__r_Status_Ovr = stream.ReadCustomBoolean();
da.__r_Id_Ovr = stream.ReadS32();
return da; }
public override void Serialize(BufferStream stream, alpoLib.Sample.Data.RewardBase da) {
stream.WriteS32(da.RewardGroupId);
SerializeComp<alpoLib.Sample.Data.Reward, __r_Reward_1658775395_Serializer>(stream, da.Reward);
stream.WriteCustomBoolean(da.Status);
stream.WriteS32(da.Id);
}
public override alpoLib.Sample.Data.RewardBase JsonToObject(JToken token) {
var da = new alpoLib.Sample.Data.RewardBase();
da.Id = token["id"] != null ? token["id"].ToObject<System.Int32>() : default;
da.Reward = new alpoLib.Sample.Data.Reward {
Type = token["reward_type"] != null ? token["reward_type"].ToObject<alpoLib.Sample.Data.AssetType>() : default,
Id = token["reward_id"] != null ? token["reward_id"].ToObject<System.Int32>() : default,
Amount = token["reward_amount"] != null ? token["reward_amount"].ToObject<System.Int32>() : default,
};
da.RewardGroupId = token["reward_group_id"] != null ? token["reward_group_id"].ToObject<System.Int32>() : default;
da.Status = token["status"] != null ? token["status"].ToObject<alpoLib.Core.Foundation.CustomBoolean>() : default;
return da; }
public override void ObjectToJson(JToken token, alpoLib.Sample.Data.RewardBase da) {
}
}
public sealed record __r_Reward_1658775395_Wrapped : alpoLib.Sample.Data.Reward {
public static SchemeDefinition[] __schema__ = {
new() { NameHash = 4002822995, TypeHash = 115391202 }, /* AssetType Type */
new() { NameHash = 4214230326, TypeHash = 1798982289 }, /* Int32 Id */
new() { NameHash = 422475319, TypeHash = 1798982289 }, /* Int32 Amount */
/* Definition Count: 3 */
};
public alpoLib.Sample.Data.AssetType __r_Type_Ovr { set { Type = value; } }
public System.Int32 __r_Id_Ovr { set { Id = value; } }
public System.Int32 __r_Amount_Ovr { set { Amount = value; } }
}
public sealed class __r_Reward_1658775395_Serializer : SerializerBase<alpoLib.Sample.Data.Reward> {
public override SchemeDefinition[] GetSchemeDefinitions() { return __r_Reward_1658775395_Wrapped.__schema__; }
public override alpoLib.Sample.Data.Reward Deserialize(BufferStream stream) {
var da = new __r_Reward_1658775395_Wrapped();
da.__r_Type_Ovr = (alpoLib.Sample.Data.AssetType)stream.ReadS32(); // ENUM
da.__r_Id_Ovr = stream.ReadS32();
da.__r_Amount_Ovr = stream.ReadS32();
return da; }
public override void Serialize(BufferStream stream, alpoLib.Sample.Data.Reward da) {
stream.WriteS32((System.Int32)da.Type); // ENUM
stream.WriteS32(da.Id);
stream.WriteS32(da.Amount);
}
public override alpoLib.Sample.Data.Reward JsonToObject(JToken token) {
var da = new alpoLib.Sample.Data.Reward();
return da; }
public override void ObjectToJson(JToken token, alpoLib.Sample.Data.Reward da) {
}
}
public static partial class GeneratedSerializerFactory {
[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
public static void RegisterSerializers() { SerializerFactory.RegisterSerializers(ob); }
static Dictionary<Type, ISerializerBase> ob = new() {
{ typeof(alpoLib.Sample.Data.AchievementDetailBase), new __r_AchievementDetailBase_1353023679_Serializer() },
{ typeof(alpoLib.Sample.Data.AchievementSummaryBase), new __r_AchievementSummaryBase_2225946754_Serializer() },
{ typeof(alpoLib.Sample.Data.Goal), new __r_Goal_775933579_Serializer() },
{ typeof(alpoLib.Sample.Data.CharacterAwakeningCostBase), new __r_CharacterAwakeningCostBase_1396567940_Serializer() },
{ typeof(alpoLib.Sample.Data.CharacterExpBase), new __r_CharacterExpBase_1245192702_Serializer() },
{ typeof(alpoLib.Sample.Data.CharacterLevelBase), new __r_CharacterLevelBase_1737323998_Serializer() },
{ typeof(alpoLib.Sample.Data.RewardBase), new __r_RewardBase_4157815432_Serializer() },
{ typeof(alpoLib.Sample.Data.Reward), new __r_Reward_1658775395_Serializer() },
};}
}
