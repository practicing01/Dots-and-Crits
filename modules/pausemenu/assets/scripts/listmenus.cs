//populate lists
//load dynamic world objects

%dwomodules=ModuleDatabase.findModuleTypes("dwo",false);

if (!isObject(simset_list_dwos))
{
new SimSet(simset_list_dwos);
}

simset_list_dwos.clear();

%dwocount=getWordCount(%dwomodules);

for (%x=0;%x<%dwocount;%x++)
{
%moduleid=getWord(%dwomodules,%x);
ModuleDatabase.LoadExplicit(%moduleid.ModuleId);
simset_list_dwos.add(%moduleid);
gui_list_dwo.addItem(%moduleid.description);
}

//load npcs

%npcmodules=ModuleDatabase.findModuleTypes("npc",false);

if (!isObject(simset_list_npcs))
{
new SimSet(simset_list_npcs);
}

simset_list_npcs.clear();

%npccount=getWordCount(%npcmodules);

for (%x=0;%x<%npccount;%x++)
{
%moduleid=getWord(%npcmodules,%x);
ModuleDatabase.LoadExplicit(%moduleid.ModuleId);
simset_list_npcs.add(%moduleid);
gui_list_npc.addItem(%moduleid.description);
}

function gui_pausemenu::dwoselect(%this)
{

//call the selected dwo's load function
if (gui_list_dwo.getSelectedItem()!=-1)
{
%dwomoduleid=simset_list_dwos.getObject(gui_list_dwo.getSelectedItem());
%dwomoduleid.ScopeSet.loaddwo();
}

}

function gui_pausemenu::npcselect(%this)
{

//call the selected npc's load function
if (gui_list_npc.getSelectedItem()!=-1)
{
%npcmoduleid=simset_list_npcs.getObject(gui_list_npc.getSelectedItem());
%npcmoduleid.ScopeSet.loadnpc();
}

}
