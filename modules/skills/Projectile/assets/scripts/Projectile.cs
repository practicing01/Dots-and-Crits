exec("./projectiledecay.cs");
exec("./oncollision.cs");
exec("./onmovetocomplete.cs");
exec("./skill_projectile.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");

function Projectile::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Shell the target with a Projectile of radiation.");
Projectile.setskillbaricon(%slot);
}

function Projectile::onlevelload(%this)
{
echo("loaded Projectile projectiles");

Projectile.top_projectileass=AssetDatabase.acquireAsset("Projectile:image_topdown_projectile");
Projectile.top_explosionass=AssetDatabase.acquireAsset("Projectile:image_topdown_explosion");

Projectile.side_projectileass=AssetDatabase.acquireAsset("Projectile:image_sideview_projectile");
Projectile.side_explosionass=AssetDatabase.acquireAsset("Projectile:image_sideview_explosion");

}

function Projectile::create(%this)
{
echo("created Projectile");
}

function Projectile::destroy(%this)
{
echo("deleted Projectile");
}

function Projectile::unloadskill(%this)
{
echo("unloaded Projectile");

AssetDatabase.releaseAsset(Projectile.top_projectileass.getAssetId());
AssetDatabase.releaseAsset(Projectile.top_explosionass.getAssetId());

AssetDatabase.releaseAsset(Projectile.side_projectileass.getAssetId());
AssetDatabase.releaseAsset(Projectile.side_explosionass.getAssetId());

}

function Projectile::transformobjects(%this,%playerindex)
{
return;
}
