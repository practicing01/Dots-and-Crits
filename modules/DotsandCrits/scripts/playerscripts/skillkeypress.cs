function skillkeypressed(%player,%key)
{
if (!%player)
{
if (!%key)//up
{
if (!$player1activeskillbarnibble)//first nibble
{
skillslots(%player,0);
}
else//second nibble
{
skillslots(%player,4);
}
}
else if (%key==1)//down
{
if (!$player1activeskillbarnibble)//first nibble
{
skillslots(%player,1);
}
else//second nibble
{
skillslots(%player,5);
}
}
else if (%key==2)//left
{
if (!$player1activeskillbarnibble)//first nibble
{
skillslots(%player,2);
}
else//second nibble
{
skillslots(%player,6);
}
}
else//right
{
if (!$player1activeskillbarnibble)//first nibble
{
skillslots(%player,3);
}
else//second nibble
{
skillslots(%player,7);
}
}
}
else
{
if (!%key)//up
{
if (!$player2activeskillbarnibble)//first nibble
{
skillslots(%player,0);
}
else//second nibble
{
skillslots(%player,4);
}
}
else if (%key==1)//down
{
if (!$player2activeskillbarnibble)//first nibble
{
skillslots(%player,1);
}
else//second nibble
{
skillslots(%player,5);
}
}
else if (%key==2)//left
{
if (!$player2activeskillbarnibble)//first nibble
{
skillslots(%player,2);
}
else//second nibble
{
skillslots(%player,6);
}
}
else//right
{
if (!$player2activeskillbarnibble)//first nibble
{
skillslots(%player,3);
}
else//second nibble
{
skillslots(%player,7);
}
}
}
}
