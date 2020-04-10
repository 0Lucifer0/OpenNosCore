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
using NosCore.Core;
using NosCore.Dao.Interfaces;
using NosCore.Data.Enumerations.Map;
using NosCore.Data.StaticEntities;
namespace NosCore.Parser.Parsers
{
    public class DropParser
    {
        private readonly IDao<DropDto, short> _dropDao; 
        public DropParser(IDao<DropDto, short> dropDao) { 
            _dropDao = dropDao; 
        }
        public DropDto GenerateDropDto(short vnum, int amount, short? monsterVNum, int dropChance, short mapTypeId) { 
            return new DropDto {
                VNum = vnum, 
                Amount = amount,
                MonsterVNum = monsterVNum,
                DropChance = dropChance,
                MapTypeId = mapTypeId
            };
        }

        public Task InsertDropAsync()
        {
            var drops = new List<DropDto> {
                // Act 1 
                GenerateDropDto(1002, 1, null, 100, (short)MapTypeType.Act1),
                GenerateDropDto(1012, 1, null, 12000, (short)MapTypeType.Act1),
                GenerateDropDto(2015, 1, null, 100, (short)MapTypeType.Act1),
                GenerateDropDto(2016, 1, null, 100, (short)MapTypeType.Act1),
                GenerateDropDto(2023, 1, null, 100, (short)MapTypeType.Act1),
                GenerateDropDto(2024, 1, null, 100, (short)MapTypeType.Act1),
                GenerateDropDto(2028, 1, null, 100, (short)MapTypeType.Act1 ),
 
                // Act2
                GenerateDropDto(1004, 1, null, 500, (short)MapTypeType.Act2),
                GenerateDropDto(1007, 1, null, 500, (short)MapTypeType.Act2),
                GenerateDropDto(1012, 1, null, 7000, (short)MapTypeType.Act2),
                GenerateDropDto(1028, 1, null, 100, (short)MapTypeType.Act2),
                GenerateDropDto(1086, 1, null, 100, (short)MapTypeType.Act2),
                GenerateDropDto(1114, 1, null, 100, (short)MapTypeType.Act2),
                GenerateDropDto(1237, 1, null, 100, (short)MapTypeType.Act2),
                GenerateDropDto(1239, 1, null, 100, (short)MapTypeType.Act2),
                GenerateDropDto(1241, 1, null, 100, (short)MapTypeType.Act2),
                GenerateDropDto(2098, 1, null, 100, (short)MapTypeType.Act2),
                GenerateDropDto(2099, 1, null, 100, (short)MapTypeType.Act2),
                GenerateDropDto(2100, 1, null, 100, (short)MapTypeType.Act2),
                GenerateDropDto(2101, 1, null, 100, (short)MapTypeType.Act2),
                GenerateDropDto(2102, 1, null, 100, (short)MapTypeType.Act2),
                GenerateDropDto(2114, 1, null, 900, (short)MapTypeType.Act2),
                GenerateDropDto(2115, 1, null, 900, (short)MapTypeType.Act2),
                GenerateDropDto(2116, 1, null, 900, (short)MapTypeType.Act2),
                GenerateDropDto(2117, 1, null, 900, (short)MapTypeType.Act2),
                GenerateDropDto(2118, 1, null, 900, (short)MapTypeType.Act2),
                GenerateDropDto(2129, 1, null, 200, (short)MapTypeType.Act2),
                GenerateDropDto(2205, 1, null, 200, (short)MapTypeType.Act2),
                GenerateDropDto(2206, 1, null, 200, (short)MapTypeType.Act2),
                GenerateDropDto(2207, 1, null, 200, (short)MapTypeType.Act2),
                GenerateDropDto(2208, 1, null, 200, (short)MapTypeType.Act2),
                GenerateDropDto(2282, 1, null, 2500, (short)MapTypeType.Act2),
                GenerateDropDto(2283, 1, null, 1000, (short)MapTypeType.Act2),
                GenerateDropDto(2284, 1, null, 500, (short)MapTypeType.Act2),
                GenerateDropDto(2296, 1, null, 250, (short)MapTypeType.Act2),
                GenerateDropDto(5119, 1, null, 30, (short)MapTypeType.Act2),
                GenerateDropDto(5853, 1, null, 80, (short)MapTypeType.Oasis),
                GenerateDropDto(5854, 1, null, 80, (short)MapTypeType.Oasis),
                GenerateDropDto(5855, 1, null, 80, (short)MapTypeType.Oasis ),
 
                // Act3
                GenerateDropDto(1004, 1, null, 500, (short)MapTypeType.Act3),
                GenerateDropDto(1007, 1, null, 500, (short)MapTypeType.Act3),
                GenerateDropDto(1012, 1, null, 8000, (short)MapTypeType.Act3),
                GenerateDropDto(1086, 1, null, 100, (short)MapTypeType.Act3),
                GenerateDropDto(1078, 1, null, 500, (short)MapTypeType.Act3),
                GenerateDropDto(1114, 1, null, 100, (short)MapTypeType.Act3),
                GenerateDropDto(1235, 1, null, 150, (short)MapTypeType.Act3),
                GenerateDropDto(1237, 1, null, 150, (short)MapTypeType.Act3),
                GenerateDropDto(1238, 1, null, 30, (short)MapTypeType.Act3),
                GenerateDropDto(1239, 1, null, 150, (short)MapTypeType.Act3),
                GenerateDropDto(1240, 1, null, 30, (short)MapTypeType.Act3),
                GenerateDropDto(1241, 1, null, 400, (short)MapTypeType.Act3),
                GenerateDropDto(2098, 1, null, 100, (short)MapTypeType.Act3),
                GenerateDropDto(2099, 1, null, 100, (short)MapTypeType.Act3),
                GenerateDropDto(2100, 1, null, 100, (short)MapTypeType.Act3),
                GenerateDropDto(2101, 1, null, 100, (short)MapTypeType.Act3),
                GenerateDropDto(2102, 1, null, 100, (short)MapTypeType.Act3),
                GenerateDropDto(2114, 1, null, 800, (short)MapTypeType.Act3),
                GenerateDropDto(2115, 1, null, 800, (short)MapTypeType.Act3),
                GenerateDropDto(2116, 1, null, 800, (short)MapTypeType.Act3),
                GenerateDropDto(2117, 1, null, 800, (short)MapTypeType.Act3),
                GenerateDropDto(2118, 1, null, 800, (short)MapTypeType.Act3),
                GenerateDropDto(2129, 1, null, 100, (short)MapTypeType.Act3),
                GenerateDropDto(2205, 1, null, 300, (short)MapTypeType.Act3),
                GenerateDropDto(2206, 1, null, 300, (short)MapTypeType.Act3),
                GenerateDropDto(2207, 1, null, 300, (short)MapTypeType.Act3),
                GenerateDropDto(2208, 1, null, 300, (short)MapTypeType.Act3),
                GenerateDropDto(2282, 1, null, 4000, (short)MapTypeType.Act3),
                GenerateDropDto(2283, 1, null, 700, (short)MapTypeType.Act3),
                GenerateDropDto(2284, 1, null, 350, (short)MapTypeType.Act3),
                GenerateDropDto(2285, 1, null, 150, (short)MapTypeType.Act3),
                GenerateDropDto(2296, 1, null, 150, (short)MapTypeType.Act3),
                GenerateDropDto(5119, 1, null, 30, (short)MapTypeType.Act3),
                GenerateDropDto(5853, 1, null, 100, (short)MapTypeType.Act3),
                GenerateDropDto(5854, 1, null, 100, (short)MapTypeType.Act3),
                GenerateDropDto(5855, 1, null, 100, (short)MapTypeType.Act3 ),
 
                // Act3.2 (Midgard)
                GenerateDropDto(1004, 1, null, 500, (short)MapTypeType.Act32),
                GenerateDropDto(1007, 1, null, 500, (short)MapTypeType.Act32),
                GenerateDropDto(1012, 1, null, 6000, (short)MapTypeType.Act32),
                GenerateDropDto(1086, 1, null, 100, (short)MapTypeType.Act32),
                GenerateDropDto(1078, 1, null, 250, (short)MapTypeType.Act32),
                GenerateDropDto(1114, 1, null, 100, (short)MapTypeType.Act32),
                GenerateDropDto(1235, 1, null, 100, (short)MapTypeType.Act32),
                GenerateDropDto(1237, 1, null, 100, (short)MapTypeType.Act32),
                GenerateDropDto(1238, 1, null, 20, (short)MapTypeType.Act32),
                GenerateDropDto(1239, 1, null, 100, (short)MapTypeType.Act32),
                GenerateDropDto(1240, 1, null, 20, (short)MapTypeType.Act32),
                GenerateDropDto(1241, 1, null, 200, (short)MapTypeType.Act32),
                GenerateDropDto(2098, 1, null, 50, (short)MapTypeType.Act32),
                GenerateDropDto(2099, 1, null, 60, (short)MapTypeType.Act32),
                GenerateDropDto(2100, 1, null, 40, (short)MapTypeType.Act32),
                GenerateDropDto(2101, 1, null, 60, (short)MapTypeType.Act32),
                GenerateDropDto(2102, 1, null, 40, (short)MapTypeType.Act32),
                GenerateDropDto(2114, 1, null, 500, (short)MapTypeType.Act32),
                GenerateDropDto(2115, 1, null, 500, (short)MapTypeType.Act32),
                GenerateDropDto(2116, 1, null, 500, (short)MapTypeType.Act32),
                GenerateDropDto(2117, 1, null, 500, (short)MapTypeType.Act32),
                GenerateDropDto(2118, 1, null, 500, (short)MapTypeType.Act32),
                GenerateDropDto(2129, 1, null, 100, (short)MapTypeType.Act32),
                GenerateDropDto(2205, 1, null, 300, (short)MapTypeType.Act32),
                GenerateDropDto(2206, 1, null, 300, (short)MapTypeType.Act32),
                GenerateDropDto(2207, 1, null, 300, (short)MapTypeType.Act32),
                GenerateDropDto(2208, 1, null, 300, (short)MapTypeType.Act32),
                GenerateDropDto(2282, 1, null, 3500, (short)MapTypeType.Act32),
                GenerateDropDto(2283, 1, null, 500, (short)MapTypeType.Act32),
                GenerateDropDto(2284, 1, null, 200, (short)MapTypeType.Act32),
                GenerateDropDto(2285, 1, null, 100, (short)MapTypeType.Act32),
                GenerateDropDto(2296, 1, null, 100, (short)MapTypeType.Act32),
                GenerateDropDto(2600, 1, null, 200, (short)MapTypeType.Act32),
                GenerateDropDto(2605, 1, null, 200, (short)MapTypeType.Act32),
                GenerateDropDto(5119, 1, null, 30, (short)MapTypeType.Act32),
                GenerateDropDto(5857, 1, null, 50, (short)MapTypeType.Act32),
                GenerateDropDto(5853, 1, null, 50, (short)MapTypeType.Act32),
                GenerateDropDto(5854, 1, null, 50, (short)MapTypeType.Act32),
                GenerateDropDto(5855, 1, null, 100, (short)MapTypeType.Act32),
 
                // Act 3.4 Oasis
                GenerateDropDto(1004, 1, null, 300, (short)MapTypeType.Oasis),
                GenerateDropDto(1007, 1, null, 300, (short)MapTypeType.Oasis),
                GenerateDropDto(1012, 1, null, 7000, (short)MapTypeType.Oasis),
                GenerateDropDto(1086, 1, null, 100, (short)MapTypeType.Oasis),
                GenerateDropDto(1078, 1, null, 500, (short)MapTypeType.Oasis),
                GenerateDropDto(1114, 1, null, 100, (short)MapTypeType.Oasis),
                GenerateDropDto(1235, 1, null, 100, (short)MapTypeType.Oasis),
                GenerateDropDto(1237, 1, null, 150, (short)MapTypeType.Oasis),
                GenerateDropDto(1238, 1, null, 30, (short)MapTypeType.Oasis),
                GenerateDropDto(1239, 1, null, 100, (short)MapTypeType.Oasis),
                GenerateDropDto(1240, 1, null, 30, (short)MapTypeType.Oasis),
                GenerateDropDto(1241, 1, null, 400, (short)MapTypeType.Oasis),
                GenerateDropDto(2098, 1, null, 100, (short)MapTypeType.Oasis),
                GenerateDropDto(2099, 1, null, 100, (short)MapTypeType.Oasis),
                GenerateDropDto(2100, 1, null, 100, (short)MapTypeType.Oasis),
                GenerateDropDto(2101, 1, null, 100, (short)MapTypeType.Oasis),
                GenerateDropDto(2102, 1, null, 100, (short)MapTypeType.Oasis),
                GenerateDropDto(2114, 1, null, 800, (short)MapTypeType.Oasis),
                GenerateDropDto(2115, 1, null, 800, (short)MapTypeType.Oasis),
                GenerateDropDto(2116, 1, null, 800, (short)MapTypeType.Oasis),
                GenerateDropDto(2117, 1, null, 800, (short)MapTypeType.Oasis),
                GenerateDropDto(2118, 1, null, 800, (short)MapTypeType.Oasis),
                GenerateDropDto(2129, 1, null, 100, (short)MapTypeType.Oasis),
                GenerateDropDto(2205, 1, null, 300, (short)MapTypeType.Oasis),
                GenerateDropDto(2206, 1, null, 300, (short)MapTypeType.Oasis),
                GenerateDropDto(2207, 1, null, 300, (short)MapTypeType.Oasis),
                GenerateDropDto(2208, 1, null, 300, (short)MapTypeType.Oasis),
                GenerateDropDto(2282, 1, null, 3000, (short)MapTypeType.Oasis),
                GenerateDropDto(2283, 1, null, 700, (short)MapTypeType.Oasis),
                GenerateDropDto(2284, 1, null, 300, (short)MapTypeType.Oasis),
                GenerateDropDto(2285, 1, null, 100, (short)MapTypeType.Oasis),
                GenerateDropDto(2296, 1, null, 100, (short)MapTypeType.Oasis),
                GenerateDropDto(5119, 1, null, 30, (short)MapTypeType.Oasis),
                GenerateDropDto(5853, 1, null, 100, (short)MapTypeType.Oasis),
                GenerateDropDto(5854, 1, null, 100, (short)MapTypeType.Oasis),
                GenerateDropDto(5855, 1, null, 100, (short)MapTypeType.Oasis),
                GenerateDropDto(5999, 1, null, 100, (short)MapTypeType.Oasis ),
 
                // Act4
                GenerateDropDto(1004, 1, null, 1000, (short)MapTypeType.Act4),
                GenerateDropDto(1007, 1, null, 1000, (short)MapTypeType.Act4),
                GenerateDropDto(1010, 3, null, 1500, (short)MapTypeType.Act4),
                GenerateDropDto(1012, 2, null, 3000, (short)MapTypeType.Act4),
                GenerateDropDto(1241, 3, null, 3000, (short)MapTypeType.Act4),
                GenerateDropDto(1078, 3, null, 1500, (short)MapTypeType.Act4),
                GenerateDropDto(1246, 1, null, 2500, (short)MapTypeType.Act4),
                GenerateDropDto(1247, 1, null, 2500, (short)MapTypeType.Act4),
                GenerateDropDto(1248, 1, null, 2500, (short)MapTypeType.Act4),
                GenerateDropDto(1429, 1, null, 2500, (short)MapTypeType.Act4),
                GenerateDropDto(2296, 1, null, 1000, (short)MapTypeType.Act4),
                GenerateDropDto(2307, 1, null, 1500, (short)MapTypeType.Act4),
                GenerateDropDto(2308, 1, null, 1500, (short)MapTypeType.Act4),
 
                //Act4.2
                GenerateDropDto(1004, 1, null, 1000, (short)MapTypeType.Act42),
                GenerateDropDto(1007, 1, null, 1000, (short)MapTypeType.Act42),
                GenerateDropDto(1010, 3, null, 1500, (short)MapTypeType.Act42),
                GenerateDropDto(1012, 2, null, 3000, (short)MapTypeType.Act42),
                GenerateDropDto(1241, 3, null, 3000, (short)MapTypeType.Act42),
                GenerateDropDto(1078, 3, null, 1500, (short)MapTypeType.Act42),
                GenerateDropDto(1246, 1, null, 2500, (short)MapTypeType.Act42),
                GenerateDropDto(1247, 1, null, 2500, (short)MapTypeType.Act42),
                GenerateDropDto(1248, 1, null, 2500, (short)MapTypeType.Act42),
                GenerateDropDto(1429, 1, null, 2500, (short)MapTypeType.Act42),
                GenerateDropDto(2296, 1, null, 1000, (short)MapTypeType.Act42),
                GenerateDropDto(2307, 1, null, 1500, (short)MapTypeType.Act42),
                GenerateDropDto(2308, 1, null, 1500, (short)MapTypeType.Act42),
                GenerateDropDto(2445, 1, null, 700, (short)MapTypeType.Act42),
                GenerateDropDto(2448, 1, null, 700, (short)MapTypeType.Act42),
                GenerateDropDto(2449, 1, null, 700, (short)MapTypeType.Act42),
                GenerateDropDto(2450, 1, null, 700, (short)MapTypeType.Act42),
                GenerateDropDto(2451, 1, null, 700, (short)MapTypeType.Act42),
                GenerateDropDto(5986, 1, null, 700, (short)MapTypeType.Act42 ),
 
                // Act5
                GenerateDropDto(1004, 1, null, 400, (short)MapTypeType.Act51),
                GenerateDropDto(1007, 1, null, 400, (short)MapTypeType.Act51),
                GenerateDropDto(1012, 1, null, 6000, (short)MapTypeType.Act51),
                GenerateDropDto(1086, 1, null, 200, (short)MapTypeType.Act51),
                GenerateDropDto(1114, 1, null, 150, (short)MapTypeType.Act51),
                GenerateDropDto(1872, 1, null, 500, (short)MapTypeType.Act51),
                GenerateDropDto(1873, 1, null, 500, (short)MapTypeType.Act51),
                GenerateDropDto(1874, 1, null, 500, (short)MapTypeType.Act51),
                GenerateDropDto(2099, 1, null, 700, (short)MapTypeType.Act51),
                GenerateDropDto(2102, 1, null, 700, (short)MapTypeType.Act51),
                GenerateDropDto(2114, 1, null, 700, (short)MapTypeType.Act51),
                GenerateDropDto(2115, 1, null, 700, (short)MapTypeType.Act51),
                GenerateDropDto(2116, 1, null, 700, (short)MapTypeType.Act51),
                GenerateDropDto(2117, 1, null, 700, (short)MapTypeType.Act51),
                GenerateDropDto(2129, 1, null, 300, (short)MapTypeType.Act51),
                GenerateDropDto(2206, 1, null, 500, (short)MapTypeType.Act51),
                GenerateDropDto(2207, 1, null, 500, (short)MapTypeType.Act51),
                GenerateDropDto(2282, 1, null, 2500, (short)MapTypeType.Act51),
                GenerateDropDto(2283, 1, null, 800, (short)MapTypeType.Act51),
                GenerateDropDto(2284, 1, null, 400, (short)MapTypeType.Act51),
                GenerateDropDto(2285, 1, null, 200, (short)MapTypeType.Act51),
                GenerateDropDto(2351, 1, null, 800, (short)MapTypeType.Act51),
                GenerateDropDto(2379, 1, null, 1000, (short)MapTypeType.Act51),
                GenerateDropDto(5119, 1, null, 30, (short)MapTypeType.Act51),
                GenerateDropDto(5853, 1, null, 100, (short)MapTypeType.Act51),
                GenerateDropDto(5854, 1, null, 100, (short)MapTypeType.Act51),
                GenerateDropDto(5855, 1, null, 100, (short)MapTypeType.Act51 ),
 
                // Act5.2
                GenerateDropDto(1004, 1, null, 600, (short)MapTypeType.Act52),
                GenerateDropDto(1007, 1, null, 600, (short)MapTypeType.Act52),
                GenerateDropDto(1012, 1, null, 5000, (short)MapTypeType.Act52),
                GenerateDropDto(1086, 1, null, 400, (short)MapTypeType.Act52),
                GenerateDropDto(1092, 1, null, 1200, (short)MapTypeType.Act52),
                GenerateDropDto(1093, 1, null, 1500, (short)MapTypeType.Act52),
                GenerateDropDto(1094, 1, null, 1200, (short)MapTypeType.Act52),
                GenerateDropDto(1114, 1, null, 100, (short)MapTypeType.Act52),
                GenerateDropDto(2098, 1, null, 1500, (short)MapTypeType.Act52),
                GenerateDropDto(2099, 1, null, 1200, (short)MapTypeType.Act52),
                GenerateDropDto(2102, 1, null, 1200, (short)MapTypeType.Act52),
                GenerateDropDto(2114, 1, null, 1200, (short)MapTypeType.Act52),
                GenerateDropDto(2115, 1, null, 1200, (short)MapTypeType.Act52),
                GenerateDropDto(2116, 1, null, 1200, (short)MapTypeType.Act52),
                GenerateDropDto(2117, 1, null, 1200, (short)MapTypeType.Act52),
                GenerateDropDto(2206, 1, null, 1200, (short)MapTypeType.Act52),
                GenerateDropDto(2379, 1, null, 3000, (short)MapTypeType.Act52),
                GenerateDropDto(2380, 1, null, 6000, (short)MapTypeType.Act52),
                GenerateDropDto(5119, 1, null, 100, (short)MapTypeType.Act52 ),
 
                // Act6.1 Angel
                GenerateDropDto(1004, 1, null, 600, (short)MapTypeType.Act61A),
                GenerateDropDto(1007, 1, null, 600, (short)MapTypeType.Act61A),
                GenerateDropDto(1010, 1, null, 400, (short)MapTypeType.Act61A),
                GenerateDropDto(1012, 1, null, 5000, (short)MapTypeType.Act61A),
                GenerateDropDto(1028, 1, null, 400, (short)MapTypeType.Act61A),
                GenerateDropDto(1078, 1, null, 400, (short)MapTypeType.Act61A),
                GenerateDropDto(1086, 1, null, 400, (short)MapTypeType.Act61A),
                GenerateDropDto(1092, 1, null, 500, (short)MapTypeType.Act61A),
                GenerateDropDto(1093, 1, null, 600, (short)MapTypeType.Act61A),
                GenerateDropDto(1094, 1, null, 600, (short)MapTypeType.Act61A),
                GenerateDropDto(1114, 1, null, 100, (short)MapTypeType.Act61A),
                GenerateDropDto(2098, 1, null, 400, (short)MapTypeType.Act61A),
                GenerateDropDto(2099, 1, null, 600, (short)MapTypeType.Act61A),
                GenerateDropDto(2102, 1, null, 600, (short)MapTypeType.Act61A),
                GenerateDropDto(2114, 1, null, 600, (short)MapTypeType.Act61A),
                GenerateDropDto(2115, 1, null, 600, (short)MapTypeType.Act61A),
                GenerateDropDto(2116, 1, null, 600, (short)MapTypeType.Act61A),
                GenerateDropDto(2117, 1, null, 600, (short)MapTypeType.Act61A),
                GenerateDropDto(2129, 1, null, 400, (short)MapTypeType.Act61A),
                GenerateDropDto(2206, 1, null, 400, (short)MapTypeType.Act61A),
                GenerateDropDto(2282, 1, null, 2000, (short)MapTypeType.Act61A),
                GenerateDropDto(2283, 1, null, 400, (short)MapTypeType.Act61A),
                GenerateDropDto(2284, 1, null, 200, (short)MapTypeType.Act61A),
                GenerateDropDto(2285, 1, null, 100, (short)MapTypeType.Act61A),
                GenerateDropDto(2446, 1, null, 100, (short)MapTypeType.Act61A),
                GenerateDropDto(2806, 1, null, 300, (short)MapTypeType.Act61A),
                GenerateDropDto(2807, 1, null, 300, (short)MapTypeType.Act61A),
                GenerateDropDto(2813, 1, null, 150, (short)MapTypeType.Act61A),
                GenerateDropDto(2815, 1, null, 200, (short)MapTypeType.Act61A),
                GenerateDropDto(2816, 1, null, 200, (short)MapTypeType.Act61A),
                GenerateDropDto(2818, 1, null, 200, (short)MapTypeType.Act61A),
                GenerateDropDto(2819, 1, null, 200, (short)MapTypeType.Act61A),
                GenerateDropDto(5119, 1, null, 50, (short)MapTypeType.Act61A),
                GenerateDropDto(5853, 1, null, 50, (short)MapTypeType.Act61A),
                GenerateDropDto(5854, 1, null, 50, (short)MapTypeType.Act61A),
                GenerateDropDto(5855, 1, null, 50, (short)MapTypeType.Act61A),
                GenerateDropDto(5880, 1, null, 100, (short)MapTypeType.Act61A),
 
                // Act6.1 Demon
                GenerateDropDto(1004, 1, null, 600, (short)MapTypeType.Act61D),
                GenerateDropDto(1007, 1, null, 600, (short)MapTypeType.Act61D),
                GenerateDropDto(1010, 1, null, 400, (short)MapTypeType.Act61D),
                GenerateDropDto(1012, 1, null, 5000, (short)MapTypeType.Act61D),
                GenerateDropDto(1028, 1, null, 400, (short)MapTypeType.Act61D),
                GenerateDropDto(1078, 1, null, 400, (short)MapTypeType.Act61D),
                GenerateDropDto(1086, 1, null, 400, (short)MapTypeType.Act61D),
                GenerateDropDto(1092, 1, null, 500, (short)MapTypeType.Act61D),
                GenerateDropDto(1093, 1, null, 600, (short)MapTypeType.Act61D),
                GenerateDropDto(1094, 1, null, 600, (short)MapTypeType.Act61D),
                GenerateDropDto(1114, 1, null, 100, (short)MapTypeType.Act61D),
                GenerateDropDto(2098, 1, null, 500, (short)MapTypeType.Act61D),
                GenerateDropDto(2099, 1, null, 600, (short)MapTypeType.Act61D),
                GenerateDropDto(2102, 1, null, 600, (short)MapTypeType.Act61D),
                GenerateDropDto(2114, 1, null, 600, (short)MapTypeType.Act61D),
                GenerateDropDto(2115, 1, null, 800, (short)MapTypeType.Act61D),
                GenerateDropDto(2116, 1, null, 600, (short)MapTypeType.Act61D),
                GenerateDropDto(2117, 1, null, 600, (short)MapTypeType.Act61D),
                GenerateDropDto(2129, 1, null, 400, (short)MapTypeType.Act61D),
                GenerateDropDto(2206, 1, null, 500, (short)MapTypeType.Act61D),
                GenerateDropDto(2282, 1, null, 2000, (short)MapTypeType.Act61D),
                GenerateDropDto(2283, 1, null, 400, (short)MapTypeType.Act61D),
                GenerateDropDto(2284, 1, null, 200, (short)MapTypeType.Act61D),
                GenerateDropDto(2285, 1, null, 100, (short)MapTypeType.Act61D),
                GenerateDropDto(2446, 1, null, 150, (short)MapTypeType.Act61D),
                GenerateDropDto(2806, 1, null, 200, (short)MapTypeType.Act61D),
                GenerateDropDto(2807, 1, null, 200, (short)MapTypeType.Act61D),
                GenerateDropDto(2813, 1, null, 150, (short)MapTypeType.Act61D),
                GenerateDropDto(2815, 1, null, 200, (short)MapTypeType.Act61D),
                GenerateDropDto(2816, 1, null, 200, (short)MapTypeType.Act61D),
                GenerateDropDto(2818, 1, null, 200, (short)MapTypeType.Act61D),
                GenerateDropDto(2819, 1, null, 200, (short)MapTypeType.Act61D),
                GenerateDropDto(5119, 1, null, 100, (short)MapTypeType.Act61D),
                GenerateDropDto(5853, 1, null, 50, (short)MapTypeType.Act61D),
                GenerateDropDto(5854, 1, null, 50, (short)MapTypeType.Act61D),
                GenerateDropDto(5855, 1, null, 50, (short)MapTypeType.Act61D),
                GenerateDropDto(5881, 1, null, 100, (short)MapTypeType.Act61D ),
 
                // Act6.2 
                GenerateDropDto(1004, 1, null, 600, (short)MapTypeType.Act62),
                GenerateDropDto(1007, 1, null, 600, (short)MapTypeType.Act62),
                GenerateDropDto(1010, 1, null, 400, (short)MapTypeType.Act61),
                GenerateDropDto(1010, 1, null, 400, (short)MapTypeType.Act62),
                GenerateDropDto(1012, 1, null, 6000, (short)MapTypeType.Act62),
                GenerateDropDto(1028, 1, null, 400, (short)MapTypeType.Act62),
                GenerateDropDto(1078, 1, null, 700, (short)MapTypeType.Act62),
                GenerateDropDto(1086, 1, null, 400, (short)MapTypeType.Act62),
                GenerateDropDto(1092, 1, null, 500, (short)MapTypeType.Act62),
                GenerateDropDto(1093, 1, null, 600, (short)MapTypeType.Act62),
                GenerateDropDto(1094, 1, null, 600, (short)MapTypeType.Act62),
                GenerateDropDto(1114, 1, null, 100, (short)MapTypeType.Act62),
                GenerateDropDto(1191, 1, null, 100, (short)MapTypeType.Act62),
                GenerateDropDto(1192, 1, null, 100, (short)MapTypeType.Act62),
                GenerateDropDto(1193, 1, null, 100, (short)MapTypeType.Act62),
                GenerateDropDto(1194, 1, null, 100, (short)MapTypeType.Act62),
                GenerateDropDto(2098, 1, null, 500, (short)MapTypeType.Act62),
                GenerateDropDto(2099, 1, null, 600, (short)MapTypeType.Act62),
                GenerateDropDto(2102, 1, null, 500, (short)MapTypeType.Act62),
                GenerateDropDto(2114, 1, null, 400, (short)MapTypeType.Act62),
                GenerateDropDto(2115, 1, null, 600, (short)MapTypeType.Act62),
                GenerateDropDto(2116, 1, null, 500, (short)MapTypeType.Act62),
                GenerateDropDto(2117, 1, null, 600, (short)MapTypeType.Act62),
                GenerateDropDto(2129, 1, null, 400, (short)MapTypeType.Act62),
                GenerateDropDto(2206, 1, null, 500, (short)MapTypeType.Act62),
                GenerateDropDto(2452, 1, null, 100, (short)MapTypeType.Act62),
                GenerateDropDto(2453, 1, null, 100, (short)MapTypeType.Act62),
                GenerateDropDto(2454, 1, null, 100, (short)MapTypeType.Act62),
                GenerateDropDto(2455, 1, null, 100, (short)MapTypeType.Act62),
                GenerateDropDto(2456, 1, null, 100, (short)MapTypeType.Act62),
                GenerateDropDto(5119, 1, null, 50, (short)MapTypeType.Act62),
                GenerateDropDto(5853, 1, null, 50, (short)MapTypeType.Act62),
                GenerateDropDto(5854, 1, null, 50, (short)MapTypeType.Act62),
                GenerateDropDto(5855, 1, null, 100, (short)MapTypeType.Act62),
 
                // Comet plain 
                GenerateDropDto(1004, 1, null, 300, (short)MapTypeType.CometPlain),
                GenerateDropDto(1007, 1, null, 300, (short)MapTypeType.CometPlain),
                GenerateDropDto(1012, 1, null, 7000, (short)MapTypeType.CometPlain),
                GenerateDropDto(1114, 1, null, 100, (short)MapTypeType.CometPlain),
                GenerateDropDto(2098, 1, null, 200, (short)MapTypeType.CometPlain),
                GenerateDropDto(2099, 1, null, 200, (short)MapTypeType.CometPlain),
                GenerateDropDto(2100, 1, null, 200, (short)MapTypeType.CometPlain),
                GenerateDropDto(2101, 1, null, 200, (short)MapTypeType.CometPlain),
                GenerateDropDto(2102, 1, null, 200, (short)MapTypeType.CometPlain),
                GenerateDropDto(2114, 1, null, 1200, (short)MapTypeType.CometPlain),
                GenerateDropDto(2115, 1, null, 1200, (short)MapTypeType.CometPlain),
                GenerateDropDto(2116, 1, null, 1200, (short)MapTypeType.CometPlain),
                GenerateDropDto(2117, 1, null, 1200, (short)MapTypeType.CometPlain),
                GenerateDropDto(2205, 1, null, 300, (short)MapTypeType.CometPlain),
                GenerateDropDto(2206, 1, null, 300, (short)MapTypeType.CometPlain),
                GenerateDropDto(2207, 1, null, 300, (short)MapTypeType.CometPlain),
                GenerateDropDto(2208, 1, null, 300, (short)MapTypeType.CometPlain),
                GenerateDropDto(2296, 1, null, 300, (short)MapTypeType.CometPlain),
                GenerateDropDto(5119, 1, null, 30, (short)MapTypeType.CometPlain),
 
                // Mine1
                GenerateDropDto(1002, 1, null, 500, (short)MapTypeType.Mine1),
                GenerateDropDto(1005, 1, null, 500, (short)MapTypeType.Mine1),
                GenerateDropDto(1012, 1, null, 11000, (short)MapTypeType.Mine1 ),
 
                // Mine2
                GenerateDropDto(1002, 1, null, 500, (short)MapTypeType.Mine2),
                GenerateDropDto(1005, 1, null, 500, (short)MapTypeType.Mine2),
                GenerateDropDto(1012, 1, null, 11000, (short)MapTypeType.Mine2),
                GenerateDropDto(1241, 1, null, 200, (short)MapTypeType.Mine2),
                GenerateDropDto(2099, 1, null, 100, (short)MapTypeType.Mine2),
                GenerateDropDto(2100, 1, null, 100, (short)MapTypeType.Mine2),
                GenerateDropDto(2101, 1, null, 100, (short)MapTypeType.Mine2),
                GenerateDropDto(2102, 1, null, 100, (short)MapTypeType.Mine2),
                GenerateDropDto(2115, 1, null, 600, (short)MapTypeType.Mine2),
                GenerateDropDto(2116, 1, null, 600, (short)MapTypeType.Mine2),
                GenerateDropDto(2205, 1, null, 300, (short)MapTypeType.Mine2 ),
 
                // MeadownOfMine
                GenerateDropDto(1002, 1, null, 400, (short)MapTypeType.MeadowOfMine),
                GenerateDropDto(1005, 1, null, 400, (short)MapTypeType.MeadowOfMine),
                GenerateDropDto(1012, 1, null, 10000, (short)MapTypeType.MeadowOfMine),
                GenerateDropDto(2016, 1, null, 400, (short)MapTypeType.MeadowOfMine),
                GenerateDropDto(2023, 1, null, 300, (short)MapTypeType.MeadowOfMine),
                GenerateDropDto(2024, 1, null, 300, (short)MapTypeType.MeadowOfMine),
                GenerateDropDto(2028, 1, null, 100, (short)MapTypeType.MeadowOfMine),
                GenerateDropDto(2116, 1, null, 200, (short)MapTypeType.MeadowOfMine),
                GenerateDropDto(2118, 1, null, 200, (short)MapTypeType.MeadowOfMine),
 
                // SunnyPlain
                GenerateDropDto(1003, 1, null, 300, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(1006, 1, null, 300, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(1012, 1, null, 8000, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(1078, 1, null, 100, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(1092, 1, null, 200, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(1093, 1, null, 200, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(1094, 1, null, 200, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(2098, 1, null, 200, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(2099, 1, null, 200, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(2100, 1, null, 200, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(2101, 1, null, 200, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(2102, 1, null, 200, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(2114, 1, null, 200, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(2115, 1, null, 300, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(2116, 1, null, 300, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(2118, 1, null, 300, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(2205, 1, null, 300, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(2206, 1, null, 300, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(2207, 1, null, 300, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(2208, 1, null, 300, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(2296, 1, null, 300, (short)MapTypeType.SunnyPlain),
                GenerateDropDto(5119, 1, null, 30, (short)MapTypeType.SunnyPlain ),
 
                // Fernon
                GenerateDropDto(1003, 1, null, 500, (short)MapTypeType.Fernon),
                GenerateDropDto(1006, 1, null, 500, (short)MapTypeType.Fernon),
                GenerateDropDto(1012, 1, null, 9000, (short)MapTypeType.Fernon),
                GenerateDropDto(1114, 1, null, 200, (short)MapTypeType.Fernon),
                GenerateDropDto(1092, 1, null, 300, (short)MapTypeType.Fernon),
                GenerateDropDto(1093, 1, null, 300, (short)MapTypeType.Fernon),
                GenerateDropDto(1094, 1, null, 300, (short)MapTypeType.Fernon),
                GenerateDropDto(2098, 1, null, 300, (short)MapTypeType.Fernon),
                GenerateDropDto(2099, 1, null, 300, (short)MapTypeType.Fernon),
                GenerateDropDto(2100, 1, null, 300, (short)MapTypeType.Fernon),
                GenerateDropDto(2101, 1, null, 400, (short)MapTypeType.Fernon),
                GenerateDropDto(2102, 1, null, 300, (short)MapTypeType.Fernon),
                GenerateDropDto(2114, 1, null, 500, (short)MapTypeType.Fernon),
                GenerateDropDto(2115, 1, null, 500, (short)MapTypeType.Fernon),
                GenerateDropDto(2116, 1, null, 500, (short)MapTypeType.Fernon),
                GenerateDropDto(2117, 1, null, 500, (short)MapTypeType.Fernon),
                GenerateDropDto(2296, 1, null, 400, (short)MapTypeType.Fernon),
                GenerateDropDto(5119, 1, null, 30, (short)MapTypeType.Fernon),
 
                // FernonF 
                GenerateDropDto(1004, 1, null, 600, (short)MapTypeType.FernonF),
                GenerateDropDto(1007, 1, null, 600, (short)MapTypeType.FernonF),
                GenerateDropDto(1012, 1, null, 9000, (short)MapTypeType.FernonF),
                GenerateDropDto(1078, 1, null, 200, (short)MapTypeType.FernonF),
                GenerateDropDto(1114, 1, null, 200, (short)MapTypeType.FernonF),
                GenerateDropDto(1092, 1, null, 500, (short)MapTypeType.FernonF),
                GenerateDropDto(1093, 1, null, 500, (short)MapTypeType.FernonF),
                GenerateDropDto(1094, 1, null, 500, (short)MapTypeType.FernonF),
                GenerateDropDto(2098, 1, null, 200, (short)MapTypeType.FernonF),
                GenerateDropDto(2099, 1, null, 200, (short)MapTypeType.FernonF),
                GenerateDropDto(2100, 1, null, 200, (short)MapTypeType.FernonF),
                GenerateDropDto(2101, 1, null, 200, (short)MapTypeType.FernonF),
                GenerateDropDto(2102, 1, null, 200, (short)MapTypeType.FernonF),
                GenerateDropDto(2114, 1, null, 700, (short)MapTypeType.FernonF),
                GenerateDropDto(2115, 1, null, 700, (short)MapTypeType.FernonF),
                GenerateDropDto(2116, 1, null, 700, (short)MapTypeType.FernonF),
                GenerateDropDto(2117, 1, null, 700, (short)MapTypeType.FernonF),
                GenerateDropDto(2205, 1, null, 300, (short)MapTypeType.FernonF),
                GenerateDropDto(2206, 1, null, 300, (short)MapTypeType.FernonF),
                GenerateDropDto(2207, 1, null, 300, (short)MapTypeType.FernonF),
                GenerateDropDto(2208, 1, null, 300, (short)MapTypeType.FernonF),
                GenerateDropDto(2296, 1, null, 300, (short)MapTypeType.FernonF),
                GenerateDropDto(5119, 1, null, 30, (short)MapTypeType.FernonF),
 
                // Cliff
                GenerateDropDto(1012, 1, null, 8000, (short)MapTypeType.Cliff),
                GenerateDropDto(2098, 1, null, 400, (short)MapTypeType.Cliff),
                GenerateDropDto(2099, 1, null, 400, (short)MapTypeType.Cliff),
                GenerateDropDto(2100, 1, null, 400, (short)MapTypeType.Cliff),
                GenerateDropDto(2101, 1, null, 400, (short)MapTypeType.Cliff),
                GenerateDropDto(2102, 1, null, 400, (short)MapTypeType.Cliff),
                GenerateDropDto(2296, 1, null, 400, (short)MapTypeType.Cliff),
                GenerateDropDto(5119, 1, null, 30, (short)MapTypeType.Cliff ),
 
                // LandOfTheDead
                GenerateDropDto(1007, 1, null, 800, (short)MapTypeType.LandOfTheDead),
                GenerateDropDto(1010, 1, null, 800, (short)MapTypeType.LandOfTheDead),
                GenerateDropDto(1012, 1, null, 8000, (short)MapTypeType.LandOfTheDead),
                GenerateDropDto(1015, 1, null, 600, (short)MapTypeType.LandOfTheDead),
                GenerateDropDto(1016, 1, null, 600, (short)MapTypeType.LandOfTheDead),
                GenerateDropDto(1078, 1, null, 400, (short)MapTypeType.LandOfTheDead),
                GenerateDropDto(1114, 1, null, 400, (short)MapTypeType.LandOfTheDead),
                GenerateDropDto(1019, 1, null, 2000, (short)MapTypeType.LandOfTheDead),
                GenerateDropDto(1020, 1, null, 1200, (short)MapTypeType.LandOfTheDead),
                GenerateDropDto(1021, 1, null, 600, (short)MapTypeType.LandOfTheDead),
                GenerateDropDto(1022, 1, null, 300, (short)MapTypeType.LandOfTheDead),
                GenerateDropDto(1211, 1, null, 250, (short)MapTypeType.LandOfTheDead),
                GenerateDropDto(5119, 1, null, 100, (short)MapTypeType.LandOfTheDead )
            };
            IEnumerable<DropDto> dropDtos = drops;
            return _dropDao.TryInsertOrUpdateAsync(dropDtos);
        }
    }
}