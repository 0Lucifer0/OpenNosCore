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

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NosCore.Core;
using NosCore.Core.I18N;
using NosCore.Data.Enumerations.I18N;
using NosCore.Data.WebApi;
using NosCore.GameObject.Networking.ClientSession;
using NosCore.PacketHandlers.CharacterScreen;
using NosCore.Packets.ClientPackets.Infrastructure;
using NosCore.Tests.Shared;
using Serilog;

namespace NosCore.PacketHandlers.Tests.CharacterScreen
{
    [TestClass]
    public class DacPacketHandlerTests
    {
        private static readonly Mock<ILogger> Logger = new Mock<ILogger>();
        private DacPacketHandler _dacPacketHandler = null!;
        private ClientSession _session = null!;
        private string _accountName = null!;

        [TestInitialize]
        public async Task SetupAsync()
        {
            await TestHelpers.ResetAsync().ConfigureAwait(false);
            _session = await TestHelpers.Instance.GenerateSessionAsync().ConfigureAwait(false);
            _accountName = _session!.Account.Name;
            _session!.Account = null!;
            await TestHelpers.Instance.CharacterDao.TryInsertOrUpdateAsync(_session.Character);
            await _session.SetCharacterAsync(null).ConfigureAwait(false);
            _dacPacketHandler =
                new DacPacketHandler(TestHelpers.Instance.AccountDao, Logger.Object, TestHelpers.Instance.ChannelHubClient.Object);
        }

        [TestMethod]
        public async Task ConnectionWithAlreadyConnectedAccountAsync()
        {
            var packet = new DacPacket
            {
                Slot = 2,
                AccountName = _accountName
            };
            TestHelpers.Instance.ChannelHubClient.Setup(o => o.GetChannels()).ReturnsAsync(new List<ChannelInfo>()
            {
                new ChannelInfo
                {
                    Id = 1,
                }
            });
            TestHelpers.Instance.ChannelHubClient.Setup(o => o.GetConnectedAccountsAsync()).ReturnsAsync(
                new List<ConnectedAccount>
                {
                    new ConnectedAccount
                    {
                        ChannelId = 1,
                        Name = _accountName
                    }
                });
            await _dacPacketHandler.ExecuteAsync(packet, _session);
            Logger.Verify(o => o.Error(It.Is<string>(o => o == LogLanguage.Instance.GetMessageFromKey(LogLanguageKey.ALREADY_CONNECTED)), It.Is<It.IsAnyType>((v, t) => true)), Times.Once);
            Assert.IsNull(_session!.Account);
        }

        [TestMethod]
        public async Task ConnectionWithInvalidAccountAsync()
        {
            var packet = new DacPacket
            {
                Slot = 2,
                AccountName = "fakeName"
            };
            await _dacPacketHandler.ExecuteAsync(packet, _session);
            Logger.Verify(o => o.Error(It.Is<string>(o => o == LogLanguage.Instance.GetMessageFromKey(LogLanguageKey.INVALID_ACCOUNT)), It.Is<It.IsAnyType>((v, t) => true)), Times.Once);

            Assert.IsNull(_session!.Account);
        }

        [TestMethod]
        public async Task ConnectionWithNotInwaitingAccountAsync()
        {
            await _dacPacketHandler.ExecuteAsync(new DacPacket
            {
                Slot = 0,
                AccountName = _accountName
            }, _session);
            Logger.Verify(o => o.Error(It.Is<string>(o => o == LogLanguage.Instance.GetMessageFromKey(LogLanguageKey.INVALID_PASSWORD)), It.Is<It.IsAnyType>((v, t) => true)), Times.Once);
            Assert.IsNull(_session!.Account);
        }

        [TestMethod]
        public async Task ConnectionWithInwaitingAccountAsync()
        {
            var packet = new DacPacket
            {
                Slot = 0,
                AccountName = _accountName
            };
            //_authHttpClient.Setup(authHttpClient => authHttpClient
            //        .GetAwaitingConnectionAsync(It.IsAny<string?>(), It.IsAny<string>(), It.IsAny<int>()))
            //    .ReturnsAsync("123");
            await _dacPacketHandler.ExecuteAsync(packet, _session);
            Assert.IsNotNull(_session!.Account);
        }
    }
}