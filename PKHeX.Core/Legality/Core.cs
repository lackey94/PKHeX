﻿using System;
using System.Collections.Generic;
using System.Linq;
using static PKHeX.Core.Encounters1;
using static PKHeX.Core.Encounters2;
using static PKHeX.Core.Encounters3;
using static PKHeX.Core.Encounters4;
using static PKHeX.Core.Encounters5;
using static PKHeX.Core.Encounters6;
using static PKHeX.Core.Encounters7;
using static PKHeX.Core.LegalityCheckStrings;

namespace PKHeX.Core
{
    public static partial class Legal
    {
        /// <summary>Setting to specify if an analysis should permit data sourced from the physical cartridge era of GameBoy games.</summary>
        public static bool AllowGBCartEra { get; set; }
        public static bool AllowGen1Tradeback { get; set; }
        public static bool AllowGen2Crystal(bool Korean) => !Korean; // Pokemon Crystal was never released in Korea
        public static bool AllowGen2Crystal(PKM pkm) => AllowGen2Crystal(pkm.Korean);
        public static bool AllowGen2MoveReminder(PKM pkm) => !pkm.Korean && AllowGBCartEra; // Pokemon Stadium 2 was never released in Korea

        public static bool CheckWordFilter { get; set; } = true;

        /// <summary> e-Reader Berry originates from a Japanese SaveFile </summary>
        public static bool SavegameJapanese => ActiveTrainer.Language == 1;
        /// <summary> e-Reader Berry is Enigma or special berry </summary>
        public static bool EReaderBerryIsEnigma { get; set; } = true;
        /// <summary> e-Reader Berry Name </summary>
        public static string EReaderBerryName { get; set; } = string.Empty;
        /// <summary> e-Reader Berry Name formatted in Title Case </summary>
        public static string EReaderBerryDisplayName => string.Format(V372, Util.ToTitleCase(EReaderBerryName.ToLower()));

        public static ITrainerInfo ActiveTrainer = new SimpleTrainerInfo {OT = string.Empty, Game = (int)GameVersion.Any, Language = -1};
        public static int SavegameLanguage => ActiveTrainer.Language;
        private static string Savegame_OT => ActiveTrainer.OT;
        private static int Savegame_TID => ActiveTrainer.TID;
        private static int Savegame_SID => ActiveTrainer.SID;
        private static int Savegame_Gender => ActiveTrainer.Gender;
        private static GameVersion Savegame_Version => (GameVersion)ActiveTrainer.Game;

        // Gen 1
        internal static readonly Learnset[] LevelUpRB = Learnset1.GetArray(Util.GetBinaryResource("lvlmove_rb.pkl"), MaxSpeciesID_1);
        internal static readonly Learnset[] LevelUpY = Learnset1.GetArray(Util.GetBinaryResource("lvlmove_y.pkl"), MaxSpeciesID_1);

        // Gen 2
        internal static readonly EggMoves[] EggMovesGS = EggMoves2.GetArray(Util.GetBinaryResource("eggmove_gs.pkl"), MaxSpeciesID_2);
        internal static readonly Learnset[] LevelUpGS = Learnset1.GetArray(Util.GetBinaryResource("lvlmove_gs.pkl"), MaxSpeciesID_2);
        internal static readonly EggMoves[] EggMovesC = EggMoves2.GetArray(Util.GetBinaryResource("eggmove_c.pkl"), MaxSpeciesID_2);
        internal static readonly Learnset[] LevelUpC = Learnset1.GetArray(Util.GetBinaryResource("lvlmove_c.pkl"), MaxSpeciesID_2);

        // Gen 3
        internal static readonly Learnset[] LevelUpE = Learnset6.GetArray(Data.UnpackMini(Util.GetBinaryResource("lvlmove_e.pkl"), "em"));
        internal static readonly Learnset[] LevelUpRS = Learnset6.GetArray(Data.UnpackMini(Util.GetBinaryResource("lvlmove_rs.pkl"), "rs"));
        internal static readonly Learnset[] LevelUpFR = Learnset6.GetArray(Data.UnpackMini(Util.GetBinaryResource("lvlmove_fr.pkl"), "fr"));
        internal static readonly Learnset[] LevelUpLG = Learnset6.GetArray(Data.UnpackMini(Util.GetBinaryResource("lvlmove_lg.pkl"), "lg"));
        internal static readonly EggMoves[] EggMovesRS = EggMoves6.GetArray(Data.UnpackMini(Util.GetBinaryResource("eggmove_rs.pkl"), "rs"));

        // Gen 4
        internal static readonly Learnset[] LevelUpDP = Learnset6.GetArray(Data.UnpackMini(Util.GetBinaryResource("lvlmove_dp.pkl"), "dp"));
        internal static readonly Learnset[] LevelUpPt = Learnset6.GetArray(Data.UnpackMini(Util.GetBinaryResource("lvlmove_pt.pkl"), "pt"));
        internal static readonly Learnset[] LevelUpHGSS = Learnset6.GetArray(Data.UnpackMini(Util.GetBinaryResource("lvlmove_hgss.pkl"), "hs"));
        internal static readonly EggMoves[] EggMovesDPPt = EggMoves6.GetArray(Data.UnpackMini(Util.GetBinaryResource("eggmove_dppt.pkl"), "dp"));
        internal static readonly EggMoves[] EggMovesHGSS = EggMoves6.GetArray(Data.UnpackMini(Util.GetBinaryResource("eggmove_hgss.pkl"), "hs"));

        // Gen 5
        internal static readonly Learnset[] LevelUpBW = Learnset6.GetArray(Data.UnpackMini(Util.GetBinaryResource("lvlmove_bw.pkl"), "51"));
        internal static readonly Learnset[] LevelUpB2W2 = Learnset6.GetArray(Data.UnpackMini(Util.GetBinaryResource("lvlmove_b2w2.pkl"), "52"));
        internal static readonly EggMoves[] EggMovesBW = EggMoves6.GetArray(Data.UnpackMini(Util.GetBinaryResource("eggmove_bw.pkl"), "bw"));

        // Gen 6
        internal static readonly EggMoves[] EggMovesXY = EggMoves6.GetArray(Data.UnpackMini(Util.GetBinaryResource("eggmove_xy.pkl"), "xy"));
        internal static readonly Learnset[] LevelUpXY = Learnset6.GetArray(Data.UnpackMini(Util.GetBinaryResource("lvlmove_xy.pkl"), "xy"));
        internal static readonly EggMoves[] EggMovesAO = EggMoves6.GetArray(Data.UnpackMini(Util.GetBinaryResource("eggmove_ao.pkl"), "ao"));
        internal static readonly Learnset[] LevelUpAO = Learnset6.GetArray(Data.UnpackMini(Util.GetBinaryResource("lvlmove_ao.pkl"), "ao"));

        // Gen 7
        internal static readonly EggMoves[] EggMovesSM = EggMoves7.GetArray(Data.UnpackMini(Util.GetBinaryResource("eggmove_sm.pkl"), "sm"));
        internal static readonly Learnset[] LevelUpSM = Learnset6.GetArray(Data.UnpackMini(Util.GetBinaryResource("lvlmove_sm.pkl"), "sm"));
        internal static readonly EggMoves[] EggMovesUSUM = EggMoves7.GetArray(Data.UnpackMini(Util.GetBinaryResource("eggmove_uu.pkl"), "uu"));
        internal static readonly Learnset[] LevelUpUSUM = Learnset6.GetArray(Data.UnpackMini(Util.GetBinaryResource("lvlmove_uu.pkl"), "uu"));

        // Setup Help
        static Legal()
        {
            // Misc Fixes to Data pertaining to legality constraints
            EggMovesUSUM[198].Moves = EggMovesUSUM[198].Moves.Take(15).ToArray(); // Remove Punishment from USUM Murkrow (no species can pass it #1829)
        }

