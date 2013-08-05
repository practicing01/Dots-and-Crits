$player_to_load=0;
$numofplayers=2;
$players=new SimSet();
$player1menuiconsprite=0;
$player2menuiconsprite=0;

$player1activeskillbarnibble=0;
$player2activeskillbarnibble=0;

$normalplayerspeed=5;

for (%x=0;%x<$numofplayers;%x++)
{
%player=new ScriptObject()
{
//sprite related
sprite=0;
menusprite=0;
spritepath=0;
spriteid=0;//self composite sprite id

anim_stand_up=0;
anim_stand_down=0;
anim_stand_left=0;
anim_stand_right=0;
anim_run_up=0;
anim_run_down=0;
anim_run_left=0;
anim_run_right=0;

//simsets containing ScriptObject with the anim frames
anim_stand_up_selfcast=0;
anim_stand_down_selfcast=0;
anim_stand_left_selfcast=0;
anim_stand_right_selfcast=0;

anim_run_up_selfcast=0;
anim_run_down_selfcast=0;
anim_run_left_selfcast=0;
anim_run_right_selfcast=0;

anim_stand_up_targetcast=0;
anim_stand_down_targetcast=0;
anim_stand_left_targetcast=0;
anim_stand_right_targetcast=0;

anim_run_up_targetcast=0;
anim_run_down_targetcast=0;
anim_run_left_targetcast=0;
anim_run_right_targetcast=0;

anim_stand_up_melee=0;
anim_stand_down_melee=0;
anim_stand_left_melee=0;
anim_stand_right_melee=0;

anim_run_up_melee=0;
anim_run_down_melee=0;
anim_run_left_melee=0;
anim_run_right_melee=0;

anim_stand_up_emote=0;
anim_stand_down_emote=0;
anim_stand_left_emote=0;
anim_stand_right_emote=0;

anim_run_up_emote=0;
anim_run_down_emote=0;
anim_run_left_emote=0;
anim_run_right_emote=0;
/////////////////////////////

//skill related
skillanimtype=0;//0=selfcast 1=targetcast 2=melee 3=emote
health=100;
objgrabbed=0;
grabbing=false;
cancast=true;
ammo=10;//universal ammo :v

//physics
linear_damping=0;
speed=$normalplayerspeed;
canmove=true;
canjump=true;
collidingobject=0;
keysdown="0 0 0 0";
curdir=1;//0=up 1=down 2=left 3=right

//sound
playerfootsteps=0;

//schedules
schedule_jumpfall=0;
schedule_keycleanup=0;

mountedspriteids=0;//simset containing the other sprites in this composite
//mountedspriteids format:
//spriteid
//spritename //incase it doesn't know it's id
//rotates //if rotates based on dir or not
//centeroffset //distance from center

projectileorigindirset=0;//projectile origin direction sim set
//contains simsets for the 4 directions
//within those sets are the origins of projectiles that skills can use (instead of being forced to use a players origin)

};

$players.add(%player);

%player.mountedspriteids=new SimSet();

%player.projectileorigindirset=new SimSet();
for (%y=0;%y<4;%y++)//4 dirs
{
%dirset=new SimSet();
%player.projectileorigindirset.add(%dirset);
}

}

$player1skillbar=new SimSet();
$player2skillbar=new SimSet();
$skillschedules=new SimSet();

for (%x=0;%x<8;%x++)//8 slots
{
%bar0slot=new ScriptObject()
{
moduleid=0;
skillstate=0;//0=ready 1=cooldown
cdschedule=0;
guihandle=0;
};
%bar1slot=new ScriptObject()
{
moduleid=0;
skillstate=0;
cdschedule=0;
guihandle=0;
};
$player1skillbar.add(%bar0slot);
$player2skillbar.add(%bar1slot);
}
