using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SpiritMod.Tiles.MusicBox
{
	internal class SpiritBox1 : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileObsidianKill[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(Type);
			TileID.Sets.DisableSmartCursor[Type] = true;

			AddMapEntry(new Color(200, 200, 200), Language.GetText("ItemName.MusicBox"));
			RegisterItemDrop(ModContent.ItemType<Items.Placeable.MusicBox.SpiritBox1>());
			DustType = -1;
        }

		public override void MouseOver(int i, int j)
		{
			Player player = Main.LocalPlayer;
			player.noThrow = 2;
			player.cursorItemIconEnabled = true;
			player.cursorItemIconID = ModContent.ItemType<Items.Placeable.MusicBox.SpiritBox1>();
		}

		public override bool CanDrop(int i, int j) => false;

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
			=> Item.NewItem(null, new Rectangle(i * 16, j * 16, 32, 32), new Item(ModContent.ItemType<Items.Placeable.MusicBox.SpiritBox1>()), false, true);
		//Spawn in the drop manually to prevent a random prefix
	}
}