        public static void RefreshMGDB(string localDbPath) => EncounterEvent.RefreshMGDB(localDbPath);

        // Moves
        internal static int[] GetMinLevelLearnMoveG1(int species, List<int> moves)
        {
            var r = new int[moves.Count];
            for (int i = 0; i < r.Length; i++)
                r[i] = MoveLevelUp.GetIsLevelUp1(species, moves[i], 100, 0, 0).Level;
            return r;
        }
        internal static int[] GetMaxLevelLearnMoveG1(int species, List<int> moves)
        {
            var r = new int[moves.Count];

            int index = PersonalTable.RB.GetFormeIndex(species, 0);
            if (index == 0)
                return r;

            var pi_rb = ((PersonalInfoG1)PersonalTable.RB[index]).Moves;
            var pi_y = ((PersonalInfoG1)PersonalTable.Y[index]).Moves;

            for (int m = 0; m < moves.Count; m++)
            {
                bool start = pi_rb.Contains(moves[m]) && pi_y.Contains(moves[m]);
                r[m] = start ? 1 : Math.Max(GetHighest(LevelUpRB), GetHighest(LevelUpY));
                int GetHighest(IReadOnlyList<Learnset> learn) => learn[index].GetLevelLearnMove(moves[m]);
            }
            return r;
        }
        internal static List<int>[] GetExclusiveMovesG1(int species1, int species2, IEnumerable<int> tmhm, IEnumerable<int> moves)
        {
            // Return from two species the exclusive moves that only one could learn and also the current pokemon have it in its current moveset
            var moves1 = MoveLevelUp.GetMovesLevelUp1(species1, 0, 1, 100);
            var moves2 = MoveLevelUp.GetMovesLevelUp1(species2, 0, 1, 100);

            // Remove common moves and remove tmhm, remove not learned moves
            var common = new HashSet<int>(moves1.Intersect(moves2).Concat(tmhm));
            var hashMoves = new HashSet<int>(moves);
            moves1.RemoveAll(x => !hashMoves.Contains(x) || common.Contains(x));
            moves2.RemoveAll(x => !hashMoves.Contains(x) || common.Contains(x));
            return new[] { moves1, moves2 };
        }
        internal static List<int>[] GetValidMovesAllGens(PKM pkm, IReadOnlyList<EvoCriteria>[] evoChains, int minLvLG1 = 1, int minLvLG2 = 1, bool LVL = true, bool Tutor = true, bool Machine = true, bool MoveReminder = true, bool RemoveTransferHM = true)
        {
            var Moves = new List<int>[evoChains.Length];
            for (int i = 1; i < evoChains.Length; i++)
            {
                if (evoChains[i].Count != 0)
                    Moves[i] = GetValidMoves(pkm, evoChains[i], i, minLvLG1, minLvLG2, LVL, Tutor, Machine, MoveReminder, RemoveTransferHM).ToList();
                else
                    Moves[i] = new List<int>();
            }
            return Moves;
        }
        internal static IEnumerable<int> GetValidMoves(PKM pkm, IReadOnlyList<EvoCriteria>[] evoChains, bool LVL = true, bool Tutor = true, bool Machine = true, bool MoveReminder = true, bool RemoveTransferHM = true)
        {
            GameVersion version = (GameVersion)pkm.Version;
            if (!pkm.IsUntraded)
                version = GameVersion.Any;
            return GetValidMoves(pkm, version, evoChains, minLvLG1: 1, minLvLG2: 1, LVL: LVL, Relearn: false, Tutor: Tutor, Machine: Machine, MoveReminder: MoveReminder, RemoveTransferHM: RemoveTransferHM);
        }
        internal static IEnumerable<int> GetValidMoves(PKM pkm, IReadOnlyList<EvoCriteria> evoChain, int generation, int minLvLG1 = 1, int minLvLG2 = 1, bool LVL = true, bool Tutor = true, bool Machine = true, bool MoveReminder = true, bool RemoveTransferHM = true)
        {
            GameVersion version = (GameVersion)pkm.Version;
            if (!pkm.IsUntraded)
                version = GameVersion.Any;
            return GetValidMoves(pkm, version, evoChain, generation, minLvLG1: minLvLG1, minLvLG2: minLvLG2, LVL: LVL, Relearn: false, Tutor: Tutor, Machine: Machine, MoveReminder: MoveReminder, RemoveTransferHM: RemoveTransferHM);
        }
        internal static IEnumerable<int> GetValidRelearn(PKM pkm, int species, bool inheritlvlmoves, GameVersion version = GameVersion.Any)
        {
            List<int> r = new List<int> { 0 };
            if (pkm.GenNumber < 6 || pkm.VC)
                return r;

            r.AddRange(MoveEgg.GetRelearnLVLMoves(pkm, species, 1, pkm.AltForm, version));

            int form = pkm.AltForm;
            if (pkm.Format == 6 && pkm.Species != 678)
                form = 0;

            r.AddRange(MoveEgg.GetEggMoves(pkm, species, form, version));
            if (inheritlvlmoves)
                r.AddRange(MoveEgg.GetRelearnLVLMoves(pkm, species, 100, pkm.AltForm, version));
            return r.Distinct();
        }
        internal static IList<int> GetShedinjaEvolveMoves(PKM pkm, int lvl = -1, int generation = 0)
        {
            if (lvl == -1)
                lvl = pkm.CurrentLevel;
            if (pkm.Species != 292 || lvl < 20)
                return new List<int>();

            // If nincada evolves into Ninjask an learn in the evolution a move from ninjask learnset pool
            // Shedinja would appear with that move learned. Only one move above level 20 allowed, only in generations 3 and 4
            switch (generation)
            {
                case 0: // Default (both)
                case 3: // Ninjask have the same learnset in every gen 3 games
                    if (pkm.InhabitedGeneration(3))
                        return LevelUpE[291].GetMoves(lvl, 20).ToList();

                    if (generation == 0)
                        goto case 4;
                    break;
                case 4: // Ninjask have the same learnset in every gen 4 games
                    if (pkm.InhabitedGeneration(4))
                        return LevelUpPt[291].GetMoves(lvl, 20);
                    break;
            }
            return new List<int>();
        }
        internal static int GetShedinjaMoveLevel(int species, int move, int generation)
        {
            var src = generation == 4 ? LevelUpPt : LevelUpE;
            var moves = src[species];
            return moves.GetLevelLearnMove(move);
        }
        internal static int[] GetBaseEggMoves(PKM pkm, int species, GameVersion gameSource, int lvl)
        {
            if (gameSource == GameVersion.Any)
                gameSource = (GameVersion)pkm.Version;

            switch (gameSource)
            {
                case GameVersion.GSC:
                case GameVersion.GS:
                    // If checking back-transfer specimen (GSC->RBY), remove moves that must be deleted prior to transfer
                    int[] getRBYCompatibleMoves(int[] moves) => pkm.Format == 1 ? moves.Where(m => m <= MaxMoveID_1).ToArray() : moves;
                    if (pkm.InhabitedGeneration(2))
                        return getRBYCompatibleMoves(LevelUpGS[species].GetMoves(lvl));
                    break;
                case GameVersion.C:
                    if (pkm.InhabitedGeneration(2))
                        return getRBYCompatibleMoves(LevelUpC[species].GetMoves(lvl));
                    break;

                case GameVersion.R:
                case GameVersion.S:
                case GameVersion.RS:
                    if (pkm.InhabitedGeneration(3))
                        return LevelUpRS[species].GetMoves(lvl);
                    break;
                case GameVersion.E:
                    if (pkm.InhabitedGeneration(3))
                        return LevelUpE[species].GetMoves(lvl);
                    break;
                case GameVersion.FR:
                case GameVersion.LG:
                case GameVersion.FRLG:
                    // only difference in FR/LG is deoxys which doesn't breed.
                    if (pkm.InhabitedGeneration(3))
                        return LevelUpFR[species].GetMoves(lvl);
                    break;

                case GameVersion.D:
                case GameVersion.P:
                case GameVersion.DP:
                    if (pkm.InhabitedGeneration(4))
                        return LevelUpDP[species].GetMoves(lvl);
                    break;
                case GameVersion.Pt:
                    if (pkm.InhabitedGeneration(4))
                        return LevelUpPt[species].GetMoves(lvl);
                    break;
                case GameVersion.HG:
                case GameVersion.SS:
                case GameVersion.HGSS:
                    if (pkm.InhabitedGeneration(4))
                        return LevelUpHGSS[species].GetMoves(lvl);
                    break;

                case GameVersion.B:
                case GameVersion.W:
                case GameVersion.BW:
                    if (pkm.InhabitedGeneration(5))
                        return LevelUpBW[species].GetMoves(lvl);
                    break;

                case GameVersion.B2:
                case GameVersion.W2:
                case GameVersion.B2W2:
                    if (pkm.InhabitedGeneration(5))
                        return LevelUpB2W2[species].GetMoves(lvl);
                    break;

                case GameVersion.X:
                case GameVersion.Y:
                case GameVersion.XY:
                    if (pkm.InhabitedGeneration(6))
                        return LevelUpXY[species].GetMoves(lvl);
                    break;

                case GameVersion.AS:
                case GameVersion.OR:
                case GameVersion.ORAS:
                    if (pkm.InhabitedGeneration(6))
                        return LevelUpAO[species].GetMoves(lvl);
                    break;

                case GameVersion.SN:
                case GameVersion.MN:
                case GameVersion.SM:
                    if (species > MaxSpeciesID_7)
                        break;
                    if (pkm.InhabitedGeneration(7))
                    {
                        int index = PersonalTable.SM.GetFormeIndex(species, pkm.AltForm);
                        return LevelUpSM[index].GetMoves(lvl);
                    }
                    break;

                case GameVersion.US:
                case GameVersion.UM:
                case GameVersion.USUM:
                    if (pkm.InhabitedGeneration(7))
                    {
                        int index = PersonalTable.USUM.GetFormeIndex(species, pkm.AltForm);
                        return LevelUpUSUM[index].GetMoves(lvl);
                    }
                    break;
            }
            return new int[0];
        }
        internal static List<int> GetValidPostEvolutionMoves(PKM pkm, int Species, IReadOnlyList<EvoCriteria>[] evoChains, GameVersion Version)
        {
            // Return moves that the pokemon could learn after evolving
            var moves = new List<int>();
            for (int i = 1; i < evoChains.Length; i++)
                if (evoChains[i].Count != 0)
                    moves.AddRange(GetValidPostEvolutionMoves(pkm, Species, evoChains[i], i, Version));
            if (pkm.GenNumber >= 6)
                moves.AddRange(pkm.RelearnMoves.Where(m => m != 0));
            return moves.Distinct().ToList();
        }
        private static List<int> GetValidPostEvolutionMoves(PKM pkm, int Species, IReadOnlyList<EvoCriteria> evoChain, int Generation, GameVersion Version)
        {
            var evomoves = new List<int>();
            var index = EvolutionChain.GetEvoChainSpeciesIndex(evoChain, Species);
            for (int i = 0; i <= index; i++)
            {
                var evo = evoChain[i];
                var moves = GetMoves(pkm, evo.Species, 1, 1, evo.Level, pkm.AltForm, moveTutor: true, Version: Version, LVL: true, specialTutors: true, Machine: true, MoveReminder: true, RemoveTransferHM: false, Generation: Generation);
                // Moves from Species or any species after in the evolution phase
                evomoves.AddRange(moves);
            }
            return evomoves;
        }
        internal static IEnumerable<int> GetExclusivePreEvolutionMoves(PKM pkm, int Species, IReadOnlyList<EvoCriteria> evoChain, int Generation, GameVersion Version)
        {
            var preevomoves = new List<int>();
            var evomoves = new List<int>();
            var index = EvolutionChain.GetEvoChainSpeciesIndex(evoChain, Species);
            for (int i = 0; i < evoChain.Count; i++)
            {
                var evo = evoChain[i];
                var moves = GetMoves(pkm, evo.Species, 1, 1, evo.Level, pkm.AltForm, moveTutor: true, Version: Version, LVL: true, specialTutors: true, Machine: true, MoveReminder: true, RemoveTransferHM: false, Generation: Generation);
                var list = i >= index ? preevomoves : evomoves;
                list.AddRange(moves);
            }
            return preevomoves.Except(evomoves).Distinct();
        }

