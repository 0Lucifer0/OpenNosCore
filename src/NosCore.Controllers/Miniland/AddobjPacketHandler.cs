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

using ChickenAPI.Packets.ClientPackets.Miniland;
using ChickenAPI.Packets.Enumerations;
using ChickenAPI.Packets.ServerPackets.Miniland;
using ChickenAPI.Packets.ServerPackets.UI;
using NosCore.Core.I18N;
using NosCore.Data;
using NosCore.Data.Enumerations.I18N;
using NosCore.Data.Enumerations.Items;
using NosCore.GameObject;
using NosCore.GameObject.ComponentEntities.Extensions;
using NosCore.GameObject.Networking.ClientSession;
using NosCore.GameObject.Providers.MapInstanceProvider;
using System.Linq;

namespace NosCore.PacketHandlers.Inventory
{
    public class AddobjPacketHandler : PacketHandler<AddobjPacket>, IWorldPacketHandler
    {
        public override void Execute(AddobjPacket addobjPacket, ClientSession clientSession)
        {
            var minilandobject = clientSession.Character.Inventory.LoadBySlotAndType(addobjPacket.Slot, NoscorePocketType.Miniland);
            if (minilandobject == null)
            {
                return;
            }

            if (clientSession.Character.MapInstance.MapDesignObjects.ContainsKey(minilandobject.Id))
            {
                clientSession.SendPacket(new MsgPacket
                {
                    Message = Language.Instance.GetMessageFromKey(LanguageKey.ALREADY_THIS_MINILANDOBJECT, clientSession.Account.Language)
                });
                return;
            }

            if (clientSession.Character.MinilandState != MinilandState.Lock)
            {
                clientSession.SendPacket(new MsgPacket
                {
                    Message = Language.Instance.GetMessageFromKey(LanguageKey.MINILAND_NEED_LOCK, clientSession.Account.Language)
                });
                return;
            }
            var minilandobj = new MapDesignObject
            {
                CharacterId = clientSession.Character.CharacterId,
                InventoryItemInstance = minilandobject,
                ItemInstanceId = minilandobject.Id,
                MapX = addobjPacket.PositionX,
                MapY = addobjPacket.PositionY,
                Level1BoxAmount = 0,
                Level2BoxAmount = 0,
                Level3BoxAmount = 0,
                Level4BoxAmount = 0,
                Level5BoxAmount = 0
            };

            if (minilandobject.ItemInstance.Item.ItemType == ItemType.House)
            {
                switch (minilandobject.ItemInstance.Item.ItemSubType)
                {
                    case 0:
                        minilandobj.MapX = 24;
                        minilandobj.MapY = 7;
                        break;

                    case 1:
                        minilandobj.MapX = 21;
                        minilandobj.MapY = 4;
                        break;

                    case 2:
                        minilandobj.MapX = 31;
                        minilandobj.MapY = 3;
                        break;
                }

                var min = clientSession.Character.MapInstance.MapDesignObjects
                    .FirstOrDefault(s => s.Value.InventoryItemInstance.ItemInstance.Item.ItemType == ItemType.House &&
                    s.Value.InventoryItemInstance.ItemInstance.Item.ItemSubType == minilandobject.ItemInstance.Item.ItemSubType).Value;
                if (min != null)
                {
                    clientSession.HandlePackets(new[] { new RmvobjPacket { Slot = min.InventoryItemInstance.Slot } });
                }
            }

            if (minilandobject.ItemInstance.Item.IsWarehouse)
            {
                //TODO add warehouse points
                //clientSession.Character.WareHouseSize = minilandobject.ItemInstance.Item.MinilandObjectPoint;
            }
            clientSession.Character.MapInstance.MapDesignObjects.TryAdd(minilandobject.Id, minilandobj);
            clientSession.SendPacket(minilandobj.GenerateEffect());
            clientSession.SendPacket(new MinilandPointPacket { MinilandPoint = minilandobject.ItemInstance.Item.MinilandObjectPoint, Unknown = 100 });
            clientSession.SendPacket(minilandobj.GenerateMapDesignObject(false));
        }
    }
}