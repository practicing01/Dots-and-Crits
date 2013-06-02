exec("./projectiledecay.cs");
exec("./oncollision.cs");
exec("./onmovetocomplete.cs");
exec("./skill_volley.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");

function Volley::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Shell the target with a volley of radiation.");
Volley.setskillbaricon(%slot);
}

function Volley::onlevelload(%this)
{
echo("loaded Volley projectiles");

Volley.projectileass=AssetDatabase.acquireAsset("Volley:image_projectile");
Volley.explosionass=AssetDatabase.acquireAsset("Volley:image_explosion");

Volley.vectortable=new SimSet();

%degree=0;
%pos="0 0";
%dest="0 0";

for (%x=0;%x<=360;%x++)
{
%degree=%x;

%cx=%pos.X;
%cy=%pos.Y;

%c=mCos(mDegToRad(%degree));
%s=mSin(mDegToRad(%degree));

%dest="0 0";
%dest.X=%pos.X;
%dest.Y=%pos.Y+$resolution.Y;

%dest.X-=%pos.X;
%dest.Y-=%pos.Y;
%xval=%dest.X*%c-%dest.Y*%s;
%yval=%dest.X*%s+%dest.Y*%c;
%dest.X=%xval+%pos.X;
%dest.Y=%yval+%pos.Y;

%dest=ScaleVectorToCam(%dest);
%vector=new SimObject()
{
x=%dest.X;
y=%dest.Y;
};
Volley.vectortable.add(%vector);

}

}

function Volley::create(%this)
{
echo("created Volley");
}

function Volley::destroy(%this)
{
echo("deleted Volley");
}

function Volley::unloadskill(%this)
{
echo("unloaded Volley");

AssetDatabase.releaseAsset(Volley.projectileass.getAssetId());
AssetDatabase.releaseAsset(Volley.explosionass.getAssetId());

Volley.vectortable.deleteObjects();
Volley.vectortable.delete();
}

function Volley::transformobjects(%this,%playerindex)
{
return;
}