        // Encounter
        internal static IEnumerable<GameVersion> GetGen2Versions(LegalInfo Info)
        {
            if (AllowGen2Crystal(Info.Korean) && Info.Game == GameVersion.C)
                yield return GameVersion.C;

            // Any encounter marked with version GSC is for pokemon with the same moves in GS and C
            // it is sufficient to check just GS's case
            yield return GameVersion.GS;
        }
        internal static IEnumerable<GameVersion> GetGen1Versions(LegalInfo Info)
        {
            if (Info.EncounterMatch.Species == 133 && Info.Game == GameVersion.Stadium)
            {
                // Stadium Eevee; check for RB and yellow initial moves
                yield return GameVersion.RB;
                yield return GameVersion.YW;
            }
            else if (Info.Game == GameVersion.YW)
                yield return GameVersion.YW;

            // Any encounter marked with version RBY is for pokemon with the same moves and catch rate in RB and Y,
            // it is sufficient to check just RB's case
            yield return GameVersion.RB;
        }
        internal static int GetRequiredMoveCount(PKM pk, int[] moves, LegalInfo info, int[] initialmoves)
        {
            if (pk.Format != 1 || !pk.Gen1_NotTradeback) // No Move Deleter in Gen 1
                return 1; // Move Deleter exits, slots from 2 onwards can allways be empty

            int required = GetRequiredMoveCount(pk, moves, info.EncounterMoves.LevelUpMoves, initialmoves);
            if (required >= 4)
                return 4;

            // tm, hm and tutor moves replace a free slots if the pokemon have less than 4 moves
            // Ignore tm, hm and tutor moves already in the learnset table
            var learn = info.EncounterMoves.LevelUpMoves;
            var tmhm = info.EncounterMoves.TMHMMoves;
            var tutor = info.EncounterMoves.TutorMoves;
            var union = initialmoves.Union(learn[1]);
            required += moves.Count(m => m != 0 && union.All(t => t != m) && (tmhm[1].Any(t => t == m) || tutor[1].Any(t => t == m)));

            return Math.Min(4, required);
        }
        private static int GetRequiredMoveCount(PKM pk, int[] moves, List<int>[] learn, int[] initialmoves)
        {
            if (SpecialMinMoveSlots.Contains(pk.Species))
                return GetRequiredMoveCountSpecial(pk, moves, learn);

            // A pokemon is captured with initial moves and can't forget any until have all 4 slots used
            // If it has learn a move before having 4 it will be in one of the free slots
            int required = GetRequiredMoveSlotsRegular(pk, moves, learn, initialmoves);
            return required != 0 ? required : GetRequiredMoveCountDecrement(pk, moves, learn, initialmoves);
        }
        private static int GetRequiredMoveSlotsRegular(PKM pk, int[] moves, List<int>[] learn, int[] initialmoves)
        {
            int species = pk.Species;
            int catch_rate = ((PK1)pk).Catch_Rate;
            // Caterpie and Metapod evolution lines have different count of possible slots available if captured in different evolutionary phases
            // Example: a level 7 caterpie evolved into metapod will have 3 learned moves, a captured metapod will have only 1 move
            if ((species == 011 || species == 012) && catch_rate == 120)
            {
                // Captured as Metapod without Caterpie moves
                return initialmoves.Union(learn[1]).Distinct().Count(lm => lm != 0 && !G1CaterpieMoves.Contains(lm));
                // There is no valid Butterfree encounter in generation 1 games
            }
            if ((species == 014 || species == 015) && (catch_rate == 45 || catch_rate == 120))
            {
                if (species == 15 && catch_rate == 45) // Captured as Beedril without Weedle and Kakuna moves
                    return initialmoves.Union(learn[1]).Distinct().Count(lm => lm != 0 && !G1KakunaMoves.Contains(lm));

                // Captured as Kakuna without Weedle moves
                return initialmoves.Union(learn[1]).Distinct().Count(lm => lm != 0 && !G1WeedleMoves.Contains(lm));
            }

            return IsMoveCountRequired3(species, pk.CurrentLevel, moves) ? 3 : 0; // no match
        }
        private static bool IsMoveCountRequired3(int species, int level, int[] moves)
        {
            // Species that evolve and learn the 4th move as evolved species at a greather level than base species
            // The 4th move is included in the level up table set as a preevolution move,
            // it should be removed from the used slots count if is not the learn move
            switch (species)
            {
                case 017: return level < 21 && !moves.Contains(018); // Pidgeotto without Whirlwind
                case 028: return level < 27 && !moves.Contains(040); // Sandslash without Poison Sting
                case 047: return level < 30 && !moves.Contains(147); // Parasect without Spore
                case 055: return level < 39 && !moves.Contains(093); // Golduck without Confusion
                case 087: return level < 44 && !moves.Contains(156); // Dewgong without Rest
                case 093:
                case 094: return level < 29 && !moves.Contains(095); // Haunter/Gengar without Hypnosis
                case 110: return level < 39 && !moves.Contains(108); // Weezing without Smoke Screen
            }
            return false;
        }
        private static int GetRequiredMoveCountDecrement(PKM pk, int[] moves, List<int>[] learn, int[] initialmoves)
        {
            int usedslots = initialmoves.Union(learn[1]).Where(m => m != 0).Distinct().Count();
            switch (pk.Species)
            {
                case 031: // Venonat; ignore Venomoth (by the time Venonat evolves it will always have 4 moves)
                    if (pk.CurrentLevel >= 11 && !moves.Contains(48)) // Supersonic
                        usedslots--;
                    if (pk.CurrentLevel >= 19 && !moves.Contains(93)) // Confusion
                        usedslots--;
                    break;
                case 064: case 065: // Abra & Kadabra
                    int catch_rate = ((PK1)pk).Catch_Rate;
                    if (catch_rate != 100)// Initial Yellow Kadabra Kinesis (move 134)
                        usedslots--;
                    if (catch_rate == 200 && pk.CurrentLevel < 20) // Kadabra Disable, not learned until 20 if captured as Abra (move 50)
                        usedslots--;
                    break;
                case 104: case 105: // Cubone & Marowak
                    if (!moves.Contains(39)) // Initial Yellow Tail Whip
                        usedslots--;
                    if (!moves.Contains(125)) // Initial Yellow Bone Club
                        usedslots--;
                    if (pk.Species == 105 && pk.CurrentLevel < 33 && !moves.Contains(116)) // Marowak evolved without Focus Energy
                        usedslots--;
                    break;
                case 113:
                    if (!moves.Contains(39)) // Yellow Initial Tail Whip
                        usedslots--;
                    if (!moves.Contains(3)) // Yellow Lvl 12 and Initial Red/Blue Double Slap
                        usedslots--;
                    break;
                case 056 when pk.CurrentLevel >= 9 && !moves.Contains(67): // Mankey (Low Kick)
                case 127 when pk.CurrentLevel >= 21 && !moves.Contains(20): // Pinsir (Bind)
                case 130 when pk.CurrentLevel < 32: // Gyarados
                    usedslots--;
                    break;
            }
            return usedslots;
        }
        private static int GetRequiredMoveCountSpecial(PKM pk, int[] moves, List<int>[] learn)
        {
            // Species with few mandatory slots, species with stone evolutions that could evolve at lower level and do not learn any more moves
            // and Pikachu and Nidoran family, those only have mandatory the initial moves and a few have one level up moves,
            // every other move could be avoided switching game or evolving
            var mandatory = GetRequiredMoveCountLevel(pk);
            switch (pk.Species)
            {
                case 103 when pk.CurrentLevel >= 28: // Exeggutor
                    // At level 28 learn different move if is a Exeggute or Exeggutor
                    if (moves.Contains(73))
                        mandatory.Add(73); // Leech Seed level 28 Exeggute
                    if (moves.Contains(23))
                        mandatory.Add(23); // Stomp level 28 Exeggutor
                    break;
                case 25 when pk.CurrentLevel >= 33:
                    mandatory.Add(97); // Pikachu always learns Agility
                    break;
                case 114:
                    mandatory.Add(132); // Tangela always has Constrict as Initial Move
                    break;
            }

            // Add to used slots the non-mandatory moves from the learnset table that the pokemon have learned
            return mandatory.Count + moves.Count(m => m != 0 && mandatory.All(l => l != m) && learn[1].Any(t => t == m));
        }
        private static List<int> GetRequiredMoveCountLevel(PKM pk)
        {
            int species = pk.Species;
            int basespecies = GetBaseSpecies(pk);
            int maxlevel = 1;
            int minlevel = 1;

            if (species == 114) // Tangela moves before level 32 are different in RB vs Y
            {
                minlevel = 32;
                maxlevel = pk.CurrentLevel;
            }
            else if (029 <= species && species <= 034 && pk.CurrentLevel >= 8)
            {
                maxlevel = 8; // Always learns a third move at level 8
            }

            if (minlevel > pk.CurrentLevel)
                return new List<int>();

            return MoveLevelUp.GetMovesLevelUp1(basespecies, 0, maxlevel, minlevel);
        }

