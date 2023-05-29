using SpiritMod.Tiles.Furniture.NeonLights;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.Items.Material;

namespace SpiritMod.Items.Placeable.Furniture.Neon
{
	[Sacrifice(1)]
	public class NeonCandleGreen : ModItem
	{
		public override void SetStaticDefaults() => DisplayName.SetDefault("Green Neon Candle");

		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 28;
			Item.value = Item.value = Item.buyPrice(0, 0, 1, 0);
			Item.rare = ItemRarityID.Blue;
			Item.maxStack = 99;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
			Item.useAnimation = 15;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<GreenNeonCandle>();
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(3);
            recipe.AddIngredient(ModContent.ItemType<Tiles.TechBlockItem>(), 2);
            recipe.AddIngredient(ModContent.ItemType<SynthMaterial>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}