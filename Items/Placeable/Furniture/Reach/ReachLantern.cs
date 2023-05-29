using SpiritMod.Items.Sets.HuskstalkSet;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ReachLanternTile = SpiritMod.Tiles.Furniture.Reach.ReachLanternTile;

namespace SpiritMod.Items.Placeable.Furniture.Reach
{
	[Sacrifice(1)]
	public class ReachLantern : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elderbark Lantern");
		}


		public override void SetDefaults()
		{
			Item.width = 64;
			Item.height = 34;
			Item.value = 150;

			Item.maxStack = 99;

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
			Item.useAnimation = 15;

			Item.useTurn = true;
			Item.autoReuse = true;
			Item.consumable = true;

			Item.createTile = ModContent.TileType<ReachLanternTile>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<AncientBark>(), 4);
			recipe.AddIngredient(ItemID.Torch, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}