        internal static bool GetWasEgg23(PKM pkm)
        {
            if (pkm.IsEgg)
                return true;
            if (pkm.Format > 2 && pkm.Ball != 4)
                return false;
            if (pkm.Format == 3)
                return pkm.WasEgg;

            int lvl = pkm.CurrentLevel;
            if (lvl < 5)
                return false;

            if (pkm.Format > 3 && pkm.Met_Level < 5)
                return false;
            if (pkm.Format > 3 && pkm.FatefulEncounter)
                return false;

            return IsEvolutionValid(pkm);
        }

        // Generation Specific Fetching
        internal static IEnumerable<EncounterStatic> GetEncounterStaticTable(PKM pkm, GameVersion gameSource = GameVersion.Any)
        {
            if (gameSource == GameVersion.Any)
                gameSource = (GameVersion)pkm.Version;

            switch (gameSource)
            {
                case GameVersion.RBY:
                case GameVersion.RD:
                case GameVersion.BU:
                case GameVersion.GN:
                case GameVersion.YW:
                    return StaticRBY;

                case GameVersion.GSC:
                case GameVersion.GD:
                case GameVersion.SV:
                case GameVersion.C:
                    return GetEncounterStaticTableGSC(pkm);

                case GameVersion.R: return StaticR;
                case GameVersion.S: return StaticS;
                case GameVersion.E: return StaticE;
                case GameVersion.FR: return StaticFR;
                case GameVersion.LG: return StaticLG;
                case GameVersion.CXD: return Encounter_CXD;

                case GameVersion.D: return StaticD;
                case GameVersion.P: return StaticP;
                case GameVersion.Pt: return StaticPt;
                case GameVersion.HG: return StaticHG;
                case GameVersion.SS: return StaticSS;

                case GameVersion.B: return StaticB;
                case GameVersion.W: return StaticW;
                case GameVersion.B2: return StaticB2;
                case GameVersion.W2: return StaticW2;

                case GameVersion.X: return StaticX;
                case GameVersion.Y: return StaticY;
                case GameVersion.AS: return StaticA;
                case GameVersion.OR: return StaticO;

                case GameVersion.SN: return StaticSN;
                case GameVersion.MN: return StaticMN;
                case GameVersion.US: return StaticUS;
                case GameVersion.UM: return StaticUM;

                default: return Enumerable.Empty<EncounterStatic>();
            }
        }
        internal static IEnumerable<EncounterArea> GetEncounterTable(PKM pkm, GameVersion gameSource = GameVersion.Any)
        {
            if (gameSource == GameVersion.Any)
                gameSource = (GameVersion)pkm.Version;

            switch (gameSource)
            {
                case GameVersion.RBY:
                case GameVersion.RD:
                case GameVersion.BU:
                case GameVersion.GN:
                case GameVersion.YW:
                    return SlotsRBY;

                case GameVersion.GSC:
                case GameVersion.GD:
                case GameVersion.SV:
                case GameVersion.C:
                    return GetEncounterTableGSC(pkm);

                case GameVersion.R: return SlotsR;
                case GameVersion.S: return SlotsS;
                case GameVersion.E: return SlotsE;
                case GameVersion.FR: return SlotsFR;
                case GameVersion.LG: return SlotsLG;
                case GameVersion.CXD: return SlotsXD;

                case GameVersion.D: return SlotsD;
                case GameVersion.P: return SlotsP;
                case GameVersion.Pt: return SlotsPt;
                case GameVersion.HG: return SlotsHG;
                case GameVersion.SS: return SlotsSS;

                case GameVersion.B: return SlotsB;
                case GameVersion.W: return SlotsW;
                case GameVersion.B2: return SlotsB2;
                case GameVersion.W2: return SlotsW2;

                case GameVersion.X: return SlotsX;
                case GameVersion.Y: return SlotsY;
                case GameVersion.AS: return SlotsA;
                case GameVersion.OR: return SlotsO;

                case GameVersion.SN: return SlotsSN;
                case GameVersion.MN: return SlotsMN;
                case GameVersion.US: return SlotsUS;
                case GameVersion.UM: return SlotsUM;

                default: return Enumerable.Empty<EncounterArea>();
            }
        }
        private static IEnumerable<EncounterStatic> GetEncounterStaticTableGSC(PKM pkm)
        {
            if (!AllowGen2Crystal(pkm))
                return StaticGS;
            if (pkm.Format != 2)
                return StaticGSC;

            if (pkm.HasOriginalMetLocation)
                return StaticC;
            return StaticGSC;
        }
        private static IEnumerable<EncounterArea> GetEncounterTableGSC(PKM pkm)
        {
            if (!AllowGen2Crystal(pkm))
                return SlotsGS;

            if (pkm.Format != 2)
                // Gen 2 met location is lost outside gen 2 games
                return SlotsGSC;

            if (pkm.HasOriginalMetLocation)
                // Format 2 with met location, encounter should be from Crystal
                return SlotsC;

            if (pkm.Species > 151 && !FutureEvolutionsGen1.Contains(pkm.Species))
                // Format 2 without met location but pokemon could not be tradeback to gen 1,
                // encounter should be from gold or silver
                return SlotsGS;

            // Encounter could be any gen 2 game, it can have empty met location for have a g/s origin
            // or it can be a Crystal pokemon that lost met location after being tradeback to gen 1 games
            return SlotsGSC;
        }

