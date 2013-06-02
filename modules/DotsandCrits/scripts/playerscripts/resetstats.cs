function resetstats()
{
for (%x=0;%x<$numofplayers;%x++)
{
%player=$players.getObject(%x);
%player.health=100;
%player.mountedspriteids.deleteObjects();
}
}
