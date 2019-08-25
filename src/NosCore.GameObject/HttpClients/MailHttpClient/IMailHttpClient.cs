﻿using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using NosCore.Data;
using NosCore.Data.Enumerations.I18N;
using NosCore.Data.WebApi;
using NosCore.GameObject.ComponentEntities.Interfaces;

namespace NosCore.GameObject.HttpClients.FriendHttpClient
{
    public interface IMailHttpClient
    {
        void SendGift(ICharacterEntity characterEntity, long receiverId, IItemInstanceDto itemInstance, bool isNosmall);
        void SendGift(ICharacterEntity characterEntity, long receiverId, short vnum, short amount, sbyte rare, byte upgrade, bool isNosmall);
    }
}