        internal static ICollection<int> GetWildBalls(PKM pkm)
        {
            switch (pkm.GenNumber)
            {
                case 1: return WildPokeBalls1;
                case 2: return WildPokeBalls2;
                case 3: return WildPokeBalls3;
                case 4: return pkm.HGSS ? WildPokeBalls4_HGSS : WildPokeBalls4_DPPt;
                case 5: return WildPokeBalls5;
                case 6: return WildPokeballs6;
                case 7: return WildPokeballs7;

                default: return null;
            }
        }
        internal static int GetEggHatchLevel(PKM pkm) => GetEggHatchLevel(pkm.Format);
        internal static int GetEggHatchLevel(int gen) => gen <= 3 ? 5 : 1;

        internal static ICollection<int> GetSplitBreedGeneration(PKM pkm)
        {
            return GetSplitBreedGeneration(pkm.GenNumber);
        }
        private static ICollection<int> GetSplitBreedGeneration(int generation)
        {
            switch (generation)
            {
                case 1:
                case 2: return Empty;
                case 3: return SplitBreed_3;
                case 4:
                case 5:
                case 6:
                case 7: return SplitBreed;
                default: return Empty;
            }
        }
        internal static int GetMaxSpeciesOrigin(PKM pkm)
        {
            if (pkm.Format == 1)
                return GetMaxSpeciesOrigin(1);
            if (pkm.Format == 2 || pkm.VC)
                return GetMaxSpeciesOrigin(2);
            return GetMaxSpeciesOrigin(pkm.GenNumber);
        }
        internal static int GetMaxSpeciesOrigin(int generation)
        {
            switch (generation)
            {
                case 1: return MaxSpeciesID_1;
                case 2: return MaxSpeciesID_2;
                case 3: return MaxSpeciesID_3;
                case 4: return MaxSpeciesID_4;
                case 5: return MaxSpeciesID_5;
                case 6: return MaxSpeciesID_6;
                case 7: return MaxSpeciesID_7_USUM;
                default: return -1;
            }
        }
        internal static IEnumerable<int> GetFutureGenEvolutions(int generation)
        {
            switch (generation)
            {
                case 1: return FutureEvolutionsGen1;
                case 2: return FutureEvolutionsGen2;
                case 3: return FutureEvolutionsGen3;
                case 4: return FutureEvolutionsGen4;
                case 5: return FutureEvolutionsGen5;
                default: return Enumerable.Empty<int>();
            }
        }
        internal static int GetDebutGeneration(int species)
        {
            if (species <= MaxSpeciesID_1)
                return 1;
            if (species <= MaxSpeciesID_2)
                return 2;
            if (species <= MaxSpeciesID_3)
                return 3;
            if (species <= MaxSpeciesID_4)
                return 4;
            if (species <= MaxSpeciesID_5)
                return 5;
            if (species <= MaxSpeciesID_6)
                return 6;
            if (species <= MaxSpeciesID_7_USUM)
                return 7;
            return -1;
        }

        internal static int GetMaxLanguageID(int generation)
        {
            switch (generation)
            {
                case 1:
                case 3:
                    return 7; // 1-7 except 6
                case 2:
                case 4:
                case 5:
                case 6:
                    return 8;
                case 7:
                    return 10;
            }
            return -1;
        }
        private static bool[] GetReleasedHeldItems(int generation)
        {
            switch (generation)
            {
                case 2: return ReleasedHeldItems_2;
                case 3: return ReleasedHeldItems_3;
                case 4: return ReleasedHeldItems_4;
                case 5: return ReleasedHeldItems_5;
                case 6: return ReleasedHeldItems_6;
                case 7: return ReleasedHeldItems_7;
                default: return new bool[0];
            }
        }
        internal static bool IsHeldItemAllowed(PKM pkm)
        {
            return IsHeldItemAllowed(pkm.HeldItem, pkm.Format);
        }
        private static bool IsHeldItemAllowed(int item, int generation)
        {
            if (item < 0)
                return false;
            if (item == 0)
                return true;

            var items = GetReleasedHeldItems(generation);
            return items.Length > item && items[item];
        }

