exec("./projectiledecay.cs");
exec("./oncollision.cs");
exec("./onmovetocomplete.cs");
exec("./skill_sinevolley.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");

function SineVolley::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Shell the target with a volley of radiation that moves in waves.");
SineVolley.setskillbaricon(%slot);
}

function SineVolley::onlevelload(%this)
{
echo("loaded sinevolley projectiles");

SineVolley.projectileass=AssetDatabase.acquireAsset("SineVolley:image_projectile");
SineVolley.explosionass=AssetDatabase.acquireAsset("SineVolley:image_explosion");

SineVolley.vectortable=new SimSet();

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

%wavevectors=new SimSet();

%freq=8;
%amp=30;
%phase=0;

///////////////////////////////
%dx=%dest.X-%cx;
%dy=%dest.Y-%cy;
%l=mSqrt(%dx*%dx+%dy*%dy);

%nx=%amp*%dy/%l;
%ny=%amp*-%dx/%l;

%tstep=1.0/(%l/35);//dividing by a lower number makes smoother sinoids, higher faster

for (%t=0;%t<=1.0;%t+=%tstep)
{
%a=mSin(%phase+(2*$pie)*%t*%freq);
%xval=%cx+%t*%dx+%nx*%a;
%yval=%cy+%t*%dy+%ny*%a;
%tmpvec="0 0";%tmpvec.X=%xval;%tmpvec.Y=%yval;
%tmpvec=ScaleVectorToCam(%tmpvec);
%vector=new ScriptObject()
{
x=%tmpvec.X;
y=%tmpvec.Y;
};
%wavevectors.add(%vector);
}

SineVolley.vectortable.add(%wavevectors);

}

}

function SineVolley::create(%this)
{
echo("created SineVolley");
}

function SineVolley::destroy(%this)
{
echo("deleted SineVolley");
}

function SineVolley::unloadskill(%this)
{
echo("unloaded SineVolley");

AssetDatabase.releaseAsset(SineVolley.projectileass.getAssetId());
AssetDatabase.releaseAsset(SineVolley.explosionass.getAssetId());

for (%x=0;%x<SineVolley.vectortable.getCount();%x++)
{
%vecset=SineVolley.vectortable.getObject(%x);
%vecset.deleteObjects();
}
SineVolley.vectortable.deleteObjects();
SineVolley.vectortable.delete();
}

function SineVolley::transformobjects(%this,%playerindex)
{
return;
}
