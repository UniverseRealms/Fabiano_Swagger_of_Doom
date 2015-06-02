﻿/*
    Copyright (C) 2015 creepylava

    This file is part of RotMG Dungeon Generator.

    RotMG Dungeon Generator is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.

*/

using RotMG.Common;
using System;
using wServer.generator.dungeon;

namespace wServer.generator.templates
{
    public abstract class DungeonTemplate
    {
        protected Random Rand { get; private set; }

        internal void SetRandom(Random rand)
        {
            Rand = rand;
        }

        public abstract int MaxDepth { get; }

        public abstract NormDist TargetDepth { get; }

        public abstract NormDist SpecialRmCount { get; }

        public abstract NormDist SpecialRmDepthDist { get; }

        public abstract int CorridorWidth { get; }

        public abstract Range RoomSeparation { get; }

        public virtual void Initialize()
        {
        }

        public abstract Room CreateStart(int depth);

        public abstract Room CreateTarget(int depth, Room prev);

        public abstract Room CreateSpecial(int depth, Room prev);

        public abstract Room CreateNormal(int depth, Room prev);

        public virtual void InitializeRasterization(DungeonGraph graph)
        {
        }

        public virtual MapBackground CreateBackground()
        {
            return new MapBackground();
        }

        public virtual MapOverlay CreateOverlay()
        {
            return new MapOverlay();
        }

        public virtual MapCorridor CreateCorridor()
        {
            return new MapCorridor();
        }
    }
}