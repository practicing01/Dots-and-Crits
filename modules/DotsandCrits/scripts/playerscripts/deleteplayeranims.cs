function deleteplayeranims()
{
%player=$players.getObject($player_to_load);

if (isObject(%player.anim_stand_up_selfcast))
{
%player.anim_stand_up_selfcast.deleteObjects();
%player.anim_stand_up_selfcast.delete();
}

if (isObject(%player.anim_stand_down_selfcast))
{
%player.anim_stand_down_selfcast.deleteObjects();
%player.anim_stand_down_selfcast.delete();
}

if (isObject(%player.anim_stand_left_selfcast))
{
%player.anim_stand_left_selfcast.deleteObjects();
%player.anim_stand_left_selfcast.delete();
}

if (isObject(%player.anim_stand_right_selfcast))
{
%player.anim_stand_right_selfcast.deleteObjects();
%player.anim_stand_right_selfcast.delete();
}
/////////////////////////////////////////////
if (isObject(%player.anim_run_up_selfcast))
{
%player.anim_run_up_selfcast.deleteObjects();
%player.anim_run_up_selfcast.delete();
}

if (isObject(%player.anim_run_down_selfcast))
{
%player.anim_run_down_selfcast.deleteObjects();
%player.anim_run_down_selfcast.delete();
}

if (isObject(%player.anim_run_left_selfcast))
{
%player.anim_run_left_selfcast.deleteObjects();
%player.anim_run_left_selfcast.delete();
}

if (isObject(%player.anim_run_right_selfcast))
{
%player.anim_run_right_selfcast.deleteObjects();
%player.anim_run_right_selfcast.delete();
}
///////////////////////////////////////////////

if (isObject(%player.anim_stand_up_targetcast))
{
%player.anim_stand_up_targetcast.deleteObjects();
%player.anim_stand_up_targetcast.delete();
}

if (isObject(%player.anim_stand_down_targetcast))
{
%player.anim_stand_down_targetcast.deleteObjects();
%player.anim_stand_down_targetcast.delete();
}

if (isObject(%player.anim_stand_left_targetcast))
{
%player.anim_stand_left_targetcast.deleteObjects();
%player.anim_stand_left_targetcast.delete();
}

if (isObject(%player.anim_stand_right_targetcast))
{
%player.anim_stand_right_targetcast.deleteObjects();
%player.anim_stand_right_targetcast.delete();
}
/////////////////////////////////////////////
if (isObject(%player.anim_run_up_targetcast))
{
%player.anim_run_up_targetcast.deleteObjects();
%player.anim_run_up_targetcast.delete();
}

if (isObject(%player.anim_run_down_targetcast))
{
%player.anim_run_down_targetcast.deleteObjects();
%player.anim_run_down_targetcast.delete();
}

if (isObject(%player.anim_run_left_targetcast))
{
%player.anim_run_left_targetcast.deleteObjects();
%player.anim_run_left_targetcast.delete();
}

if (isObject(%player.anim_run_right_targetcast))
{
%player.anim_run_right_targetcast.deleteObjects();
%player.anim_run_right_targetcast.delete();
}
///////////////////////////////////////////////

if (isObject(%player.anim_stand_up_melee))
{
%player.anim_stand_up_melee.deleteObjects();
%player.anim_stand_up_melee.delete();
}

if (isObject(%player.anim_stand_down_melee))
{
%player.anim_stand_down_melee.deleteObjects();
%player.anim_stand_down_melee.delete();
}

if (isObject(%player.anim_stand_left_melee))
{
%player.anim_stand_left_melee.deleteObjects();
%player.anim_stand_left_melee.delete();
}

if (isObject(%player.anim_stand_right_melee))
{
%player.anim_stand_right_melee.deleteObjects();
%player.anim_stand_right_melee.delete();
}
/////////////////////////////////////////////
if (isObject(%player.anim_run_up_melee))
{
%player.anim_run_up_melee.deleteObjects();
%player.anim_run_up_melee.delete();
}

if (isObject(%player.anim_run_down_melee))
{
%player.anim_run_down_melee.deleteObjects();
%player.anim_run_down_melee.delete();
}

if (isObject(%player.anim_run_left_melee))
{
%player.anim_run_left_melee.deleteObjects();
%player.anim_run_left_melee.delete();
}

if (isObject(%player.anim_run_right_melee))
{
%player.anim_run_right_melee.deleteObjects();
%player.anim_run_right_melee.delete();
}
////////////////////////////////////////////////

if (isObject(%player.anim_stand_up_emote))
{
%player.anim_stand_up_emote.deleteObjects();
%player.anim_stand_up_emote.delete();
}

if (isObject(%player.anim_stand_down_emote))
{
%player.anim_stand_down_emote.deleteObjects();
%player.anim_stand_down_emote.delete();
}

if (isObject(%player.anim_stand_left_emote))
{
%player.anim_stand_left_emote.deleteObjects();
%player.anim_stand_left_emote.delete();
}

if (isObject(%player.anim_stand_right_emote))
{
%player.anim_stand_right_emote.deleteObjects();
%player.anim_stand_right_emote.delete();
}
/////////////////////////////////////////////
if (isObject(%player.anim_run_up_emote))
{
%player.anim_run_up_emote.deleteObjects();
%player.anim_run_up_emote.delete();
}

if (isObject(%player.anim_run_down_emote))
{
%player.anim_run_down_emote.deleteObjects();
%player.anim_run_down_emote.delete();
}

if (isObject(%player.anim_run_left_emote))
{
%player.anim_run_left_emote.deleteObjects();
%player.anim_run_left_emote.delete();
}

if (isObject(%player.anim_run_right_emote))
{
%player.anim_run_right_emote.deleteObjects();
%player.anim_run_right_emote.delete();
}
///////////////////////////////////////////////
}
