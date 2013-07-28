//can have custom health display code
function ZombieBox::healthdisplay(%this,%playerindex,%health)//change ZombieBox to your module name
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