        private static bool IsEvolvedFormChange(PKM pkm)
        {
            if (pkm.IsEgg)
                return false;

            if (pkm.Format >= 7 && AlolanVariantEvolutions12.Contains(pkm.Species))
                return pkm.AltForm == 1;
            if (pkm.Species == 678 && pkm.Gender == 1)
                return pkm.AltForm == 1;
            if (pkm.Species == 773)
                return true;
            return false;
        }
        internal static bool IsTradeEvolved(IReadOnlyList<EvoCriteria>[] chain, int pkmFormat)
        {
            return chain[pkmFormat].Any(IsTradeEvolved);
        }
        internal static bool IsTradeEvolved(EvoCriteria z) => EvolutionMethod.TradeMethods.Contains(z.Method);
        internal static bool IsEvolutionValid(PKM pkm, int minSpecies = -1, int minLevel = -1)
        {
            var curr = EvolutionChain.GetValidPreEvolutions(pkm);
            var min = curr.FindLast(z => z.Species == minSpecies);
            if (min != null && min.Level < minLevel)
                return false;
            var poss = EvolutionChain.GetValidPreEvolutions(pkm, lvl: 100, skipChecks: true);

            if (minSpecies != -1)
            {
                int last = poss.FindLastIndex(z => z.Species == minSpecies);
                return curr.Count >= last;
            }
            if (GetSplitBreedGeneration(pkm).Contains(GetBaseSpecies(pkm, 1)))
                return curr.Count >= poss.Count - 1;
            return curr.Count >= poss.Count;
        }
        internal static bool IsEvolutionValidWithMove(PKM pkm, LegalInfo info)
        {
            // Exclude species that do not evolve leveling with a move
            // Exclude gen 1-3 formats
            // Exclude Mr Mime and Snorlax for gen 1-3 games
            if (!SpeciesEvolutionWithMove.Contains(pkm.Species) || pkm.Format <= 3 || (BabyEvolutionWithMove.Contains(pkm.Species) && pkm.GenNumber <= 3))
                return true;

            var index = Array.FindIndex(SpeciesEvolutionWithMove, p => p == pkm.Species);
            var levels = MinLevelEvolutionWithMove[index];
            var moves = MoveEvolutionWithMove[index];
            var allowegg = EggMoveEvolutionWithMove[index][pkm.GenNumber];

            // Get the minimum level in any generation when the pokemon could learn the evolve move
            var LearnLevel = 101;
            for (int g = pkm.GenNumber; g <= pkm.Format; g++)
                if (pkm.InhabitedGeneration(g) && levels[g] > 0)
                    LearnLevel = Math.Min(LearnLevel, levels[g]);

            // Check also if the current encounter include the evolve move as an special move
            // That means the pokemon have the move from the encounter level
            if (info.EncounterMatch is IMoveset s && s.Moves?.Any(m => moves.Contains(m)) == true)
                LearnLevel = Math.Min(LearnLevel, info.EncounterMatch.LevelMin);

            // If the encounter is a player hatched egg check if the move could be an egg move or inherited level up move
            if (info.EncounterMatch.EggEncounter && !pkm.WasGiftEgg && !pkm.WasEventEgg && allowegg)
            {
                if (IsMoveInherited(pkm, info, moves))
                    LearnLevel = Math.Min(LearnLevel, pkm.GenNumber < 4 ? 6 : 2);
            }

            // If has original met location the minimum evolution level is one level after met level
            // Gen 3 pokemon in gen 4 games: minimum level is one level after transfer to generation 4
            // VC pokemon: minimum level is one level after transfer to generation 7
            // Sylveon: always one level after met level, for gen 4 and 5 eevees in gen 6 games minimum for evolution is one level after transfer to generation 5
            if (pkm.HasOriginalMetLocation || pkm.Format == 4 && pkm.Gen3 || pkm.VC || pkm.Species == 700)
                LearnLevel = Math.Max(pkm.Met_Level + 1, LearnLevel);

            // Current level must be at least one the minimum learn level
            // the level-up event that triggers the learning of the move also triggers evolution with no further level-up required
            return pkm.CurrentLevel >= LearnLevel;
        }
        private static bool IsMoveInherited(PKM pkm, LegalInfo info, int[] moves)
        {
            // In 3DS games, the inherited move must be in the relearn moves.
            if (info.Generation >= 6)
                return pkm.RelearnMoves.Any(moves.Contains);

            // In Pre-3DS games, the move is inherited if it has the move and it can be hatched with the move.
            if (pkm.Moves.Any(moves.Contains))
                return true;

            // If the pokemon does not have the move, it still could be an egg move that was forgotten.
            // This requires the pokemon to not have 4 other moves identified as egg moves or inherited level up moves.
            return 4 > info.Moves.Count(m => m.Source == MoveSource.EggMove || m.Source == MoveSource.InheritLevelUp);
        }
        internal static bool IsFormChangeable(PKM pkm, int species)
        {
            if (FormChange.Contains(species))
                return true;
            if (IsEvolvedFormChange(pkm))
                return true;
            if (species == 718 && pkm.InhabitedGeneration(7) && pkm.AltForm > 1)
                return true;
            return false;
        }

