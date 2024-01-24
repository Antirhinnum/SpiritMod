using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace SpiritMod.Tiles.Furniture.Paintings
{
	public class TheBadPainting : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;

			TileID.Sets.FramesOnKillWall[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.AnchorBottom = default;
			TileObjectData.newTile.AnchorTop = default;
			TileObjectData.newTile.AnchorWall = true;
			TileObjectData.addTile(Type);
			DustType = DustID.WoodFurniture;
			AddMapEntry(new Color(23, 23, 23), Language.GetText("MapObject.Painting"));
		}

		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 3 : 10;
	}
}