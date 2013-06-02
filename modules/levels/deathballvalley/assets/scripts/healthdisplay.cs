function deathballvalley::healthdisplay(%this,%playerindex,%health)
{
if (isObject(gui_text_player1health))
{
if (%playerindex==0)
{
gui_text_player1health.setText(%health);
}
else
{
gui_text_player2health.setText(%health);
}
}
}
