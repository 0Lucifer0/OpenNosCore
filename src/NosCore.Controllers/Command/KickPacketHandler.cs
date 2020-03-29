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

using System.Threading.Tasks;
using NosCore.Core.HttpClients.ConnectedAccountHttpClients;
using NosCore.Packets.ServerPackets.UI;
using NosCore.Core.I18N;
using NosCore.Data.CommandPackets;
using NosCore.Data.Enumerations.I18N;
using NosCore.GameObject;
using NosCore.GameObject.Networking.ClientSession;

namespace NosCore.PacketHandlers.Command
{
    public class KickPacketHandler : PacketHandler<KickPacket>, IWorldPacketHandler
    {
        private readonly IConnectedAccountHttpClient _connectedAccountHttpClient;

        public KickPacketHandler(IConnectedAccountHttpClient connectedAccountHttpClient)
        {
            _connectedAccountHttpClient = connectedAccountHttpClient;
        }

        public override async Task Execute(KickPacket kickPacket, ClientSession session)
        {
            var receiver = await _connectedAccountHttpClient.GetCharacter(null, kickPacket.Name);

            if (receiver.Item2 == null) //TODO: Handle 404 in WebApi
            {
                await session.SendPacket(new InfoPacket
                {
                    Message = GameLanguage.Instance.GetMessageFromKey(LanguageKey.CANT_FIND_CHARACTER,
                        session.Account.Language)
                });
                return;
            }

            await _connectedAccountHttpClient.Disconnect(receiver.Item2.ConnectedCharacter!.Id);
        }
    }
}