function gui_mainmenu::player1select()
{
$player_to_load=0;
if (gui_list_player1.getSelectedItem()!=-1)
{
%moduleid=simset_list_playersprites.getObject(gui_list_player1.getSelectedItem());
%moduleid.ScopeSet.setmenuiconvisible();
}
}

function gui_mainmenu::player2select()
{
$player_to_load=1;
if (gui_list_player2.getSelectedItem()!=-1)
{
%moduleid=simset_list_playersprites.getObject(gui_list_player2.getSelectedItem());
%moduleid.ScopeSet.setmenuiconvisible();
}
}

function gui_mainmenu::selectlevel()
{
if (gui_list_level.getSelectedItem()!=-1)
{
%moduleid=simset_list_levels.getObject(gui_list_level.getSelectedItem());
%moduleid.ScopeSet.setmenuiconvisible();
}
}

function gui_mainmenu::topdownselect()
{
$view=0;
}

function gui_mainmenu::sideviewselect()
{
$view=1;
}

function gui_mainmenu::splitverticalselect()
{
$splitplane=0;
}

function gui_mainmenu::splithorizontalselect()
{
$splitplane=1;
}

function gui_mainmenu::aiselect()
{
$aiopponent=!$aiopponent;
}

function gui_mainmenu::singleplayerselect()
{
$singleplayer=!$singleplayer;
}
