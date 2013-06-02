exec("./ScatterVolleydecay.cs");
exec("./oncollision.cs");
exec("./onmovetocomplete.cs");
exec("./skill_ScatterVolley.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");

function ScatterVolley::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Shell the target with a ScatterVolley of radiation.");
ScatterVolley.setskillbaricon(%slot);
}

function ScatterVolley::onlevelload(%this)
{
echo("loaded ScatterVolley ScatterVolleys");

ScatterVolley.top_projectileass=AssetDatabase.acquireAsset("ScatterVolley:image_topdown_ScatterVolley");
ScatterVolley.top_explosionass=AssetDatabase.acquireAsset("ScatterVolley:image_topdown_explosion");

ScatterVolley.side_projectileass=AssetDatabase.acquireAsset("ScatterVolley:image_sideview_ScatterVolley");
ScatterVolley.side_explosionass=AssetDatabase.acquireAsset("ScatterVolley:image_sideview_explosion");

ScatterVolley.vectortable=new SimSet();

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
ScatterVolley.vectortable.add(%vector);

}

}

function ScatterVolley::create(%this)
{
echo("created ScatterVolley");
}

function ScatterVolley::destroy(%this)
{
echo("deleted ScatterVolley");
}

function ScatterVolley::unloadskill(%this)
{
echo("unloaded ScatterVolley");

AssetDatabase.releaseAsset(ScatterVolley.top_projectileass.getAssetId());
AssetDatabase.releaseAsset(ScatterVolley.top_explosionass.getAssetId());

AssetDatabase.releaseAsset(ScatterVolley.side_projectileass.getAssetId());
AssetDatabase.releaseAsset(ScatterVolley.side_explosionass.getAssetId());

ScatterVolley.vectortable.deleteObjects();
ScatterVolley.vectortable.delete();
}

function ScatterVolley::transformobjects(%this,%playerindex)
{
return;
}
