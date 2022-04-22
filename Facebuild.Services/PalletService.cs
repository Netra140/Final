using Facebuild.Data;
using Facebuild.Data.Pallets;
using Facebuild.Models.Pallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebuild.Services
{
    public class PalletService
    {
        private Guid _userId;

        public BuildService GetBuildService (Guid userId)
        {
            var serve = new BuildService(userId);
            return serve;
        }

        public PalletService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePallet(PalletCreate model, int palletId)
        {
            var entity =
                new Pallet()
                {
                    id = palletId,
                    CreatedUtc = DateTimeOffset.Now,
                    BuildId = model.BuildId,
        userId = _userId,
        Stone = model.Stone,
        Granite = model.Granite,
        Diorite = model.Diorite,
        Andesite = model.Andesite,
        Deepslate = model.Deepslate,
        Calcite = model.Calcite,
        Tuff = model.Tuff,
        Dripstone = model.Dripstone,
        Grass = model.Grass,
        Dirt = model.Dirt,
        Podzol = model.Podzol,
        Warped_Nylium = model.Warped_Nylium,
        Crimson_Nylium = model.Crimson_Nylium,
        Oak = model.Oak,
        Spruce = model.Spruce,
        Birch = model.Birch,
        Jungle = model.Jungle,
        Acacia = model.Acacia,
        Dark_Oak = model.Dark_Oak,
        Mangrove = model.Mangrove,
        Crimson_Wood = model.Crimson_Wood,
        Warped_Wood = model.Warped_Wood,
        Bedrock = model.Bedrock,
        Sand = model.Sand,
        Red_Sand = model.Red_Sand,
        Gravel = model.Gravel,
        Stone_Ores = model.Stone_Ores,
        Deepslate_Ores = model.Deepslate_Ores,
        Nether_Ores = model.Nether_Ores,
        Block = model.Block,
        Raw_Iron = model.Raw_Iron,
        Raw_Copper = model.Raw_Copper,
        Raw_Gold = model.Raw_Gold,
        Amethyst = model.Amethyst,
        Iron = model.Iron,
        Gold = model.Gold,
        Diamond = model.Diamond,
        Netherite = model.Netherite,
        Copper = model.Copper,
        Exposed_Copper = model.Exposed_Copper,
        Weathered_Copper = model.Weathered_Copper,
        Oxidised = model.Oxidised,
        Sponge = model.Sponge,
        Wet_Sponged = model.Wet_Sponged,
        Glass = model.Glass,
        Tinted_Glass = model.Tinted_Glass,
        Lapis_Lazuli = model.Lapis_Lazuli,
        Sandstone = model.Sandstone,
        Wool = model.Wool,
        Smooth_Stone = model.Smooth_Stone,
        Bricks = model.Bricks,
        Bookshelf = model.Bookshelf,
        Mossy_Cobblestone = model.Mossy_Cobblestone,
        Obsidian = model.Obsidian,
        Purpur = model.Purpur,
        Ice = model.Ice,
        Snow = model.Snow,
        Clay = model.Clay,
        Pumpkin = model.Pumpkin,
        Netherrack = model.Netherrack,
        Soul_Sand = model.Soul_Sand,
        Basalt = model.Basalt,
        Glowstone = model.Glowstone,
        Stone_Brick = model.Stone_Brick,
        Deepslate_Brick = model.Deepslate_Brick,
        Melon = model.Melon,
        Mycelium = model.Mycelium,
        Nether_Bricks = model.Nether_Bricks,
        End_Stone = model.End_Stone,
        End_Stone_Brick = model.End_Stone_Brick,
        Emerald = model.Emerald,
        Quartz = model.Quartz,
        Terracotta = model.Terracotta,
        Hay_Bale = model.Hay_Bale,
        Packed_Ice = model.Packed_Ice,
        Stained_Glass = model.Stained_Glass,
        Prismarine = model.Prismarine,
        Prismarine_Brick = model.Prismarine_Brick,
        Dark_Prismarine = model.Dark_Prismarine,
        Sea_Lantern = model.Sea_Lantern,
        Magma_Block = model.Magma_Block,
        Nether_Wart = model.Nether_Wart,
        Red_Nether_Brick = model.Red_Nether_Brick,
        Bone_Block = model.Bone_Block,
        Concrete = model.Concrete,
        Concrete_Powder = model.Concrete_Powder,
        Coral = model.Coral,
        Blue_Ice = model.Blue_Ice,
        Dried_Kelp = model.Dried_Kelp,
        Crying_Obsidian = model.Crying_Obsidian,
        Blackstone = model.Blackstone
    };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Pallet.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePallet(int PalletId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Pallet
                        .Single(e => e.id == PalletId && e.userId == _userId);

                ctx.Pallet.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PalletListItem> GetPallets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Pallet
                        .Where(e => e.userId == _userId)
                        .Select(
                            e =>
                                    new PalletListItem
                                    {
                                        id = e.id,
                                        BuildId = e.BuildId,
                                        CreatedUtc = e.CreatedUtc,
                                        userId = e.userId,
                                        Stone = e.Stone,
                                        Granite = e.Granite,
                                        Diorite = e.Diorite,
                                        Andesite = e.Andesite,
                                        Deepslate = e.Deepslate,
                                        Calcite = e.Calcite,
                                        Tuff = e.Tuff,
                                        Dripstone = e.Dripstone,
                                        Grass = e.Grass,
                                        Dirt = e.Dirt,
                                        Podzol = e.Podzol,
                                        Warped_Nylium = e.Warped_Nylium,
                                        Crimson_Nylium = e.Crimson_Nylium,
                                        Oak = e.Oak,
                                        Spruce = e.Spruce,
                                        Birch = e.Birch,
                                        Jungle = e.Jungle,
                                        Acacia = e.Acacia,
                                        Dark_Oak = e.Dark_Oak,
                                        Mangrove = e.Mangrove,
                                        Crimson_Wood = e.Crimson_Wood,
                                        Warped_Wood = e.Warped_Wood,
                                        Bedrock = e.Bedrock,
                                        Sand = e.Sand,
                                        Red_Sand = e.Red_Sand,
                                        Gravel = e.Gravel,
                                        Stone_Ores = e.Stone_Ores,
                                        Deepslate_Ores = e.Deepslate_Ores,
                                        Nether_Ores = e.Nether_Ores,
                                        Block = e.Block,
                                        Raw_Iron = e.Raw_Iron,
                                        Raw_Copper = e.Raw_Copper,
                                        Raw_Gold = e.Raw_Gold,
                                        Amethyst = e.Amethyst,
                                        Iron = e.Iron,
                                        Gold = e.Gold,
                                        Diamond = e.Diamond,
                                        Netherite = e.Netherite,
                                        Copper = e.Copper,
                                        Exposed_Copper = e.Exposed_Copper,
                                        Weathered_Copper = e.Weathered_Copper,
                                        Oxidised = e.Oxidised,
                                        Sponge = e.Sponge,
                                        Wet_Sponged = e.Wet_Sponged,
                                        Glass = e.Glass,
                                        Tinted_Glass = e.Tinted_Glass,
                                        Lapis_Lazuli = e.Lapis_Lazuli,
                                        Sandstone = e.Sandstone,
                                        Wool = e.Wool,
                                        Smooth_Stone = e.Smooth_Stone,
                                        Bricks = e.Bricks,
                                        Bookshelf = e.Bookshelf,
                                        Mossy_Cobblestone = e.Mossy_Cobblestone,
                                        Obsidian = e.Obsidian,
                                        Purpur = e.Purpur,
                                        Ice = e.Ice,
                                        Snow = e.Snow,
                                        Clay = e.Clay,
                                        Pumpkin = e.Pumpkin,
                                        Netherrack = e.Netherrack,
                                        Soul_Sand = e.Soul_Sand,
                                        Basalt = e.Basalt,
                                        Glowstone = e.Glowstone,
                                        Stone_Brick = e.Stone_Brick,
                                        Deepslate_Brick = e.Deepslate_Brick,
                                        Melon = e.Melon,
                                        Mycelium = e.Mycelium,
                                        Nether_Bricks = e.Nether_Bricks,
                                        End_Stone = e.End_Stone,
                                        End_Stone_Brick = e.End_Stone_Brick,
                                        Emerald = e.Emerald,
                                        Quartz = e.Quartz,
                                        Terracotta = e.Terracotta,
                                        Hay_Bale = e.Hay_Bale,
                                        Packed_Ice = e.Packed_Ice,
                                        Stained_Glass = e.Stained_Glass,
                                        Prismarine = e.Prismarine,
                                        Prismarine_Brick = e.Prismarine_Brick,
                                        Dark_Prismarine = e.Dark_Prismarine,
                                        Sea_Lantern = e.Sea_Lantern,
                                        Magma_Block = e.Magma_Block,
                                        Nether_Wart = e.Nether_Wart,
                                        Red_Nether_Brick = e.Red_Nether_Brick,
                                        Bone_Block = e.Bone_Block,
                                        Concrete = e.Concrete,
                                        Concrete_Powder = e.Concrete_Powder,
                                        Coral = e.Coral,
                                        Blue_Ice = e.Blue_Ice,
                                        Dried_Kelp = e.Dried_Kelp,
                                        Crying_Obsidian = e.Crying_Obsidian,
                                        Blackstone = e.Blackstone
                                    }
                               );
                return query.ToArray();
            }
        }

        public bool UpdatePallet(PalletEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Pallet
                        .Single(e => e.id == model.id && e.userId == _userId);

                entity.id = model.id;
        //entity.BuildId = model.BuildId;
        entity.userId = _userId;
        entity.Stone = model.Stone;
        entity.Granite = model.Granite;
        entity.Diorite = model.Diorite;
                entity.Andesite = model.Andesite;
        entity.Deepslate = model.Deepslate;
        entity.Calcite = model.Calcite;
        entity.Tuff = model.Tuff;
        entity.Dripstone = model.Dripstone;
        entity.Grass = model.Grass;
                entity.Dirt = model.Dirt;
        entity.Podzol = model.Podzol;
        entity.Warped_Nylium = model.Warped_Nylium;
        entity.Crimson_Nylium = model.Crimson_Nylium;
        entity.Oak = model.Oak;
                entity.Spruce = model.Spruce;
        entity.Birch = model.Birch;
        entity.Jungle = model.Jungle;
        entity.Acacia = model.Acacia;
        entity.Dark_Oak = model.Dark_Oak;
        entity.Mangrove = model.Mangrove;
        entity.Crimson_Wood = model.Crimson_Wood;
        entity.Warped_Wood = model.Warped_Wood;
        entity.Bedrock = model.Bedrock;
        entity.Sand = model.Sand;
        entity.Red_Sand = model.Red_Sand;
        entity.Gravel = model.Gravel;
        entity.Stone_Ores = model.Stone_Ores;
        entity.Deepslate_Ores = model.Deepslate_Ores;
        entity.Nether_Ores = model.Nether_Ores;
        entity.Block = model.Block;
        entity.Raw_Iron = model.Raw_Iron;
                entity.Raw_Copper = model.Raw_Copper;
                entity.Raw_Gold = model.Raw_Gold;
        entity.Amethyst = model.Amethyst;
        entity.Iron = model.Iron;
        entity.Gold = model.Gold;
        entity.Diamond = model.Diamond;
        entity.Netherite = model.Netherite;
        entity.Copper = model.Copper;
        entity.Exposed_Copper = model.Exposed_Copper;
                entity.Weathered_Copper = model.Weathered_Copper;
        entity.Oxidised = model.Oxidised;
        entity.Sponge = model.Sponge;
        entity.Wet_Sponged = model.Wet_Sponged;
        entity.Glass = model.Glass;
        entity.Tinted_Glass = model.Tinted_Glass;
        entity.Lapis_Lazuli = model.Lapis_Lazuli;
        entity.Sandstone = model.Sandstone;
        entity.Wool = model.Wool;
        entity.Smooth_Stone = model.Smooth_Stone;
                entity.Bricks = model.Bricks;
        entity.Bookshelf = model.Bookshelf;
        entity.Mossy_Cobblestone = model.Mossy_Cobblestone;
        entity.Obsidian = model.Obsidian;
        entity.Purpur = model.Purpur;
        entity.Ice = model.Ice;
                entity.Snow = model.Snow;
        entity.Clay = model.Clay;
        entity.Pumpkin = model.Pumpkin;
        entity.Netherrack = model.Netherrack;
        entity.Soul_Sand = model.Soul_Sand;
                entity.Basalt = model.Basalt;
        entity.Glowstone = model.Glowstone;
        entity.Stone_Brick = model.Stone_Brick;
        entity.Deepslate_Brick = model.Deepslate_Brick;
        entity.Melon = model.Melon;
        entity.Mycelium = model.Mycelium;
        entity.Nether_Bricks = model.Nether_Bricks;
        entity.End_Stone = model.End_Stone;
        entity.End_Stone_Brick = model.End_Stone_Brick;
        entity.Emerald = model.Emerald;
        entity.Quartz = model.Quartz;
        entity.Terracotta = model.Terracotta;
        entity.Hay_Bale = model.Hay_Bale;
                entity.Packed_Ice = model.Packed_Ice;
        entity.Stained_Glass = model.Stained_Glass;
        entity.Prismarine = model.Prismarine;
        entity.Prismarine_Brick = model.Prismarine_Brick;
        entity.Dark_Prismarine = model.Dark_Prismarine;
        entity.Sea_Lantern = model.Sea_Lantern;
        entity.Magma_Block = model.Magma_Block;
        entity.Nether_Wart = model.Nether_Wart;
        entity.Red_Nether_Brick = model.Red_Nether_Brick;
        entity.Bone_Block = model.Bone_Block;
        entity.Concrete = model.Concrete;
        entity.Concrete_Powder = model.Concrete_Powder;
        entity.Coral = model.Coral;
        entity.Blue_Ice = model.Blue_Ice;
        entity.Dried_Kelp = model.Dried_Kelp;
        entity.Crying_Obsidian = model.Crying_Obsidian;
        entity.Blackstone = model.Blackstone;

                return ctx.SaveChanges() == 1;
            }
        }

        public PalletDetail GetPalletById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Pallet
                        .Single(e => e.id == id && e.userId == _userId);
                return
                    new PalletDetail
                    {
                        //id = entity.id,
                        BuildId = entity.BuildId,
                        userId = entity.userId,
                        Stone = entity.Stone,
                        Granite = entity.Granite,
                        Diorite = entity.Diorite,
                        Andesite = entity.Andesite,
                        Deepslate = entity.Deepslate,
                        Calcite = entity.Calcite,
                        Tuff = entity.Tuff,
                        Dripstone = entity.Dripstone,
                        Grass = entity.Grass,
                        Dirt = entity.Dirt,
                        Podzol = entity.Podzol,
                        Warped_Nylium = entity.Warped_Nylium,
                        Crimson_Nylium = entity.Crimson_Nylium,
                        Oak = entity.Oak,
                        Spruce = entity.Spruce,
                        Birch = entity.Birch,
                        Jungle = entity.Jungle,
                        Acacia = entity.Acacia,
                        Dark_Oak = entity.Dark_Oak,
                        Mangrove = entity.Mangrove,
                        Crimson_Wood = entity.Crimson_Wood,
                        Warped_Wood = entity.Warped_Wood,
                        Bedrock = entity.Bedrock,
                        Sand = entity.Sand,
                        Red_Sand = entity.Red_Sand,
                        Gravel = entity.Gravel,
                        Stone_Ores = entity.Stone_Ores,
                        Deepslate_Ores = entity.Deepslate_Ores,
                        Nether_Ores = entity.Nether_Ores,
                        Block = entity.Block,
                        Raw_Iron = entity.Raw_Iron,
                        Raw_Copper = entity.Raw_Copper,
                        Raw_Gold = entity.Raw_Gold,
                        Amethyst = entity.Amethyst,
                        Iron = entity.Iron,
                        Gold = entity.Gold,
                        Diamond = entity.Diamond,
                        Netherite = entity.Netherite,
                        Copper = entity.Copper,
                        Exposed_Copper = entity.Exposed_Copper,
                        Weathered_Copper = entity.Weathered_Copper,
                        Oxidised = entity.Oxidised,
                        Sponge = entity.Sponge,
                        Wet_Sponged = entity.Wet_Sponged,
                        Glass = entity.Glass,
                        Tinted_Glass = entity.Tinted_Glass,
                        Lapis_Lazuli = entity.Lapis_Lazuli,
                        Sandstone = entity.Sandstone,
                        Wool = entity.Wool,
                        Smooth_Stone = entity.Smooth_Stone,
                        Bricks = entity.Bricks,
                        Bookshelf = entity.Bookshelf,
                        Mossy_Cobblestone = entity.Mossy_Cobblestone,
                        Obsidian = entity.Obsidian,
                        Purpur = entity.Purpur,
                        Ice = entity.Ice,
                        Snow = entity.Snow,
                        Clay = entity.Clay,
                        Pumpkin = entity.Pumpkin,
                        Netherrack = entity.Netherrack,
                        Soul_Sand = entity.Soul_Sand,
                        Basalt = entity.Basalt,
                        Glowstone = entity.Glowstone,
                        Stone_Brick = entity.Stone_Brick,
                        Deepslate_Brick = entity.Deepslate_Brick,
                        Melon = entity.Melon,
                        Mycelium = entity.Mycelium,
                        Nether_Bricks = entity.Nether_Bricks,
                        End_Stone = entity.End_Stone,
                        End_Stone_Brick = entity.End_Stone_Brick,
                        Emerald = entity.Emerald,
                        Quartz = entity.Quartz,
                        Terracotta = entity.Terracotta,
                        Hay_Bale = entity.Hay_Bale,
                        Packed_Ice = entity.Packed_Ice,
                        Stained_Glass = entity.Stained_Glass,
                        Prismarine = entity.Prismarine,
                        Prismarine_Brick = entity.Prismarine_Brick,
                        Dark_Prismarine = entity.Dark_Prismarine,
                        Sea_Lantern = entity.Sea_Lantern,
                        Magma_Block = entity.Magma_Block,
                        Nether_Wart = entity.Nether_Wart,
                        Red_Nether_Brick = entity.Red_Nether_Brick,
                        Bone_Block = entity.Bone_Block,
                        Concrete = entity.Concrete,
                        Concrete_Powder = entity.Concrete_Powder,
                        Coral = entity.Coral,
                        Blue_Ice = entity.Blue_Ice,
                        Dried_Kelp = entity.Dried_Kelp,
                        Crying_Obsidian = entity.Crying_Obsidian,
                        Blackstone = entity.Blackstone
                    };
            }
        }
    }
}
