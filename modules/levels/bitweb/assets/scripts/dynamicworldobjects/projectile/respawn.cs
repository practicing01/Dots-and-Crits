function class_bitwebprojectile::respawn(%this)
{

%this.Visible=true;
%this.used=false;
//%this.setCollisionSuppress(false);
//%this.createPolygonBoxCollisionShape(%this.Size);
%this.Position=ScalePositionVectorToCam((getRandom(0,24)*50)+25+15 SPC (getRandom(0,15)*50)+25);

%this.schedule_respawnprojectile.schedulehandle=schedule(20000,0,"class_bitwebprojectile::respawn",%this);
}
