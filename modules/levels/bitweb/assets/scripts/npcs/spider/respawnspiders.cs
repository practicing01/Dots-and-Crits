function bitweb::respawnspiders(%this)
{

for (%x=%this.simset_spiders.getCount();%x<5;%x++)
{
%this.spawnspider();
}

%this.schedule_respawnspiders.schedulehandle=schedule(20000,0,"bitweb::respawnspiders",%this);
}
