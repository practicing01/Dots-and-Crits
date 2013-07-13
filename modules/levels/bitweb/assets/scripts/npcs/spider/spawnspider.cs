function bitweb::spawnspider(%this)
{
%player1=$players.getObject(0);
%player2=$players.getObject(1);

%spider=new Sprite()
{
Position="0 0";
Size=ScaleAssSizeVectorToCam(%this.spiderass);
Image="bitweb:image_bitspider";
SceneLayer=16;
GravityScale=0;
SceneGroup=25;//npc
class="class_bitspider";
parentbitweb=%this;
curdir=1;//0=up,1=down,2=left,3=right
schedule_moveto=0;
FixedAngle=true;
ismoving=false;
};

%spider.playAnimation("bitweb:anim_spider_stand_down");
while (1)
{
%spider.Position=ScalePositionVectorToCam((getRandom(0,24)*50)+25+15 SPC (getRandom(0,15)*50)+25);
if (isObject(%player1.sprite))
{

if (isObject(%player2.sprite))
{
if (%spider.Position!=%player1.sprite.Position&&%spider.Position!=%player2.sprite.Position){break;}
}
else{if (%spider.Position!=%player1.sprite.Position){break;}}

}

}

%spider.createPolygonBoxCollisionShape(%spider.Size);
%spider.setCollisionGroups(0,1,28,29);//0/1 players, 28/29 projectiles

DotsandCritsscene.add(%spider);

%this.simset_spiders.add(%spider);

}
