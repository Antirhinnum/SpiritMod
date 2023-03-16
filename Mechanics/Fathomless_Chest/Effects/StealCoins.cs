using SpiritMod.Mechanics.Fathomless_Chest.Entities;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Mechanics.Fathomless_Chest.Effects
{
	public class StealCoins : ChanceEffect
	{
		public override bool Unlucky => true;

		public override void Effects(Player player, Point16 tileCoords, IEntitySource source)
		{
			int id = NPC.NewNPC(source, (tileCoords.X * 16) + 16, (tileCoords.Y * 16) + 47, ModContent.NPCType<Fathomless_Chest_Mimic>());

			if (Main.netMode == NetmodeID.MultiplayerClient)
				NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, id);
		}

		public override void OnKillVase(Player player, Point16 tileCoords, IEntitySource source) => SoundEngine.PlaySound(SoundID.NPCDeath33, tileCoords.ToVector2() * 16);
	}
}