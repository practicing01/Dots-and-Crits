function gui_mainmenu::player1clearskillbar(%this)
{
for (%x=0;%x<$player1skillbar.getCount();%x++)
{
%slot=$player1skillbar.getObject(%x);
%slot.moduleid=0;
%slot.skillstate=0;
cancel(%slot.cdschedule);
%slot.cdschedule=0;
}
if (skillbar_p1slot0.Active)
{
skillbar_p1slot0.Image="DotsandCrits:image_noskillset";
skillbar_p1slot1.Image="DotsandCrits:image_noskillset";
skillbar_p1slot2.Image="DotsandCrits:image_noskillset";
skillbar_p1slot3.Image="DotsandCrits:image_noskillset";
skillbar_p1slot4.Image="DotsandCrits:image_noskillsetinactive";
skillbar_p1slot5.Image="DotsandCrits:image_noskillsetinactive";
skillbar_p1slot6.Image="DotsandCrits:image_noskillsetinactive";
skillbar_p1slot7.Image="DotsandCrits:image_noskillsetinactive";
skillbar_p1slot0.setAnimation("DotsandCrits:anim_noskillset");
skillbar_p1slot1.setAnimation("DotsandCrits:anim_noskillset");
skillbar_p1slot2.setAnimation("DotsandCrits:anim_noskillset");
skillbar_p1slot3.setAnimation("DotsandCrits:anim_noskillset");
skillbar_p1slot4.setAnimation("DotsandCrits:anim_noskillsetinactive");
skillbar_p1slot5.setAnimation("DotsandCrits:anim_noskillsetinactive");
skillbar_p1slot6.setAnimation("DotsandCrits:anim_noskillsetinactive");
skillbar_p1slot7.setAnimation("DotsandCrits:anim_noskillsetinactive");
}
else
{
skillbar_p1slot0.Image="DotsandCrits:image_noskillsetinactive";
skillbar_p1slot1.Image="DotsandCrits:image_noskillsetinactive";
skillbar_p1slot2.Image="DotsandCrits:image_noskillsetinactive";
skillbar_p1slot3.Image="DotsandCrits:image_noskillsetinactive";
skillbar_p1slot4.Image="DotsandCrits:image_noskillset";
skillbar_p1slot5.Image="DotsandCrits:image_noskillset";
skillbar_p1slot6.Image="DotsandCrits:image_noskillset";
skillbar_p1slot7.Image="DotsandCrits:image_noskillset";
skillbar_p1slot0.setAnimation("DotsandCrits:anim_noskillsetinactive");
skillbar_p1slot1.setAnimation("DotsandCrits:anim_noskillsetinactive");
skillbar_p1slot2.setAnimation("DotsandCrits:anim_noskillsetinactive");
skillbar_p1slot3.setAnimation("DotsandCrits:anim_noskillsetinactive");
skillbar_p1slot4.setAnimation("DotsandCrits:anim_noskillset");
skillbar_p1slot5.setAnimation("DotsandCrits:anim_noskillset");
skillbar_p1slot6.setAnimation("DotsandCrits:anim_noskillset");
skillbar_p1slot7.setAnimation("DotsandCrits:anim_noskillset");
}
}

function gui_mainmenu::player2clearskillbar(%this)
{
for (%x=0;%x<$player2skillbar.getCount();%x++)
{
%slot=$player2skillbar.getObject(%x);
%slot.moduleid=0;
%slot.skillstate=0;
cancel(%slot.cdschedule);
%slot.cdschedule=0;
}
if (skillbar_p1slot0.Active)
{
skillbar_p2slot0.Image="DotsandCrits:image_noskillset";
skillbar_p2slot1.Image="DotsandCrits:image_noskillset";
skillbar_p2slot2.Image="DotsandCrits:image_noskillset";
skillbar_p2slot3.Image="DotsandCrits:image_noskillset";
skillbar_p2slot4.Image="DotsandCrits:image_noskillsetinactive";
skillbar_p2slot5.Image="DotsandCrits:image_noskillsetinactive";
skillbar_p2slot6.Image="DotsandCrits:image_noskillsetinactive";
skillbar_p2slot7.Image="DotsandCrits:image_noskillsetinactive";
skillbar_p2slot0.setAnimation("DotsandCrits:anim_noskillset");
skillbar_p2slot1.setAnimation("DotsandCrits:anim_noskillset");
skillbar_p2slot2.setAnimation("DotsandCrits:anim_noskillset");
skillbar_p2slot3.setAnimation("DotsandCrits:anim_noskillset");
skillbar_p2slot4.setAnimation("DotsandCrits:anim_noskillsetinactive");
skillbar_p2slot5.setAnimation("DotsandCrits:anim_noskillsetinactive");
skillbar_p2slot6.setAnimation("DotsandCrits:anim_noskillsetinactive");
skillbar_p2slot7.setAnimation("DotsandCrits:anim_noskillsetinactive");
}
else
{
skillbar_p2slot0.Image="DotsandCrits:image_noskillsetinactive";
skillbar_p2slot1.Image="DotsandCrits:image_noskillsetinactive";
skillbar_p2slot2.Image="DotsandCrits:image_noskillsetinactive";
skillbar_p2slot3.Image="DotsandCrits:image_noskillsetinactive";
skillbar_p2slot4.Image="DotsandCrits:image_noskillset";
skillbar_p2slot5.Image="DotsandCrits:image_noskillset";
skillbar_p2slot6.Image="DotsandCrits:image_noskillset";
skillbar_p2slot7.Image="DotsandCrits:image_noskillset";
skillbar_p2slot0.setAnimation("DotsandCrits:anim_noskillsetinactive");
skillbar_p2slot1.setAnimation("DotsandCrits:anim_noskillsetinactive");
skillbar_p2slot2.setAnimation("DotsandCrits:anim_noskillsetinactive");
skillbar_p2slot3.setAnimation("DotsandCrits:anim_noskillsetinactive");
skillbar_p2slot4.setAnimation("DotsandCrits:anim_noskillset");
skillbar_p2slot5.setAnimation("DotsandCrits:anim_noskillset");
skillbar_p2slot6.setAnimation("DotsandCrits:anim_noskillset");
skillbar_p2slot7.setAnimation("DotsandCrits:anim_noskillset");
}
}