        internal static bool GetCanInheritMoves(int species)
        {
            if (FixedGenderFromBiGender.Contains(species)) // Nincada -> Shedinja loses gender causing 'false', edge case
                return true;
            var pi = PKX.Personal[species];
            if (!pi.Genderless && !pi.OnlyMale)
                return true;
            if (MixedGenderBreeding.Contains(species))
                return true;
            return false;
        }
        public static int GetLowestLevel(PKM pkm, int startLevel)
        {
            if (startLevel == -1)
                startLevel = 100;

            var table = EvolutionTree.GetEvolutionTree(pkm.Format);
            int count = 1;
            for (int i = 100; i >= startLevel; i--)
            {
                var evos = table.GetValidPreEvolutions(pkm, maxLevel: i, minLevel: startLevel, skipChecks: true);
                if (evos.Count < count) // lost an evolution, prior level was minimum current level
                    return evos.Max(evo => evo.Level) + 1;
                count = evos.Count;
            }
            return startLevel;
        }
        internal static bool GetCanBeCaptured(int species, int gen, GameVersion version = GameVersion.Any)
        {
            switch (gen)
            {
                // Capture Memory only obtainable via Gen 6.
                case 6:
                    switch (version)
                    {
                        case GameVersion.Any:
                            return FriendSafari.Contains(species)
                                || GetCanBeCaptured(species, SlotsX, StaticX)
                                || GetCanBeCaptured(species, SlotsY, StaticY)
                                || GetCanBeCaptured(species, SlotsA, StaticA)
                                || GetCanBeCaptured(species, SlotsO, StaticO);
                        case GameVersion.X:
                            return FriendSafari.Contains(species)
                                || GetCanBeCaptured(species, SlotsX, StaticX);
                        case GameVersion.Y:
                            return FriendSafari.Contains(species)
                                || GetCanBeCaptured(species, SlotsY, StaticY);

                        case GameVersion.AS:
                            return GetCanBeCaptured(species, SlotsA, StaticA);
                        case GameVersion.OR:
                            return GetCanBeCaptured(species, SlotsO, StaticO);
                    }
                    break;
            }
            return false;
        }
        private static bool GetCanBeCaptured(int species, IEnumerable<EncounterArea> area, IEnumerable<EncounterStatic> statics)
        {
            if (area.Any(loc => loc.Slots.Any(slot => slot.Species == species)))
                return true;
            if (statics.Any(enc => enc.Species == species && !enc.Gift))
                return true;
            return false;
        }
        internal static bool GetCanLearnMachineMove(PKM pkm, int move, int generation, GameVersion version = GameVersion.Any)
        {
            return GetValidMoves(pkm, version, EvolutionChain.GetValidPreEvolutions(pkm), generation, Machine: true).Contains(move);
        }
        internal static bool GetCanRelearnMove(PKM pkm, int move, int generation, GameVersion version = GameVersion.Any)
        {
            return GetValidMoves(pkm, version, EvolutionChain.GetValidPreEvolutions(pkm), generation, LVL: true, Relearn: true).Contains(move);
        }
        internal static bool GetCanKnowMove(PKM pkm, int move, int generation, GameVersion version = GameVersion.Any)
        {
            if (pkm.Species == 235 && !InvalidSketch.Contains(move))
                return true;
            return GetValidMoves(pkm, version, EvolutionChain.GetValidPreEvolutions(pkm), generation, LVL: true, Relearn: true, Tutor: true, Machine: true).Contains(move);
        }
        internal static int GetBaseEggSpecies(PKM pkm, int skipOption = 0)
        {
            if (pkm.Format == 1)
                return GetBaseSpecies(pkm, generation: 2);
            return GetBaseSpecies(pkm, skipOption);
        }
        internal static int GetBaseSpecies(PKM pkm, int skipOption = 0, int generation = -1)
        {
            int tree = generation != -1 ? generation : pkm.Format;
            var table = EvolutionTree.GetEvolutionTree(tree);
            int maxSpeciesOrigin = generation != -1 ? GetMaxSpeciesOrigin(generation) : -1;
            var evos = table.GetValidPreEvolutions(pkm, maxLevel: 100, maxSpeciesOrigin: maxSpeciesOrigin, skipChecks: true);
            return GetBaseSpecies(pkm, evos, skipOption);
        }
        internal static int GetBaseSpecies(PKM pkm, IReadOnlyList<DexLevel> evos, int skipOption = 0)
        {
            if (pkm.Species == 292)
                return 290;
            switch (skipOption)
            {
                case -1: return pkm.Species;
                case 1: return evos.Count <= 1 ? pkm.Species : evos[evos.Count - 2].Species;
                default: return evos.Count <= 0 ? pkm.Species : evos[evos.Count - 1].Species;
            }
        }
        private static int GetMaxLevelGeneration(PKM pkm)
        {
            return GetMaxLevelGeneration(pkm, pkm.GenNumber);
        }
        private static int GetMaxLevelGeneration(PKM pkm, int generation)
        {
            if (!pkm.InhabitedGeneration(generation))
                return pkm.Met_Level;

            if (pkm.Format <= 2)
            {
                if (generation == 1 && FutureEvolutionsGen1_Gen2LevelUp.Contains(pkm.Species))
                    return pkm.CurrentLevel - 1;
                return pkm.CurrentLevel;
            }

            if (pkm.Species == 700 && generation == 5)
                return pkm.CurrentLevel - 1;

            if (pkm.Gen3 && pkm.Format > 4 && pkm.Met_Level == pkm.CurrentLevel && FutureEvolutionsGen3_LevelUpGen4.Contains(pkm.Species))
                return pkm.Met_Level - 1;

            if (!pkm.HasOriginalMetLocation)
                return pkm.Met_Level;

            return pkm.CurrentLevel;
        }
        internal static int GetMinLevelEncounter(PKM pkm)
        {
            if (pkm.Format == 3 && pkm.WasEgg)
                // Only for gen 3 pokemon in format 3, after transfer to gen 4 it should return transfer level
                return 5;
            if (pkm.Format == 4 && pkm.Gen4 && pkm.WasEgg)
                // Only for gen 4 pokemon in format 4, after transfer to gen 5 it should return transfer level
                return 1;
            return pkm.HasOriginalMetLocation ? pkm.Met_Level : GetMaxLevelGeneration(pkm);
        }
        private static bool GetCatchRateMatchesPreEvolution(PKM pkm, int catch_rate, IEnumerable<int> gen1)
        {
            // For species catch rate, discard any species that has no valid encounters and a different catch rate than their pre-evolutions
            var Lineage = gen1.Except(Species_NotAvailable_CatchRate);
            return IsCatchRateRBY(Lineage) || IsCatchRateTrade() || IsCatchRateStadium();

            // Dragonite's Catch Rate is different than Dragonair's in Yellow, but there is no Dragonite encounter.
            bool IsCatchRateRBY(IEnumerable<int> ds) => ds.Any(s => catch_rate == PersonalTable.RB[s].CatchRate || s != 149 && catch_rate == PersonalTable.Y[s].CatchRate);
            // Krabby encounter trade special catch rate
            bool IsCatchRateTrade() => (pkm.Species == 098 || pkm.Species == 099) && catch_rate == 204;
            bool IsCatchRateStadium() => Stadium_GiftSpecies.Contains(pkm.Species) && Stadium_CatchRate.Contains(catch_rate);
        }
        internal static void SetTradebackStatusRBY(PK1 pkm)
        {
            if (!AllowGen1Tradeback)
            {
                pkm.TradebackStatus = TradebackType.Gen1_NotTradeback;
                pkm.CatchRateIsItem = false;
                return;
            }

            // Detect tradeback status by comparing the catch rate(Gen1)/held item(Gen2) to the species in the pkm's evolution chain.
            var catch_rate = pkm.Catch_Rate;
            var table = EvolutionTree.GetEvolutionTree(1);
            var lineage = table.GetValidPreEvolutions(pkm, maxLevel: pkm.CurrentLevel);
            var gen1 = lineage.Select(evolution => evolution.Species);
            bool matchAny = GetCatchRateMatchesPreEvolution(pkm, catch_rate, gen1);

            // If the catch rate value has been modified, the item has either been removed or swapped in Generation 2.
            var HeldItemCatchRate = catch_rate == 0 || HeldItems_GSC.Contains((ushort)catch_rate);
            if (HeldItemCatchRate && !matchAny)
                pkm.TradebackStatus = TradebackType.WasTradeback;
            else if (!HeldItemCatchRate && matchAny)
                pkm.TradebackStatus = TradebackType.Gen1_NotTradeback;
            else
                pkm.TradebackStatus = TradebackType.Any;

            // Update the editing settings for the PKM to acknowledge the tradeback status if the species is changed.
            pkm.CatchRateIsItem = !pkm.Gen1_NotTradeback && HeldItemCatchRate && !matchAny;
        }

