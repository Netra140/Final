using Facebuild.Models.Pallets;
using Facebuild.Models;
using Facebuild.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Facebuild.NeoMvc.Controllers
{
    [Authorize]
    public class PalletController : Controller
    {
        // GET: Pallet
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PalletService(userId);
            var model = service.GetPallets();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PalletCreate model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());

            var service = new PalletService(userId);

            service.CreatePallet(model,id);
            var serve = CreateBuildService();
            IEnumerable<PalletListItem> stuff = service.GetPallets().OrderByDescending(PalletListItem => PalletListItem.CreatedUtc);
            int palId = stuff.First().id;
            serve.ApplyPallet(palId,id);
            //PairBuild(id);

            return RedirectToAction("../Build/Index");
        }

        /*public ActionResult PairBuild (int BuildId)
        {
            var svc = CreatePalletService();
            var buildLnk = CreateBuildService();
            var model = svc.GetPalletById(BuildId);
            buildLnk.ApplyPallet(BuildId,model)

            return RedirectToAction("Index");
        }*/

        public ActionResult Details(int id)
        {
            var svc = CreatePalletService();
            var model = svc.GetPalletById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePalletService();
            var detail = service.GetPalletById(id);
            var model =
                new PalletEdit
                {
                    BuildId = detail.BuildId,
                    userId = detail.userId,
                    Stone = detail.Stone,
                    Granite = detail.Granite,
                    Diorite = detail.Diorite,
                    Andesite = detail.Andesite,
                    Deepslate = detail.Deepslate,
                    Calcite = detail.Calcite,
                    Tuff = detail.Tuff,
                    Dripstone = detail.Dripstone,
                    Grass = detail.Grass,
                    Dirt = detail.Dirt,
                    Podzol = detail.Podzol,
                    Warped_Nylium = detail.Warped_Nylium,
                    Crimson_Nylium = detail.Crimson_Nylium,
                    Oak = detail.Oak,
                    Spruce = detail.Spruce,
                    Birch = detail.Birch,
                    Jungle = detail.Jungle,
                    Acacia = detail.Acacia,
                    Dark_Oak = detail.Dark_Oak,
                    Mangrove = detail.Mangrove,
                    Crimson_Wood = detail.Crimson_Wood,
                    Warped_Wood = detail.Warped_Wood,
                    Bedrock = detail.Bedrock,
                    Sand = detail.Sand,
                    Red_Sand = detail.Red_Sand,
                    Gravel = detail.Gravel,
                    Stone_Ores = detail.Stone_Ores,
                    Deepslate_Ores = detail.Deepslate_Ores,
                    Nether_Ores = detail.Nether_Ores,
                    Block = detail.Block,
                    Raw_Iron = detail.Raw_Iron,
                    Raw_Copper = detail.Raw_Copper,
                    Raw_Gold = detail.Raw_Gold,
                    Amethyst = detail.Amethyst,
                    Iron = detail.Iron,
                    Gold = detail.Gold,
                    Diamond = detail.Diamond,
                    Netherite = detail.Netherite,
                    Copper = detail.Copper,
                    Exposed_Copper = detail.Exposed_Copper,
                    Weathered_Copper = detail.Weathered_Copper,
                    Oxidised = detail.Oxidised,
                    Sponge = detail.Sponge,
                    Wet_Sponged = detail.Wet_Sponged,
                    Glass = detail.Glass,
                    Tinted_Glass = detail.Tinted_Glass,
                    Lapis_Lazuli = detail.Lapis_Lazuli,
                    Sandstone = detail.Sandstone,
                    Wool = detail.Wool,
                    Smooth_Stone = detail.Smooth_Stone,
                    Bricks = detail.Bricks,
                    Bookshelf = detail.Bookshelf,
                    Mossy_Cobblestone = detail.Mossy_Cobblestone,
                    Obsidian = detail.Obsidian,
                    Purpur = detail.Purpur,
                    Ice = detail.Ice,
                    Snow = detail.Snow,
                    Clay = detail.Clay,
                    Pumpkin = detail.Pumpkin,
                    Netherrack = detail.Netherrack,
                    Soul_Sand = detail.Soul_Sand,
                    Basalt = detail.Basalt,
                    Glowstone = detail.Glowstone,
                    Stone_Brick = detail.Stone_Brick,
                    Deepslate_Brick = detail.Deepslate_Brick,
                    Melon = detail.Melon,
                    Mycelium = detail.Mycelium,
                    Nether_Bricks = detail.Nether_Bricks,
                    End_Stone = detail.End_Stone,
                    End_Stone_Brick = detail.End_Stone_Brick,
                    Emerald = detail.Emerald,
                    Quartz = detail.Quartz,
                    Terracotta = detail.Terracotta,
                    Hay_Bale = detail.Hay_Bale,
                    Packed_Ice = detail.Packed_Ice,
                    Stained_Glass = detail.Stained_Glass,
                    Prismarine = detail.Prismarine,
                    Prismarine_Brick = detail.Prismarine_Brick,
                    Dark_Prismarine = detail.Dark_Prismarine,
                    Sea_Lantern = detail.Sea_Lantern,
                    Magma_Block = detail.Magma_Block,
                    Nether_Wart = detail.Nether_Wart,
                    Red_Nether_Brick = detail.Red_Nether_Brick,
                    Bone_Block = detail.Bone_Block,
                    Concrete = detail.Concrete,
                    Concrete_Powder = detail.Concrete_Powder,
                    Coral = detail.Coral,
                    Blue_Ice = detail.Blue_Ice,
                    Dried_Kelp = detail.Dried_Kelp,
                    Crying_Obsidian = detail.Crying_Obsidian,
                    Blackstone = detail.Blackstone
                };
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePalletService();
            var model = svc.GetPalletById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePalletService();
            service.DeletePallet(id);
            TempData["SaveResult"] = "Your Pallet was deleted";
            return RedirectToAction("../Build");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PalletEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePalletService();/*
            var bServe = service.GetBuildService(Guid.Parse(User.Identity.GetUserId()));
            var builds = bServe.GetBuilds();
            int bId = -1;
            for (int i = 0; i < builds.Count(); i++)
            {
                if (bServe.GetBuildById(i))
                {

                }
            }*/

            if (service.UpdatePallet(model))
            {
                TempData["SaveResult"] = "Your Pallet was updated.";
                return RedirectToAction("../Build/");
            }

            ModelState.AddModelError("", "Your Pallet could not be updated.");
            return View();
        }

        private PalletService CreatePalletService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PalletService(userId);
            return service;
        }

        private BuildService CreateBuildService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BuildService(userId);
            return service;
        }

    }
}
