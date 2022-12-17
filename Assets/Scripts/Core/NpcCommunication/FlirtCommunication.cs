using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Extensions;
using Leopotam.Ecs;
using Modules;
using Settings.NpcCommunication;
using UnityEngine;

namespace Core.NpcCommunication
{
    public class FlirtCommunication : Communication<FlirtSettings, ReactionsSettings>
    {
        public FlirtCommunication(FlirtSettings communicationSettings, ReactionsSettings reactionSettings)
            : base(communicationSettings, reactionSettings)
        {
        }

        public override string GetTopText(Npc npc)
        {
            return _communicationSettings.ScreenTitle.Enrich(npc);
        }

        public override List<CommunicationChoice> GenerateChoices(Npc npc)
        {
            return _communicationSettings.SelectRandomChoices(ChoiceCount, npc);
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity characterEntity, ref EcsEntity npcEntity)
        {
            throw new System.NotImplementedException();
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity characterEntity, ref EcsEntity npcEntity,
            out string description)
        {
            var choiceSettings = _communicationSettings.Communications[choiceIndex];
            var npc = npcEntity.Get<NpcComponent>().Npc;
            var character = characterEntity.Get<CharacterComponent>().Character;
            
            if (npc.FlirtProgress.FlirtResult < 0 &&
                (WorldDateModule.CurrentDate - npc.FlirtProgress.FlirtResultWorldDate).TotalYears > 2)
            {
                npc.FlirtProgress.Reset();
            }

            npc.FlirtProgress.LastFlirtWorldDate = WorldDateModule.CurrentDate;
            
            var sympathy = npc.Parameters.Get(ParameterType.Sympathy.ToString());
            var relationship = npc.Parameters.Get(ParameterType.Relationship.ToString());
            var failResponses = _communicationSettings.Responses.Where(x => !x.IsSuccess).ToList();
            var successResponses = _communicationSettings.Responses.Where(x => x.IsSuccess).ToList();
            var failResponseLogs = _communicationSettings.FlirtResponseLogSettings.Where(x => !x.IsSuccess).ToList();
            var successResponseLogs = _communicationSettings.FlirtResponseLogSettings.Where(x => x.IsSuccess).ToList();
            var failResult = _communicationSettings.ResultSettings.Where(x => !x.IsSuccess).ToList();
            var successResult = _communicationSettings.ResultSettings.Where(x => x.IsSuccess).ToList();

            description = "";
            if (npc.FlirtProgress.FlirtResult < 0)
            {
                var overdose =
                    _communicationSettings.FlirtOverdoseSettings[
                        Random.Range(0, _communicationSettings.FlirtOverdoseSettings.Count)];
                description = failResponses[Random.Range(0, failResponses.Count)].Text.Enrich(npc);
                relationship.Dec(_communicationSettings.RelationshipYearDec);
                character.AgeLog.AddRecord(WorldDateModule.CurrentDate,
                    new Record(overdose.LogText.Enrich(npc).Replace(overdose.ReplaceBubleText, npc, character)));
                return overdose.BubleText.Enrich(npc).Replace(overdose.ReplaceBubleText, npc, character);
            }
            
            npc.FlirtProgress.PersistenceSum += choiceSettings.Persistence ? 1 : -1;
            npc.FlirtProgress.Count++;
            sympathy.Inc(Random.Range(_communicationSettings.SympathyIncMin, _communicationSettings.SympathyIncMax + 1));
            
            var successResponse = successResponses[Random.Range(0, successResponses.Count)];
            var failResponse = failResponses[Random.Range(0, failResponses.Count)];
            var successResponseLog = successResponseLogs[Random.Range(0, successResponseLogs.Count)];
            var failResponseLog = failResponseLogs[Random.Range(0, failResponseLogs.Count)];
            
            description = npc.Parameters.Get(ParameterType.Sympathy.ToString()).Value > 50
                ? successResponse.Text.Enrich(npc)
                : failResponse.Text.Enrich(npc);

            character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Record(npc.Parameters.Get(ParameterType.Sympathy.ToString()).Value > 50
                ? successResponseLog.Text.Enrich(npc).Replace(successResponseLog.ReplaceText, npc, character)
                : failResponseLog.Text.Enrich(npc).Replace(failResponseLog.ReplaceText, npc, character)));

            var bubble = npc.Parameters.Get(ParameterType.Sympathy.ToString()).Value > 50
                ? choiceSettings.SuccessBubleText.Enrich(npc).Replace(choiceSettings.ReplaceSuccessBubleText, npc, character)
                : choiceSettings.FailBubleText.Enrich(npc).Replace(choiceSettings.ReplaceFailBubleText, npc, character);
            
            if (npc.FlirtProgress.Count >= _communicationSettings.FlirtCountMin && sympathy.Value >= _communicationSettings.SympathyThreshold)
            {
                npc.FlirtProgress.FlirtResult = 1;
                
                var result = successResult[Random.Range(0, successResult.Count)];
                character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Record(result.LogText.Enrich(npc).Replace(result.ReplaceLogText, npc, character)));
                return bubble;
            }

            if (npc.FlirtProgress.Count == _communicationSettings.FlirtCountMax)
            {
                npc.FlirtProgress.FlirtResult = -1;
                npc.FlirtProgress.FlirtResultWorldDate = WorldDateModule.CurrentDate;
                sympathy.Set(Random.Range(_communicationSettings.SympathyDecMin, _communicationSettings.SympathyDecMax + 1));
                if (relationship.Value > 0)
                {
                    relationship.Dec(_communicationSettings.RelationshipInstantDec);
                    relationship.Set(Mathf.Max(0, relationship.Value));
                }
                
                var result = failResult[Random.Range(0, failResult.Count)];
                character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Record(result.LogText.Enrich(npc).Replace(result.ReplaceLogText, npc, character)));
                return bubble;
            }

            return bubble;
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity communicationEntity, ref EcsEntity characterEntity,
            ref EcsEntity npcEntity)
        {
            throw new System.NotImplementedException();
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity communicationEntity, ref EcsEntity characterEntity,
            ref EcsEntity npcEntity, out string description)
        {
            throw new System.NotImplementedException();
        }

        public override string GetChoiceText(int choiceIndex, Npc npc)
        {
            return _communicationSettings.Communications[choiceIndex].GetActualText(npc);
        }
    }
}