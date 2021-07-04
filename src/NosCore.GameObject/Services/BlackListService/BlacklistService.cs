﻿//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// 
// Copyright (C) 2019 - NosCore
// 
// NosCore is a free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using NosCore.Dao.Interfaces;
using NosCore.Data.Dto;
using NosCore.Data.Enumerations.I18N;
using NosCore.Data.WebApi;
using NosCore.Packets.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NosCore.Core.MessageQueue;

namespace NosCore.GameObject.Services.BlackListService
{
    public class BlacklistService : IBlacklistService
    {
        private readonly IDao<CharacterDto, long> _characterDao;
        private readonly IDao<CharacterRelationDto, Guid> _characterRelationDao;
        private readonly IPubSubHub _connectedAccountHttpClient;

        public BlacklistService(IPubSubHub connectedAccountHttpClient,
            IDao<CharacterRelationDto, Guid> characterRelationDao, IDao<CharacterDto, long> characterDao)
        {
            _connectedAccountHttpClient = connectedAccountHttpClient;
            _characterRelationDao = characterRelationDao;
            _characterDao = characterDao;
        }

        public async Task<LanguageKey> BlacklistPlayerAsync(long characterId, long secondCharacterId)
        {
            var characters = await _connectedAccountHttpClient.GetSubscribersAsync().ConfigureAwait(false);
            var character = characters.FirstOrDefault(x => x.ConnectedCharacter?.Id == characterId);
            var targetCharacter = characters.FirstOrDefault(x => x.ConnectedCharacter?.Id == secondCharacterId);
            if ((character == null) || (targetCharacter == null))
            {
                throw new ArgumentException();
            }

            var relations = _characterRelationDao.Where(s => s.CharacterId == characterId)?
                .ToList() ?? new List<CharacterRelationDto>();
            if (relations.Any(s =>
                (s.RelatedCharacterId == secondCharacterId) &&
                (s.RelationType != CharacterRelationType.Blocked)))
            {
                return LanguageKey.CANT_BLOCK_FRIEND;
            }

            if (relations.Any(s =>
                (s.RelatedCharacterId == secondCharacterId) &&
                (s.RelationType == CharacterRelationType.Blocked)))
            {
                return LanguageKey.ALREADY_BLACKLISTED;
            }

            var data = new CharacterRelationDto
            {
                CharacterId = character.ConnectedCharacter!.Id,
                RelatedCharacterId = targetCharacter.ConnectedCharacter!.Id,
                RelationType = CharacterRelationType.Blocked
            };

            await _characterRelationDao.TryInsertOrUpdateAsync(data).ConfigureAwait(false);
            return LanguageKey.BLACKLIST_ADDED;

        }

        public async Task<List<CharacterRelationStatus>> GetBlacklistedListAsync(long id)
        {
            var characters = await _connectedAccountHttpClient.GetSubscribersAsync().ConfigureAwait(false);
            var charList = new List<CharacterRelationStatus>();
            var list = _characterRelationDao
                .Where(s => (s.CharacterId == id) && (s.RelationType == CharacterRelationType.Blocked));
            if (list == null)
            {
                return charList;
            }
            foreach (var rel in list)
            {
                charList.Add(new CharacterRelationStatus
                {
                    CharacterName = (await _characterDao.FirstOrDefaultAsync(s => s.CharacterId == rel.RelatedCharacterId).ConfigureAwait(false))?.Name ?? "",
                    CharacterId = rel.RelatedCharacterId,
                    IsConnected = characters.FirstOrDefault(x=>x.ConnectedCharacter?.Id == rel.RelatedCharacterId) != null,
                    RelationType = rel.RelationType,
                    CharacterRelationId = rel.CharacterRelationId
                });
            }

            return charList;
        }

        public async Task<bool> UnblacklistAsync(Guid id)
        {
            var rel = await _characterRelationDao.FirstOrDefaultAsync(s =>
                (s.CharacterRelationId == id) && (s.RelationType == CharacterRelationType.Blocked)).ConfigureAwait(false);
            if (rel == null)
            {
                return false;
            }
            await _characterRelationDao.TryDeleteAsync(rel.CharacterRelationId).ConfigureAwait(false);
            return true;
        }
    }
}