        private static IEnumerable<int> GetValidMoves(PKM pkm, GameVersion Version, IReadOnlyList<IReadOnlyList<EvoCriteria>> vs, int minLvLG1 = 1, int minLvLG2 = 1, bool LVL = false, bool Relearn = false, bool Tutor = false, bool Machine = false, bool MoveReminder = true, bool RemoveTransferHM = true)
        {
            List<int> r = new List<int> { 0 };
            if (Relearn && pkm.Format >= 6)
                r.AddRange(pkm.RelearnMoves);

            for (int gen = pkm.GenNumber; gen <= pkm.Format; gen++)
                if (vs[gen].Count != 0)
                    r.AddRange(GetValidMoves(pkm, Version, vs[gen], gen, minLvLG1: minLvLG1, minLvLG2: minLvLG2, LVL: LVL, Relearn: false, Tutor: Tutor, Machine: Machine, MoveReminder: MoveReminder, RemoveTransferHM: RemoveTransferHM));

            return r.Distinct();
        }
        private static IEnumerable<int> GetValidMoves(PKM pkm, GameVersion Version, IReadOnlyList<EvoCriteria> vs, int Generation, int minLvLG1 = 1, int minLvLG2 = 1, bool LVL = false, bool Relearn = false, bool Tutor = false, bool Machine = false, bool MoveReminder = true, bool RemoveTransferHM = true)
        {
            List<int> r = new List<int> { 0 };
            if (vs.Count == 0)
                return r;
            int species = pkm.Species;

            // Special Type Tutors Availability
            bool moveTutor = Tutor || MoveReminder; // Usually true, except when called for move suggestions (no tutored moves)

            if (FormChangeMoves.Contains(species)) // Deoxys & Shaymin & Giratina (others don't have extra but whatever)
            {
                int formcount = pkm.PersonalInfo.FormeCount;
                if (species == 386 && pkm.Format == 3)
                    // In gen 3 deoxys has different forms depending on the current game, in personal info there is no alter form info
                    formcount = 4;
                for (int i = 0; i < formcount; i++)
                    r.AddRange(GetMoves(pkm, species, minLvLG1, minLvLG2, vs[0].Level, i, moveTutor, Version, LVL, Tutor, Machine, MoveReminder, RemoveTransferHM, Generation));
                if (Relearn)
                    r.AddRange(pkm.RelearnMoves);
                return r.Distinct();
            }

            for (var i = 0; i < vs.Count; i++)
            {
                var evo = vs[i];
                var moves = GetEvoMoves(pkm, Version, vs, Generation, minLvLG1, minLvLG2, LVL, Tutor, Machine, MoveReminder, RemoveTransferHM, moveTutor, i, evo);
                r.AddRange(moves);
            }

            if (pkm.Format <= 3)
                return r.Distinct();

            if (LVL)
                MoveTutor.AddSpecialFormChangeMoves(r, pkm, Generation, species);
            if (Tutor)
                MoveTutor.AddSpecialTutorMoves(r, pkm, Generation, species);
            if (Relearn && Generation >= 6)
                r.AddRange(pkm.RelearnMoves);
            return r.Distinct();
        }
        private static IEnumerable<int> GetEvoMoves(PKM pkm, GameVersion Version, IReadOnlyList<EvoCriteria> vs, int Generation, int minLvLG1, int minLvLG2, bool LVL, bool Tutor, bool Machine, bool MoveReminder, bool RemoveTransferHM, bool moveTutor, int i, EvoCriteria evo)
        {
            var minlvlevo1 = 1;
            var minlvlevo2 = 1;
            if (Generation == 1)
            {
                // Return moves from minLvLG1 if species if the species encounters
                // For evolutions return moves using evolution min level as min level
                minlvlevo1 = minLvLG1;
                if (evo.MinLevel > 1)
                    minlvlevo1 = Math.Min(pkm.CurrentLevel, evo.MinLevel);
            }
            if (Generation == 2 && !AllowGen2MoveReminder(pkm))
            {
                minlvlevo2 = minLvLG2;
                if (evo.MinLevel > 1)
                    minlvlevo2 = Math.Min(pkm.CurrentLevel, evo.MinLevel);
            }
            var maxLevel = evo.Level;
            if (i != 0 && vs[i - 1].RequiresLvlUp) // evolution
                ++maxLevel; // allow lvlmoves from the level it evolved to the next species
            return GetMoves(pkm, evo.Species, minlvlevo1, minlvlevo2, maxLevel, pkm.AltForm, moveTutor, Version, LVL, Tutor, Machine, MoveReminder, RemoveTransferHM, Generation);
        }
        private static IEnumerable<int> GetMoves(PKM pkm, int species, int minlvlG1, int minlvlG2, int lvl, int form, bool moveTutor, GameVersion Version, bool LVL, bool specialTutors, bool Machine, bool MoveReminder, bool RemoveTransferHM, int Generation)
        {
            List<int> r = new List<int>();
            if (LVL)
                r.AddRange(MoveLevelUp.GetMovesLevelUp(pkm, species, minlvlG1, minlvlG2, lvl, form, Version, MoveReminder, Generation));
            if (Machine)
                r.AddRange(MoveTechnicalMachine.GetTMHM(pkm, species, form, Generation, Version, RemoveTransferHM));
            if (moveTutor)
                r.AddRange(MoveTutor.GetTutorMoves(pkm, species, form, specialTutors, Generation));
            return r.Distinct();
        }

        internal static bool IsTradedKadabraG1(PKM pkm)
        {
            if (!(pkm is PK1 pk1) || pk1.Species != 64)
                return false;
            if (pk1.TradebackStatus == TradebackType.WasTradeback)
                return true;
            if (Savegame_Version == GameVersion.Any)
                return false;
            var IsYellow = Savegame_Version == GameVersion.YW;
            if (pk1.TradebackStatus == TradebackType.Gen1_NotTradeback)
            {
                // If catch rate is Abra catch rate it wont trigger as invalid trade without evolution, it could be traded as Abra
                var catch_rate = pk1.Catch_Rate;
                // Yellow Kadabra catch rate in Red/Blue game, must be Alakazam
                if (!IsYellow && catch_rate == PersonalTable.Y[64].CatchRate)
                    return true;
                // Red/Blue Kadabra catch rate in Yellow game, must be Alakazam
                if (IsYellow && catch_rate == PersonalTable.RB[64].CatchRate)
                    return true;
            }
            if (IsYellow)
                return false;
            // Yellow only moves in Red/Blue game, must be Alakazam
            if (pk1.Moves.Contains(134)) // Kinesis, yellow only move
                return true;
            if (pk1.CurrentLevel < 20 && pkm.Moves.Contains(50)) // Obtaining Disable below level 20 implies a yellow only move
                return true;

            return false;
        }
        internal static bool IsOutsider(PKM pkm)
        {
            if (Savegame_Version == GameVersion.Any)
                return false;
            var Outsider = Savegame_TID != pkm.TID || Savegame_OT != pkm.OT_Name;
            if (pkm.Format <= 2)
                return Outsider;
            Outsider |= Savegame_SID != pkm.SID;
            if (pkm.Format == 3) // Generation 3 does not check ot geneder nor pokemon version
                return Outsider;
            Outsider |= Savegame_Gender != pkm.OT_Gender || Savegame_Version != (GameVersion)pkm.Version;
            return Outsider;
        }

        internal const GameVersion NONE = GameVersion.Invalid;
        internal static readonly LearnVersion LearnNONE = new LearnVersion(-1);

        internal static bool HasVisitedB2W2(this PKM pkm) => pkm.InhabitedGeneration(5);
        internal static bool HasVisitedORAS(this PKM pkm) => pkm.InhabitedGeneration(6) && (pkm.AO || !pkm.IsUntraded);
        internal static bool HasVisitedUSUM(this PKM pkm) => pkm.InhabitedGeneration(7) && (pkm.USUM || !pkm.IsUntraded);
        internal static bool IsMovesetRestricted(this PKM pkm) => pkm.IsUntraded;

        internal static bool CanInhabitGen1(this PKM pkm)
        {
            // Korean Gen2 games can't tradeback because there are no Gen1 Korean games released
            if (pkm.Korean || pkm.IsEgg)
                return false;
            if (pkm is PK2 pk2 && pk2.CaughtData != 0)
                return false;
            int species = pkm.Species;
            if (species > MaxSpeciesID_1 && !FutureEvolutionsGen1.Contains(species))
                return false;
            return true;
        }

        public static LanguageID GetSafeLanguage(int generation, LanguageID prefer, GameVersion game = GameVersion.Any)
        {
            switch (generation)
            {
                case 1:
                case 2:
                    if (Languages_GB.Contains((int)prefer) && (prefer != LanguageID.Korean || game == GameVersion.C))
                        return prefer;
                    return LanguageID.English;
                case 3:
                    if (Languages_3.Contains((int)prefer))
                        return prefer;
                    return LanguageID.English;
                case 4:
                case 5:
                case 6:
                    if (Languages_46.Contains((int)prefer))
                        return prefer;
                    return LanguageID.English;
                default:
                    if (Languages_7.Contains((int)prefer))
                        return prefer;
                    return LanguageID.English;
            }
        }

        public static bool HasMetLocationUpdatedTransfer(int originalGeneration, int currentGeneration)
        {
            if (originalGeneration < 3)
                return currentGeneration >= 3;
            if (originalGeneration <= 4)
                return currentGeneration != originalGeneration;
            return false;
        }

        public static bool IsValidMissingLanguage(PKM pkm)
        {
            return pkm.Format == 5 && pkm.BW;
        }

        public static string GetG1OT_GFMew(int lang) => lang == (int)LanguageID.Japanese ? "ゲーフリ" : "GF";
        public static string GetG5OT_NSparkle(int lang) => lang == (int)LanguageID.Japanese ? "Ｎ" : "N";
    }
}
